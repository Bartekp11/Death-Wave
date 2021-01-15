using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour
{
   public static AudioClip jumpSound, attackSound, hitSound, skeletonHit, skeletonAttack;
   static AudioSource audioS;
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jump");
        attackSound = Resources.Load<AudioClip>("attack");
        hitSound = Resources.Load<AudioClip>("hit1");
        skeletonHit = Resources.Load<AudioClip>("hit2");
        skeletonAttack = Resources.Load<AudioClip>("skeletonAttack");
    

        audioS = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "jump":
            audioS.PlayOneShot(jumpSound);
            break;

            case "attack":
            audioS.PlayOneShot(attackSound);
            break;

            case "hit1":
            audioS.PlayOneShot(hitSound);
            break;

            case "hit2":
            audioS.PlayOneShot(skeletonHit);
            break;

             case "skeletonAttack":
            audioS.PlayOneShot(skeletonAttack);
            break;
        }
    }
}
