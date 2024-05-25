using System;
using UnityEngine;

namespace PlayerStateMachine
{
    public class BigState : IState
    {
        
        public void EnterState(PlayerManager player)
        {
            player.playerBigAnimator.SetBool("isRunning",true);
        }

        public void UpdateState(PlayerManager player)
        {
        }

        public void ExitState(PlayerManager player)
        {
            player.playerSmallLeft.SetActive(true);
            player.playerSmallRight.SetActive(true);
            player.playerBig.SetActive(false);
        }
    }
}
