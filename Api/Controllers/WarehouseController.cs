using DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        private readonly ILogger<WarehouseController> _logger;

        private readonly string _errorMessage = "An error occurred while processing your request";

        public WarehouseController(IWarehouseService warehouseService, ILogger<WarehouseController> logger)
        {
            _warehouseService = warehouseService;
            _logger = logger;
        }

        // Warehouse CRUD operations

        [HttpPost("add-warehouse")]
        public async Task<IActionResult> AddWarehouse([FromBody] Warehouse warehouse)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _warehouseService.AddWarehouseAsync(warehouse);
                return CreatedAtAction(nameof(GetWarehouse), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding warehouse");
                return StatusCode(500, _errorMessage);
            }
        }

        [HttpGet("get-warehouse/{id}")]
        public async Task<IActionResult> GetWarehouse(int id)
        {
            try
            {
                var result = await _warehouseService.GetWarehouseByIdAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting warehouse");
                return StatusCode(500, _errorMessage);
            }
        }

        [HttpGet("get-all-warehouses")]
        public async Task<IActionResult> GetAllWarehouses()
        {
            try
            {
                var result = await _warehouseService.GetAllWarehousesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all warehouses");
                return StatusCode(500, _errorMessage);
            }
        }

        [HttpPut("update-warehouse/{id}")]
        public async Task<IActionResult> UpdateWarehouse(int id, [FromBody] Warehouse warehouse)
        {
            try
            {
                if (id != warehouse.Id)
                {
                    return BadRequest("Warehouse ID mismatch");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedWarehouse = await _warehouseService.UpdateWarehouseAsync(warehouse);
                return Ok(updatedWarehouse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating warehouse");
                return StatusCode(500, _errorMessage);
            }
        }

        [HttpDelete("delete-warehouse/{id}")]
        public async Task<IActionResult> DeleteWarehouse(int id)
        {
            try
            {
                var deletedWarehouse = await _warehouseService.DeleteWarehouseAsync(id);
                if (deletedWarehouse == null)
                {
                    return NotFound();
                }
                return Ok(deletedWarehouse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting warehouse");
                return StatusCode(500, _errorMessage);
            }
        }

        // WarehouseItem CRUD operations

        [HttpPost("add-warehouse-item")]
        public async Task<IActionResult> AddWarehouseItem([FromBody] WarehouseItem warehouseItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _warehouseService.AddWarehouseItemAsync(warehouseItem);
                return CreatedAtAction(nameof(GetWarehouseItem), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding warehouse item");
                return StatusCode(500, _errorMessage);
            }
        }

        [HttpGet("get-warehouse-item/{id}")]
        public async Task<IActionResult> GetWarehouseItem(int id)
        {
            try
            {
                var result = await _warehouseService.GetWarehouseItemByIdAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting warehouse item");
                return StatusCode(500, _errorMessage);
            }
        }

        [HttpGet("get-warehouse-items/{warehouseId}")]
        public async Task<IActionResult> GetWarehouseItemsByWarehouseId(int warehouseId)
        {
            try
            {
                var result = await _warehouseService.GetWarehouseItemsByWarehouseIdAsync(warehouseId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting warehouse items");
                return StatusCode(500, _errorMessage);
            }
        }

        [HttpPut("update-warehouse-item/{id}")]
        public async Task<IActionResult> UpdateWarehouseItem(int id, [FromBody] WarehouseItem warehouseItem)
        {
            try
            {
                if (id != warehouseItem.Id)
                {
                    return BadRequest("Warehouse Item ID mismatch");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedWarehouseItem = await _warehouseService.UpdateWarehouseItemAsync(warehouseItem);
                return Ok(updatedWarehouseItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating warehouse item");
                return StatusCode(500, _errorMessage);
            }
        }

        [HttpDelete("delete-warehouse-item/{id}")]
        public async Task<IActionResult> DeleteWarehouseItem(int id)
        {
            try
            {
                var deletedWarehouseItem = await _warehouseService.DeleteWarehouseItemAsync(id);
                if (deletedWarehouseItem == null)
                {
                    return NotFound();
                }
                return Ok(deletedWarehouseItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting warehouse item");
                return StatusCode(500, _errorMessage);
            }
        }
    }
}
