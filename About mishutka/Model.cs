using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;

namespace About_mishutka
{
    class Model
    {
        protected int countVertex;
        protected int VBOVertex, VBOColor;
        public float[] vertices;
        public float[] colors;           
        public Model(int countVertex)
        {
            this.countVertex = countVertex;
        }
        public int CreateVertexBufferObject(float[] data)
        {
            int indexVBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, indexVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * sizeof(float), data, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            return indexVBO;
        }
        public void initVertexBufferObject()
        {
            VBOVertex = CreateVertexBufferObject(vertices);
            VBOColor = CreateVertexBufferObject(colors);
        }
        public void DrawVertexBufferObject()
        {
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.ColorArray);

            GL.BindBuffer(BufferTarget.ArrayBuffer, VBOVertex);
            GL.VertexPointer(3, VertexPointerType.Float, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, VBOColor);
            GL.ColorPointer(4, ColorPointerType.Float, 0, 0);

            GL.DrawArrays(PrimitiveType.LineLoop, 0, countVertex);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DisableClientState(ArrayCap.VertexArray);
            GL.DisableClientState(ArrayCap.ColorArray);
        }
        public void DeleteVertexBufferObject()
        {
            GL.DeleteBuffer(VBOVertex);
            GL.DeleteBuffer(VBOColor);
        }
        
    }
}
