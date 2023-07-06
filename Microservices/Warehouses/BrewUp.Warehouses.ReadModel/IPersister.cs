﻿using BrewUp.Warehouses.ReadModel.Entities;

namespace BrewUp.Warehouses.ReadModel;

public interface IPersister
{
	Task<T> GetByIdAsync<T>(string id, CancellationToken cancellationToken) where T : EntityBase;
	Task InsertAsync<T>(T entity, CancellationToken cancellationToken) where T : EntityBase;
	Task UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : EntityBase;
	Task DeleteAsync<T>(T entity, CancellationToken cancellationToken) where T : EntityBase;
}