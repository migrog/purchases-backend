using purchase.domain.entities.dtos;

namespace purchase.domain.entities.interfaces.services
{
    public interface IPurchaseService: IServiceBase<Purchase>
    {
        PurchasePrintResponse GetPurchasePrint(int id);
    }
}
