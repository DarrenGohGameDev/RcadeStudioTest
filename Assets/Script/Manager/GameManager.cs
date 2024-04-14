using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameStateMachine stateMachine;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //private void Update()
    //{
    //    Debug.Log(stateMachine.currentState.ToString());
    //    Debug.Log(GameStateMachine.EGameState.InGameState);
    //}
}
