using BrewUp.Warehouses.SharedKernel.DomainIds;

namespace BrewUp.Warehouses.SharedKernel.Dtos;

public record OrderLine(BeerId BeerId, BeerName BeerName, Quantity Quantity, Price Price);