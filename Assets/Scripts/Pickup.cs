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
      if(collision.gameObject.tag == "Player")
      {
          Inventory.potionCount += 1;
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
