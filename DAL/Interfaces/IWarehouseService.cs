using DAL.Entity;

namespace DAL.Interfaces
{
    public interface IWarehouseService
    {
        Task<Warehouse> AddWarehouseAsync(Warehouse warehouse);
        Task<Warehouse> GetWarehouseByIdAsync(int id);
        Task<IEnumerable<Warehouse>> GetAllWarehousesAsync();
        Task<Warehouse> UpdateWarehouseAsync(Warehouse warehouse);
        Task<Warehouse> DeleteWarehouseAsync(int id);

        // WarehouseItem CRUD operations
        Task<WarehouseItem> AddWarehouseItemAsync(WarehouseItem warehouseItem);
        Task<WarehouseItem> GetWarehouseItemByIdAsync(int id);
        Task<IEnumerable<WarehouseItem>> GetWarehouseItemsByWarehouseIdAsync(int warehouseId);
        Task<WarehouseItem> UpdateWarehouseItemAsync(WarehouseItem warehouseItem);
        Task<WarehouseItem> DeleteWarehouseItemAsync(int id);
    }
}
