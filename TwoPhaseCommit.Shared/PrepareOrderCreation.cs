namespace TWOPCShared;

// Inviato dal Coordinatore
// Ricevuto dall'OrderMicroservice
public class PrepareOrderCreation
{
    public Guid TID { get; } // ID Transazione
    public int ProductId { get; } // Id del prodotto
    
    public PrepareOrderCreation(Guid tid, int productId)
    {
        TID = tid;
        ProductId = productId;
    }
}