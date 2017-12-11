using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leap;

namespace MediaPlayer
{
    public class Sample
    {
        public static void Main()
        {
            Controller controller = new Controller();
            SampleListener listener = new SampleListener();
            controller.Connect += listener.OnServiceConnect;
            controller.Device += listener.OnConnect;
            controller.FrameReady += listener.OnFrame;

            Console.WriteLine("Press Enter to quit ...");
            Console.ReadLine();

            //controller.RemoveListner(listener);
            controller.Dispose();
        }
    }
}