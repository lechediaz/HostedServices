using Core.Settings;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Services
{
    public class MyLogService : IHostedService
    {
        private readonly IHostEnvironment environment;
        private readonly EscribirArchivoSettings settings;
        private Timer timer;

        public MyLogService(IHostEnvironment environment, EscribirArchivoSettings settings)
        {
            this.environment = environment;
            this.settings = settings;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            WriteToFile($"Proceso iniciado {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}");
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(settings.IntervaloSegundos));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            WriteToFile($"Proceso detenido {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}");
            timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            WriteToFile($"Hacer una operación {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}");
        }

        private void WriteToFile(string message)
        {
            string folder = $@"{environment.ContentRootPath}\{settings.RutaCarpeta}";
            string path = $@"{folder}\{settings.NombreArchivo}";

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            using (StreamWriter writer = new StreamWriter(path, append: true))
            {
                writer.WriteLine(message);
            }
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
