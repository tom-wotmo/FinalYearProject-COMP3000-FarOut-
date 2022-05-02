using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    //
    //
    //
    //
    //----- script to control the UI
    //
    //
    //
    //
 
    public static bool gameIsPaused;
    private InputDevice targetDevice;
    public GameObject pauseMenu;

    public void ButtonTest()
    {
        Debug.Log("Button works");
    }
    public void PauseGame() 
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void FixedUpdate()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];

        }

        targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
        if (secondaryButtonValue)
        {
            if (gameIsPaused == true)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
