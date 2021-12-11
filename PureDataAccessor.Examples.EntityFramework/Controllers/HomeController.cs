using Microsoft.AspNetCore.Mvc;
using PureDataAccessor.EntityFrameworkCore.UnitOfWork;
using PureDataAccessor.Examples.EntityFrameworkCore.Entities;
using PureDataAccessor.Examples.EntityFrameworkCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace PureDataAccessor.Examples.EntityFrameworkCore.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly IPDAEFUnitOfWork _unitOfWork;
        public HomeController(IPDAEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<ProductOverViewModel> Get()
        {
            var productRepository = _unitOfWork.GetRepository<ProductEntity>();
            var products = productRepository.Get().Select(product => new ProductOverViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Category = new ProductOverViewModel.ProductCategoryModel()
                {
                    Id = product.CategoryId,
                    Name = product.Category.Name
                }
            }).ToList();
            return products;
        }

        [HttpGet("{id}")]
        public ProductOverViewModel Get(int id)
        {
            var productRepository = _unitOfWork.GetRepository<ProductEntity>();
            var products = productRepository.Get(q=> q.Id == id).Select(product => new ProductOverViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Category = new ProductOverViewModel.ProductCategoryModel()
                {
                    Id = product.CategoryId,
                    Name = product.Category.Name
                }
            }).FirstOrDefault();
            return products;
        }
    }
}
