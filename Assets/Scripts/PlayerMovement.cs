using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 10f;
    [SerializeField] float dragSensitive = 3f;
    [SerializeField] GameObject playerBig, playerSmallRight, playerSmallLeft;
    [SerializeField] private Animator playerBigAnimator;

    private float _playerSpeed;
    private float _horizontalMove;
    private float _left=-3f;
    private float _right=3;
    private float _distance;
    private float _maxDistance;
    private void OnEnable()
    {
        EventManager.Subscribe(EventList.GameStarted, StartMovement);
        EventManager.Subscribe(EventList.OnHorizontalDrag, MovePlayer);
    }
    
    private void OnDisable()
    {
        EventManager.Unsubscribe(EventList.GameStarted, StartMovement);
        EventManager.Unsubscribe(EventList.OnHorizontalDrag, MovePlayer);
    }

    private void Start()
    {
        _playerSpeed = 0;
        _maxDistance=Vector3.Distance(playerSmallLeft.transform.position,playerSmallRight.transform.position);
    }

    /*private void Update()
    {
        _distance=Vector3.Distance(playerSmallLeft.transform.position,playerSmallRight.transform.position);
        ChangePlayerObject();
    }*/

    /*private void ChangePlayerObject()
    {
        if (_distance <= _maxDistance)
        {
            playerBig.SetActive(true);
            /*playerBigAnimator.SetTrigger("Flip");#1#
            playerBigAnimator.SetBool("isRunning",true);
            playerSmallLeft.SetActive(false);
            playerSmallRight.SetActive(false);
        }
        else if (_distance>_maxDistance)
        {
            playerBig.SetActive(false);
            playerSmallLeft.SetActive(true);
            playerSmallRight.SetActive(true);
        }
    }*/

    private void StartMovement()
    {
        _playerSpeed = forwardSpeed;
    }
    
    private void MovePlayer(float horizontal)
    {
       var posR= playerSmallRight.transform.position;
       var posL= playerSmallLeft.transform.position;
       
       posR.x=Math.Clamp(posR.x+(horizontal*dragSensitive*Time.deltaTime),_left,_right);
       playerSmallRight.transform.position= posR;
       playerSmallLeft.transform.position=Vector3.Reflect(playerSmallRight.transform.position,Vector3.right);
    }
}