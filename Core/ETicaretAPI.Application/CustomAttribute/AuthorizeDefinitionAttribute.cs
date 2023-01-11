using ETicaretAPI.Application.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ETicaretAPI.Application.CustomAttribute;

public class AuthorizeDefinitionAttribute : Attribute
{
    public string Menu { get; set; }
    public string Definiton { get; set; }
    public ActionType ActionType { get; set; }
}