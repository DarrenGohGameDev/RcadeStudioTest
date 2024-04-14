using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public class GameStateController : MonoBehaviour
{
    public GameObject menuCamera;

    public GameObject gameCamera;

    public UiManager uiManager;

    public bool startGame;


    private void Awake()
    {
        Assert.IsNotNull(menuCamera, "Please set Menu Camera");
        Assert.IsNotNull(gameCamera, "Please set Game Camera");
        Assert.IsNotNull(uiManager, "Please set ui manager");
        SwapToMenuCamera(true);
    }

    public void SwapToMenuCamera(bool toggle)
    {
        if(toggle) 
        {
            menuCamera.GetComponent<Camera>().enabled = true;
            gameCamera.GetComponent<Camera>().enabled = false;
        }
        else
        {
            menuCamera.GetComponent<Camera>().enabled = false;
            gameCamera.GetComponent<Camera>().enabled = true;
        }
    }

    public void StartGame()
    {
        SwapToMenuCamera(false);
        uiManager.StartGameCountdown();
    }

}
