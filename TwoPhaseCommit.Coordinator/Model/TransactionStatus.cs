using TWOPCShared;

namespace TwoPhaseCommit.Coordinator.Model
{
    public class TransactionStatus
    {
        public Guid Id { get; } // l'id transazione
        public List<ParticipantType> Participants { get; } // Indica tutti i partecipanti della transazione
        public List<TransactionSubStatus> Phases { get; }

        public TransactionStatus(Guid id, IEnumerable<ParticipantType> participants, IEnumerable<TransactionSubStatus> phases)
        {
            Id = id;
            Participants = participants.ToList();
            Phases = phases.ToList();
        }
    }
}
