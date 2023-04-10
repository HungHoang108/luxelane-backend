using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.Configuration;
using Moq;
using Luxelane.Repositories.BaseRepo;
using Luxelane.Models;
using Luxelane.Db;
using Xunit;
using Luxelane.Repositories.AddressRepo;
using FluentAssertions;

namespace backend.Test
{

    public class BaseRepoTests
    {
        public interface IAddressRepo
        {
            Task<Address> GetAsync(int id);
        };

        [Fact]
        public async void AddressRepo_GetAddress_ReturnsAddress()
        {
            //Arrange
            var mockRepo = new Mock<IAddressRepo>();
            mockRepo.Setup(repo => repo.GetAsync(1))
                .ReturnsAsync(new Address() { Id = 1, City = "c1", PostalCode = 1212, Country = "kasdf", UserId = 2 });
            var AddressRepo = mockRepo.Object;

            //Act
            var result = await AddressRepo.GetAsync(1);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Address>();
        }
    }

}