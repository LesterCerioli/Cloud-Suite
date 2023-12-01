using AutoMapper;
using CloudSuite.Modules.Cora.Application.Services.Implementations;
using CloudSuite.Modules.Cora.Application.ViewModels;
using CloudSuite.Modules.Cora.Domain.Contracts;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Tests.Services
{
	public class AccountAppServiceTests
	{
		[Fact]
		public async Task GetByAccountDigit_ShouldReturnMappedViewModel()
		{
			// Arrange
			var accountDigit = "123456";
			var accountRepositoryMock = new Mock<IAccountRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var accountAppService = new AccountAppService(
				accountRepositoryMock.Object,
				mediatorHandlerMock.Object,
				mapperMock.Object);

			var accountEntity = new AccountEntity(); // Replace with your actual entity
			var accountViewModel = new AccountViewModel(); // Replace with your actual view model

			accountRepositoryMock.Setup(repo => repo.GetByAccountDigit(accountDigit))
				.ReturnsAsync(accountEntity);

			mapperMock.Setup(mapper => mapper.Map<AccountViewModel>(accountEntity))
				.Returns(accountViewModel);

			// Act
			var result = await accountAppService.GetByAccountDigit(accountDigit);

			// Assert
			Assert.NotNull(result);
			Assert.Same(accountViewModel, result);

		}
	}
}
