using TWOPCShared;

namespace TwoPhaseCommit.Coordinator.Model
{
    public class TransactionSubStatus
    {
        public ParticipantType Participant { get; } // Soggetto: Customer, microservice
        public MessageAction MessageAction { get; } // Indica che azione riguarda

        public TransactionSubStatus(ParticipantType participant, MessageAction messageAction)
        {
            Participant = participant;
            MessageAction = messageAction;
        }
    }
}
