using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LogHostedService
{
    public class LogHostedService: IHostedService
    {
        private readonly IHostEnvironment environment;
        private readonly LogHostedServiceSettings settings;
        private Timer timer;

        public LogHostedService(IHostEnvironment environment, LogHostedServiceSettings settings)
        {
            this.environment = environment;
            this.settings = settings;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {

            await WriteToFile("Proceso iniciado");

            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(settings.IntervaloSegundos));
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await WriteToFile("Proceso detenido");
            timer?.Change(Timeout.Infinite, 0);
        }

        private void DoWork(object state)
        {
            DoWorkAsync().Wait();
        }

        private async Task DoWorkAsync()
        {
            await WriteToFile(settings.Mensaje);
        }

        private async Task WriteToFile(string message)
        {
            string path = Path.Combine(settings.RutaArchivo);
            string folder = Path.GetDirectoryName(path);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            message = $"LogHostedService {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")} {message}";

            using (StreamWriter writer = new StreamWriter(path, append: true))
            {
                await writer.WriteLineAsync(message);
            }
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
