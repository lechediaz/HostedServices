## Descripción

En este repositorio se busca demostrar dos formas de mantener tareas trabajando en segundo plano, bien sea en un WebHost o un Host, para ello, contamos con los siguientes proyectos:

- [Core](Core): En este se encuentra la clase [MyLogService](Core\Services\MyLogService.cs), ésta básicmaente lo que hace es que mientras el proceso principal esté corriendo, escribirá en un archivo un texto.

- [ApiWithHostedService](ApiWithHostedService): Consiste en una Web API comùn y corriente, pero que registra el *MyLogService* para que escriba el archivo mientras el Web API está ejecutandose en IIS, por ejemplo.

- [WorkerService](WorkerService): Es un proyecto creado a partir de la plantilla llamada de la misma forma, con la diferencia que registra el *MyLogService* para que escriba el archivo mientras el proceso se está ejecutando.

**Nota**: La otra forma de realizar este tipo de tareas es con un servicio de Windows como tal, sin embargo es bueno revisar cuál es la opción que más nos conviene, dejo unos links de interés.

- [Background tasks with hosted services in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-3.1): Ejemplo de un Service Worker.
- [Host ASP.NET Core in a Windows Service](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/windows-service?view=aspnetcore-5.0&tabs=visual-studio): Registrar un ServiceWorker como servicio de Windows.
- [Implement background tasks in microservices with IHostedService and the BackgroundService class](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/background-tasks-with-ihostedservice): En la sección [Deployment considerations and takeaways](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/background-tasks-with-ihostedservice#deployment-considerations-and-takeaways) menciona algunas consideraciones a tener en cuenta.