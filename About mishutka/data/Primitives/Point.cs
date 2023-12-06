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
using About_mishutka.data.Models;

namespace About_mishutka.data.Primitives
{
    class Point : VBOModel
    {
        float[] pivot;
        public int count_Key = 0; // Кол-во нажатых клавиш. Нужно для премещений в методе Move;
        public Point(float x, float y, float z)
        {
            pivot = new float[] {x, y, z};
            countVertex = 4;
            vertices = new float[]
            {
                0.01f + pivot[0], 0.01f + pivot[1], 0.0f + pivot[2],
                -0.01f + pivot[0], 0.01f + pivot[1], 0.0f + pivot[2],
                -0.01f + pivot[0], -0.01f + pivot[1], 0.0f + pivot[2],
                0.01f + pivot[0], -0.01f + pivot[1], 0.0f + pivot[2]
            };
            colors = new float[countVertex * 4];
            for (int i = 0; i < countVertex * 4; i++) colors[i] = 1;
        }
        /*
         * Move: (по оси x, пока что)
         * Функция работает так, что от пользователя ждут нажатия двух клавиш (0 - 9), то есть тогда 
         * когда count_Key будет равно 2:
         * клавиша 1 x - целое часть числа с запятой (x.0f)
         * клавиша 2 x - целое часть числа с запятой (0.xf)
         * Когда count_Key = 2: точка перемещается
         */
        public void Move(KeyboardState input)
        {
            count_Key++;
            if (count_Key == 1)
            {
                //Не знаю как нормально считать нажатие чисел;
                //ToString() при нажатии 0 возвращает строку "{D0}"; 0 - [2]; Номер символа "0" в ASCII - 48; 
                //(К каждой цифре приписывается D. Незнаю почему)
                pivot[0] += Convert.ToInt16(input.ToString()[2] - 48);
                
            }
            if (count_Key == 2)
            {
                pivot[0] += (Convert.ToInt16(input.ToString()[2]) - 48)/10.0f;
                vertices[0] = pivot[0] + 0.01f;
                vertices[3] = pivot[0] + -0.01f;
                vertices[6] = pivot[0] + -0.01f;
                vertices[9] = pivot[0] + 0.01f;
                pivot[0] = 0.0f;
            }
            if (count_Key == 3)
            {
                //Не помню как обновить буфер.
                //НЕ работат.
                pivot[1] += Convert.ToInt16(input.ToString()[2] - 48);

            }
            if (count_Key == 4)
            {
                pivot[1] += (Convert.ToInt16(input.ToString()[2]) - 48) / 10.0f;
                vertices[1] = pivot[1] + 0.01f;
                vertices[4] = pivot[1] + 0.01f;
                vertices[7] = pivot[1] + -0.01f;
                vertices[10] = pivot[1] + -0.01f;
                pivot[1] = 0.0f;
                count_Key = 0;

            }
        }
    }
}
