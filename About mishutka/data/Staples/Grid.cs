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

namespace About_mishutka.data.Staples
{
    class Grid
    {
        Staples[] gridArray = new Staples[38];
        public Grid()
        {
            float j = 0.0f;
            for(int i = 0; i < gridArray.Length-19; i++)
            {
                gridArray[i] = new Staples( new float[] 
                    {-0.9f+j, -1.0f, 0.0f,
                     -0.9f+j, 1.0f, 0.0f}, 2);
                j += 0.1f;
            }
            j = 0.0f;
            for (int i = 19; i < gridArray.Length; i++)
            {
                gridArray[i] = new Staples(new float[]
                    {1.0f, -0.9f+j, 0.0f,
                     -1.0f, -0.9f+j, 0.0f}, 2);
                j += 0.1f;
            }
        }
        public void DrawGrid()
        {
            for (int i = 0; i < gridArray.Length; i++) gridArray[i].DrawVertexBufferObject(PrimitiveType.LineStrip);
        }
        public void InitGrid() 
        {
            for (int i = 0; i < gridArray.Length; i++) gridArray[i].initVertexBufferObject();
        }
    }
}
