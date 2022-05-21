using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GuguShop.Application.Dto;
using GuguShop.Application.Interfaces;
using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;

namespace GuguShop.Application.Services
{
    public class ProductService: BaseEntityService<Product, ProductDto, ProductListDto,ProductCreateDto, ProductUpdateDto>,IProductService
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;
        private readonly IProductRepository _productRepository;
        public ProductService(IMapper mapper, IProductRepository baseRepository, ITagRepository tagRepository) : base(mapper, baseRepository)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
            _productRepository = baseRepository;
        }

        public override async Task<ProductDto> CreateAsync(ProductCreateDto createDto)
        {
            var tags = await _tagRepository.GetWithSpecification(x => createDto.TagIds.Contains(x.Id));
            var createEntity = _mapper.Map<ProductCreateDto, Product>(createDto);
            var product = await _productRepository.Create(createEntity, true);
            product.Tags = tags.ToList();
            await _productRepository.Update(product, true);
            return _mapper.Map<Product, ProductDto>(product);
        }
    }
}