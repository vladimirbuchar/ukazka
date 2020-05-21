using EduServices.CodeBookService;
using Model.Functions.User;
using Model.Tables.CodeBook;
using Model.Tables.Shared;
using System.Collections.Generic;
using System.Linq;
using WebModel.Shared;

namespace EduFacade.UserFacade.Convertors
{
    public class AddressConvertor : IAddressConvertor
    {
        private readonly ICodeBookService _codeBookService;
        private readonly HashSet<AddressType> _addressTypes = new HashSet<AddressType>();
        private readonly HashSet<Country> _countries = new HashSet<Country>();
        public AddressConvertor(ICodeBookService codeBookService)
        {
            _codeBookService = codeBookService;
            _addressTypes = _codeBookService.GetCodeBookItems<AddressType>();
            _countries = codeBookService.GetCodeBookItems<Country>();
        }
        public Address ConvertToBussinessEntity(AddressDto addressDto)
        {
            return new Address()
            {
                AddressType = _addressTypes.FirstOrDefault(x => x.Id == addressDto.AddressTypeId),
                City = addressDto.City,
                Country = _countries.First(x => x.Id == addressDto.CountryId),
                HouseNumber = addressDto.HouseNumber,
                Region = addressDto.Region,
                Street = addressDto.Street,
                ZipCode = addressDto.ZipCode
            };
        }

        public List<AddressDto> ConvertToWebModel(List<GetUserAddress> getUserAddress)
        {
            List<AddressDto> addr = new List<AddressDto>();
            foreach (GetUserAddress item in getUserAddress)
            {
                addr.Add(new AddressDto()
                {
                    AddressTypeId = item.AddressTypeId,
                    City = item.City,
                    CountryId = item.CountryId,
                    HouseNumber = item.HouseNumber,
                    Region = item.Region,
                    Street = item.Street,
                    ZipCode = item.ZipCode
                });
            }
            return addr;
        }
    }
}
