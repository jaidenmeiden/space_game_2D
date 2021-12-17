using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    public Text coinsText, scoresText, maxScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.SharedInstance.currentGameState == GameState.InGame)
        {
            int coins = GameManager.SharedInstance.collectedObjectsCount;
            float score = 0;
            float maxScore = 0;
            
            coinsText.text = coins.ToString();
            scoresText.text = "Score: " + score.ToString("f1");
            maxScoreText.text = "Max: " + maxScore.ToString("f1");
        }
    }
}
