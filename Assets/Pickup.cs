using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public AudioClip soundEffect;
    public GameObject pickupEffect;
   private void OnTriggerEnter2D(Collider2D collision)
   {
      Inventory manager = collision.GetComponent<Inventory>();
       if(manager)
       {
           manager.PickupItem(gameObject);
           RemoveItem();
       
       }
      
   }

   private void RemoveItem()
   {
      
       AudioSource.PlayClipAtPoint(soundEffect, transform.position);
       //Instantiate(pickupEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
   }
}
