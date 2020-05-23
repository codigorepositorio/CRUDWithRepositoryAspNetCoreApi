using CRUDWithRepositoryAspNetCoreApi.Models.EFCore;

namespace CRUDWithRepositoryAspNetCoreApi.Models
{
    public partial class Item:IEntity

    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
    }
}
