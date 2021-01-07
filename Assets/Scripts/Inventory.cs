using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
   public static int potionCount;
   Text ptext;


    void Start()
    {
        ptext = GetComponent<Text>();
    }

     void Update()
    {
        ptext.text = potionCount.ToString();
    }
   public void PickupItem(GameObject obj)
   {
       potionCount++;
   }
   
}
