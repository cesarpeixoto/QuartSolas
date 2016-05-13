using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDRoundTime : MonoBehaviour 
{
	private Text uiTextTimer;
	public float time = 70.00f;
    public static bool inGame = true;

    public Image actPtn1 = null;
    public Image actPtn2 = null;
    public Image actPtn3 = null;
    public Image mstPtn1 = null;
    public Image mstPtn2 = null;
    public Image mstPtn3 = null;


	void Awake () 
	{
		uiTextTimer = GetComponent<Text> ();

        // Pontuação no HUD
        if (GameStateManager.GetInstance().ActorPoints > 0)
            actPtn1.gameObject.SetActive(true);
        if (GameStateManager.GetInstance().ActorPoints > 1)
            actPtn2.gameObject.SetActive(true);
        if (GameStateManager.GetInstance().ActorPoints > 2)
            actPtn3.gameObject.SetActive(true);

        if (GameStateManager.GetInstance().MasterPoints > 0)
            mstPtn1.gameObject.SetActive(true);
        if (GameStateManager.GetInstance().MasterPoints > 1)
            mstPtn2.gameObject.SetActive(true);
        if (GameStateManager.GetInstance().MasterPoints > 2)
            mstPtn3.gameObject.SetActive(true);
        
	}
	
	// Update is called once per frame
	void Update () 
	{
        if(inGame)
        {
            time -= Time.deltaTime;

            if(Mathf.Floor (time / 60) >= 1)
            {
                string minutes = Mathf.Floor (time / 60).ToString ("00");
                string seconds = (time % 60).ToString ("00");
                uiTextTimer.text = minutes + ":" + seconds; 
            }
            else
            {
                if (time >= 10)
                    uiTextTimer.text = time.ToString ("00");
                else if(time < 10 && time >= 0)
                    uiTextTimer.text = "<Color=red>" + time.ToString ("00") + "</color>";
                else if(time < 0)
                {
                    inGame = false;
                    Managers.GameManagerMatchSummary.actorWins = true;
                    Managers.GameManagerMain.GetInstance().CallEventMatchSummary();
                }
            }						
		}
	
	}
}
