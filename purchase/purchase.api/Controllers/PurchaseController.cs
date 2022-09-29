using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using purchase.api.Models;
using purchase.api.Utils;
using purchase.domain.core;
using purchase.domain.core.services;
using purchase.domain.core.valitators;
using purchase.domain.entities;
using purchase.domain.entities.interfaces.services;

namespace purchase.api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceBase<Purchase> _servicePurchase = new ServiceBase<Purchase>();
        private readonly IServiceBase<PurchaseDetail> _servicePurchaseDetail = new ServiceBase<PurchaseDetail>();
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IConfiguration configuration)
        {
            _configuration = configuration;
            _purchaseService = new PurchaseService(_configuration);
        }

        [HttpPost("purchases")]
        public IActionResult Post([FromBody] object req)
        {
            try
            {
                PurchasePostRequest body = JsonConvert.DeserializeObject<PurchasePostRequest>(req.ToString());

                var purchase = new Purchase();
                purchase.UserId = body.Purchase.UserId;
                purchase.Total = (double)body.Detail.Sum(x => x.Quantity * x.UnitPrice);
                purchase.CurrencyTypeEnum = body.Purchase.CurrencyTypeEnum;
                purchase.CreateAt = DateTime.Now;

                _servicePurchase.Post<PurchaseValidator>(purchase);

                foreach (var item in body.Detail)
                {
                    var detail = new PurchaseDetail();
                    detail.PurchaseId = purchase.Id;
                    detail.ProductId = item.ProductId;
                    detail.Quantity = item.Quantity;
                    detail.UnitPrice = item.UnitPrice;
                    _servicePurchaseDetail.Post<PurchaseDetailValidator>(detail);
                }

                return Ok("Se registró con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("purchases/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                var purchase = _servicePurchase.Get().Where(x => x.Id == id).FirstOrDefault();
                var detail = _servicePurchaseDetail.Get().Where(x => x.PurchaseId == id).ToList();
                var result = new PurchaseResponse()
                {
                    Purchase = purchase,
                    Detail = detail

                };

                if (purchase == null)
                    return NotFound(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPut("purchases")]
        public IActionResult Put([FromBody] object req)
        {
            try
            {
                PurchasePutRequest body = JsonConvert.DeserializeObject<PurchasePutRequest>(req.ToString());

                var purchase = _servicePurchase.Get().Where(x => x.Id == body.Purchase.Id).FirstOrDefault();
                purchase.UserId = body.Purchase.UserId;
                purchase.Total = (double)body.Detail.Sum(x => x.Quantity * x.UnitPrice);
                purchase.CurrencyTypeEnum = body.Purchase.CurrencyTypeEnum;

                _servicePurchase.Put<PurchaseValidator>(purchase);

                _servicePurchaseDetail.Delete(_servicePurchaseDetail.Get().Where(x => x.PurchaseId == purchase.Id).ToList());

                foreach (var item in body.Detail)
                {
                    var detail = new PurchaseDetail();
                    detail.PurchaseId = purchase.Id;
                    detail.ProductId = item.ProductId;
                    detail.Quantity = item.Quantity;
                    detail.UnitPrice = item.UnitPrice;
                    _servicePurchaseDetail.Post<PurchaseDetailValidator>(detail);
                }

                return Ok("Se actualizó con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("purchases/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var purchase = _servicePurchase.Get().Where(x => x.Id == id).FirstOrDefault();
                if (purchase == null)
                    return NotFound("Recurso no encontrado");

                var detail = _servicePurchaseDetail.Get().Where(x => x.PurchaseId == id).ToList();
                if (detail.Count > 0)
                    _servicePurchaseDetail.Delete(detail);

                _servicePurchase.Delete(id);

                return Ok("Se eliminó con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }


        [HttpGet("purchases/print/{id}")]
        public async Task<IActionResult> Print([FromRoute] int id)
        {
            var purchase = _purchaseService.Get().Where(x => x.Id == id).FirstOrDefault();
            if(purchase == null)
            {
                return NotFound("Recurso no encontrado");
            }

            var purchasePrintResponse = _purchaseService.GetPurchasePrint(id);

            var file = GeneratePDF.Instance.GeneratePurchaseFile(purchasePrintResponse);
            return File(file, "application/pdf");
        }
    }
}
