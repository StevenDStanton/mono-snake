using System;
using System.Collections.Generic;
using System.Linq;
using snake.FileManagement;

public class ScoreManager : FileHandler
{
    private const int MaxScores = 10;

    public ScoreManager(string filePath) : base(filePath)
    {
        Initialize();
    }

    private void Initialize()
    {
        CreateFileIfNotExists();
    }

    public List<Tuple<string, int>> GetTopScores()
    {
        var scores = new List<Tuple<string, int>>();

        foreach (var line in ReadFromFile().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
        {
            var parts = line.Split(',');

            if (parts.Length == 2)
            {
                string initials = parts[0];
                if (int.TryParse(parts[1], out int score))
                {
                    scores.Add(new Tuple<string, int>(initials, score));
                }
            }
        }

        return scores.OrderByDescending(s => s.Item2).Take(MaxScores).ToList();
    }

    public void AddScore(string initials, int score)
    {
        var scores = GetTopScores();
        scores.Add(new Tuple<string, int>(initials, score));
        scores = scores.OrderByDescending(s => s.Item2).Take(MaxScores).ToList();

        // Now, write updated scores back to the file
        WriteToFile(string.Join("\n", scores.Select(s => $"{s.Item1},{s.Item2}")));
    }
}
