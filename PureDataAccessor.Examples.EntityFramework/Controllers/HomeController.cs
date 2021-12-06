using Microsoft.AspNetCore.Mvc;
using PureDataAccessor.Core.UnitOfWork;
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
        private readonly IPDAUnitOfWork _unitOfWork;
        public HomeController(IPDAUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<ProductOverViewModel> Index()
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
    }
}
