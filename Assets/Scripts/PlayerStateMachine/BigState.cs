using System;
using UnityEngine;

namespace PlayerStateMachine
{
    public class BigState : IState
    {
        public void EnterState(PlayerManager player)
        {
           
        }

        public void UpdateState(PlayerManager player)
        {
          Debug.Log("Big State Update");
        }

        public void ExitState(PlayerManager player)
        {
            player.playerSmallLeft.SetActive(true);
            player.playerSmallRight.SetActive(true);
            player.playerBig.SetActive(false);
            Debug.Log("Arabaya dönüştüm");
        }
    }
}
