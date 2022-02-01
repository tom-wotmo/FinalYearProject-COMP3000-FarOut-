using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUiManager : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }
    public void EnterGame()
    {
        SceneManager.LoadScene(1);
    } 
    public void Credits()
    {

    }
}
