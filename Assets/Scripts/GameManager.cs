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
    private PlayerController _controller;
    public int collectedObjectsCount = 0;

    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
    }

    // Use this for initialization
    void Start () {
        // Function to find an object by name
		_controller = GameObject.Find("Player").GetComponent<PlayerController>();
        // Similar function to find an object, but by tag. We have the same result
		//_controller = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
	
    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Submit") && currentGameState != GameState.InGame)
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
                MenuManager.SharedInstance.ShowMainMenu();
                MenuManager.SharedInstance.HideScoreMenu();
                MenuManager.SharedInstance.HideGameOverMenu();
                break;
            case GameState.InGame:
                //TODO: Prepare the scene to play
                LevelManager.SharedInstance.RemoveAllLevelBlocks();
                LevelManager.SharedInstance.GenerateInitialBlocks();
                _controller.StartGame();
                MenuManager.SharedInstance.HideMainMenu();
                MenuManager.SharedInstance.ShowScoreMenu();
                MenuManager.SharedInstance.HideGameOverMenu();
                break;
            case GameState.GameOver:
                //TODO: Prepare the game to 'Game over'
                MenuManager.SharedInstance.HideMainMenu();
                MenuManager.SharedInstance.HideScoreMenu();
                MenuManager.SharedInstance.ShowGameOverMenu();
                break;
            default:
                break;
        }
        
        this.currentGameState = newGameSate;
    }

    public void CollectObject(Collectable collectable)
    {
        collectedObjectsCount += collectable.value;
    }
}
