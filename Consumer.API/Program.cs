using Consumer.API.Consumers;
using MassTransit;
using Messaging.RabbitMqConsts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(opt =>
{

    opt.AddConsumer<SendMessageConsumer>();//dependancy injection ile servisin tanýmý


    opt.UsingRabbitMq((context, config) =>
    {
        config.Host(builder.Configuration.GetConnectionString("RabbitConn"));

        //direct exchange bir kuyruk bekler, mesaj ilgili kuyruða iletilecek
        config.ReceiveEndpoint(QueueTypes.SendMessageQueue, e =>
        {
            e.ConfigureConsumer<SendMessageConsumer>(context);//Rabbit Mq üzerinden gelen mesaja subscribe olduðumuz yer
        });
    });

    //hangi CLR tipinde mesajý yakalamak yani consume etmek istiyorsak consumer olarak buraya tanýmlýyoruz
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
