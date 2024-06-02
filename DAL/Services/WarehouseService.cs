using DAL.Data;
using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services
{
    public sealed class WarehouseService:IWarehouseService
    {
        private readonly DataContext _context;

        public WarehouseService(DataContext context)
        {
            _context = context;
        }

        // Warehouse CRUD operations

        // Create Warehouse
        public async Task<Warehouse> AddWarehouseAsync(Warehouse warehouse)
        {
            _context.Warehouses.Add(warehouse);
            await _context.SaveChangesAsync();
            return warehouse;
        }

        // Read Warehouse by Id
        public async Task<Warehouse> GetWarehouseByIdAsync(int id)
        {
            return await _context.Warehouses
                                 .Include(w => w.Country)
                                 .Include(w => w.WarehouseItems)
                                 .FirstOrDefaultAsync(w => w.Id == id);
        }

        // Read all Warehouses
        public async Task<IEnumerable<Warehouse>> GetAllWarehousesAsync()
        {
            return await _context.Warehouses
                                 .Include(w => w.Country)
                                 .Include(w => w.WarehouseItems)
                                 .ToListAsync();
        }

        // Update Warehouse
        public async Task<Warehouse> UpdateWarehouseAsync(Warehouse warehouse)
        {
            _context.Entry(warehouse).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return warehouse;
        }

        // Delete Warehouse
        public async Task<Warehouse> DeleteWarehouseAsync(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse != null)
            {
                _context.Warehouses.Remove(warehouse);
                await _context.SaveChangesAsync();
            }
            return warehouse;
        }

        // WarehouseItem CRUD operations

        // Create WarehouseItem
        public async Task<WarehouseItem> AddWarehouseItemAsync(WarehouseItem warehouseItem)
        {
            _context.WarehouseItems.Add(warehouseItem);
            await _context.SaveChangesAsync();
            return warehouseItem;
        }

        // Read WarehouseItem by Id
        public async Task<WarehouseItem> GetWarehouseItemByIdAsync(int id)
        {
            return await _context.WarehouseItems
                                 .Include(wi => wi.Warehouse)
                                 .FirstOrDefaultAsync(wi => wi.Id == id);
        }

        // Read all WarehouseItems by WarehouseId
        public async Task<IEnumerable<WarehouseItem>> GetWarehouseItemsByWarehouseIdAsync(int warehouseId)
        {
            return await _context.WarehouseItems
                                 .Where(wi => wi.WarehouseId == warehouseId)
                                 .ToListAsync();
        }

        // Update WarehouseItem
        public async Task<WarehouseItem> UpdateWarehouseItemAsync(WarehouseItem warehouseItem)
        {
            _context.Entry(warehouseItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return warehouseItem;
        }

        // Delete WarehouseItem
        public async Task<WarehouseItem> DeleteWarehouseItemAsync(int id)
        {
            var warehouseItem = await _context.WarehouseItems.FindAsync(id);
            if (warehouseItem != null)
            {
                _context.WarehouseItems.Remove(warehouseItem);
                await _context.SaveChangesAsync();
            }
            return warehouseItem;
        }
    }
}
