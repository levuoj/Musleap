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
            Console.WriteLine("Service Connected");
        }

        public void OnConnect(object sender, DeviceEventArgs args)
        {
            Console.WriteLine("Connected");
        }

        public void OnFrame(object sender, FrameEventArgs args)
        {
            Frame frame = args.frame;
            int extendedfingers = 0;
            bool pause = false;
            int stop = 0;

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

                    if (hand.Fingers[0].IsExtended == false && hand.Fingers[1].IsExtended
                        && hand.Fingers[2].IsExtended == false && hand.Fingers[3].IsExtended == false
                        && hand.Fingers[4].IsExtended == false)
                    {
                        Console.WriteLine("Volume sound");
                        //valeur à envoyer pour gérer le son
                        //hand.Fingers[1].StabilizedTipPosition.y
                    }
                   
                    if (hand.Rotation.w > 0.95 && hand.PinchStrength > 0.9)
                        Console.WriteLine("previous track");

                    if (hand.Rotation.w < 0.1)
                        Console.WriteLine("mute");


                    if (hand.Rotation.w < 0.70)
                        ++stop;
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

                    if (hand.Fingers[0].IsExtended == false && hand.Fingers[1].IsExtended
                        && hand.Fingers[2].IsExtended == false && hand.Fingers[3].IsExtended == false
                        && hand.Fingers[4].IsExtended == false)
                    {
                        Console.WriteLine("Volume sound");
                        //valeur à envoyer pour gérer le son
                        //hand.Fingers[1].StabilizedTipPosition.y
                    }

                    if (hand.Rotation.w > 0.95 && hand.PinchStrength > 0.9)
                            Console.WriteLine("next track");

                    if (hand.Rotation.w < 0.1)
                        Console.WriteLine("mute");

                    if (hand.Rotation.w < 0.70)
                        ++stop;
                }                
            }
            if (stop == 2)
            {
                if (frame.Hands[0].PalmPosition.DistanceTo(frame.Hands[1].PalmPosition) < 20)
                    Console.WriteLine("stop");
            }
            else
            {
                if (pause == true && extendedfingers == 0)
                    Console.WriteLine("pause");
                else if (frame.Hands.Count == 2)
                    Console.WriteLine("play");
            }

        }
    }
}
