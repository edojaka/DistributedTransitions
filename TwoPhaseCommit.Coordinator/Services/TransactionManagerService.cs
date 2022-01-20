using MassTransit;
using TWOPCShared;
using TwoPhaseCommit.Coordinator.Model;

namespace TwoPhaseCommit.Coordinator.Services
{
    public class TransactionManagerService : ITransactionManagerService
    {
        private readonly Dictionary<Guid, TransactionStatus> _transactionStatuses = new Dictionary<Guid,TransactionStatus>();

        public TransactionManagerService(Dictionary<Guid, TransactionStatus> transactionStatuses)
        {
            _transactionStatuses = transactionStatuses;
        }

        private readonly IPublishEndpoint _endopoint;

        public void AddPhaseToTransaction(Guid uuid, ParticipantType participant, MessageAction action)
        {
            lock (_transactionStatuses)
            {
                if (_transactionStatuses.ContainsKey(uuid))
                {
                    _transactionStatuses[uuid].Phases.Add(
                        new TransactionSubStatus(participant, action)
                    );
                }
            }
        }

        public bool AllParticipantHaveDoneThisPhase(Guid uuid, MessageAction action)
        {
            if (_transactionStatuses.ContainsKey(uuid))
            {
                var status = _transactionStatuses[uuid];

                var x = status.Phases
                    .Count(x => x.MessageAction == action);


                return status.Phases
                           .Count(x => x.MessageAction == action)
                       == status.Participants.Count;
            }

            return false;
        }

        public void CleanTransaction(Guid uuid)
        {
            _transactionStatuses.Remove(uuid);
        }

        public async Task StartTransactionForCustomerAndOrder(int customerId, decimal amountToAdd, int productId)
        {
            var uuid = Guid.NewGuid();

            _transactionStatuses.Add(
                uuid,
                    new TransactionStatus(
                    uuid,
                    new[] { ParticipantType.OrderMicroservice, ParticipantType.CustomerMicroservice },
                    new List<TransactionSubStatus>()
                    )
                );

            await _endopoint.Publish(
               new PrepareCustomerUpdate(
                   uuid,
                   customerId,
                   amountToAdd
                   )
            );

            AddPhaseToTransaction(uuid, ParticipantType.CustomerMicroservice, MessageAction.Prepare);

            await _endopoint.Publish(
                new PrepareOrderCreation(
                    uuid,
                    productId
                    )
                );

            AddPhaseToTransaction(uuid, ParticipantType.OrderMicroservice, MessageAction.Prepare);
        }
    }
}
