using System;
using System.Collections;
using System.Collections.Generic;
using PlayerStateMachine;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public GameObject playerBig, playerSmallRight, playerSmallLeft;
    [SerializeField] public Animator playerBigAnimator;

    private float _distance;
    private float _maxDistance;

    public IState currentState;

    

    private void OnEnable()
    {
        EventManager.Subscribe(EventList.GameStarted, StartGame);
    }
    
    private void OnDisable()
    {
        EventManager.Unsubscribe(EventList.GameStarted, StartGame);
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
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
    void StartGame()
    {
        ChangeState(new BigState());
    }


   
}