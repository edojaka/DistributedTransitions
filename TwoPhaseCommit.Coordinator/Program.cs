using MassTransit;
using TwoPhaseCommit.Coordinator.Consumers;
using TwoPhaseCommit.Coordinator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, config) =>
    {

        config.Host("localhost", "/", credentials =>
        {
            credentials.Username("admin");
            credentials.Password("password");
        });

        config.ConfigureEndpoints(context);

        config.ReceiveEndpoint("feedback-endpoint", e =>
        {
            e.Consumer(() => new FeedbackConsumer(context.GetRequiredService<ITransactionManagerService>()));
        });

        config.ReceiveEndpoint("ack-endpoint", e =>
        {
            e.Consumer(() => new AckConsumer());
        });
    });
}
);

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
