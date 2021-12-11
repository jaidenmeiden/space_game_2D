using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    Menu,
    InGame,
    GameOver
}

public class GameManager : MonoBehaviour {

    public GameState currentGameState = GameState.Menu;

    // Use this for initialization
    void Start () {
		
    }
	
    // Update is called once per frame
    void Update () {
		
    }

    public void StartGame(){

    } 

    public void GameOver(){

    }

    public void BackToMenu(){

    }

    private void SetGameState(GameState newGameSate){
        switch(newGameSate)
        {
            case GameState.Menu:
                //TODO: Put the logic into menu
                break;
            case GameState.InGame:
                //TODO: Prepare the scene to play
                break;
            case GameState.GameOver:
                //TODO: Prepare the game to 'Game over'
                break;
            default:
                break;
        }
        
        this.currentGameState = newGameSate;
    }
}
