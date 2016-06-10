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
    public GameObject blinkText = null;

    public bool completed = false;

    private int steps = 1;                                  // Contador dos passos do tutorial, começar no primeiro passo
    private bool checkSlots = false;
    private bool menuMode = false;


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

    void OnDestroy()
    {
        _Instance = null;
    }
        
	// Use this for initialization
    void Start () 
    {
        Invoke("FirstStep", 0.5f);
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (checkSlots && (!slot1.interactable && !slot3.interactable && !slot3.interactable))
        {
            checkSlots = false;
            Invoke("NextStep", 5.5f);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuMode = !menuMode;
            if(menuMode)
                Cursor.visible = true;
        }
                    
        if(!menuMode)
        {            
            if (Input.mousePosition.x < Screen.width / 2)
                Cursor.visible = false;
            else
                Cursor.visible = true;
        }

        if(completed && ActorTutorialManager.GetInstance().completed)
        {
            Invoke("NextStep", 2.5f);
        }
	}

    private void FirstStep()
    {
        tutorialWindow.SetActive(true);
        dialogManager.DisplayNextText(3);
    }

    private void SecondStep()
    {
        slot1.GetComponent<TutorialButtonPower>().thisPower = powers.GetComponent<PowerClockBomb1>();
        slot1.image.sprite = powers.GetComponent<PowersManager>().resources[(int)PowersManager.ConstPowerList.ClockBomb1].icon;
        slot1.interactable = true;
        slot2.GetComponent<TutorialButtonPower>().thisPower = powers.GetComponent<PowerClockBomb2>();
        slot2.image.sprite = powers.GetComponent<PowersManager>().resources[(int)PowersManager.ConstPowerList.ClockBomb2].icon;
        slot2.interactable = true;
        slot3.GetComponent<TutorialButtonPower>().thisPower = powers.GetComponent<PowerClockBomb3>();
        slot3.image.sprite = powers.GetComponent<PowersManager>().resources[(int)PowersManager.ConstPowerList.ClockBomb3].icon;
        slot3.interactable = true;

        checkSlots = true;

    }

    private void ThirdStep()
    {
        tutorialWindow.SetActive(true);
        dialogManager.DisplayNextText(2);
    }

    private void FourthStep()
    {
        slot1.GetComponent<TutorialButtonPower>().thisPower = powers.GetComponent<PowerSpikes>();
        slot1.image.sprite = powers.GetComponent<PowersManager>().resources[(int)PowersManager.ConstPowerList.Spike].icon;
        slot1.interactable = true;
        slot2.GetComponent<TutorialButtonPower>().thisPower = powers.GetComponent<PowerBomb>();
        slot2.image.sprite = powers.GetComponent<PowersManager>().resources[(int)PowersManager.ConstPowerList.Bomb].icon;
        slot2.interactable = true;
        slot3.GetComponent<TutorialButtonPower>().thisPower = powers.GetComponent<PowerBomb>();
        slot3.image.sprite = powers.GetComponent<PowersManager>().resources[(int)PowersManager.ConstPowerList.Bomb].icon;
        slot3.interactable = true;
        checkSlots = true;
    }


    private void FifthStep()
    {
        tutorialWindow.SetActive(true);
        dialogManager.DisplayNextText(2);
    }


    private void SixthStep()
    {
        slot1.GetComponent<TutorialButtonPower>().thisPower = powers.GetComponent<PowerVerticalMove>();
        slot1.image.sprite = powers.GetComponent<PowersManager>().resources[(int)PowersManager.ConstPowerList.VerticalMove].icon;
        slot1.interactable = true;
        slot2.GetComponent<TutorialButtonPower>().thisPower = powers.GetComponent<PowerHorizontalMove>();
        slot2.image.sprite = powers.GetComponent<PowersManager>().resources[(int)PowersManager.ConstPowerList.HorizontalMove].icon;
        slot2.interactable = true;
        slot3.GetComponent<TutorialButtonPower>().thisPower = powers.GetComponent<PowerFreeze>();
        slot3.image.sprite = powers.GetComponent<PowersManager>().resources[(int)PowersManager.ConstPowerList.Freeze].icon;
        slot3.interactable = true;
        checkSlots = true;
    }

    private void SeventhStep()
    {
        tutorialWindow.SetActive(true);
        dialogManager.DisplayNextText(2);
    }

    private void EighthStep()
    {
        completed = true;
        StartBlinkMessage();
    }

    private void NinethStep()
    {
        GameStateManager.GetInstance().ToMainMenu();
    }



    public void NextStep()
    {
        steps++;
        tutorialWindow.SetActive(false);
        MouseManager.masterPower = null;
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
            case 8:
                EighthStep();
                break;        
            case 9:
                NinethStep();
                break;          
                // invocar a função do segundo passo
            default:
                break;
        }


    }

    private void StartBlinkMessage()
    {
        blinkText.SetActive(true);
        StartCoroutine("Blink");
    }

    private void StopBlinkMessage()
    {
        StopCoroutine("Blink");
        blinkText.SetActive(false);
    }


    private IEnumerator Blink()
    {
        while(true)
        {
            blinkText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            blinkText.SetActive(false);
            yield return new WaitForSeconds(0.3f);
        }
    }



}
