using VirtualStore.Identity.Core.Configurations.DTOs;
using VirtualStore.Identity.Core.Configurations.Enums;

namespace VirtualStore.Identity.Core.Arguments;

public class LogOutArgument : ActionAccountDTO
{
    public string ActionType { get => ActionAccountType.LogOut.GetDescription(); }
}