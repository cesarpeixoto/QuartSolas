/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável pela administração do painel Match Summary  da partida.
O ideal era fazer separado, um para o mestre outro para o ator, para melhor controle, mas
em função do curto tempo, e do baixo numero de circunstâncias (morte do ator, tempo finalizado e falta de recrusos 
de mestre, a contagem de prontos será efetuada antes de invocar este evento), controlaremos quem ganhou um um flag

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 13/05/2016
=============================================================================================================== */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace Managers
{
    public class GameManagerMatchSummary : MonoBehaviour 
    {
        //---------------------------------------------------------------------------------------------------------------
        // Propriedades da Classe

        public GameObject GlossaryMenuCanvasUI = null;                                          // Referência para o Canvas do StatusMenu
        //public GameObject ResumePainel = null;
        public Text whoWins = null;
        public Text placar = null;
        public static bool actorWins = false;
        public float waitTime = 5.0f;
        public bool isEnable = false;


        void OnEnable()
        {
            GameManagerMain.GetInstance().MatchSummaryEvent += OnMatchSummary;
        }

        void OnDisable()
        {
            GameManagerMain.GetInstance().MatchSummaryEvent -= OnMatchSummary;
        }



        // Use this for initialization
        void Start () 
        {

        }

        // Update is called once per frame
        void Update () 
        {
            if(isEnable)
            {
                if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))              // teclas para pular a tela
                {
                    NextRound();
                }
            }
        }


        //---------------------------------------------------------------------------------------------------------------
        // Métodos responsável por ativar o Canvas do Status Menu, atualizar o status e disparar o evento.

        public void OnMatchSummary()
        {
            if(GlossaryMenuCanvasUI != null)
            {
                isEnable = true;
                GlossaryMenuCanvasUI.SetActive(!GlossaryMenuCanvasUI.activeSelf);                   // Inverte o estado atual de ativação do Canvas.
                GameManagerMain.GetInstance().isMatchSummaryOn = !GameManagerMain.GetInstance().isMatchSummaryOn;   // Inverte o estado do flag do Gerenciador de Eventos.
                HUDRoundTime.inGame = false;
                // Tratar os textos de quem ganhou quem perdeu, ativação do painel, carregar nova fase, tudo aqui!!!!!!!!!!!
                // Quando este evento acontece, nunca estará em outros menus, portanto não precisa validar
                if(actorWins)
                {
                    GameStateManager.GetInstance().ActorPoints++;
                    whoWins.text = "Ator Ganhou!";
                    placar.text = "Ator " + GameStateManager.GetInstance().ActorPoints + " X " + GameStateManager.GetInstance().MasterPoints + " Mestre";
                    Invoke("NextRound", waitTime);
                }
                else
                {
                    GameStateManager.GetInstance().MasterPoints++;
                    whoWins.text = "Mestre Ganhou!";
                    placar.text = "Ator " + GameStateManager.GetInstance().ActorPoints + " X " + GameStateManager.GetInstance().MasterPoints + " Mestre";

                    
                    Invoke ("NextRound", waitTime);
                }

            }
            else
                Debug.LogError("Nenhum Menu Atribuido ao GameManagerMasterPowersGlossary!");
        }

        private void NextRound()
        {
            isEnable = false;
            GameStateManager.GetInstance().NextScene();
        }

        //---------------------------------------------------------------------------------------------------------------

    }

}

