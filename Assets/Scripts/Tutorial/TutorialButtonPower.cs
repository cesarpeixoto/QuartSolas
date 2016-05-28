using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TutorialButtonPower : MonoBehaviour, IPointerClickHandler
{
    public MasterBehaviour thisPower = null;


    public void OnPointerClick(PointerEventData eventData)
    {
        if(thisPower != null)
        {
            MouseManager.masterPower = thisPower;
            GetComponent<Button>().interactable = false;
        }                    
    }        
}
