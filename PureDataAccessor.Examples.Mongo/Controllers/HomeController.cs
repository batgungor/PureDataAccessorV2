using Microsoft.AspNetCore.Mvc;
using PureDataAccessor.Examples.Mongo.Entities;
using PureDataAccessor.Examples.Mongo.Models;
using PureDataAccessor.Mongo.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace PureDataAccessor.Examples.Mongo.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly IPDAMongoUnitOfWork _unitOfWork;
        public HomeController(IPDAMongoUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<ProductOverViewModel> Get()
        {
            var productRepository = _unitOfWork.GetRepository<ProductEntity>();
            productRepository.Add(new ProductEntity()
            { 
                Name = "test3"
            });
            _unitOfWork.SaveChanges();
            var products = productRepository.Get().Select(product => new ProductOverViewModel()
            {
                Id = product.Id,
                Name = product.Name,
            }).ToList();
            return products;
        }
    }
}
