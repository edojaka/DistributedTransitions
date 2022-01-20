namespace TWOPCShared;

// Payload inviato da parte del Coordinatore per indicare ai partecipanti di effettuare il commit
// delle transazione
public class Commit
{
    public Guid TID { get; }

    public Commit(Guid tid)
    {
        TID = tid;
    }
}