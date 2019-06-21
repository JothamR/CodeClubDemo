using UnityEngine;

public static class Game {

    public static GameObject Player = null;
    private static int score = 0;
    public static ScoreBoard scoreboard = null;

    public static void AddScore(int amount)
    {
        score += amount;
        if (scoreboard!=null) scoreboard.ShowScore(score);
    }
}
