using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("Fabula1");
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void PlayLevel4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void PlayLevel5()
    {
        SceneManager.LoadScene("Level5");
    }

    public void PlayLevel6()
    {
        SceneManager.LoadScene("Level6");
    }

    public void PlayLevel7()
    {
        SceneManager.LoadScene("Level7");
    }

    public void PlayLevel8()
    {
        SceneManager.LoadScene("Level8");
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    

    public void Quit()
        {
        Application.Quit();
    }

}

