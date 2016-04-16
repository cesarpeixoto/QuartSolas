using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDRoundTime : MonoBehaviour 
{
	private Text uiTextTimer;
	public float time = 70.00f;


	void Awake () 
	{
		uiTextTimer = GetComponent<Text> ();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		time -= Time.deltaTime;

		if(Mathf.Floor (time / 60) >= 1)
		{
			string minutes = Mathf.Floor (time / 60).ToString ("00");
			string seconds = (time % 60).ToString ("00");
			uiTextTimer.text = "Tempo: " + minutes + ":" + seconds; 
		}
		else
		{
			if (time >= 10)
				uiTextTimer.text = "Tempo: " + time.ToString ("00");
			else if(time < 10 && time >= 0)
				uiTextTimer.text = "Tempo: <Color=red>" + time.ToString ("00") + "</color>";
			else if(time < 0)
				uiTextTimer.text = "ACABOU!!!!";
		}
	
	}
}
