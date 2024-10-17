using MassTransit;
using Notification.API.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMassTransit(opt =>
{
    opt.AddConsumer<MessageSubmittedConsumer>();
    opt.UsingRabbitMq((context, config) =>
    {

        config.Host(builder.Configuration.GetConnectionString("RabbitConn"));
        //event dinleme olduðundan queue ile iþimiz yok, event birdan fazla yerden dinlenebilir. EventListener tanýmý yeterli
        config.ReceiveEndpoint(x => x.ConfigureConsumer<MessageSubmittedConsumer>(context));

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
