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
using About_mishutka.data.Models;

namespace About_mishutka.data.Primitives
{
    class Circle : VBOModel
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
        protected void CalcultVertex()
        {
            for (int i = 0, j = 0; i < countVertex * 3; j++)
            {
                float x = radius * (float)Math.Cos(j * (2.0f * (float)Math.PI / countVertex)) + this.x;
                float y = radius * (float)Math.Sin(j * (2.0f * (float)Math.PI / countVertex)) + this.y;
                vertices[i / 3 * 3] = x;
                vertices[i / 3 * 3 + 1] = y;
                i += 3;
            }
        }

        // Конструктор круга
        public Circle(int countVertex, float radius, float x0, float y0)
        {
            x = x0;
            y = y0;
            type = PrimitiveType.LineLoop;
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
        public static void Animation(Circle a)
        {
            a.radius += 0.01f;
            a.CalcultVertex();
        }

        //Создание объектов неотрывно связанны с миром (World). Все объекты могут существовать
        //только в том или ином мире. Кроме персонажа.
        // Поэтому мы фабричному методу передаем countObject.
        public static Circle Create(int countVertex, float radius, float x0, float y0)
        {
            Circle a = new Circle(countVertex, radius, x0, y0);
            return a;
        }
    }
}
