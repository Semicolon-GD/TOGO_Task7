using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      Debug.Log("Obstacle Hit!"+other.tag);
      if (other.CompareTag("Player"))
      {
         EventManager.Trigger(EventList.GameFailed);
      }
      
   }
}
