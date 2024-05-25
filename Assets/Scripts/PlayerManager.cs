using System;
using System.Collections;
using System.Collections.Generic;
using PlayerStateMachine;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public GameObject playerBig, playerSmallRight, playerSmallLeft;
    [SerializeField] public Animator playerBigAnimator;
    [SerializeField] private ParticleSystem playerCelebrationParticle;

    private float _distance;
    private float _maxDistance;

    public IState currentState;

    

    private void OnEnable()
    {
        EventManager.Subscribe(EventList.GameStarted, StartGame);
        EventManager.Subscribe(EventList.GameFailed, GameFailed);
        EventManager.Subscribe(EventList.GameWon, GameWon);
        EventManager.Subscribe(EventList.OnCollectiblePickup,IncreaseBigPlayerSize);
    }

    

    private void OnDisable()
    {
        EventManager.Unsubscribe(EventList.GameStarted, StartGame);
        EventManager.Unsubscribe(EventList.GameFailed, GameFailed);
        EventManager.Unsubscribe(EventList.GameWon, GameWon);
        EventManager.Unsubscribe(EventList.OnCollectiblePickup,IncreaseBigPlayerSize);
    }
    private void Start()
    {
        _maxDistance=Vector3.Distance(playerSmallLeft.transform.position,playerSmallRight.transform.position);
        currentState = new IdleState();
        currentState.EnterState(this);
    }

    private void Update()
    {
        _distance=Vector3.Distance(playerSmallLeft.transform.position,playerSmallRight.transform.position);
        currentState.UpdateState(this);

        CheckDistanceAndChangeState();
    }

    private void CheckDistanceAndChangeState()
    {
        if(currentState is IdleState) return;
        if (_distance <= _maxDistance && currentState is not BigState)
        {
            ChangeState(new BigState());
        }
        else if (_distance > _maxDistance && currentState is not SmallState)
        {
            ChangeState(new SmallState());
        }
    }
    public void ChangeState(IState newState)
    {
        if (currentState != newState)
            currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
    void StartGame()
    {
        ChangeState(new BigState());
    }
    
    void GameFailed()
    {
        playerSmallLeft.SetActive(false);
        playerSmallRight.SetActive(false);
        playerBig.SetActive(true);
        playerBigAnimator.SetBool("isRunning",false);
        playerBigAnimator.SetTrigger("Fall");
    }
    
    void GameWon()
    {
        playerSmallLeft.SetActive(false);
        playerSmallRight.SetActive(false);
        playerBig.SetActive(true);
        playerBigAnimator.SetBool("isRunning",false);
        playerBigAnimator.SetTrigger("Dance");
        playerCelebrationParticle.Play();
    }
    
    private void IncreaseBigPlayerSize()
    {
        playerBig.transform.localScale += new Vector3(0.015f,0.05f,0.05f);
    }


   
}