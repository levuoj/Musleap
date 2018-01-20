using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leap;
using WMPLib;

namespace MusLeapPlayer
{
    class SampleListener
    {
        enum EState
        {
            PLAY,
            PAUSE,
            NEXT,
            PREVIOUS,
            STOP,
            NONE
        }

        private AxWMPLib.AxWindowsMediaPlayer _mediaPlayer;
        private ListView _list;
        private EState _state;
        private float  _height;
        private bool _isStarted = false;

        public SampleListener(ref AxWMPLib.AxWindowsMediaPlayer media, ref ListView list)
        {
            EState state = EState.NONE;
            _mediaPlayer = media;
            _list = list;
            _height = 0.0f;
        }

        public void OnServiceConnect(object sender, ConnectionEventArgs args)
        {
            Console.WriteLine("Service Connected");
        }

        public void OnConnect(object sender, DeviceEventArgs args)
        {
            Console.WriteLine("Connected");
        }

        private void playPlaylist()
        {
            WMPLib.IWMPPlaylist playlist = _mediaPlayer.playlistCollection.newPlaylist("playlist");
            WMPLib.IWMPMedia media;

            for (int i = 0; i < _list.Items.Count; i++)
            {
                media = _mediaPlayer.newMedia(_list.Items[i].SubItems[1].Text);
                playlist.appendItem(media);

                _mediaPlayer.currentPlaylist = playlist;
            }
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
                        if (hand.Fingers[1].StabilizedTipPosition.y > _height)
                            _mediaPlayer.settings.volume += 1;
                        else
                            _mediaPlayer.settings.volume -= 1;
                        _height = hand.Fingers[1].StabilizedTipPosition.y;
                    }

                    if (hand.Rotation.w > 0.95 && hand.PinchStrength > 0.9 && _state != EState.PREVIOUS)
                    {
                        _mediaPlayer.Ctlcontrols.previous();
                        _state = EState.PREVIOUS;
                    }

                    if(hand.Rotation.w < 0.1)
                        _mediaPlayer.settings.volume = 100;

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
                        if (hand.Fingers[1].StabilizedTipPosition.y > _height)
                            _mediaPlayer.settings.volume += 1;
                        else
                            _mediaPlayer.settings.volume -= 1;
                        _height = hand.Fingers[1].StabilizedTipPosition.y;
                    }

                    if (hand.Rotation.w > 0.95 && hand.PinchStrength > 0.9 && _state != EState.NEXT)
                    {
                        _mediaPlayer.Ctlcontrols.next();
                        _state = EState.NEXT;
                    }

                    if (hand.Rotation.w < 0.1)
                        _mediaPlayer.settings.volume = 0;
                    if (hand.Rotation.w < 0.70)
                        ++stop;
                }
            }
            if (stop == 2)
            {
                if (frame.Hands[0].PalmPosition.DistanceTo(frame.Hands[1].PalmPosition) < 20 && _state != EState.STOP)
                {
                    _mediaPlayer.Ctlcontrols.stop();
                    _state = EState.STOP;
                    _isStarted = false;
                }
            }
            else
            {
                if (pause == true && extendedfingers == 0 && _state != EState.PAUSE)
                {
                    _mediaPlayer.Ctlcontrols.pause();
                    _state = EState.PAUSE;
                }
                else if (frame.Hands.Count == 2 && _state != EState.PLAY)
                {
                    if (_isStarted == false)
                        playPlaylist();
                    _mediaPlayer.Ctlcontrols.play();
                    _state = EState.PLAY;
                    _isStarted = true;
                }
            }

        }
    }
}

