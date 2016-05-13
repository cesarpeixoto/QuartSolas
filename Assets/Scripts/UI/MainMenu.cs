using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void OnBegin(int bestOf)
    {
        GameStateManager.GetInstance().Restart();
        GameStateManager.GetInstance().numOfRounds = bestOf;
        GameStateManager.GetInstance().NextScene();
        Time.timeScale = 1;
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnMainMenu()
    {
        GameStateManager.GetInstance().ToMainMenu();
    }
}
