using Health_Insurance.Api.Controllers.WebCore;
using Health_Insurance.Application.DI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var appSettingSection = builder.Configuration.GetSection("ConnectionStringManager");
ConfigServiceCollection.AddContextServices(builder.Services, builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(swagger =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    swagger.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

//if (!app.Environment.IsProduction())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.ConfigureCors(builder.Configuration);
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
