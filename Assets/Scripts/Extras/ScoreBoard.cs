using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    private Text ScoreText;

    //Register with Game
    void Start () {
        Game.scoreboard = this;
        ScoreText = GetComponent<Text>();
    }
	
    public void ShowScore(int score)
    {
        ScoreText.text = "Score: " + score;
    }
}
