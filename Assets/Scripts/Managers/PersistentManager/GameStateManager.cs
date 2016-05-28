using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour 
{
    //---------------------------------------------------------------------------------------------------------------
    // Propriedades da Classe

    // Singleton - Design Patterns
    private static GameStateManager _intance = null;
    public static GameStateManager GetInstance() { return _intance; }

    private float masterPoints = 0;
    private float actorPoints = 0;


    public float numOfRounds = 1;
    public string currentScene = "";
    public List<string> sceneList = new List<string>();
    private bool isGameOver = false;

    public float MasterPoints
    {
        get { return masterPoints; }
        set
        {
            masterPoints = value;
            if (masterPoints >= (numOfRounds / 2.0f))
                isGameOver = true;
        }
    }        

    public float ActorPoints
    {
        get { return actorPoints; }
        set
        {
            actorPoints = value;
            if (actorPoints >= (numOfRounds / 2.0f))
                isGameOver = true;
        }
    }

    //---------------------------------------------------------------------------------------------------------------
    // Métodos herdados de MonoBehaviour 

    void Awake()
    {
        if (_intance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        _intance = this;

        // Inicializar as cenas do sceneList
        //sceneList.Add("Woods");
    }

    void OnEnable()
    {
        //Managers.GameManagerMain.GetInstance().GameOverEvent += GameOverScene;
    }

    void OnDisable()
    {
        //Managers.GameManagerMain.GetInstance().GameOverEvent -= GameOverScene;
    }
        

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}


    //---------------------------------------------------------------------------------------------------------------
    // 

    public void NextScene()
    {
        HUDRoundTime.inGame = true;                                     // Reativando porque é estático
        if(isGameOver)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene(sceneList[Random.Range(0, sceneList.Count)]);
        }

    }

    private void GameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Restart()
    {
        masterPoints = 0;
        actorPoints = 0;
        numOfRounds = 1;
        isGameOver = false;
        //currentScene = "";
        //sceneList.Clear();
    }

}
