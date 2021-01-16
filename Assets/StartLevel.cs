using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{

    private int nextSceneToLoad;
     public void Menu()
    {
         nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneToLoad);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
