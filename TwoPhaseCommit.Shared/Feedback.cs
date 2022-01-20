namespace TWOPCShared;

// Inviato dai partecipanti, come risposta al prepare.
// Ricevuto e interpretato dal Coordinatore
public class Feedback
{
    public Guid TID { get; } // ID Transizione
    public ParticipantType Participant { get; } // Indica il Partecipante che invia il messaggio
    public bool Ready { get; } // yes/no (prepared/failed) come risposta alla Prepare Phase

    public Feedback(Guid tid, ParticipantType participant, bool ready)
    {
        TID = tid;
        Participant = participant;
        Ready = ready;
    }
}