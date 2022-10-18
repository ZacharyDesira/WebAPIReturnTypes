using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIReturnTypes.API.Models;

namespace WebAPIReturnTypes.API.Controllers
{
    [RoutePrefix("Products")]
    public class ProductsController : ApiController
    {
        [HttpPost]
        [Route("Void")]
        public void SaveProduct()
        {
            try
            {
                CreateProduct();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        [Route("Void/Http")]
        public IHttpActionResult SaveProductHttp()
        {
            try
            {
                CreateProduct();
                return Ok();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("HttpResponseMessage")]
        public HttpResponseMessage GetProductUsingHttpResponseMessage()
        {
            Product product = GetProduct();
            HttpResponseMessage response;
            if (product == null)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, product);
            }
            return response;
        }

        [HttpGet]
        [Route("IHttpActionResult")]
        public IHttpActionResult GetProductUsingIHttpActionResult()
        {
            Product product = GetProduct();
            if(product == null)
            {
                return NotFound();
            }
            
            return Ok(product);
        }

        [HttpGet]
        [Route("Model")]
        public Product GetProductUsingModel()
        {
            Product product = GetProduct();
            
            if(product == null)
            {
                return null;
            }
            return product;
        }

        [HttpGet]
        [Route("Model/Null")]
        public Product GetNullProductUsingModel()
        {
            Product product = null;

            if (product == null)
            {
                return null;
            }
            return product;
        }

        private Product GetProduct()
        {
            Product product = new Product()
            {
                Id = 1,
                Name = "Bread"
            };
            return product;
        }

        private void CreateProduct()
        {
            throw new Exception();
            // Code to create product
        }
    }
}
