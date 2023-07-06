namespace BrewUp.Sagas.Warehouses.SharedKernel.Dtos;

public record OrderLineJson(string BeerId, string BeerName, Quantity Quantity, Price Price);