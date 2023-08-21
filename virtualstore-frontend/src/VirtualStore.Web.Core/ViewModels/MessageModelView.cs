using System.Text.Json;
using VirtualStore.Web.Core.Configurations.Enum;

namespace VirtualStore.Web.Core.ViewModels;

public class MessageModelView
{
    public MessageType Type { get; set; }

    public string Message { get; set; }

    public static string Serialize(string message, MessageType type)
        => JsonSerializer.Serialize(new { Message = message, Type = type});

    public static MessageModelView Deserialize(string message)
        => JsonSerializer.Deserialize<MessageModelView>(message);
}