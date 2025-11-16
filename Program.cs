using guille_test.src;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<ITodoList, TodoList>();
builder.Services.AddScoped<ITodoListRepository, TodoListRepository>();
builder.Services.AddSingleton<CLI>();

var provider = builder.Services.BuildServiceProvider();

var app = provider.GetRequiredService<CLI>();
app.Run();
