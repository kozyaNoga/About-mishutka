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
//Не работает
namespace About_mishutka.data.Models
{
    // EBO (Element Buffer Object)
    class EBOModel
    {
        // Указатель на Буффер элементов
        private int inedex;

        // Массив элементов 
        uint[] element = new uint[]
        {
            0, 1, 2,
            2, 1, 3
        };
        private int CreateEBO(uint[] data)
        {
            int indexEBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexEBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, data.Length * sizeof(uint), data, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            return indexEBO;
        }
        public void DrawElementObject()
        {

        }
    }
}
