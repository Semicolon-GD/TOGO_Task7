using System;
using UnityEngine;


namespace PlayerStateMachine
{
    public class IdleState : IState
    {
       
        public void EnterState(PlayerManager player)
        {
            player.playerSmallLeft.SetActive(false);
            player.playerSmallRight.SetActive(false);
            player.playerBig.SetActive(true);
        }

        public void UpdateState(PlayerManager player)
        {
        }

        public void ExitState(PlayerManager player)
        {
        }
    }
}
