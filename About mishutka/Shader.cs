using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
//Не понятно
namespace About_mishutka
{
    class Shader
    {
        private readonly int vertexShader = 0;
        private readonly int fragmentShader = 0;
        private readonly int programShader = 0;
        public Shader(string vertexFile, string fragmentFile) 
        {
            vertexShader = CreateShader(ShaderType.VertexShader, vertexFile);
            fragmentShader = CreateShader(ShaderType.FragmentShader, fragmentFile);

            programShader = GL.CreateProgram();
            GL.AttachShader(programShader, vertexShader);
            GL.AttachShader(programShader, fragmentShader);

            GL.LinkProgram(programShader);
            GL.GetProgram(programShader, GetProgramParameterName.LinkStatus, out int code);
            if (code != (int)All.True)
            {
                var infolog = GL.GetProgramInfoLog(programShader);
                throw new Exception($"Ошибка при компиляции {programShader} \n\n {infolog}");
            }

            DeleteShader(vertexShader); 
            DeleteShader(fragmentShader);
        }

        public void ActiveProgram()
        {
            GL.UseProgram(programShader);
        }
        public void DeactiveProgram()
        {
            GL.UseProgram(0);
        }
        public void DeleteProgram()
        {
            GL.DeleteProgram(programShader);
        }
        private int CreateShader(ShaderType shaderType, string shaderFile)
        {
            string shaderCode = File.ReadAllText(shaderFile);
            int shaderId = GL.CreateShader(shaderType);
            GL.ShaderSource(shaderId, shaderCode);
            GL.CompileShader(shaderId);

            GL.GetShader(shaderId, ShaderParameter.CompileStatus, out int code);
            if(code != (int)All.True)
            {
                var infolog = GL.GetShaderInfoLog(shaderId);
                throw new Exception($"Ошибка при компиляции {shaderId} \n\n {infolog}");
            }
            return shaderId;
        }

        private void DeleteShader(int shader)
        {
            GL.DetachShader(programShader, shader);
            GL.DeleteShader(shader);
        }
    }
}
