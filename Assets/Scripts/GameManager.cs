using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.menu;
    public static GameManager sharedInstance;
    private PlayerController controller;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        
    }

    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    private void Update()
    {
        if(Input.GetButtonDown("Submit") || (Input.touchCount > 0) && currentGameState !=  GameState.inGame)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    private void SetGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu){
            //TODO: Menú
        }
        else if(newGameState == GameState.inGame){
            controller.StartGame();
        }
        else if(newGameState == GameState.gameOver){

        }
        this.currentGameState = newGameState;

    }
}
