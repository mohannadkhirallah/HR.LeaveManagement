using HR.LeaveManagement.Application.DTOs.Specifics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveRequestListRequest :IRequest<List<LeaveRequestListDto>>
    {

    }
}
