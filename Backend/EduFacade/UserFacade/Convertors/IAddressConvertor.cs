using Model.Functions.User;
using Model.Tables.Shared;
using System.Collections.Generic;
using WebModel.Shared;

namespace EduFacade.UserFacade.Convertors
{
    public interface IAddressConvertor
    {
        Address ConvertToBussinessEntity(AddressDto addressDto);
        List<AddressDto> ConvertToWebModel(List<GetUserAddress> getUserAddress);

    }
}
