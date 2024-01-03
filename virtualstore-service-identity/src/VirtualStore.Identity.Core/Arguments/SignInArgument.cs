using VirtualStore.Identity.Core.Configurations.DTOs;
using VirtualStore.Identity.Core.Configurations.Enums;

namespace VirtualStore.Identity.Core.Arguments;

public class SignInArgument : ActionAccountDTO
{
    public string ActionType { get => ActionAccountType.SigIn.GetDescription(); }
}