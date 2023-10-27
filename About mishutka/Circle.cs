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
    class Circle : Model
    {
        /*
        float y
        {
            get
            { return y; }

            set
            {
                if (value <= 1.0f & value >= -1.0f) y = value;
                else if (value > 1.0f) y = 1.0f;
                else y = -1.0f;
            }
        }
        float x
        {
            get
            { return x;}

            set
            {
                if (value <= 1.0f & value >= -1.0f) x = value;
                else if (value > 1.0f) x = 1.0f;
                else x = -1.0f;
            }
        }
        */
        // Пареметры
        private float x = 0.0f, y = 0.0f;
        private float radius;
        
        // Просчёт вертексов
        private void CalcultVertex()
        {
            for (int i = 0, j = 0; i < countVertex * 3; j++)
            {
                float x = this.radius * (float)Math.Cos(j * ((2.0f * (float)Math.PI) / countVertex)) + this.x;
                float y = this.radius * (float)Math.Sin(j * ((2.0f * (float)Math.PI) / countVertex)) + this.y;
                vertices[(i / 3) * 3] = x;
                vertices[(i / 3) * 3 + 1] = y;
                i += 3;
            }
        }

        // Конструктор круга
        public Circle(int countVertex, float radius, float x0, float y0) : base(countVertex)
        {
            this.x = x0;
            this.y = y0;
            this.radius = radius;
            this.countVertex = countVertex;
            vertices = new float[countVertex * 3];
            colors = new float[countVertex * 4];
            CalcultVertex();
            for (int i = 0; i < countVertex * 4; i++) colors[i] = 1;
        }

        // Пивот (Положение круга в сцене). x и y одновременно используются
        // для расчёта вертексов и задания положения объекта в сцене
        public void Pivot(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        
        // Анимация Кргуга
        public void Animation(float max, float min)
        {
            if (this.radius < max) this.radius += 0.01f;
            else if (this.radius > min) this.radius -= 0.01f;
            CalcultVertex();
            VBOVertex = CreateVertexBufferObject(vertices);
            VBOColor = CreateVertexBufferObject(colors);
        }
    }
}
