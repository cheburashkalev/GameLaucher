using System;
using System.Diagnostics;
using System.Runtime;
using FlaxEngine;
using FlaxEngine.GUI;
using System.Globalization;
using System.Net;
using System.Threading;
using TorrentSwifter;
using TorrentSwifter.Peers;
using TorrentSwifter.Preferences;
using TorrentSwifter.Torrents;
using Debug = FlaxEngine.Debug;

namespace Game
{
    /// <summary>
    /// TrayIconCS Script.
    /// </summary>
    public class TrayIconCs : Script
    {
       // [AssetReference("UIControl")]
        public Actor[] ButtonsPlay;
        //public Actor AText;
        private SystemTrayLoader _systemTray;
        private Torrent torrent;
        private Thread beggar;
        
        /// <inheritdoc/>
        public override void OnStart()
        {
           // SystemTray systemTray = new SystemTray(Globals.BinariesFolder);
            // Here you can add code that needs to be called when script is created, just before the first game update
        }
        
        /// <inheritdoc/>
        public override void OnEnable()
        {
            Prefs.Peer.ListenPort = 6654;
            Prefs.Torrent.AllocateFullFileSizes = false;
            TorrentEngine.Initialize();
            foreach (var aButton in ButtonsPlay)
            {
                Button button = (Button)(aButton.As<UIControl>().Control);
                button.ButtonClicked += ButtonOnButtonClicked;
                
            }

            _systemTray = new SystemTrayLoader();
            //systemTray.
            //SystemTray systemTray = new SystemTray(Globals.BinariesFolder+"FlaxEditor.exe");
          //  systemTray.exe = Globals.BinariesFolder + 
          #if !FLAX_EDITOR
          RootControl.GameRoot.RootWindow.Window.Minimize();
          #endif
            _systemTray.useApplicationIcon = true;
            _systemTray.Awake();
            _systemTray.Start();
            Debug.Log(Globals.BinariesFolder);
            // Here you can add code that needs to be called when script is enabled (eg. register for events)
        }

        private void ButtonOnButtonClicked(Button obj)
        {
            beggar = new Thread(() =>
            {
                TorrentMetaData torrentMetaData = new TorrentMetaData();
                torrentMetaData.LoadFromFile(
                    @"C:\Users\duxan\Downloads\spore-collection_3_1_0_22_10834_win_gog.torrent");
                torrent = new Torrent(torrentMetaData, ".\\Downloads\\");
                var peerEndPoint = ParseEndPoint("127.0.0.1:6996");
                if (peerEndPoint != null)
                {
                    var peerInfo = new PeerInfo(peerEndPoint);
                    torrent.AddPeer(peerInfo);
                }

                torrent.Start();
            });
            beggar.Start();
        }
        private static IPEndPoint ParseEndPoint(string endPointText)
        {
            if (string.IsNullOrEmpty(endPointText))
                return null;

            endPointText = endPointText.Trim();
            int portSplitIndex = endPointText.LastIndexOf(':');
            if (portSplitIndex == -1)
                return null;

            string hostText = endPointText.Substring(0, portSplitIndex);
            string portText = endPointText.Substring(portSplitIndex + 1);

            IPAddress ipAddress;
            int port;

            if (IPAddress.TryParse(hostText, out ipAddress) && int.TryParse(portText, out port))
            {
                return new IPEndPoint(ipAddress, port);
            }
            else
            {
                return null;
            }
        }

        /// <inheritdoc/>
        public override void OnDisable()
        {
            
           // beggar.Abort();
           // _systemTray.tray.Dispose();
           // Destroy(_systemTray);
           // Destroy(this);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            // Here you can add code that needs to be called when script is disabled (eg. unregister from events)
        }

        /// <inheritdoc/>
        public override void OnUpdate()
        {

#if !FLAX_EDITOR
            if (RootControl.GameRoot.RootWindow.Window.IsMinimized)
            {
                if (RootControl.GameRoot.RootWindow.Window.IsVisible)
                {
                    RootControl.GameRoot.RootWindow.Window.Hide();
                }
            }

#endif
        }
    }
}
