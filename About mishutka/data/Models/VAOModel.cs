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
using System.Drawing;
//Не работает
namespace About_mishutka.data.Models
{
    // (VAO + VBO) Vertex Array Object (no Shader)
    class VAOModel
    {
        private float[] vertex = {
           -0.5f, -0.5f, 0.0f,
            0.5f, -0.5f, 0.0f,
           -0.5f,  0.5f, 0.0f,
            0.5f,  0.5f, 0.0f};
        private float[] color = {
            1.0f, 0.0f, 0.0f, 1.0f,
            0.0f, 1.0f, 0.0f, 1.0f,
            0.0f, 0.0f, 1.0f, 1.0f,
            0.8f, 0.6f, 0.2f, 1.0f};
        private int vboV, vboC;
        public int vaoId;
        public void CreateVAOnoShaders()
        {
            int vaoId = GL.GenVertexArray();
            GL.BindVertexArray(vaoId);

            int vboV = CreateVertexBufferObject(vertex);
            int vboC = CreateVertexBufferObject(color);

            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.ColorArray);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboV);
            GL.VertexPointer(3, VertexPointerType.Float, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboC);
            GL.ColorPointer(4, ColorPointerType.Float, 0, 0);

            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DisableClientState(ArrayCap.VertexArray);
            GL.DisableClientState(ArrayCap.ColorArray);
        }
        public void DrawVertexArrayObject()
        {
            GL.BindVertexArray(vaoId);
            GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4);
        }
        protected int CreateVertexBufferObject(float[] data)
        {
            int indexVBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, indexVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * sizeof(float), data, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            return indexVBO;
        }
        public void DeleteVAO()
        {
            GL.BindVertexArray(0);
            GL.DeleteVertexArray(vaoId);
            GL.DeleteBuffer(vboV);
            GL.DeleteBuffer(vboC);
        }
    }
}
