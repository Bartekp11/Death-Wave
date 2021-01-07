using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
       public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;
   
      public void SetHealth(float Health, float maxHealth)
    {
        Slider.gameObject.SetActive(Health < maxHealth);
        Slider.value = Health;
        Slider.maxValue = maxHealth;
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
       
    }
    void Update()
    {
         Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
  
}
