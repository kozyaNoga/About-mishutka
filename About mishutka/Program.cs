using System;
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
using About_mishutka;
using System.Diagnostics;
using About_mishutka.data.Textures;

namespace ConsoleApp1
{
    public class Game : GameWindow
    {

        private Stopwatch _timer;
        private float sec = 0.0f;
        private int fps;

        Shader _shader1;
        Shader _shader2;
        Texture _texture;

        Face Tringle1 = new Face(
            new float[] 
            {
                0.2f, 0.2f, 0.0f, 1.0f, 1.0f,
                -0.2f, 0.2f, 0.0f, 0.0f, 1.0f,
                -0.2f, -0.2f, 0.0f, 0.0f, 0.0f,
                0.2f, -0.2f, 0.0f, 1.0f, 0.0f
            },
            new uint[]
            {
                0, 1, 2,
                3, 0, 2
            });
        Face Tringle2 = new Face(
            new float[]
            {
                0.2f-0.5f, 0.2f, 0.0f, 1.0f, 1.0f,
                -0.2f-0.5f, 0.2f, 0.0f, 0.0f, 1.0f,
                -0.2f-0.5f, -0.2f, 0.0f, 0.0f, 0.0f,
                0.2f-0.5f, -0.2f, 0.0f, 1.0f, 0.0f
            },
            new uint[]
            {
                0, 1, 2,
                3, 0, 2
            });

        KeyboardState input_coordinat; //Информация о нажатых клавишах.
        private bool KeyPressedOff = true; //индекатор о том, что клавиша была отжата.
        
        public Game(GameWindowSettings GWsettings, NativeWindowSettings NWsettings) : base(GWsettings, NWsettings)
        {
            VSync = VSyncMode.On;
        }
        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            // GL.Enable(EnableCap.CullFace);
            // GL.CullFace(CullFaceMode.Back);

            _shader1 = new Shader("Shaders/Base1.vert", "Shaders/Base1.frag");

            Tringle1.CreateEBO();
            _shader1.Use();

            var vertexLocation = _shader1.GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);

            var texCoordLocation = _shader1.GetAttribLocation("aTexCoord");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));


            _texture = new Texture("images/img1.png");
            _texture.Use(TextureUnit.Texture0);
            
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
                Title = $"Posidon's Creation: fps - {(float)fps}";
                fps = 0;
                sec = 0.0f;
            }
            fps += 1;

            //Считывание нажатых клавишь:
            //Если мы просто нажмем на клавиш, то за это нажатие успеет пролететь 3-4 кадра.
            //Наше якобы короткое нажатие слишком длинное.
            //Для того чтобы считывались именно отдельные нажатия была введена переменная KeyPressedOff
            //Говорящая о том, что клавиша была отжата. Так одно нажатие отделяется от другого.
            /*
            input_coordinat = KeyboardState;
            if (input_coordinat.IsAnyKeyDown && (KeyPressedOff == true))
            {
                point.Move(input_coordinat);
                KeyPressedOff = false;
            }
           
            if (!input_coordinat.IsAnyKeyDown) KeyPressedOff = true; 
            */
            base.OnUpdateFrame(args);
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);


            
            Tringle1.DrawEBO();
            
            //Tringle2.DrawEBO();
            //_shader2.Use();


            //_shader2.Use();


            //_shader2.Use();


            SwapBuffers();
            base.OnRenderFrame(args);
        }
        protected override void OnUnload()
        {
            Tringle1.DeleteEBO();
            Tringle2.DeleteEBO();
            _shader1.Dispose();
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