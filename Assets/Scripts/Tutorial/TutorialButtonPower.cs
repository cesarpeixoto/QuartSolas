using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TutorialButtonPower : MonoBehaviour, IPointerClickHandler
{
    public MasterBehaviour thisPower = null;
    public GameObject plarformsAll = null;


    public void OnPointerClick(PointerEventData eventData)
    {
        if(thisPower != null)
        {
            CheckSelectables();
            MouseManager.masterPower = thisPower;
            GetComponent<Button>().interactable = false;
        }                    
    }

    private void CheckSelectables()
    {
        if (thisPower.GetType() == typeof(PowerHorizontalMove))
        {
            SimpleMovement[] platforms = plarformsAll.GetComponentsInChildren<SimpleMovement>();//GetComponents<SimpleMovement>();
            foreach (SimpleMovement selection in platforms)           // Seleciona todas as plataformas.
                if (selection.canHorizontalMove)
                    selection.Select();
        }
        else if (thisPower.GetType() == typeof(PowerVerticalMove))
        {
            SimpleMovement[] platforms = plarformsAll.GetComponentsInChildren<SimpleMovement>();//GetComponents<SimpleMovement>();
            foreach (SimpleMovement selection in platforms)           // Seleciona todas as plataformas.
                if (selection.canVerticalMove)
                    selection.Select();            
        }
        else if (thisPower.GetType() == typeof(PowerFreeze))
        {
            SimpleMovement[] platforms = plarformsAll.GetComponentsInChildren<SimpleMovement>(); //GetComponents<SimpleMovement>();
            foreach (SimpleMovement selection in platforms)                                      // Seleciona todas as plataformas.
                selection.Select();            
        }
    }


}
