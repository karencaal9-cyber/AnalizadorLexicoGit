using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexicoGit.GitService
{
    internal class ControladorGit
    {
        private string _rutaRepositorio;

        public ControladorGit(string rutaRepositorio)
        {
            _rutaRepositorio = rutaRepositorio;
        }

        public string EjecutarComando(string comandoGit)
        {
            ProcessStartInfo psi = new ProcessStartInfo("git", comandoGit)
            {
                WorkingDirectory = _rutaRepositorio,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process proceso = Process.Start(psi))
            {
                string salida = proceso.StandardOutput.ReadToEnd();
                string error = proceso.StandardError.ReadToEnd();
                proceso.WaitForExit();

                return !string.IsNullOrEmpty(error) ? error : salida;
            }
        }

        public string ObtenerEstado() => EjecutarComando("status -s");
        public string HacerCommit(string mensaje) => EjecutarComando($"commit -am \"{mensaje}\"");
        public string HacerPush() => EjecutarComando("push");
        public string HacerPull() => EjecutarComando("pull");
    }
}

