using ETicaretAPI.API.Controllers.Base;
using ETicaretAPI.Application.Consts;
using ETicaretAPI.Application.CustomAttribute;
using ETicaretAPI.Application.Enums;
using ETicaretAPI.Application.Features.Commads.Order.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
public class OrderController : BaseController
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AuthorizeDefinition(Menu = AuohorizeDefinitionCustom.Orders, ActionType = ActionType.Writing, Definiton = "Create Orders")]
    public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest createOrderCommandRequest)
    {
         CreateOrderCommandResponse response = await _mediator.Send(createOrderCommandRequest);
         return Ok(response);
    }
}