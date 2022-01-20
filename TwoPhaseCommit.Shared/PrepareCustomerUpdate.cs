namespace TWOPCShared;

// Inviato dal Coordinatore
// Ricevuto da: CustomerMicroservice
public class PrepareCustomerUpdate
{
    public Guid TID { get; } // ID Transazione
    public int CustomerId { get; } // ID del customer da aggiornare
    public decimal AddFound { get; } // importo da sommare al customer

    public PrepareCustomerUpdate(Guid tid, int customerId, decimal addFound)
    {
        TID = tid;
        CustomerId = customerId;
        AddFound = addFound;
    }
}