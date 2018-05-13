using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStats
{
    private static int turns = 0;

    private static List<string> birds = new List<string> {
        "bluejay",
        "cardinal",
        "sparrow",
        "chickadee",
        "crow",
        "goldfinch",
        "robin"
    };

    private static Dictionary<string, bool> found = new Dictionary<string, bool>() {
        { "bluejay", false },
        { "cardinal", false },
        { "sparrow", false },
        { "chickadee", false },
        { "crow", false },
        { "goldfinch", false },
        { "robin", false }
    };

    public static void SetFound(string birdName)
    {
        found[birdName] = true;
    }

    public static bool Next()
    {
        if (turns == 6)
        {
            return false;
        } else
        {
            turns += 1;
            return true;
        }
    }

    public static string NextBird()
    {
        return birds[turns];
    }
        
    public static bool Won()
    {
        return found[birds[turns]];
    }

    public static Dictionary<string, bool> GetResults()
    {
        return found;
    }
}
