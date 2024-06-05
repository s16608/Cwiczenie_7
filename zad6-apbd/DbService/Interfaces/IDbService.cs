using zad6_apbd.DTO;

namespace zad6_apbd.DbService.Interfaces
{
    public interface IDbService
    {
        Task<bool> ProductExists(int id);

        Task<bool> WarehouseExists(int id);

        Task<int?> GetOrderId(int idProduct, int amount, DateTime date);

        Task<bool> OrderIsCompleted(int idOrder);

        Task<int> CompleteOrder(CreateProductDto dto, int idOrder);
    }
}