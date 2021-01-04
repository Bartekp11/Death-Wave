using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public int potionCount;

   public void PickupItem(GameObject obj)
   {
       potionCount++;
   }
   
}
