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
    class Cyrcle : Model
    {
        public Cyrcle(int countVertex, float radius) : base(countVertex)
        {
            this.countVertex = countVertex;
            vertices = new float[countVertex * 3];
            colors = new float[countVertex * 4];
            for (int i = 0, j = 0; i < countVertex * 3; j++)
            {
                float x = radius * (float)Math.Cos(j * ((2.0f * (float)Math.PI) / countVertex));
                float y = radius * (float)Math.Sin(j * ((2.0f * (float)Math.PI) / countVertex));
                vertices[(i / 3) * 3] = x;
                vertices[(i / 3) * 3 + 1] = y;
                i += 3;
            }
            for (int i = 0; i < countVertex * 4; i++) colors[i] = 1;
        }
        
        public void Animation()
        {

        }
    }
}
