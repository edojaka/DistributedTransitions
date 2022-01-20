using MassTransit;
using TWOPCShared;

namespace TwoPhaseCommit.Coordinator.Consumers
{
    public class AckConsumer : IConsumer<Ack>
    {
        public Task Consume(ConsumeContext<Ack> context)
        {
            Console.WriteLine("Recevied Ack from {0} for TID: {1}", 
                context.Message.Participant, context.Message.TID);

            return Task.CompletedTask;
        }
    }
}
