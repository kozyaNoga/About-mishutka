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
using About_mishutka.data.Primitives;

namespace About_mishutka.data.Models
{
    class World 
    {
        protected int countObjects = 0;
        protected Object basisOfWorld;
        protected Object basisOfPersone;
        protected Circle[] arrayCircle;

        public World(int level)
        {
            switch (level)
            {
                case 1:
                    countObjects = 2;
                    arrayCircle = new Circle[countObjects];
                    arrayCircle[0] = new Circle(17, 0.1f, 0.0f, 0.0f);
                    arrayCircle[1] = new Circle(17, 0.1f, 0.2f, 0.1f);
                    break;
                case 0:
                    countObjects = 1;
                    arrayCircle = new Circle[countObjects];
                    arrayCircle[0] = new Circle(17, 0.1f, 0.0f, 0.0f);
                    break;
                default:
                    break;
            }
        }
        public void InitObjects()
        {
            for (int i = 0; i < arrayCircle.Length; i++)
            {
                arrayCircle[i].initVertexBufferObject();
            }
        }
        public void DrawObjects()
        {
            for (int i = 0; i < arrayCircle.Length; i++)
            {
                arrayCircle[i].DrawVertexBufferObject(PrimitiveType.LineLoop);
            }
        }
        public void UpdateObjects()
        {
            for (int i = 0; i < arrayCircle.Length; i++)
            {
                Circle.Animation(arrayCircle[i]);
            }
            
        }
    }

}
