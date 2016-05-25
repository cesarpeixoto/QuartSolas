using UnityEngine;
using System.Collections;

public class TutorialCheckpoint : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        ActorTutorialManager.GetInstance().NextStep();
    }

}
