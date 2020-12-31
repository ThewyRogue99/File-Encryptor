using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using CipherFile;  //Encrypt/Decrypt algorithms are in Cipher.cs file

namespace File_Decryptor
{
    public partial class Form1 : Form
    {
        List<string> pathlist = new List<string>();
        bool abortth = false;
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            CenterToScreen();
            ThreadStart reference = new ThreadStart(getselect);
            Thread th = new Thread(reference);
            th.Start();
            reference = new ThreadStart(getcount);
            th = new Thread(reference);
            th.Start();
        }

        public void getselect()
        {
            while (!abortth)
            {
                if (file_list.SelectedIndex >= 0)
                    remove_button.Enabled = true;
                else
                    remove_button.Enabled = false;
                Thread.Sleep(50);
            }
        }

        public void getcount()
        {
            while (!abortth)
            {
                if (file_list.Items.Count > 0 && passbox.Text != "")
                {
                    encrypt_button.Enabled = true;
                    decrypt_button.Enabled = true;
                }
                else
                {
                    encrypt_button.Enabled = false;
                    decrypt_button.Enabled = false;
                }
                Thread.Sleep(50);
            }
        }

        private void add_files_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Multiselect = true;
            file_list.AllowDrop = true;

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                foreach(string path in OFD.FileNames)
                {
                    pathlist.Add(path);
                }
                foreach (string file in OFD.SafeFileNames)
                {
                    if (!file_list.Items.Contains(file))
                    {
                        file_list.Items.Add(file);
                    }
                }
            }
        }

        private void remove_button_Click(object sender, EventArgs e)
        {
            string name = file_list.Items[file_list.SelectedIndex].ToString();
            for (int i = 0; i < pathlist.Count; i++)
            {
                string path = pathlist[i];
                if (path.Contains(name))
                    pathlist.Remove(path);
            }
            file_list.Items.RemoveAt(file_list.SelectedIndex);
        }

        private bool file_exists(string path)
        {
            try
            {
                File.ReadAllBytes(path);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            abortth = true;
            Thread.Sleep(100);
            Environment.Exit(0);
        }

        private void encrypt_button_Click(object sender, EventArgs e)
        {
            int loops = 1; //This variable is used to define the file order ( because they will have the same name )
            
            for(int i = 0; i < pathlist.Count; i++)
            {
                string path = pathlist[i];
                int cont = loops;

                if(!file_exists(path))
                {
                    MessageBox.Show("Failed to find file in " + path, "Failed to find a file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                byte[] file = File.ReadAllBytes(path);
                string filename = "\\" + Path.GetFileName(path);
                file = file.Concat(Encoding.ASCII.GetBytes(filename)).ToArray();  //Add filename and it's extension to the end of the file
                if (passbox.Text != string.Empty)
                {
                    byte[] encfile = Cipher.EncryptFile(file, passbox.Text);   //Encrypt file using your encryption algorithm
                    string filedir = Path.GetDirectoryName(path);
                    while (file_exists(filedir + "\\encrypted" + cont.ToString() + ".enc"))
                    {
                        cont += 10; //Add 10 to the cont variable because of the fact there might be another file with the same index

                        //Loop until we can't find a file with the same index
                    }
                    string newpath = filedir + "\\encrypted" + cont.ToString() + ".enc";
                    File.WriteAllBytes(newpath, encfile);
                    File.Delete(path);
                    file_list.Items[file_list.Items.IndexOf(Path.GetFileName(path))] = "encrypted" + cont.ToString() + ".enc";
                    //Replace old file with the new encrypted file in our lists
                    pathlist[pathlist.IndexOf(path)] = newpath;
                    cont = loops; // we restore cont variable to it's old value to continue with the same index
                }
                else
                {
                    MessageBox.Show("You need to enter a key to encrypt a file", "No key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ++loops;
            }
        }

        private void decrypt_button_Click(object sender, EventArgs e)
        {
            bool noencused = false; //This variable is used to notify user if an attempt was made to decrypt a file without .enc extension
            for (int i = 0; i < pathlist.Count; i++)
            {
                string path = pathlist[i];
                if(!file_exists(path))
                {
                    MessageBox.Show("Failed to find file in " + path, "Failed to find a file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                byte[] file = File.ReadAllBytes(path);

                if (Path.GetExtension(path) == ".enc")
                {
                    if (passbox.Text != string.Empty)
                    {
                        byte[] decfile = Cipher.DecryptFile(file, passbox.Text); //Decrypt file using decryption algorithm
                        string filedir = Path.GetDirectoryName(path);
                        try
                        {
                            File.ReadAllBytes(path);
                        }
                        catch
                        {
                            MessageBox.Show("File path " + filedir + " doesn't exist", "File path doesn't exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        string enctype = Encoding.ASCII.GetString(decfile);
                        decfile = decfile.Subset<byte>(0, enctype.LastIndexOf('\\')); //Get the file without its full name at the end of it
                        enctype = enctype.Substring(enctype.LastIndexOf('\\'), enctype.Length - enctype.LastIndexOf('\\')); //Get file name with its extension from the end of the file
                        try
                        {
                            File.WriteAllBytes(filedir + enctype, decfile);
                        }
                        catch
                        {
                            MessageBox.Show("Failed to decrypt the file (Probably password is wrong)", "Failed to decrypt a file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        File.Delete(path);
                        file_list.Items[file_list.Items.IndexOf(Path.GetFileName(path))] = enctype.Substring(enctype.LastIndexOf('\\') + 1, enctype.Length - enctype.LastIndexOf('\\') - 1);
                        //Replace new decrypted file with the encrypted one in our lists
                        pathlist[pathlist.IndexOf(path)] = filedir + enctype;
                    }
                    else
                    {
                        MessageBox.Show("You need to enter a key to decrypt a file", "No key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    noencused = true;
                }
            }

            if (noencused)
                MessageBox.Show("Some of the files weren't in .enc format so they were skipped", "Skipped files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    public static class ArrayExt
    {
        public static T[] Subset<T>(this T[] array, int start, int count)
        {
            T[] result = new T[count];
            Array.Copy(array, start, result, 0, count);
            return result;
        }
    }
}
