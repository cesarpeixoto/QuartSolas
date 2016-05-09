/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável pela administração do comportamento do Game Menu.

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 08/05/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

namespace Managers
{
    public class GameManagerGameMenu : MonoBehaviour 
    {
        //---------------------------------------------------------------------------------------------------------------
        // Propriedades da Classe

        public GameObject GameMenuCanvasUI = null;                                          // Referência para o Canvas do GameMenu

        //---------------------------------------------------------------------------------------------------------------
        // Métodos herdados de MonoBehaviour 

        // Update is called once per frame
        private void Update () 
        {
            bool conditions = (!GameManagerMain.GetInstance().isGameOver && !GameManagerMain.GetInstance().isActorItemGlossaryOn &&
                               !GameManagerMain.GetInstance().isMasterPowersGlossaryOn && !GameManagerMain.GetInstance().isMatchSummaryOn);

            if (Input.GetKeyUp(KeyCode.Escape) && conditions)
                OnGameMenu();
        }
            
        //---------------------------------------------------------------------------------------------------------------
        // Métodos responsável por ativar o Canvas do Game Menu, atualizar o status e disparar o evento.

        public void OnGameMenu()
        {
            if(GameMenuCanvasUI != null)
            {
                GameMenuCanvasUI.SetActive(!GameMenuCanvasUI.activeSelf);                   // Inverte o estado atual de ativação do Canvas.
                GameManagerMain.GetInstance().isGameMenuOn = !GameManagerMain.GetInstance().isGameMenuOn;                // Inverte o estado do flag do Gerenciador de Eventos.
                GameManagerMain.GetInstance().CallEventGameMenu();                                        // Dispara o evento GameMenu.
            }
            else
                Debug.LogError("Nenhum Menu Atribuido ao GameManagerGameMenu!");
        }

        //---------------------------------------------------------------------------------------------------------------
    }

    //-------------------------------------------------------------------------------------------------------------------
}




