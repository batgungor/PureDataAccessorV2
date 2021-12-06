using PureDataAccessor.Core.UnitOfWork;
using PureDataAccessor.Examples.EntityFrameworkCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PureDataAccessor.Examples.EntityFrameworkCore.Infrastructure
{
    public static class ServiceInitializer
    {
        public static void SeedData(IPDAUnitOfWork unitOfWork)
        {
            var categoryRepository = unitOfWork.GetRepository<CategoryEntity>();
            if (!categoryRepository.Get().Any())
            {
                var category = new CategoryEntity()
                {
                    Name = "Category1",
                    Products = new List<ProductEntity>()
                };
                var products = new List<ProductEntity>();
                for (int i = 1; i <= 10; i++)
                {
                    category.Products.Add(new ProductEntity()
                    {
                        Name = $"Product{i}",
                    });
                }
                categoryRepository.Add(category);

                category = new CategoryEntity()
                {
                    Name = "Category2",
                    Products = new List<ProductEntity>()
                };
                products = new List<ProductEntity>();
                for (int i = 11; i <= 20; i++)
                {
                    category.Products.Add(new ProductEntity()
                    {
                        Name = $"Product{i}",
                    });
                }

                categoryRepository.Add(category);
                unitOfWork.SaveChanges();
            }
        }
    }
}
