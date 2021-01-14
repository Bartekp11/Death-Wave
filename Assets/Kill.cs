using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    [SerializeField]Transform spawn;

    void OnCollisionEnter2D(Collision2D floor)
    {
        if(floor.transform.CompareTag("Player"))
        {
            floor.transform.position = spawn.position;
        }
    }
}
