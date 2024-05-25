using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   [SerializeField] private GameObject inputPanel;
   [SerializeField] private GameObject tutorialPanel;
   [SerializeField] private GameObject gameOverPanel;
   [SerializeField] private GameObject gameWonPanel;
   [SerializeField] private GameObject gamePlayPanel;
   [SerializeField] private TMPro.TextMeshProUGUI scoreText;
   
   private void OnEnable()
   {
      EventManager.Subscribe(EventList.GameStateChange, ChangeUI);
      EventManager.Subscribe(EventList.UpdateScoreText, UpdateScoreText);
   }

  

   private void OnDisable()
   {
      EventManager.Unsubscribe(EventList.GameStateChange, ChangeUI);
      EventManager.Unsubscribe(EventList.UpdateScoreText, UpdateScoreText);
   }
   private void ChangeUI(GameState newState)
   {
      switch (newState)
      {
         case GameState.TutorialState:
            tutorialPanel.SetActive(true);
            break;
         case GameState.PlayingState:
            tutorialPanel.SetActive(false);
            gamePlayPanel.SetActive(true);
            break;
         case GameState.GameWonState:
            gamePlayPanel.SetActive(false);
            inputPanel.SetActive(false);
            gameWonPanel.SetActive(true);
            break;
         case GameState.GameOverState:
            inputPanel.SetActive(false);
            gamePlayPanel.SetActive(false);
            gameOverPanel.SetActive(true);
            break;
      }
   }


   private void UpdateScoreText(float score)
   {
      scoreText.text=score.ToString();
   }
   
}
