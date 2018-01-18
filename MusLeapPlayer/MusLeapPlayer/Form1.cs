using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leap;
using System.IO;

namespace MusLeapPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            SampleListener listener = new SampleListener(ref axWindowsMediaPlayer1, ref listView1);
            controller.Connect += listener.OnServiceConnect;
            controller.Device += listener.OnConnect;
            controller.FrameReady += listener.OnFrame;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadFiles_Click(object sender, EventArgs e)
        {
            Stream stream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "MP3 Audio File (.mp3)| *.mp3|Windows Media Audio File (*.wma)|*.wma|WAV Audio File (*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = false;
            openFileDialog.Multiselect = true;
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = openFileDialog.OpenFile()) != null)
                    {
                        using (stream)
                        {
                            string[] filepath = openFileDialog.FileNames;
                            string[] filename = openFileDialog.SafeFileNames;

                            for (int i = 0; i < openFileDialog.SafeFileNames.Count(); i++)
                            {
                                string[] items = new string[2];

                                items[0] = filename[i];
                                items[1] = filepath[i];

                                ListViewItem title = new ListViewItem(items);

                                listView1.Items.Add(title);
                            }
                        }
                    }                
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string selectedFile = listView1.FocusedItem.SubItems[1].Text;

            axWindowsMediaPlayer1.URL = @selectedFile;
        }
    }
}
