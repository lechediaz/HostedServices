## Descripción

En este repositorio se busca demostrar dos formas de mantener tareas trabajando en segundo plano en .Net Core, bien sea en un IWebHost o un IHost, para ello, contamos con los siguientes proyectos:

- [LogHostedService](/LogHostedService): Es una biblioteca de clases y este se encuentra la clase [LogHostedService](/LogHostedService/LogHostedService.cs), ésta básicamente lo que hace es que mientras el proceso principal esté corriendo, escribirá un mensaje personalizado en un archivo un texto.

    En el proyecto de destino es importante configurar la sección **LogHostedServiceSettings**, por ejemplo en `appsettings.json`:

    ```json
    {
        "LogHostedServiceSettings": {
            "IntervaloSegundos": 10,
            "Mensaje": "Realicé una operación en segundo plano :)",
            "RutaArchivo": "C:\\Users\\david\\Documents\\Logs\\LogHostedService.txt"
        }
    }

    ```

    Los valores de la claves indican:
    - **IntervaloSegundos**: Intervalo en segundos para escribir el mensaje en el log.
    - **Mensaje**: Mensaje a esribir en el log.
    - **NombreArchivo**: Ruta completa donde se debe escribir el log.

- [WebApi](/WebApi): Consiste en una Web API generada desde la plantilla por defecto, pero que registra el **LogHostedService** para que escriba el archivo de log mientras el Web API está ejecutandose en IIS, por ejemplo.

- [WorkerService](/WorkerService): Es un proyecto generado a partir de la plantilla por defecto llamada de la misma forma, con la diferencia que registra el **LogHostedService** para que escriba el archivo mientras el proceso se está ejecutando.

## Recursos adicionales

- [Background tasks with hosted services in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-3.1): Ejemplo de un Service Worker.
- [Host ASP.NET Core in a Windows Service](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/windows-service?view=aspnetcore-5.0&tabs=visual-studio): Registrar un ServiceWorker como servicio de Windows.
- [Implement background tasks in microservices with IHostedService and the BackgroundService class](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/background-tasks-with-ihostedservice): En la sección [Deployment considerations and takeaways](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/background-tasks-with-ihostedservice#deployment-considerations-and-takeaways) menciona algunas consideraciones a tener en cuenta.