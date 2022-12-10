using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Piano
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile("piano.jpg");
        }

        private void открытьПианиноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PianoForm p = new PianoForm(this);
            p.Show();
        }

        private void прослушатьМелодиюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Загрузите файл");
                openFileDialog1.Filter = "Text files(*.wav)|*.wav|ALL filese(*.*)|*.*";

                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                string path = openFileDialog1.FileName;
                ClassNote.path = path;
                MessageBox.Show("Файл успешно загружен");
                ClassNote.isEmpty = true;
                PianoForm p = new PianoForm(this);
                p.Show();

            }
            catch (Exception ex)
            {
                funcException(ex);
            }
        }

        public void funcException(Exception ex)
        {
            string path = @"Errors\Exception.txt";
            FileStream file = new FileStream(path, FileMode.OpenOrCreate);
            file.Seek(0, SeekOrigin.End);
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(ex.Message + "\n" + ex.StackTrace);
            file.Close();
            sw.Close();
        }

    }
}
            
        
