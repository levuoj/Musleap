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

namespace MediaPlayer
{
    public partial class InterfaceMediaPlayer : Form
    {
        Controller controller;
        SampleListener listener;

        public InterfaceMediaPlayer()
        {
            Controller controller = new Controller();
            SampleListener listener = new SampleListener();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.Connect += listener.OnServiceConnect;
            controller.Device += listener.OnConnect;
            controller.FrameReady += listener.OnFrame;

            Console.WriteLine("Press Enter to quit ...");
            Console.ReadLine();

            controller.Dispose();
        }
    }
}
