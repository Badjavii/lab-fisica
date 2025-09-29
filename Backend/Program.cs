// Esto es el punto de entrada principal de la aplicación ASP.NET Core.
// Aquí se configura y se inicia el servidor web que alojará la API.
var builder = WebApplication.CreateBuilder(args);

// Agregamos los servicios necesarios para manejar controladores.
// Esto permite que la aplicación utilice controladores para manejar solicitudes HTTP.
builder.Services.AddControllers();

// Agregamos servicios para la documentación de la API utilizando Swagger.
// Swagger es una herramienta que genera documentación interactiva para APIs RESTful.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Si la aplicación está en modo de desarrollo, habilitamos Swagger para la documentación de la API.
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitamos la redirección de HTTP a HTTPS para mejorar la seguridad.
app.UseHttpsRedirection();

// Aqui lo que se hace es mapear los controladores para que puedan manejar las solicitudes entrantes.
// Esto permite que los controladores definidos en la aplicación respondan a las rutas configuradas.
app.MapControllers();

// Iniciamos la aplicación web.
app.Run();