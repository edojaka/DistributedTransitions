using TWOPCShared;
using TwoPhaseCommit.Coordinator.Model;

namespace TwoPhaseCommit.Coordinator.Services
{
    public interface ITransactionManagerService
    {
        // Iniziare una transazione
        Task StartTransactionForCustomerAndOrder(
            int customerId,
            decimal amountToAdd,
            int productId
        );

        // Aggiungere una fase alla transazione
        void AddPhaseToTransaction(Guid uuid, ParticipantType participant, MessageAction action);

        bool AllParticipantHaveDoneThisPhase(Guid uuid, MessageAction action);

        void CleanTransaction(Guid uuid);
    }
}
