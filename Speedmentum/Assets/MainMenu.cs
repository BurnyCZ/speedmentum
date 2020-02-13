using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("Arena");
    }
    public void Level2()
    {
        SceneManager.LoadScene("CsMap");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Playground");
    }
    public void Level4()
    {
        //SceneManager.LoadScene("Arena");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
