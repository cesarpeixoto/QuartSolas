using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MasterTutorialManager : MonoBehaviour 
{

    private static MasterTutorialManager _Instance;
    public static MasterTutorialManager GetInstance() { return _Instance; }

    public InputManager inputManager = null;

    //public GameObject actor = null;
    public TutorialDialog dialogManager = null;
    public GameObject tutorialWindow = null;
    public GameObject powers = null;
    public Button slot1 = null;
    public Button slot2 = null;
    public Button slot3 = null;
    //public GameObject checkPoint = null;
    //public GameObject blinkText = null;

    //public GameObject freezePlatform1 = null;
    //public GameObject freezePlatform2 = null;

    //public GameObject horizontalPlatform = null;
    //public GameObject horizontalPlatform2 = null;
    //public GameObject verticalPlatform = null;
    //public GameObject verticalPlatform2 = null;

    //public GameObject itemSpawnPosition = null;
    //public GameObject boot = null;


    //private Vector3 position = new Vector3(-5.1f, -4.5f, 0.0f);


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
        Invoke("FirstStep", 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void FirstStep()
    {
        tutorialWindow.SetActive(true);
        dialogManager.DisplayNextText(3);
    }

    private void SecondStep()
    {
        //slot1.GetComponent<TutorialButtonPower>().thisPower = powers.GetComponent<PowerConfusion>();
        //slot1.image.sprite = powers.GetComponent<PowersManager>().resources[(int)PowersManager.ConstPowerList.Confusion].icon;

        slot1.GetComponent<TutorialButtonPower>().thisPower = powers.GetComponent<PowerClockBomb1>();
        slot1.image.sprite = powers.GetComponent<PowersManager>().resources[(int)PowersManager.ConstPowerList.ClockBomb1].icon;
        slot2.GetComponent<TutorialButtonPower>().thisPower = powers.GetComponent<PowerClockBomb2>();
        slot2.image.sprite = powers.GetComponent<PowersManager>().resources[(int)PowersManager.ConstPowerList.ClockBomb2].icon;
        slot3.GetComponent<TutorialButtonPower>().thisPower = powers.GetComponent<PowerClockBomb3>();
        slot3.image.sprite = powers.GetComponent<PowersManager>().resources[(int)PowersManager.ConstPowerList.ClockBomb3].icon;

    }

    private void ThirdStep()
    {
        
    }

    private void FourthStep()
    {
        
    }


    private void FifthStep()
    {
        
    }


    private void SixthStep()
    {
        
    }

    private void SeventhStep()
    {
        
    }

    private void EighthStep()
    {
       
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
//            case 3:
//                ThirdStep();
//                break;
//            case 4:
//                FourthStep();
//                break;
//            case 5:
//                FifthStep();
//                break;
//            case 6:
//                SixthStep();
//                break;
//            case 7:
//                SeventhStep();
//                break;
//            case 8:
//                EighthStep();
//                break;                
//                // invocar a função do segundo passo
            default:
                break;
        }


    }


}
