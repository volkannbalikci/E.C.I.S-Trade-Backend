namespace ETradeBackend.Application.Features.IndividualAdverts.Commands.Update;

public class UpdatedIndividualAdvertResponse
{
    public Guid IndividualAdvertId { get; set; }
    public Guid AdvertId { get; set; }

    public Guid AddressId { get; set; }
    public string CountryName { get; set; }
    public string CityName { get; set; }
    public string DistrictName { get; set; }
    public string NeighbourhoodName { get; set; }

    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public string BrandName { get; set; }
    public string CategoryName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Guid IndividualUserId { get; set; }
    public Guid IndividualUserUserId { get; set; }
    public string IndividualUserFirstName { get; set; }
    public string IndividualUserLastName { get; set; }
    public string IndividualUserUserName { get; set; }

    public decimal Price { get; set; }
    public bool Bargain { get; set; }
}