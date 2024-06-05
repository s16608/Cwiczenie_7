using Microsoft.AspNetCore.Mvc;
using zad6_apbd.DbService.Interfaces;
using zad6_apbd.DTO;

namespace zad6_apbd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IDbService _dbService;

        public WarehousesController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost]
        public async Task<IActionResult> CompleteOrder(CreateProductDto dto)
        {
            var productExists = await _dbService.ProductExists(dto.IdProduct);

            if (productExists is false)
                return BadRequest("Produkt nie istnieje!");

            var warehouseExists = await _dbService.WarehouseExists(dto.IdWarehouse);

            if (warehouseExists is false)
                return BadRequest("Magazyn nie istnieje!");

            var orderId = await _dbService.GetOrderId(dto.IdProduct, dto.Amount, dto.CreatedAt);

            if (orderId == null)
                return BadRequest("Brak zamówienia w bazie!");

            var orderIsCompleted = await _dbService.OrderIsCompleted(orderId.Value);

            if (orderIsCompleted)
                return BadRequest("Zamówienie zostało zrealizowane!");

            var insertedId = await _dbService.CompleteOrder(dto, orderId.Value);

            return CreatedAtAction(null, new { Id = insertedId });
        }
    }
}