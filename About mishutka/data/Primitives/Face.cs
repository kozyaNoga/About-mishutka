using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using About_mishutka.data.Models;
using About_mishutka.data.Textures;

namespace About_mishutka.data.Primitives
{
    class Face : EBOModel
    {
        public Face(float[] _vertices, uint[] _indices)
        {
            vertices = _vertices;
            indices = _indices;
        }
        public virtual void DrawEBO(Shader _shader, Texture _texture)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, vao);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);

            _texture.Use(TextureUnit.Texture0);
            _shader.Use();

            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
        }
    }
}
