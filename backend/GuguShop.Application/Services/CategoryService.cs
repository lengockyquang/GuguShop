using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace GuguShop.Application.Services
{
    public class CategoryService: BaseEntityService<Category, CategoryDto, CategoryListDto, CategoryCreateDto, CategoryUpdateDto>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(IMapper mapper, ICategoryRepository baseRepository, ILogger<CategoryService> logger) : base(mapper, baseRepository)
        {
            _categoryRepository = baseRepository;
            _logger = logger;
        }

        public async Task<ICollection<CategoryComboDto>> GetComboDataAsync(CancellationToken cancellationToken = default)
        {
            var data = await _categoryRepository.GetCategoryCombo(cancellationToken);
            return data.Select(x => new CategoryComboDto()
            {
                Label = x.Name,
                Value = x.Id.ToString(),
            }).ToList();
        }
        public async Task InsertSampleData(int maxItem)
        {
            var categories = new List<Category>();
            for (var index = 0; index < maxItem; index++)
            {
                categories.Add(new Category()
                {
                    Code = "Category_"+Guid.NewGuid(),
                    Name = "Category "+Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
            }

            var watch = new Stopwatch();
            watch.Start();
            await _categoryRepository.CreateRange(categories, true);
            watch.Stop();
            _logger.LogInformation("Category create range time: "+watch.Elapsed.Seconds);
        }
    }
}