using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Play( string MaxenceScene)
    {
        SceneManager.LoadScene(MaxenceScene);
    }
}
