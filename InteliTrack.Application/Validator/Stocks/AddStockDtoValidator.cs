using FluentValidation;
using InteliTrack.Application.DTOs.Stocks;

namespace InteliTrack.Application.Validators.Stocks;

public class AddStockDtoValidator : AbstractValidator<AddStockDto>
{
    public AddStockDtoValidator()
    {
        RuleFor(x => x.StockId)
            .GreaterThan(0)
            .WithMessage("StockId must be greater than 0.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0.");

        RuleFor(x => x.EmployeeId)
            .GreaterThan(0)
            .WithMessage("EmployeeId must be greater than 0.");

        RuleFor(x => x.Reason)
            .NotEmpty()
            .WithMessage("Reason is required.")
            .MaximumLength(200)
            .WithMessage("Reason cannot exceed 200 characters.");
    }
}