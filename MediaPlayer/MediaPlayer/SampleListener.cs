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
            
            //Console.WriteLine("frame id: {0}, timestam: {1}, finders: {2}", frame.Id, frame.Timestamp, frame.Hands.Count);               

            int extendedfingers = 0;
            bool pause = false;

            foreach (Hand hand in frame.Hands)
            {               
            
                if (hand.IsLeft)
                {                   
                    for (int f = 0; f < hand.Fingers.Count; ++f)
                    {
                        Finger digit = hand.Fingers[f];
                        if (digit.IsExtended)
                            extendedfingers++;
                    }
                    if (extendedfingers == 0)
                        pause = true;

                    if (hand.Fingers[4].IsExtended && hand.Fingers[1].IsExtended
                        && hand.Fingers[2].IsExtended == false && hand.Fingers[0].IsExtended == false)
                        Console.WriteLine("spiderman");

                    if (hand.PinchStrength > 0.9)
                        Console.WriteLine("pinch gauche");
                    
                    //Console.WriteLine(hand.PalmWidth);

                    //Console.WriteLine("  Hand id: {0}, palm position: {1}, fingers: {2}", hand.Id, hand.PalmPosition, hand.Fingers.Count);
                    //Vector normal = hand.PalmNormal;
                    //Vector direction = hand.Direction;

                    //Console.WriteLine("  Hand pitch: {0} degrees, roll: {1} degrees, yaw: {2} degrees",
                    //    direction.Pitch * 180.0f / (float)Math.PI, normal.Roll * 180.0f / (float)Math.PI, direction.Yaw * 180.0f / (float)Math.PI);

                }
                else if (hand.IsRight)
                {
                    for (int f = 0; f < hand.Fingers.Count; ++f)
                    {
                        Finger digit = hand.Fingers[f];
                        if (digit.IsExtended)
                            extendedfingers++;
                    }
                    if (extendedfingers == 0)
                        pause = true;

                    if (hand.PinchStrength > 0.9)
                        Console.WriteLine("pinch droite");
                    //Console.WriteLine("right : " + extendedfingers);

                    //Console.WriteLine(hand.PinchDistance);
                    //console.writeline(hand.pinchstrength);

                }                
            }

                
            //if (pause == true && extendedfingers == 0)
            //    Console.WriteLine("Pause");
            //else
            //    Console.WriteLine("Play");
    
        }
    }
}
