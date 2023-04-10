

using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Services.BaseService;
using static Luxelane.DTOs.AddressDto;

namespace Luxelane.Services.AddressService
{
    public interface IAddressService : IBaseService<Address, AddressCreateDto, AddressReadDto, AddressUpdateDto>
    {
        
    }
}