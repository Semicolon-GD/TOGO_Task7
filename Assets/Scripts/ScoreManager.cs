using System;
using System.Diagnostics.Tracing;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int Score { get; private set; }
    private void OnEnable()
    {
       
        EventManager.Subscribe(EventList.OnCollectiblePickup, AddScore);
    }

    private void OnDisable()
    {
        EventManager.Unsubscribe(EventList.OnCollectiblePickup, AddScore);
    }

    private void Start()
    {
        Score = 0;
    }

    void AddScore()
    {
        Score++;
        EventManager.Trigger(EventList.UpdateScoreText, Score);
    }
    
}