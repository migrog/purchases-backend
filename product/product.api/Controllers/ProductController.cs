using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using product.api.Models;
using product.domain.core;
using product.domain.core.validators;
using product.domain.entities;
using product.domain.entities.interfaces.services;

namespace product.api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceBase<Product> _serviceProduct = new ServiceBase<Product>();

        [HttpPost("products")]
        public IActionResult Post([FromBody] object req)
        {
            try
            {
                ProductPostRequest body = JsonConvert.DeserializeObject<ProductPostRequest>(req.ToString());

                var product = new Product();
                product.Name = body.Name;
                product.UnitPrice = body.UnitPrice;
                product.CurrencyTypeEnum = body.CurrencyTypeEnum;

                _serviceProduct.Post<ProductValidator>(product);

                return Ok("Se registró con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("products/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                var product = _serviceProduct.Get().Where(x => x.Id == id).FirstOrDefault();

                if (product == null)
                    return NotFound("Recurso no encontrado");

                var result = new ProductGetResponse() { Id = product.Id, Name = product.Name, UnitPrice = product.UnitPrice, CurrencyTypeEnum = product.CurrencyTypeEnum, };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
        [HttpPut("products")]
        public IActionResult Put([FromBody] object req)
        {
            try
            {
                ProductPutRequest body = JsonConvert.DeserializeObject<ProductPutRequest>(req.ToString());

                var product = _serviceProduct.Get().Where(x => x.Id == body.Id).FirstOrDefault();
                product.Name = body.Name;
                product.UnitPrice = body.UnitPrice;
                product.CurrencyTypeEnum = body.CurrencyTypeEnum;

                _serviceProduct.Put<ProductValidator>(product);

                return Ok("Se actualizó con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("products/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var product = _serviceProduct.Get().Where(x => x.Id == id).FirstOrDefault();
                if (product == null)
                    return NotFound("Recurso no encontrado");

                _serviceProduct.Delete(id);

                return Ok("Se eliminó con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
    }
}
