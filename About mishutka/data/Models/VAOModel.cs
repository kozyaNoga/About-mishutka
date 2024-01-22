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
        protected float[] vertices;
        private int vaoId;
        private int vboId;

        
        public void CreateVAO()
        {
            vboId = CreateVertexBufferObject(vertices);

            vaoId = GL.GenVertexArray();
            GL.BindVertexArray(vaoId);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }
        public void DrawVertexArrayObject()
        {
            GL.BindVertexArray(vaoId);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }
        protected int CreateVertexBufferObject(float[] data)
        {
            int indexVBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, indexVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * sizeof(float), data, BufferUsageHint.StaticDraw);
            return indexVBO;
        }
        public void DeleteVAO()
        {
            GL.BindVertexArray(0);
            GL.DeleteVertexArray(vaoId);
            GL.DeleteBuffer(vboId);
        }
    }
}
