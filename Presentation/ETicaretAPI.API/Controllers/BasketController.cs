using ETicaretAPI.API.Controllers.Base;
using ETicaretAPI.Application.Consts;
using ETicaretAPI.Application.CustomAttribute;
using ETicaretAPI.Application.Enums;
using ETicaretAPI.Application.Features.Commads.Basket.CreateBasketItem;
using ETicaretAPI.Application.Features.Commads.Basket.DeleteBasketItem;
using ETicaretAPI.Application.Features.Commads.Basket.UpdateBasketItem;
using ETicaretAPI.Application.Features.Queries.Basket.GetAllBasketItem;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ETicaretAPI.API.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
public class BasketController : BaseController
{
    private readonly IMediator _mediator;

    public BasketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AuthorizeDefinition(Menu = AuohorizeDefinitionCustom.Baskets, ActionType = ActionType.Reading, Definiton = "Get basket items")]
    public async Task<IActionResult> GetBasketItems([FromQuery] GetAllBasketItemQueryRequest getAllBasketItemQueryRequest)
    {
       List<GetAllBasketItemQueryResponse> response = await _mediator.Send(getAllBasketItemQueryRequest);
       return Ok(response);
    }

    [HttpPost]
    [AuthorizeDefinition(Menu = AuohorizeDefinitionCustom.Baskets, ActionType = ActionType.Writing, Definiton = "Add item to basket")]
    public async Task<IActionResult> AddBasketItem(CreateBasketItemCommandRequest createBasketItemCommandRequest)
    {
        CreateBasketItemCommandResponse response = await _mediator.Send(createBasketItemCommandRequest);
        return Ok(response);
    }

    [HttpPut]
    [AuthorizeDefinition(Menu = AuohorizeDefinitionCustom.Baskets, ActionType = ActionType.Updating, Definiton = "Update baskets ıtems")]
    public async Task<IActionResult> UpdateBasketItem(UpdateBasketItemCommandRequest updateBasketItemCommandRequest)
    {
        UpdateBasketItemCommandResponse response = await _mediator.Send(updateBasketItemCommandRequest);
        return Ok(response);
    }

    [HttpDelete("{BasketItemId}")]
    [AuthorizeDefinition(Menu = AuohorizeDefinitionCustom.Baskets, ActionType = ActionType.Deleting, Definiton = "Delete baskets items")]
    public async Task<IActionResult> DeleteBasketItem([FromRoute] DeleteBasketItemCommandRequest deleteBasketItemCommandRequest)
    {
        DeleteBasketItemCommandResponse response = await _mediator.Send(deleteBasketItemCommandRequest);
        return Ok(response);
    }
}