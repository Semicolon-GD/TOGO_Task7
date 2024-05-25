using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        ChangeState(GameState.TutorialState);
    }

    private void OnEnable()
    {
        EventManager.Subscribe(EventList.GameStarted, StartGame);
        EventManager.Subscribe(EventList.GameFailed, GameFailed);
    }

    private void OnDisable()
    {
        EventManager.Unsubscribe(EventList.GameStarted, StartGame);
        EventManager.Unsubscribe(EventList.GameFailed, GameFailed);
    }

    public void ChangeState(GameState state)
    {
        State = state;
        switch (State)
        {
            case GameState.TutorialState:
                Debug.Log("Tutorial State");
                break;
            case GameState.PlayingState:
                Debug.Log("Playing State");
                break;
            case GameState.GameWonState:
                Debug.Log("Game Won State");
                break;
            case GameState.GameOverState:
                Debug.Log("Game Over State");
                break;
        }

        EventManager.Trigger(EventList.GameStateChange, State);

    }
    
    
    #region Event Methods
    
    private void StartGame()
    {
        ChangeState(GameState.PlayingState);
    }
    
    private void GameFailed()
    {
        ChangeState(GameState.GameOverState);
    }
    
    
    #endregion
    
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    
}