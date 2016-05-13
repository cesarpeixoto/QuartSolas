using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{
    public Text winner = null;
	// Use this for initialization
	void Start () 
    {
        if(GameStateManager.GetInstance().ActorPoints > GameStateManager.GetInstance().MasterPoints)
            winner.text = "Ator foi o grande campeão!";
        else
            winner.text = "Mestre foi o grande campeão!";

        Invoke ("ReStart", 5.0f);

	}

    private void ReStart()
    {
        SceneManager.LoadScene("MainMenu");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
