namespace TWOPCShared;

// Inviamo questo payload dai partecipanti (microservizi: customer, order)
// quando vogliamo confermare al Coordinator che abbiamo effettuato il commit o l'abort della transazione
public class Ack
{
    public Guid TID { get; }
    public ParticipantType Participant { get; }

    public Ack(Guid tid, ParticipantType participant)
    {
        TID = tid;
        Participant = participant;
    }
}