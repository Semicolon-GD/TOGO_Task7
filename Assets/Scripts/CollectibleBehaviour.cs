using System;
using System.Collections;
using System.Collections.Generic;
using PlayerStateMachine;
using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      Debug.Log("Collectible Hit!"+other.tag);
      if (!other.CompareTag("Player")) return;
      if (other.gameObject.transform.parent.GetComponent<PlayerManager>().currentState is BigState) return;
      EventManager.Trigger(EventList.OnCollectiblePickup);
      Destroy(this.gameObject);
      
   }
}
