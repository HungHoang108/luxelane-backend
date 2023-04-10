using AutoMapper;
using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Repositories.BaseRepo;
using Luxelane.Repositories.ProductRepo;
using Luxelane.Services.BaseService;
using static Luxelane.DTOs.AddressDto;

namespace Luxelane.Services.AddressService
{
    public class AddressService : BaseService<Address, AddressCreateDto, AddressReadDto, AddressUpdateDto>, IAddressService
    {
        public AddressService(IMapper mapper, IBaseRepo<Address> repo, ILogger<BaseService<Address, AddressCreateDto, AddressReadDto, AddressUpdateDto>> logger) : base(mapper, repo, logger)
        {
        }
    }
}

