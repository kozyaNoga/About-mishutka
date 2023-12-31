﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using About_mishutka;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Data;

namespace ConsoleApp1
{
    public class Game : GameWindow
    {
        private float i = 0.01f, sec = 0.0f;
        private int fps;
        private bool flag = false;
        Circle circle = new Circle(6, 0.5f, 0.0f, 0.0f);
        Circle circle1 = new Circle(100, 0.5f, 0.0f, 0.0f);
        public Game(GameWindowSettings GWsettings, NativeWindowSettings NWsettings) : base(GWsettings, NWsettings)
        {
            VSync = VSyncMode.On;
        }
        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0 / 0.0f, 0 / 0.0f, 0 / 0.0f, 0 / 0.0f);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            circle.initVertexBufferObject();
            circle1.initVertexBufferObject();
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            sec += (float)args.Time;
            if (sec >= 1.0f)
            {
                Title = $"Linear Algebra: fps - {(float)fps}";
                fps = 0;
                sec = 0.0f;
            }
            fps += 1;

            base.OnUpdateFrame(args);
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            circle.DrawVertexBufferObject();
            circle1.DrawVertexBufferObject();

            SwapBuffers();
            base.OnRenderFrame(args);
        }
        protected override void OnUnload()
        {
            
            base.OnUnload();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            NativeWindowSettings NWsettings = new NativeWindowSettings()
            {
                Size = new Vector2i(800, 800),
                //Location = new Vector2i(0, 0),
                WindowBorder = WindowBorder.Fixed,
                WindowState = WindowState.Normal,
                Title = "Linear Algebra",

                APIVersion = new Version(3, 3),
                Flags = ContextFlags.Default,
                Profile = ContextProfile.Compatability,
                API = ContextAPI.OpenGL,

                NumberOfSamples = 0
            };
            using (Game game = new Game(GameWindowSettings.Default, NWsettings))
            {
                game.Run();
            }
        }
    }
}