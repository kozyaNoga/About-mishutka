using About_mishutka.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace About_mishutka.data.Staples
{
    class Staples : VBOModel
    {
        /*
        Staples staplesLeft = new Staples(new float[]
            { -0.04f+0.83f, 0.0f+0.61f, 0.0f,
              -0.08f+0.83f, 0.0f+0.61f, 0.0f,
              -0.08f+0.83f, 0.3f+0.61f, 0.0f,
              -0.04f+0.83f, 0.3f+0.61f, 0.0f}, 4);
        Staples staplesRight = new Staples(new float[]
            { 0.04f+0.83f, 0.0f+0.61f, 0.0f,
              0.08f+0.83f, 0.0f+0.61f, 0.0f,
              0.08f+0.83f, 0.3f+0.61f, 0.0f,
              0.04f+0.83f, 0.3f+0.61f, 0.0f}, 4);
        Staples staplesLeftM = new Staples(new float[]
            { -0.11f+0.55f, 0.0f+0.61f, 0.0f,
              -0.14f+0.55f, 0.0f+0.61f, 0.0f,
              -0.14f+0.55f, 0.3f+0.61f, 0.0f,
              -0.11f+0.55f, 0.3f+0.61f, 0.0f}, 4);
        Staples staplesRightM = new Staples(new float[]
            { 0.11f+0.55f, 0.0f+0.61f, 0.0f,
              0.14f+0.55f, 0.0f+0.61f, 0.0f,
              0.14f+0.55f, 0.3f+0.61f, 0.0f,
              0.11f+0.55f, 0.3f+0.61f, 0.0f}, 4);
        
        Staples Zero = new Staples(new float[]
            { 0.02f+0.83f, 0.0f+0.64f, 0.0f,
              -0.02f+0.83f, 0.0f+0.64f, 0.0f,
              -0.02f+0.83f, 0.06f+0.64f, 0.0f,
              0.02f+0.83f, 0.06f+0.64f, 0.0f,
              }, 4);
        Staples Zero1 = new Staples(new float[]
            { 0.02f+0.83f, 0.0f+0.73f, 0.0f,
              -0.02f+0.83f, 0.0f+0.73f, 0.0f,
              -0.02f+0.83f, 0.06f+0.73f, 0.0f,
              0.02f+0.83f, 0.06f+0.73f, 0.0f,
              }, 4);
        Staples Zero2 = new Staples(new float[]
            { 0.02f+0.83f, 0.0f+0.82f, 0.0f,
              -0.02f+0.83f, 0.0f+0.82f, 0.0f,
              -0.02f+0.83f, 0.06f+0.82f, 0.0f,
              0.02f+0.83f, 0.06f+0.82f, 0.0f,
              }, 4);

        Staples Zero1 = new Staples(new float[]
            { 0.02f+0.86f, 0.0f+0.64f, 0.0f,
              -0.02f+0.86f, 0.0f+0.64f, 0.0f,
              -0.02f+0.86f, 0.06f+0.64f, 0.0f,
              0.02f+0.86f, 0.06f+0.64f, 0.0f,
              }, 4);

      Staples One = new Staples(new float[]
            { 0.0f+0.86f, 0.0f+0.64f, 0.0f,
              0.0f+0.86f, 0.06f+0.64f, 0.0f,
              }, 2);

        Staples Two = new Staples(new float[]
            { 0.02f+0.86f, 0.0f+0.64f, 0.0f,
              -0.02f+0.86f, 0.0f+0.64f, 0.0f,
              0.02f+0.86f, 0.04f+0.64f, 0.0f,
              0.02f+0.86f, 0.06f+0.64f, 0.0f,
              -0.02f+0.86f, 0.06f+0.64f, 0.0f,
              }, 5);
        Staples Three = new Staples(new float[]
            { -0.02f+0.86f, 0.0f+0.64f, 0.0f,
              0.02f+0.86f, 0.0f+0.64f, 0.0f,
              0.02f+0.86f, 0.04f+0.64f, 0.0f,
              -0.02f+0.86f, 0.04f+0.64f, 0.0f,
              0.02f+0.86f, 0.06f+0.64f, 0.0f,
              -0.02f+0.86f, 0.06f+0.64f, 0.0f
              }, 6);
        Staples Four = new Staples(new float[]
            { 0.02f+0.86f, 0.0f+0.64f, 0.0f,
              0.02f+0.86f, 0.06f+0.64f, 0.0f,
              0.02f+0.86f, 0.04f+0.64f, 0.0f,
              -0.02f+0.86f, 0.04f+0.64f, 0.0f,
              -0.02f+0.86f, 0.06f+0.64f, 0.0f
              }, 5);
        Staples Five = new Staples(new float[]
            { -0.02f+0.86f, 0.0f+0.64f, 0.0f,
              0.02f+0.86f, 0.0f+0.64f, 0.0f,
              0.02f+0.86f, 0.04f+0.64f, 0.0f,
              -0.02f+0.86f, 0.04f+0.64f, 0.0f,
              -0.02f+0.86f, 0.06f+0.64f, 0.0f,
              0.02f+0.86f, 0.06f+0.64f, 0.0f
              }, 6);
        Staples Six = new Staples(new float[]
            { 0.02f+0.86f, 0.06f+0.64f, 0.0f,
              -0.02f+0.86f, 0.06f+0.64f, 0.0f,
              -0.02f+0.86f, 0.0f+0.64f, 0.0f,
              0.02f+0.86f, 0.0f+0.64f, 0.0f,
              0.02f+0.86f, 0.04f+0.64f, 0.0f,
              -0.02f+0.86f, 0.04f+0.64f, 0.0f,
              }, 6);
        Staples Seven = new Staples(new float[]
            { -0.02f+0.86f, 0.06f+0.64f, 0.0f,
              0.02f+0.86f, 0.06f+0.64f, 0.0f,
              -0.02f+0.86f, 0.0f+0.64f, 0.0f
              }, 3);
        Staples Eight = new Staples(new float[]
            { -0.02f+0.86f, 0.0f+0.64f, 0.0f,
              -0.02f+0.86f, 0.06f+0.64f, 0.0f,
              0.02f+0.86f, 0.06f+0.64f, 0.0f,
              0.02f+0.86f, 0.0f+0.64f, 0.0f,
              -0.02f+0.86f, 0.0f+0.64f, 0.0f,
              -0.02f+0.86f, 0.04f+0.64f, 0.0f,
              0.02f+0.86f, 0.04f+0.64f, 0.0f
              }, 7);
        Staples Nine = new Staples(new float[]
            { 0.02f+0.86f, 0.0f+0.64f, 0.0f,
              -0.02f+0.86f, 0.0f+0.64f, 0.0f,
              -0.02f+0.86f, 0.06f+0.64f, 0.0f,
              0.02f+0.86f, 0.06f+0.64f, 0.0f,
              0.02f+0.86f, 0.04f+0.64f, 0.0f,
              -0.02f+0.86f, 0.04f+0.64f, 0.0f
              }, 6);
        */
        public Staples(float[] vertices, int count)
        {

            countVertex = count;
            this.vertices = vertices;
            colors = new float[count * 4];
            for (int i = 0; i < count * 4; i++) colors[i] = 1;
        }
        
    }
}
