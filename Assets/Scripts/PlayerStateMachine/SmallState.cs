using System;
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
            Debug.Log("Small State Update");
        }

        public void ExitState(PlayerManager player)
        {
            player.playerSmallLeft.SetActive(false);
            player.playerSmallRight.SetActive(false);
            player.playerBig.SetActive(true);
            Debug.Log("Robota Dönüştüm");
            player.playerBigAnimator.SetTrigger("Flip");
        }
    }
}
