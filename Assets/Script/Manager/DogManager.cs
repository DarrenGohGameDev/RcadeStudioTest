using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogManager : MonoBehaviour
{
    [SerializeField] private DogController dogController;

    [SerializeField] private RunningDogController runningDogController;
    // Start is called before the first frame update
    public void FeedRunningDog(float speed)
    {
        SoundManager.instance.PlayClip(3);
        runningDogController.agent.speed += speed;
    }

    public void FeedDog(float speed) 
    {
        SoundManager.instance.PlayClip(3);
        dogController.agent.speed += speed;
    }
}
