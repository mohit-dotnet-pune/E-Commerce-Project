using InventoryServices.Data;
using InventoryServices.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Inventory> ReduceStock(int productId, int quantity)
        {
            var inventory = await _db.inventories.FindAsync(productId);
            if (inventory == null)
                throw new Exception("Inventory not found");

            if (inventory.StockQuantity < quantity)
                throw new Exception("Inventory is lesser than required");

            inventory.StockQuantity -= quantity;

            await _db.SaveChangesAsync();
            return inventory;
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
