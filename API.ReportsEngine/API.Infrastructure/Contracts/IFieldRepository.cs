﻿using API.Domain.Entities;

namespace API.Infrastructure.Contracts
{
    public interface IFieldRepository
    {
        Task<Field?> GetFieldByIdAsync(int? id);
        //Task<Field?> GetFieldByValueAsync(int? entityId, string name)

        Task<IEnumerable<Field>> GetAllFieldsAsync();

        Task SaveFieldAsync(Field field, CancellationToken cancellationToken);

        Task UpdateFieldAsync(Field field, CancellationToken cancellationToken);

        Task DeleteFieldAsync(int id, CancellationToken cancellationToken);
    }
}
