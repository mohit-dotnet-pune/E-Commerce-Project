using InventoryServices.Data;
using InventoryServices.Models;

namespace InventoryServices.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AppDbContext _db;
        public InventoryRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Inventory> AddInventory(Inventory inventory)
        {
            _db.inventories.Add(inventory);
            await _db.SaveChangesAsync();
            return inventory;
        }

        public async Task<bool> DeleteInventory(int id)
        {
            var invent = await GetInventoryById(id);
            if(invent != null) 
            {
                _db.inventories.Remove(invent);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Inventory>> GetAllInventories()
        {
            return _db.inventories.ToList();
        }

        public async Task<Inventory> GetInventoryById(int id)
        {
            return await _db.inventories.FindAsync(id);
        }

        public async Task<Inventory> UpdateInventory(Inventory inventory)
        {
            var invent = await GetInventoryById(inventory.InventoryId);
            if (invent != null)
            {
                invent.ProductId = inventory.ProductId;
                invent.StockQuantity = inventory.StockQuantity;

                await _db.SaveChangesAsync();
                return inventory;
            }
            return null;
        }
    }
}
