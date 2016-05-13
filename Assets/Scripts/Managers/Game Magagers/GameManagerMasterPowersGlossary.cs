/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável pela administração do painel Glossário de poderes do Mestre.

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 08/05/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

namespace Managers
{
    public class GameManagerMasterPowersGlossary : MonoBehaviour 
    {

        //---------------------------------------------------------------------------------------------------------------
        // Propriedades da Classe

        public GameObject GlossaryMenuCanvasUI = null;                                          // Referência para o Canvas do GameMenu

        //---------------------------------------------------------------------------------------------------------------
        // Métodos herdados de MonoBehaviour 

        void OnEnable()
        {
            GameManagerMain.GetInstance().MasterPowersGlossaryEvent += OnMasterPowersGlossary;
        }

        void OnDisable()
        {
            GameManagerMain.GetInstance().MasterPowersGlossaryEvent -= OnMasterPowersGlossary;
        }

        // Update is called once per frame
        private void Update () 
        {
            bool conditions = (!GameManagerMain.GetInstance().isGameOver && !GameManagerMain.GetInstance().isActorItemGlossaryOn &&
                !GameManagerMain.GetInstance().isGameMenuOn && !GameManagerMain.GetInstance().isMatchSummaryOn);

            if (Input.GetMouseButtonDown(2) && conditions)
                GameManagerMain.GetInstance().CallEventMasterPowersGlossary();                                                          //dispara o evento
        }

        //---------------------------------------------------------------------------------------------------------------
        // Métodos responsável por ativar o Canvas do Game Menu, atualizar o status e disparar o evento.

        public void OnMasterPowersGlossary()
        {
            if(GlossaryMenuCanvasUI != null)
            {
                GlossaryMenuCanvasUI.SetActive(!GlossaryMenuCanvasUI.activeSelf);                   // Inverte o estado atual de ativação do Canvas.
                GameManagerMain.GetInstance().isMasterPowersGlossaryOn = !GameManagerMain.GetInstance().isMasterPowersGlossaryOn;   // Inverte o estado do flag do Gerenciador de Eventos.
                                                        
            }
            else
                Debug.LogError("Nenhum Menu Atribuido ao GameManagerMasterPowersGlossary!");
        }

        //---------------------------------------------------------------------------------------------------------------
    }

    //-------------------------------------------------------------------------------------------------------------------
}


