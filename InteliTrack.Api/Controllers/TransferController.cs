using InteliTrack.Application.DTOs.Transfers;
using InteliTrack.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace InteliTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransferController : ControllerBase
{
    private readonly ITransferService _transferService;


    public TransferController(
        ITransferService transferService)
    {
        _transferService = transferService;
    }



    [HttpPost("create")]
    public async Task<IActionResult> CreateTransfer(
        CreateTransferDto dto)
    {
        var result =
            await _transferService.CreateTransferAsync(dto);


        if (!result.Success)
        {
            return BadRequest(result);
        }


        return Ok(result);
    }



    [HttpPost("{transferId}/start")]
    public async Task<IActionResult> StartTransfer(
        int transferId,
        int employeeId)
    {
        var result =
            await _transferService.StartTransferAsync(
                transferId,
                employeeId);


        if (!result.Success)
        {
            return BadRequest(result);
        }


        return Ok(result);
    }





    [HttpPost("{transferId}/complete")]
    public async Task<IActionResult> CompleteTransfer(
        int transferId,
        int employeeId)
    {
        var result =
            await _transferService.CompleteTransferAsync(
                transferId,
                employeeId);


        if (!result.Success)
        {
            return BadRequest(result);
        }


        return Ok(result);
    }

    [HttpPost("{transferId}/cancel")]
    public async Task<IActionResult> CancelTransfer(
        int transferId,
        int employeeId)
    {
        var result =
            await _transferService.CancelTransferAsync(
                transferId,
                employeeId);


        if (!result.Success)
        {
            return BadRequest(result);
        }


        return Ok(result);
    }
}