namespace LogHostedService
{
    /// <summary>
    /// Representación de la sección LogHostedServiceSettings de la configuración
    /// </summary>
    public class LogHostedServiceSettings
    {
        /// <summary>
        /// Intervalo en segundos para escribir el mensaje en el log
        /// </summary>
        public double IntervaloSegundos { get; set; }

        /// <summary>
        /// Mensaje a esribir en el log
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Ruta completa donde se debe escribir el log
        /// </summary>
        public string RutaArchivo { get; set; }
    }
}
