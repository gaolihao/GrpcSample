using Web;
using ProtoBuf.Grpc.Server;
using Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.WebHost.ConfigureKestrel(SocketSetup.Execute);
builder.Services.AddGrpc();
builder.Services.AddCodeFirstGrpc();
builder.Services.AddSingleton<SynchronizedScrollingRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGrpcService<SynchronizedScrollingService>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
