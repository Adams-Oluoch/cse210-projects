public class PromptGenerator
{
    private List<string> _prompts = new List<string>();

    public PromptGenerator()
    {
        _prompts.Add("What was the best part of your day?");
        _prompts.Add("What are you grateful for today?");
        _prompts.Add("What is something you learned today?");
        _prompts.Add("What is a goal you have for tomorrow?");
        _prompts.Add("What is something that made you smile today?");
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}