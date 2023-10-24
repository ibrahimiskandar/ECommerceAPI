using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Features.Commands.Product.CreateProduct;
using ECommerceAPI.Application.Features.Commands.Product.RemoveProduct;
using ECommerceAPI.Application.Features.Commands.Product.UpdateProduct;
using ECommerceAPI.Application.Features.Commands.ProductImageFile.RemoveProductImage;
using ECommerceAPI.Application.Features.Commands.ProductImageFile.UploadProductImage;
using ECommerceAPI.Application.Features.Queries.Product.GetAllProducts;
using ECommerceAPI.Application.Features.Queries.Product.GetByIdProduct;
using ECommerceAPI.Application.Features.Queries.ProductImageFile.GetProductImages;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.Repositories.File;
using ECommerceAPI.Application.RequestParameters;
using ECommerceAPI.Application.ViewModels;
using ECommerceAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Principal;
using System.Text;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<ProductController>/5 
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest request)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductsQueryRequest request)
        {
            GetAllProductsQueryResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest request)
        {
            _ = await _mediator.Send(request);
            return StatusCode((int)HttpStatusCode.Created);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest request)
        {
            UpdateProductCommandResponse response = await _mediator.Send(request);
            return Ok();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest request)
        {
            _ = await _mediator.Send(request);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromForm] UploadProductImageCommandRequest request)
        {
            UploadProductImageCommandResponse response = await _mediator.Send(request);
            return Ok();
        }
        [HttpPost("[action]/{Id}")]
        public async Task<IActionResult> GetProductImages([FromRoute]GetProductImagesQueryRequest request)
        {

            List<GetProductImagesQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("[action]/{Id}/{ImageId}")]
        public async Task<IActionResult> DeleteProductImages([FromRoute]RemoveProductImageCommandRequest request)
        {

            RemoveProductImageCommandResponse response = await _mediator.Send(request);
            return Ok();

        }
    }

}
