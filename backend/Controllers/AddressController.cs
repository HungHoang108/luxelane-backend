using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Services.AddressService;
using static Luxelane.DTOs.AddressDto;

namespace Luxelane.Controllers
{
    public class AddressController : BaseController<Address, AddressCreateDto, AddressReadDto, AddressUpdateDto>
    {
        public AddressController(IAddressService service) : base(service)
        {
        }
    }
}