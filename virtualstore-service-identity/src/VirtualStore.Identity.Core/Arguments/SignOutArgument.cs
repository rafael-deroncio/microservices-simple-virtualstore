using VirtualStore.Identity.Core.Configurations.DTOs;
using VirtualStore.Identity.Core.Configurations.Enums;

namespace VirtualStore.Identity.Core.Arguments;

public class SignOutArgument : ActionAccountDTO
{
    public string ActionType { get => ActionAccountType.SignOut.GetDescription(); }
}