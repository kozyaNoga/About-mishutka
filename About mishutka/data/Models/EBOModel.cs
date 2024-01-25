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
using About_mishutka.data.Textures;
//Не работает
namespace About_mishutka.data.Models
{
    // EBO (Element Buffer Object)
    class EBOModel
    {
        // Указатель на Буффер элементов
        public int vbo;
        public int vao;
        public int ebo;

        protected float[] vertices;
        // Массив элементов 
        protected uint[] indices;

        public void CreateEBO()
        {
            vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);

            vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer,vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            ebo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);


            // Console.WriteLine($"create VBO {vbo}, create VAO {vao}, create EBO {ebo}");
        }
       
        public void DrawEBO()
        {
            // Console.WriteLine($"draw VBO {vbo}, darw VAO {vao}, darw EBO {ebo}");
            GL.BindBuffer(BufferTarget.ArrayBuffer, vao);
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void DeleteEBO()
        {
            GL.DeleteBuffer(vbo);
            GL.DeleteBuffer(vao);
            GL.DeleteBuffer(ebo);
        }
    }
}
