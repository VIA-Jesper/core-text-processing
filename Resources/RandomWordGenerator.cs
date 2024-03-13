using System;
using System.Text;

namespace DistinctWebAPI.Utils;

public class RandomWordGenerator
{
    private static Random random = new Random();
    private static string[] punctuationMarks = { ".", ",", "!", "?", ";", ":" };

    public static string GenerateRandomWordsInKB(int sizeInKB, int batchSize)
    {
        long totalBytes = sizeInKB * 1024L;
        StringBuilder sb = new StringBuilder();

        while (Encoding.UTF8.GetByteCount(sb.ToString()) < totalBytes)
        {
            sb.Append(GenerateBatch(batchSize));
        }

        return sb.ToString().Trim();
    }

    private static string GenerateBatch(int batchSize)
    {
        StringBuilder batchBuilder = new StringBuilder();

        for (int i = 0; i < batchSize; i++)
        {
            string word = GenerateRandomWord(random.Next(3, 10)); // Generate random word with length between 3 to 10 characters
            bool addPunctuation = random.Next(4) == 0; // 1 in 4 chance of adding punctuation
            if (addPunctuation)
            {
                word += punctuationMarks[random.Next(punctuationMarks.Length)];
            }
            batchBuilder.Append(word);
            batchBuilder.Append(" ");
        }

        return batchBuilder.ToString();
    }

    private static string GenerateRandomWord(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyz";
        char[] word = new char[length];
        for (int i = 0; i < length; i++)
        {
            word[i] = chars[random.Next(chars.Length)];
        }
        return new string(word);
    }

    public static string GenerateRandomWordsInMB(int sizeInMB)
    {
        return GenerateRandomWordsInKB(sizeInMB * 1024, 1024);
    }

}