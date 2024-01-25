using System;
using System.Reflection.Metadata;
using OpenTK.Graphics.OpenGL;
using StbImageSharp;

namespace About_mishutka.data.Textures
{
    class Texture
    {
        int handle;
        public Texture(string path)
        {
            // Создаём указатель текстуры.
            handle = GL.GenTexture();

            // Биндимся к текстуре.
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, handle);

            // Флипим текстуру т.к. координаты тесктуры идут снизу вверх. 
            StbImage.stbi_set_flip_vertically_on_load(1);
            
            // Загружем изображение.
            using (Stream stream = File.OpenRead(path))
            {
                ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);

                // Теперь генерируем текстуру.
                // Arguments:
                //   Тип текстуры.
                //   Уровень дитализации (Для mipmap)
                //   Формат пикселя.
                //   Ширина.
                //   Васота.
                //   0. (Фигня из старых версий OpenGL)
                //   Ещё раз формат пикселя.
                //   Тип данных пикселя.
                //   Само изображение.
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);
            }

            // Настройки текстуры.

            // Хз. Что-то для mipmap на дальнем и ближним расстоянии.
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            // Повторение текстуры за краями.
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            // Генерируем mipmap. Не знаю зачем.
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }
        public void Use(TextureUnit unit)
        {
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, handle);
        }
    }
}
