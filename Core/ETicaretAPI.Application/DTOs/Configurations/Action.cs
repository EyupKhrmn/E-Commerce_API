using ETicaretAPI.Application.Enums;

namespace ETicaretAPI.Application.DTOs.Configurations;

public class Action
{
    public ActionType ActionType { get; set; }
    public string HttpType { get; set; }
    public string Definition { get; set; }
}