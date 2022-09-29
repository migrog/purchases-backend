using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using purchase.domain.entities;
using purchase.domain.entities.dtos;
using purchase.domain.entities.interfaces.facade;
using purchase.domain.entities.interfaces.repository;
using purchase.domain.entities.interfaces.services;
using purchase.infra.data.facade;
using purchase.infra.data.repository;
using static purchase.domain.core.Utils.Enumerates;

namespace purchase.domain.core.services
{
    public class PurchaseService : ServiceBase<Purchase>, IPurchaseService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserFacade _userFacade;
        private readonly IRepositoryBase<Purchase> _purchaseRepository = new RepositoryBase<Purchase>();
        private readonly IRepositoryBase<PurchaseDetail> _purchaseDetailRepository = new RepositoryBase<PurchaseDetail>();
        private readonly IRepositoryBase<Enumerate> _enumerateRepository = new RepositoryBase<Enumerate>();
        private readonly IRepositoryBase<Product> _productRepository = new RepositoryBase<Product>();
        public PurchaseService(IConfiguration configuration)
        {
            _configuration = configuration;
            _userFacade = new UserFacade(_configuration);
        }

        public PurchasePrintResponse GetPurchasePrint(int id)
        {
            var purchase = _purchaseRepository.Select(id);

            var user = _userFacade.UserById(purchase.UserId);
            var currency = _enumerateRepository.Select().Where(x=>x.EnumerateTypeCode == (int)EnumTypeCode.CURRENCY && x.Code == purchase.CurrencyTypeEnum).FirstOrDefault();

            var purchasePrint = new PurchasePrint()
            {
                Id = purchase.Id,
                Customer = user.Name,
                Total = purchase.Total,
                Date = purchase.CreateAt,
                Currency = currency.Value
            };

            var purchaseDetailPrint = from pur in _purchaseRepository.Select()
                         join det in _purchaseDetailRepository.Select() on pur.Id equals det.PurchaseId
                         join pro in _productRepository.Select() on det.ProductId equals pro.Id
                         where pur.Id.Equals(id)
                         select new PurchaseDetailPrint()
                         {
                             Item = pro.Name,
                             Quantity = det.Quantity,
                             UnitPrice = det.UnitPrice
                         };


            var result = new PurchasePrintResponse()
            {
                Purchase = purchasePrint,
                Detail = purchaseDetailPrint.ToList()

            };
            return result;
        }
    }
}
