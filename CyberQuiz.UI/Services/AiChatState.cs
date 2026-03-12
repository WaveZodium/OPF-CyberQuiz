using CyberQuiz.Shared.DTOs.AiChat;

namespace CyberQuiz.UI.Services;

public sealed class AiChatState
{
    public List<ChatMessageDto> History { get; } = [];

    public void Clear() => History.Clear();
}