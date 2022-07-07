using AutoMapper;
using GuguShop.Application.Mapper;
using GuguShop.Application.Services;
using GuguShop.Domain.Base.Repositories;
using GuguShop.Domain.Entities;
using GuguShop.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit.Abstractions;

namespace GuguShop.Test;

public class GuguShopTest
{
    private readonly ITestOutputHelper _output;
    private readonly Mock<ICategoryRepository> mock = new Mock<ICategoryRepository>();
    private readonly Mock<IMapper> mockMapper = new Mock<IMapper>();
    private readonly Mock<ILogger<CategoryService>> mockLogger = new Mock<ILogger<CategoryService>>();
    public GuguShopTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task Should_Get_Category_By_Id()
    {
        var guidTest = Guid.NewGuid();
        mock.Setup(x=>x.Get(guidTest, null, CancellationToken.None))    
            .ReturnsAsync(new Category(){
                Id = guidTest,
                Code = "test",
                Name = "tests"
            }); 
        var repo = mock.Object;
        var myProfile = new CategoryProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        IMapper mapper = new Mapper(configuration);
        
        var categoryService = new CategoryService(mapper, repo, mockLogger.Object);
        var result = await categoryService.GetAsync(guidTest);
        Assert.NotNull(result);
    }
}