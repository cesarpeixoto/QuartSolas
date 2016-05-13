/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável pela administração do painel Glossário de itens do Ator.

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 11/05/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

namespace Managers
{
    public class GameManagerActorItensGlossary : MonoBehaviour 
    {

        //---------------------------------------------------------------------------------------------------------------
        // Propriedades da Classe

        public GameObject GlossaryMenuCanvasUI = null;                                          // Referência para o Canvas do GameMenu

        //---------------------------------------------------------------------------------------------------------------
        // Métodos herdados de MonoBehaviour 

        void OnEnable()
        {
            GameManagerMain.GetInstance().ActorItemGlossaryEvent += OnActorItemGlossary;
        }

        void OnDisable()
        {
            GameManagerMain.GetInstance().ActorItemGlossaryEvent -= OnActorItemGlossary;
        }

        // Update is called once per frame
        private void Update () 
        {
            bool conditions = (!GameManagerMain.GetInstance().isGameOver && !GameManagerMain.GetInstance().isMasterPowersGlossaryOn &&
                !GameManagerMain.GetInstance().isGameMenuOn && !GameManagerMain.GetInstance().isMatchSummaryOn);

            if (Input.GetKeyDown(KeyCode.H) && conditions)
                GameManagerMain.GetInstance().CallEventActorItemGlossary();                                                          //dispara o evento
        }

        //---------------------------------------------------------------------------------------------------------------
        // Métodos responsável por ativar o Canvas do Game Menu, atualizar o status e disparar o evento.

        public void OnActorItemGlossary()
        {
            if(GlossaryMenuCanvasUI != null)
            {
                GlossaryMenuCanvasUI.SetActive(!GlossaryMenuCanvasUI.activeSelf);                   // Inverte o estado atual de ativação do Canvas.
                GameManagerMain.GetInstance().isActorItemGlossaryOn = !GameManagerMain.GetInstance().isActorItemGlossaryOn;   // Inverte o estado do flag do Gerenciador de Eventos.

            }
            else
                Debug.LogError("Nenhum Menu Atribuido ao GameManagerMasterPowersGlossary!");
        }

        //---------------------------------------------------------------------------------------------------------------
    }

    //-------------------------------------------------------------------------------------------------------------------
}


