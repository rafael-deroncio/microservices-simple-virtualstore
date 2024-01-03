using VirtualStore.Identity.Core.Configurations.DTOs;
using VirtualStore.Identity.Core.Configurations.Enums;

namespace VirtualStore.Identity.Core.Arguments;

public class LogInArgument : ActionAccountDTO
{
    public string ActionType { get => ActionAccountType.LogIn.GetDescription(); } 
}