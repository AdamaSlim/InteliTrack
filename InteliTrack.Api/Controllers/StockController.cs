using InteliTrack.Application.DTOs.Stocks;
using InteliTrack.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace InteliTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    private readonly IStockService _stockService;

    public StockController(
        IStockService stockService)
    {
        _stockService = stockService;
    }


    [HttpPost("add")]
    public async Task<IActionResult> AddStock(
        AddStockDto dto)
    {
        var result =
            await _stockService.AddStockAsync(dto);


        if (!result.Success)
        {
            return BadRequest(result);
        }


        return Ok(result);
    }



    [HttpPost("remove")]
    public async Task<IActionResult> RemoveStock(
        RemoveStockDto dto)
    {
        var result =
            await _stockService.RemoveStockAsync(dto);


        if (!result.Success)
        {
            return BadRequest(result);
        }


        return Ok(result);
    }
}