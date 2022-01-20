namespace TWOPCShared;

// Inviamo questo payload quando vogliamo abortire la transazione
// Inviato dal Coordinatore
public class Abort
{
    public Guid TID { get; } // Rappresenta l'ID della transazione che desideriamo abortire

    public Abort(Guid tid)
    {
        TID = tid;
    }
}