using BrewUp.Sagas.Warehouses.SharedKernel.DomainIds;

namespace BrewUp.Sagas.Warehouses.SharedKernel.Dtos;

public record OrderLine(BeerId BeerId, BeerName BeerName, Quantity Quantity, Price Price);