using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using FlaxEngine;
using FlaxEngine.GUI;

using System.Windows;
using FlaxEditor.Content.Settings;

namespace Game
{
    /// <summary>
    /// UI_WindowDock Script.
    /// </summary>
    public class UI_WindowDock : Script
    {
        public UIControl[] Close_Buttons;
        public UIControl[] Max_Buttons;
        public UIControl[] Min_Buttons;
        public UIControl ToolBar;
        public UIControl textBoxa;
        private Float2 newInp;
        /// <inheritdoc/>
        public override void OnStart()
        {
            // Here you can add code that needs to be called when script is created, just before the first game update
        }
        
        /// <inheritdoc/>
        public override void OnEnable()
        {
            ButtonClickedBind(Close_Buttons,CloseEvent);
            ButtonClickedBind(Max_Buttons,WindowedOrFullScreenEvent);
            ButtonClickedBind(Min_Buttons,MinimazeEvent);
            //Screen.CursorLock = CursorLockMode.Clipped;
            
            //ButtonClickedBind(new UIControl[] { ToolBar },TakeWindow);
            // Here you can add code that needs to be called when script is enabled (eg. register for events)
        }
        

        private void CloseEvent(Button button)
        {
#if !FLAX_EDITOR
            System.Diagnostics.Process.GetCurrentProcess().Kill();
#endif
        }
        private void WindowedOrFullScreenEvent(Button button)
        {
#if !FLAX_EDITOR
            if(RootControl.GameRoot.RootWindow.Window.IsMaximized)
                RootControl.GameRoot.RootWindow.Window.Restore();
            else
                RootControl.GameRoot.RootWindow.Window.Maximize();
#endif
        }
        private void MinimazeEvent(Button button)
        {
#if !FLAX_EDITOR
            RootControl.GameRoot.RootWindow.Window.Minimize();
#endif
        }
        private void ButtonClickedBind(UIControl[] Buttons, Action<Button> bind)
        {
            foreach (var VARIABLE in Buttons)
            {
                ((Button)VARIABLE.Control).ButtonClicked += bind;
            }
        }

        /// <inheritdoc/>
        public override void OnDisable()
        {
            // Here you can add code that needs to be called when script is disabled (eg. unregister from events)
        }

        /// <inheritdoc/>
        public override void OnUpdate()
        {
            //RootControl.GameRoot.RootWindow.MousePosition;
         // RootControl.
         Float2 old = newInp ;
         newInp = new Float2(GetCursorPosition().X, GetCursorPosition().Y);
         ((TextBox)textBoxa.Control).Text = /*Input.MousePositionDelta.ToString();*/ (newInp - old).ToString();
        if (((Button)ToolBar.Control).IsPressed)
        {
            RootControl.GameRoot.RootWindow.StartTrackingMouse(ToolBar.Control,true);
            //Screen.CursorLock = CursorLockMode.Clipped;
            RootControl.GameRoot.RootWindow.Window.Position += (newInp-old/* - new Float2(1,1)*/)/*.Normalized*/;
            //Input.MousePositionDelta;
        }
        else
        {
            RootControl.GameRoot.RootWindow.EndTrackingMouse();
        }



        //newInp = new Float2(GetCursorPosition().X, GetCursorPosition().Y);
        // Here you can add code that needs to be called every frame
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <see>See MSDN documentation for further information.</see>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        public static Point GetCursorPosition()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            // NOTE: If you need error handling
            // bool success = GetCursorPos(out lpPoint);
            // if (!success)
        
            return lpPoint;
        }
    }
}
