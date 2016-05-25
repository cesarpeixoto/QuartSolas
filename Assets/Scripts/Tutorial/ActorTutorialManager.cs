using UnityEngine;
using System.Collections;

/// <summary>
/// Interessante fazer um singleton aqui!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
/// </summary>


public class ActorTutorialManager : MonoBehaviour 
{

    private static ActorTutorialManager _Instance;
    public static ActorTutorialManager GetInstance() { return _Instance; }

    public InputManager inputManager = null;
    public GameObject actor = null;
    public TutorialDialog dialogManager = null;
    public GameObject tutorialWindow = null;
    public GameObject checkPoint = null;

    public GameObject freezePlatform1 = null;
    public GameObject freezePlatform2 = null;

    public GameObject horizontalPlatform = null;
    public GameObject horizontalPlatform2 = null;
    public GameObject verticalPlatform = null;
    public GameObject verticalPlatform2 = null;

    public GameObject itemSpawnPosition = null;
    public GameObject boot = null;


    private Vector3 position = new Vector3(-5.1f, -4.5f, 0.0f);


    private int steps = 1;                                  // Contador dos passos do tutorial, começar no primeiro passo


    void Awake()
    {
        //---------------------------------------------------------------------------------------------------------------
        // Singleton - Design Pattern
        if (_Instance != null)
        {
            Destroy(gameObject);
            Debug.LogError("Mais de uma instancia de GameManager!!! Algo muito errado aconteceu!!!");
            return;
        }
        _Instance = this;
    }


	// Use this for initialization
	void Start () 
    {
        Paralyze(false);
        Debug.Log(actor.transform.position);
        checkPoint.SetActive(false);
        Invoke("FirstStep", 0.5f);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    private void FirstStep()
    {
        Paralyze(false);
        tutorialWindow.SetActive(true);
        dialogManager.DisplayNextText(3);
    }

    private void SecondStep()
    {
        checkPoint.SetActive(true);
        Paralyze(true);
        tutorialWindow.SetActive(false);
    }

    private void ThirdStep()
    {
        Paralyze(false);
        checkPoint.SetActive(false);
        tutorialWindow.SetActive(true);
        dialogManager.DisplayNextText(1);
    }

    private void FourthStep()
    {
        Paralyze(true);
        actor.transform.position = position;
        checkPoint.SetActive(true);
        tutorialWindow.SetActive(false);
        freezePlatform1.GetComponent<Freeze>().Active();
        freezePlatform2.GetComponent<Freeze>().Active();
        horizontalPlatform.GetComponent<SimpleMovement>().activeHorizontalMove();
        horizontalPlatform2.GetComponent<SimpleMovement>().activeHorizontalMove();
        verticalPlatform.GetComponent<SimpleMovement>().activeVerticalMove();
        verticalPlatform2.GetComponent<SimpleMovement>().activeVerticalMove();
    }


    private void FifthStep()
    {
        Paralyze(false);
        checkPoint.SetActive(false);
        tutorialWindow.SetActive(true);
        dialogManager.DisplayNextText(2);
        freezePlatform1.GetComponent<Freeze>().lifeTime = 0;
        freezePlatform2.GetComponent<Freeze>().lifeTime = 0;
        horizontalPlatform.GetComponent<SimpleMovement>().lifeTime = 0;
        horizontalPlatform2.GetComponent<SimpleMovement>().lifeTime = 0;
        verticalPlatform.GetComponent<SimpleMovement>().lifeTime = 0;
        verticalPlatform2.GetComponent<SimpleMovement>().lifeTime = 0;
    }


    private void SixthStep()
    {
        tutorialWindow.SetActive(false);
        Paralyze(true);
        actor.transform.position = position;

        boot.transform.position = itemSpawnPosition.transform.position;
        checkPoint.SetActive(true);
    }

    private void SeventhStep()
    {
        Paralyze(false);
        tutorialWindow.SetActive(true);
        dialogManager.DisplayNextText(2);
    }




    public void NextStep()
    {
        steps++;
        tutorialWindow.SetActive(false);

        // fazer um switcase com as funções que precisam ser chamaras;

        switch (steps)
        {
            case 2:
                SecondStep();
                break;
            case 3:
                ThirdStep();
                break;
            case 4:
                FourthStep();
                break;
            case 5:
                FifthStep();
                break;
            case 6:
                SixthStep();
                break;
            case 7:
                SeventhStep();
                break;
                
                // invocar a função do segundo passo
            default:
                break;
        }


    }

    private void Paralyze(bool value)
    {
        inputManager.enabled = value;
        actor.GetComponent<Walk>().enabled = value;
    }


}
