using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialDialog : MonoBehaviour 
{

    public string[] dialogTexts;                                                    // Array de strings com os textos que serão apresentados.
    public Text blinkText = null;
    public float textSpeed = 0.15f;                                                 // velocidade de exibição dos caracteres.
    public float textSpeedMultiplier = 0.5f;                                        // multiplicador de velocidade se apertar para acelerar o texto.

    public int relativeEndText =0;

    public KeyCode dialogInput = KeyCode.Return;                                    // Referência para a tecla do texto.
    public bool isActor = true;
    public int mouseButton = 0;
    private Text _dialog = null;                                                    // Referência para o texto.

    private bool _isTextStarted = false;                                            // Flag que indica se já está sendo exibido um texto.
    private int currentTextIndex = 0;                                               // Indice to texto atual exibido.

    public GameObject continueIcon = null;
    public GameObject stopIcon = null;


    private void Awake()
    {
        _dialog = GetComponent<Text>();
        _dialog.text = "";
    }


	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        if((Input.GetKeyDown(dialogInput) && isActor) || (Input.GetMouseButton(mouseButton) && !isActor))
        {
            if(!_isTextStarted && currentTextIndex <= relativeEndText)
            {
                StopBlinkMessage();
                _isTextStarted = true;
                StartCoroutine(DisplayText(dialogTexts[currentTextIndex++]));           // usamos ++ depois, para ele incrementar depois que passar o valor ;-)
            }
            if((!_isTextStarted && currentTextIndex > relativeEndText) && isActor)
            {
                StopBlinkMessage();
                ActorTutorialManager.GetInstance().NextStep();
            }
            else if((!_isTextStarted && currentTextIndex > relativeEndText) && !isActor)
            {
                StopBlinkMessage();
                MasterTutorialManager.GetInstance().NextStep();
            }

        }
	}

    // Método que exibe uma sequencia de textos, partindo do texto atual até a quantidade definida.
    public void DisplayNextText(int textAmout)                                         
    {
        relativeEndText = currentTextIndex + textAmout -1;                              // Menos 1 porque sempre incrementa 1, conforme abaixo
        _isTextStarted = true;
        StartCoroutine(DisplayText(dialogTexts[currentTextIndex++]));                   // usamos ++ depois, para ele incrementar depois que passar o valor ;-)
    }
        
    private IEnumerator DisplayText(string textDisplay)
    {
        int strLength = textDisplay.Length;                                             // Tamanho do texto.
        int currentCharIndex = 0;                                                       // Indice do caractere exibido.

        _dialog.text = "";
        yield return new WaitForEndOfFrame();                                           // Aguarda o fim do frame para liberar o GetKeyDown
        while(currentCharIndex < strLength)                                             // Permanece no loop enquanto não exibir todo o texto.
        {
            _dialog.text += textDisplay[currentCharIndex];                              // Adiciona ao texto o caractere do indice atual.
            currentCharIndex++;                                                         // incrememnta o indice atual.

            if(currentCharIndex < strLength)                                            // Testa se o indice atual é maior que o tamanho do texto.
            {
                if(Input.GetKeyDown(dialogInput))
                {
                    currentCharIndex = strLength -1;
                    _dialog.text = textDisplay; 
                    yield return new WaitForSeconds(0.001f);
                }
                else
                    yield return new WaitForSeconds(textSpeed);                         // Se não for aguarda o tempo de velocidade do texto.
            }
            else
                break;                                                                  // Se for, sai do loop.
        }
        _dialog.text = textDisplay;
        StartBlinkMessage();
        _isTextStarted = false;
        yield return 0;
    }


    private void StartBlinkMessage()
    {
        blinkText.enabled = true;
        StartCoroutine("Blink");
    }

    private void StopBlinkMessage()
    {
        StopCoroutine("Blink");
        blinkText.enabled = false;
    }


    private IEnumerator Blink()
    {
        while(true)
        {
            blinkText.enabled = true;
            yield return new WaitForSeconds(0.5f);
            blinkText.enabled = false;
            yield return new WaitForSeconds(0.3f);
        }
    }


}
