using LLama.Common;
using LLama;
using Microsoft.Extensions.VectorData;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.IO.Pipelines;

namespace CashDB.Infrastructure;

public class ChatModel
{
    public ModelParams Parameters { get; set; }
    string modelPath = @""; 

    public ChatModel()
    {
        this.Parameters = new ModelParams(modelPath)
        {
            ContextSize = 1024, // The longest length of chat as memory.
            GpuLayerCount = 5 // How many layers to offload to GPU. Please adjust it according to your GPU memory.
        };
    }

    public async Task<bool> Run()
    {
        using var model = LLamaWeights.LoadFromFile(this.Parameters);
        using var context = model.CreateContext(this.Parameters);
        var executor = new InteractiveExecutor(context);

        // Add chat histories as prompt to tell AI how to act.
        var chatHistory = new ChatHistory();
        chatHistory.AddMessage(AuthorRole.System, "Hello.");

        ChatSession session = new(executor, chatHistory);

        InferenceParams inferenceParams = new InferenceParams()
        {
            MaxTokens = 128, // No more than 256 tokens should appear in answer. Remove it if antiprompt is enough for control.
            AntiPrompts = new List<string> { "User:" } // Stop generation once antiprompts appear.
        };

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("The chat session has started.\nUser: ");
        Console.ForegroundColor = ConsoleColor.Green;
        string userInput = Console.ReadLine() ?? "";

        while (userInput != "exit")
        {
            await foreach ( // Generate the response streamingly.
                var text
                in session.ChatAsync(
                    new ChatHistory.Message(AuthorRole.User, userInput),
                    inferenceParams))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(text);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            userInput = Console.ReadLine() ?? "";
        }

        return false;
    }
}