using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    class SampleListener
    {
        public void OnServiceConnect(object sender, ConnectionEventArgs args)
        {
            Console.WriteLine("Srvice Connected");
        }

        public void OnConnect(object sender, DeviceEventArgs args)
        {
            Console.WriteLine("Connected");
        }

        public void OnFrame(object sender, FrameEventArgs args)
        {
            Frame frame = args.frame;

            //Console.WriteLine("Frame id: {0}, timestam: {1}, finders: {2}",
            //   frame.Id, frame.Timestamp, frame.Hands.Count);

            foreach(Hand hand in frame.Hands)
            {
                if (hand.IsLeft)
                {
                    Console.WriteLine("  Hand id: {0}, palm position: {1}, fingers: {2}", hand.Id, hand.PalmPosition, hand.Fingers.Count);
                    Vector normal = hand.PalmNormal;
                    Vector direction = hand.Direction;

                    Console.WriteLine("  Hand pitch: {0} degrees, roll: {1} degrees, yaw: {2} degrees",
                        direction.Pitch * 180.0f / (float)Math.PI, normal.Roll * 180.0f / (float)Math.PI, direction.Yaw * 180.0f / (float)Math.PI);
                }
                else if (hand.IsRight)
                {
                    Console.WriteLine("droite");
                }
            }
        }
    }
}
