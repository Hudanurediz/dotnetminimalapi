using DotnetMinimalApi.Endpoints;
using DotnetMinimalApi.Entities;
using Marten;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PostgreSql");

builder.Services.AddMarten(options =>
{
    options.Connection(connectionString);
    options.Schema.For<RequestData>()
        .UniqueIndex(x => x.Key);
    options.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "swagger");
        c.RoutePrefix = string.Empty;
    });
}


app.CreateRequestData();
app.GetByKeyRequestData();
app.DeleteByKeyRequestData();

app.Run();