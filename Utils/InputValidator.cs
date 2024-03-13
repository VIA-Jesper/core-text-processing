namespace DistinctWebAPI.Utils;

public static class InputValidator
{
    public static ICollection<string> CleanInput(string input)
    {
        char[] arr = input.ToCharArray();
        input = new string(Array.FindAll(arr, c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '-'));
        return input.ToLower().Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
    }
}