using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.CodeBook
{
    public struct AddressTypeValues
    {
        public const string MAILING_ADDRESS = "MAILING_ADDRESS";
        public const string PERNAMENT_ADDRESS = "PERNAMENT_ADDRESS";
        public const string REGISTERED_OFFICE_ADDRESS = "RegisteredOfficeAddress";
        public const string BILLING_ADDRESS = "BillingAddress";
    }
    [Table("Cb_AddressType")]
    public class AddressType : CodeBook
    {
    }
}
