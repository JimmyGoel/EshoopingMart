using Ordering.Api;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//TODO:  Add Service Container

builder.Services.
    AddApplicationService().
    AddInfrastructureService(builder.Configuration).
    AddApiService();

var app = builder.Build();

// TODO : Configuration Http Pipline
app.UseApiServices();

app.Run();
