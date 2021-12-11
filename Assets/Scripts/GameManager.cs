using System;
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
    public static GameManager SharedInstance;//Singleton

    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
    }

    // Use this for initialization
    void Start () {
		
    }
	
    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Submit"))
        {
            StartGame();
        }
    }

    public void StartGame(){
        SetGameState(GameState.InGame);
    } 

    public void GameOver(){
        SetGameState(GameState.GameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.Menu);
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
