export class Address {
    constructor(countryId: string, region: string, city: string, street: string, houseNumber: string, zipCode: string, addressTypeId: string) {
        this.CountryId = countryId;
        this.Region = region;
        this.City = city;
        this.Street = street;
        this.HouseNumber = houseNumber;
        this.ZipCode = zipCode;
        this.AddressTypeId = addressTypeId;
    }

    public CountryId: string;
    public Region: string
    public City: string;
    public Street: string;
    public HouseNumber: string;
    public ZipCode: string;
    public AddressTypeId: string;
}