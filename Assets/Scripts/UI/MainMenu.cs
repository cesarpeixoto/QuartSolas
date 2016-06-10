using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
    private AudioSource clickAudio = null;
    public GameObject stageSelection = null;

	// Use this for initialization
	void Awake () 
    {
        clickAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}



    public void OnSelection(int bestOf)
    {
        StartCoroutine("OnBegin", bestOf);
    }

    public void OnClick(string function)
    {
        StartCoroutine(function);
    }

    private IEnumerator OnStart()
    {
        clickAudio.Play();
        yield return new WaitForSeconds(clickAudio.clip.length);
        stageSelection.SetActive(!stageSelection.activeSelf);
    }        

    private IEnumerator OnBegin(int bestOf)
    {
        clickAudio.Play();
        yield return new WaitForSeconds(clickAudio.clip.length);
        GameStateManager.GetInstance().Restart();
        GameStateManager.GetInstance().numOfRounds = bestOf;
        GameStateManager.GetInstance().NextScene();
        Time.timeScale = 1;
    }

    private IEnumerator OnTutorial()
    {
        clickAudio.Play();
        yield return new WaitForSeconds(clickAudio.clip.length);
        GameStateManager.GetInstance().Restart();
        GameStateManager.GetInstance().ToTutorial();
        Time.timeScale = 1;
    }

    private IEnumerator OnExit()
    {
        clickAudio.Play();
        yield return new WaitForSeconds(clickAudio.clip.length);
        Application.Quit();
    }

    public void OnMainMenu()
    {
        GameStateManager.GetInstance().ToMainMenu();
    }

    private void Waitntg()
    {
        Debug.Log("Clicou");
    }

    public void test()
    {
        clickAudio.Play();
    }
}
