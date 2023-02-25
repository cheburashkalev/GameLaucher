using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.GUI;


namespace Game
{
    /// <summary>
    /// TrayIconCS Script.
    /// </summary>
    public class TrayIconCS : Script
    {
       // [AssetReference("UIControl")]
        public Actor[] ButtonsPlay;
        private SystemTrayLoader systemTray;
        /// <inheritdoc/>
        public override void OnStart()
        {
           // SystemTray systemTray = new SystemTray(Globals.BinariesFolder);
            // Here you can add code that needs to be called when script is created, just before the first game update
        }
        
        /// <inheritdoc/>
        public override void OnEnable()
        {
            foreach (var AButton in ButtonsPlay)
            {
                Button button = (Button)(AButton.As<UIControl>().Control);
                button.ButtonClicked += Lbutton =>
                {
                    
                    
                };
            }

            systemTray = new SystemTrayLoader();
            //systemTray.
            //SystemTray systemTray = new SystemTray(Globals.BinariesFolder+"FlaxEditor.exe");
          //  systemTray.exe = Globals.BinariesFolder + 
          #if !FLAX_EDITOR
          RootControl.GameRoot.RootWindow.Window.Minimize();
          #endif
            systemTray.useApplicationIcon = true;
            systemTray.Awake();
            systemTray.Start();
            Debug.Log(Globals.BinariesFolder);
            // Here you can add code that needs to be called when script is enabled (eg. register for events)
        }

        /// <inheritdoc/>
        public override void OnDisable()
        {
            systemTray.tray.Dispose();
            Destroy(systemTray);
           
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
