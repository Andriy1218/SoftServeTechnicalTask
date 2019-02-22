using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SoftServerTechnicalTask.Domain.BuildingBlocks;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServerTechnicalTask.Domain.Abstractions
{
    public interface IChildEntityRepository<T> : IGenericRepository<T>
    {
        Task<T> GetByNameAndParentId(string name, int parentId);
    }
}
