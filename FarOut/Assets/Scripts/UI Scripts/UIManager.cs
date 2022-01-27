using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
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
    void Start()
    {
   
    }

    // Update is called once per frame
    public void Update()
    {
        
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

        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue)
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
