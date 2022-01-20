using MassTransit;
using TWOPCShared;
using TwoPhaseCommit.Coordinator.Services;

namespace TwoPhaseCommit.Coordinator.Consumers
{
    public class FeedbackConsumer : IConsumer<Feedback>
    {
        private readonly ITransactionManagerService _transactionManagerService;

        public FeedbackConsumer(ITransactionManagerService transactionManagerService)
        {
            _transactionManagerService = transactionManagerService;
        }

        public Task Consume(ConsumeContext<Feedback> context)
        {
            Console.WriteLine("{0} is ready for TID {1}",
                context.Message.Ready);

            return Task.CompletedTask;
        }
    }
}
