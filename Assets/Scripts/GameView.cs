using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    public Text coinsText, scoresText, maxScoreText;
    private PlayerController _controller;
    
    // Start is called before the first frame update
    void Start()
    {
        _controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.SharedInstance.currentGameState == GameState.InGame)
        {
            int coins = GameManager.SharedInstance.collectedObjectsCount;
            float score = _controller.GetTravelledDistance();
            float maxScore = PlayerPrefs.GetFloat("maxscore", 0f);
            
            coinsText.text = coins.ToString();
            scoresText.text = "Score: " + score.ToString("f1");
            maxScoreText.text = "Max: " + maxScore.ToString("f1");
        }
    }
}
