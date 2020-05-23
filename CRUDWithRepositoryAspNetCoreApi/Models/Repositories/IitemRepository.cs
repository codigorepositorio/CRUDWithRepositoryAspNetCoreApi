using CRUDWithRepositoryAspNetCoreApi.Models.EFCore;
using System.Collections.Generic;

namespace CRUDWithRepositoryAspNetCoreApi.Models.Repositories
{
    public interface IitemRepository: IGenericRepository<Item>
    {

        public  List<Item> Search(string keyword);

        public List<Item> Search(decimal min,decimal max);

    }
}
