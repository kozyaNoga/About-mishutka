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

namespace ConsoleApp1
{
    public class Game : GameWindow
    {
        private float sec = 0.0f;
        private int fps;
        private readonly float[] _vertices =
        {
             0.5f,  0.5f, 0.0f, // top right
             0.5f, -0.5f, 0.0f, // bottom right
            -0.5f, -0.5f, 0.0f, // bottom left
            -0.5f,  0.5f, 0.0f, // top left
        };

        // Then, we create a new array: indices.
        // This array controls how the EBO will use those vertices to create triangles
        private readonly uint[] _indices =
        {
            // Note that indices start at 0!
            0, 3, 1, // The first triangle will be the top-right half of the triangle
            1, 3, 2  // Then the second will be the bottom-left half of the triangle
        };

        private int _vertexBufferObject;

        private int _vertexArrayObject;
        ShaderTK _shader;
        private int _elementBufferObject;


        /*
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
        */
        public Game(GameWindowSettings GWsettings, NativeWindowSettings NWsettings) : base(GWsettings, NWsettings)
        {
            VSync = VSyncMode.On;
        }
        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            // We create/bind the Element Buffer Object EBO the same way as the VBO, except there is a major difference here which can be REALLY confusing.
            // The binding spot for ElementArrayBuffer is not actually a global binding spot like ArrayBuffer is. 
            // Instead it's actually a property of the currently bound VertexArrayObject, and binding an EBO with no VAO is undefined behaviour.
            // This also means that if you bind another VAO, the current ElementArrayBuffer is going to change with it.
            // Another sneaky part is that you don't need to unbind the buffer in ElementArrayBuffer as unbinding the VAO is going to do this,
            // and unbinding the EBO will remove it from the VAO instead of unbinding it like you would for VBOs or VAOs.
            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            // We also upload data to the EBO the same way as we did with VBOs.
            GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);
            // The EBO has now been properly setup. Go to the Render function to see how we draw our rectangle now!

            _shader = new ShaderTK("Shaders/Base.vert", "Shaders/Base.frag");
            _shader.Use();


            /*
            point.initVertexBufferObject();
            staplesLeft.initVertexBufferObject();
            staplesRight.initVertexBufferObject();
            staplesRightM.initVertexBufferObject();
            staplesLeftM.initVertexBufferObject();
            line.initVertexBufferObject();
            grid.InitGrid();
            */
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
            /*
            point.DrawVertexBufferObject(PrimitiveType.TriangleFan);
            staplesLeft.DrawVertexBufferObject(PrimitiveType.LineLoop);
            staplesRight.DrawVertexBufferObject(PrimitiveType.LineLoop);
            staplesRightM.DrawVertexBufferObject(PrimitiveType.LineLoop);
            staplesLeftM.DrawVertexBufferObject(PrimitiveType.LineLoop);
            line.DrawVertexBufferObject(PrimitiveType.LineStrip);
            grid.DrawGrid();
            */

            _shader.Use();

            // Because ElementArrayObject is a property of the currently bound VAO,
            // the buffer you will find in the ElementArrayBuffer will change with the currently bound VAO.
            GL.BindVertexArray(_vertexArrayObject);

            // Then replace your call to DrawTriangles with one to DrawElements
            // Arguments:
            //   Primitive type to draw. Triangles in this case.
            //   How many indices should be drawn. Six in this case.
            //   Data type of the indices. The indices are an unsigned int, so we want that here too.
            //   Offset in the EBO. Set this to 0 because we want to draw the whole thing.
            GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);

            SwapBuffers();
            base.OnRenderFrame(args);
        }
        protected override void OnUnload()
        {
            _shader.Dispose();
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