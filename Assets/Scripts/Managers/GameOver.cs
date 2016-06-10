using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{
    public Image Painel = null;
    public Sprite actorWins = null;
    public Sprite masterWins = null;

    public Text winner = null;
	// Use this for initialization
	void Start () 
    {
        if (GameStateManager.GetInstance().ActorPoints > GameStateManager.GetInstance().MasterPoints)
            Painel.sprite = actorWins;
        else
            Painel.sprite = masterWins;

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
