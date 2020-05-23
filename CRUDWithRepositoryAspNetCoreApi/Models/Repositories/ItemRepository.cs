using CRUDWithRepositoryAspNetCoreApi.Models.EFCore;
using System.Collections.Generic;
using System.Linq;


namespace CRUDWithRepositoryAspNetCoreApi.Models.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IitemRepository
    {
        

        public ItemRepository(DatabaseContext dbcontext) : base(dbcontext)
        {
           
        }

        public  List<Item> Search(string keyword)
        {
            return  GetAll().Where(i => i.Name.Contains(keyword.Trim().ToLower())).ToList();
        }

        public List<Item> Search(decimal min, decimal max)
        {
            return  GetAll().Where(i=>i.Price >= min && i.Price<= max).ToList();
        }

    }
}
