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
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Data;
using About_mishutka.data.Primitives;
using About_mishutka.data.Models;
using About_mishutka.data.Staples;

namespace ConsoleApp1
{
    public class Game : GameWindow
    {
        private float sec = 0.0f;
        private int fps;
        Point point = new Point(0.0f, 0.0f, 0.0f);
        Staples staplesLeft = new Staples(new float[]
            { -0.04f+0.83f, 0.0f+0.61f, 0.0f,
              -0.08f+0.83f, 0.0f+0.61f, 0.0f,
              -0.08f+0.83f, 0.3f+0.61f, 0.0f,
              -0.04f+0.83f, 0.3f+0.61f, 0.0f,
              -0.04f+0.83f, 0.29f+0.61f, 0.0f,
              -0.07f+0.83f, 0.29f+0.61f, 0.0f,
              -0.07f+0.83f, 0.01f+0.61f, 0.0f,
              -0.04f+0.83f, 0.01f+0.61f, 0.0f,}, 8);
        Staples staplesRight = new Staples(new float[]
            { 0.04f+0.83f, 0.0f+0.61f, 0.0f,
              0.08f+0.83f, 0.0f+0.61f, 0.0f,
              0.08f+0.83f, 0.3f+0.61f, 0.0f,
              0.04f+0.83f, 0.3f+0.61f, 0.0f,
              0.04f+0.83f, 0.29f+0.61f, 0.0f,
              0.07f+0.83f, 0.29f+0.61f, 0.0f,
              0.07f+0.83f, 0.01f+0.61f, 0.0f,
              0.04f+0.83f, 0.01f+0.61f, 0.0f}, 8);
        Staples staplesLeftM = new Staples(new float[]
            { -0.11f+0.55f, 0.0f+0.61f, 0.0f,
              -0.14f+0.55f, 0.0f+0.61f, 0.0f,
              -0.14f+0.55f, 0.3f+0.61f, 0.0f,
              -0.11f+0.55f, 0.3f+0.61f, 0.0f,
              -0.11f+0.55f, 0.29f+0.61f, 0.0f,
              -0.13f+0.55f, 0.29f+0.61f, 0.0f,
              -0.13f+0.55f, 0.01f+0.61f, 0.0f,
              -0.11f+0.55f, 0.01f+0.61f, 0.0f}, 8);
        Staples staplesRightM = new Staples(new float[]
            {  0.11f+0.55f, 0.0f+0.61f, 0.0f,
               0.14f+0.55f, 0.0f+0.61f, 0.0f,
               0.14f+0.55f, 0.3f+0.61f, 0.0f,
               0.11f+0.55f, 0.3f+0.61f, 0.0f,
               0.11f+0.55f, 0.29f+0.61f, 0.0f,
               0.13f+0.55f, 0.29f+0.61f, 0.0f,
               0.13f+0.55f, 0.01f+0.61f, 0.0f,
               0.11f+0.55f, 0.01f+0.61f, 0.0f}, 8);
        Grid grid = new Grid();
        Staples line = new Staples(new float[]
           { 0.4f, 0.6f, 0.0f,
             0.2f, 0.0f, 0.0f
              }, 2);



        KeyboardState input_coordinat; //Информация о нажатых клавишах.
        private bool KeyPressedOff = true; //индекатор о том, что клавиша была отжата.
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
            point.initVertexBufferObject();
            staplesLeft.initVertexBufferObject();
            staplesRight.initVertexBufferObject();
            staplesRightM.initVertexBufferObject();
            staplesLeftM.initVertexBufferObject();
            line.initVertexBufferObject();
            grid.InitGrid();
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

            //Считывание нажатых клавишь:
            //Если мы просто нажмем на клавиш, то за это нажатие успеет пролететь 3-4 кадра.
            //Наше якобы короткое нажатие слишком длинное.
            //Для того чтобы считывались именно отдельные нажатия была введена переменная KeyPressedOff
            //Говорящая о том, что клавиша была отжата. Так одно нажатие отделяется от другого.
            input_coordinat = KeyboardState;
            if (input_coordinat.IsAnyKeyDown && (KeyPressedOff == true))
            {
                point.Move(input_coordinat);
                KeyPressedOff = false;
            }
           
            if (!input_coordinat.IsAnyKeyDown) KeyPressedOff = true;
            base.OnUpdateFrame(args);
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            point.DrawVertexBufferObject(PrimitiveType.TriangleFan);
            staplesLeft.DrawVertexBufferObject(PrimitiveType.LineLoop);
            staplesRight.DrawVertexBufferObject(PrimitiveType.LineLoop);
            staplesRightM.DrawVertexBufferObject(PrimitiveType.LineLoop);
            staplesLeftM.DrawVertexBufferObject(PrimitiveType.LineLoop);
            line.DrawVertexBufferObject(PrimitiveType.LineStrip);
            grid.DrawGrid();
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