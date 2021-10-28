using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator :AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;



        public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository )
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(v => v.NumberOfDays)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(0).WithMessage("PropertyName} must be greater than 0");

            RuleFor(v=>v.Period)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0")
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("PropertyName} must be after {ComparisonValue}");

            RuleFor(v => v.LeaveTypeId)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExisit = await _leaveTypeRepository.Exists(id);
                    return leaveTypeExisit;

                }).WithMessage("{PropertyName} does not exist");
        }
    }
}
