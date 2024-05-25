using System;
using Unity.VisualScripting;
using UnityEngine;

namespace PlayerStateMachine
{
    public class SmallState : IState
    {
        
        public void EnterState(PlayerManager player)
        {
            
        }

        public void UpdateState(PlayerManager player)
        {
        }

        public void ExitState(PlayerManager player)
        {
            player.playerSmallLeft.SetActive(false);
            player.playerSmallRight.SetActive(false);
            player.playerBig.SetActive(true);
            player.playerBigAnimator.SetTrigger("Flip");
           // player.playerBigAnimator.SetBool("isRunning",true);
        }
        
        
    }
}
