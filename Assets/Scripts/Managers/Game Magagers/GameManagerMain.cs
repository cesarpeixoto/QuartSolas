/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Gerenciador de eventos central do jogo, responsável pela transição entre os vários estados do jogo.

    |- 
    |
    |
    |

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 08/05/2016
=============================================================================================================== */


using UnityEngine;
using System.Collections;

namespace Managers
{
    public class GameManagerMain : MonoBehaviour 
    {
        //---------------------------------------------------------------------------------------------------------------
        // Propriedades da Classe

        public static GameManagerMain _Instance = null;                                  // Instância global.
        public static GameManagerMain GetInstance() { return _Instance; }
        // Eventos:
        public delegate void GameManagerEventHandler();                                 // Tipo Callback para atribuir métodos aos eventos.
        public event GameManagerEventHandler GameMenuEvent;                             // Transição para o menu do jogo.
        public event GameManagerEventHandler ActorItemGlossaryEvent;                    // Transição para o glossário de itens do Ator.
        public event GameManagerEventHandler MasterPowersGlossaryEvent;                 // Transição para o glossário de poderes do Mestre.
        public event GameManagerEventHandler MatchSummaryEvent;                         // Transição para o resumo da partida;
        public event GameManagerEventHandler NextLevelEvent;                            // Transição para o próximo cenário.
        public event GameManagerEventHandler RestartLevelEvent;                         // Transição para reiniciar a partida.
        public event GameManagerEventHandler GoToMainMenuEvent;                         // Transição para o menu principal.
        public event GameManagerEventHandler GameOverEvent;                             // Transição para o fim do jogo.

        // Flags:
        public bool isGameOver;
        public bool isActorItemGlossaryOn;
        public bool isMasterPowersGlossaryOn;
        public bool isMatchSummaryOn;
        public bool isGameMenuOn;

        //---------------------------------------------------------------------------------------------------------------
        // Métodos herdados de MonoBehaviour 

        // Use this for initialization
        private void Awake () 
        {
            if(_Instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            _Instance = this;
        }

        //---------------------------------------------------------------------------------------------------------------
        // Método responsável pela chamada do evento GameMenu

        public void CallEventGameMenu()
        {
            if (GameMenuEvent != null)                           
                GameMenuEvent();                            
            else
                Debug.LogError("Nenhum método foi atribuido ao evento GameMenuEvent!");
        }

        //---------------------------------------------------------------------------------------------------------------
        // Método responsável pela chamada do evento Glossário de itens do Ator

        public void CallEventActorItemGlossary()
        {
            if (ActorItemGlossaryEvent != null)
                ActorItemGlossaryEvent();
            else
                Debug.LogError("Nenhum método foi atribuido ao evento ActorItemGlossaryEvent!");
        }

        //---------------------------------------------------------------------------------------------------------------
        // Método responsável pela chamada do evento Glossário de poderes do Mestre

        public void CallEventMasterPowersGlossary()
        {
            if (MasterPowersGlossaryEvent != null)
                MasterPowersGlossaryEvent();
            else
                Debug.LogError("Nenhum método foi atribuido ao evento MasterPowersGlossaryEvent!");
        }

        //---------------------------------------------------------------------------------------------------------------
        // Método responsável pela chamada do evento resumo da partida

        public void CallEventMatchSummary()
        {
            if (MatchSummaryEvent != null)
                MatchSummaryEvent();
            else
                Debug.LogError("Nenhum método foi atribuido ao evento MatchSummaryEvent!");
        }

        //---------------------------------------------------------------------------------------------------------------
        // Método responsável pela chamada do evento ir para o próximo cenário

        public void CallEventNextLevel()
        {
            if (NextLevelEvent != null)
                NextLevelEvent();
            else
                Debug.LogError("Nenhum método foi atribuido ao evento NextLevelEvent!");
        }

        //---------------------------------------------------------------------------------------------------------------
        // Método responsável pela chamada do evento reiniciar a partida no cenário atual

        public void CallEventRestartLevel()
        {
            if (RestartLevelEvent != null)
                RestartLevelEvent();
            else
                Debug.LogError("Nenhum método foi atribuido ao evento RestartLevelEvent!");
        }

        //---------------------------------------------------------------------------------------------------------------
        // Método responsável pela chamada do evento ir para o menu principal

        public void CallEventGoToMainMenu()
        {
            if (GoToMainMenuEvent != null)
                GoToMainMenuEvent();
            else
                Debug.LogError("Nenhum método foi atribuido ao evento GoToMainMenuEvent!");
        }

        //---------------------------------------------------------------------------------------------------------------
        // Método responsável pela chamada do evento GameOver

        public void CallEventGameOver()
        {
            if (GameOverEvent != null)
            {
                isGameOver = true;
                GameOverEvent();
            }                
            else
                Debug.LogError("Nenhum método foi atribuido ao evento GameOverEvent!");
        }
            
        //---------------------------------------------------------------------------------------------------------------

    }

    //-------------------------------------------------------------------------------------------------------------------
}


