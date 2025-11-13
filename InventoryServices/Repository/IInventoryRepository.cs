using InventoryServices.Models;

namespace InventoryServices.Repository
{
    public interface IInventoryRepository
    {
        Task<Inventory> AddInventory(Inventory inventory);
        Task<Inventory> UpdateInventory(Inventory inventory);
        Task<bool> DeleteInventory(int id);
        Task<Inventory> GetInventoryById(int id);
        Task<IEnumerable<Inventory>> GetAllInventories();
    }
}
