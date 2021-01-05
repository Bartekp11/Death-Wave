using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{
    private int nextSceneToLoad;
    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        
        if(currentLevel >= PlayerPrefs.GetInt("levelIsUnlocked"))
        {
            PlayerPrefs.SetInt("levelIsUnlocked",currentLevel + 1);
        }
        SceneManager.LoadScene(nextSceneToLoad);
    }

}
