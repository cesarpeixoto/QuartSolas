/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe acessária para inserir o comportamento de Game Pause nos evetos pertinentes.

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 08/05/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

namespace Managers
{
    public class GameManagerPauseBehaviour : MonoBehaviour 
    {
        //---------------------------------------------------------------------------------------------------------------
        // Propriedades da Classe
        
        private bool isPaused;                                                      // Estado do Jogo

        //---------------------------------------------------------------------------------------------------------------
        // Métodos herdados de MonoBehaviour                 

        private void OnEnable()
        {
            // Atribui os métodos aos Callbacks
            GameManagerMain.GetInstance().GameMenuEvent               += OnGamePause;             
            GameManagerMain.GetInstance().ActorItemGlossaryEvent      += OnGamePause;
            GameManagerMain.GetInstance().MasterPowersGlossaryEvent   += OnGamePause;
            GameManagerMain.GetInstance().MatchSummaryEvent           += OnGamePause;
        }

        private void OnDisable()
        {
            // Retira os métodos dos referêntes Callbacks
            GameManagerMain.GetInstance().GameMenuEvent               -= OnGamePause;             
            GameManagerMain.GetInstance().ActorItemGlossaryEvent      -= OnGamePause;
            GameManagerMain.GetInstance().MasterPowersGlossaryEvent   -= OnGamePause;
            GameManagerMain.GetInstance().MatchSummaryEvent           -= OnGamePause;
        }

        //---------------------------------------------------------------------------------------------------------------
        // Método responsável pelo comportamento GamePause

        private void OnGamePause()
        {
            if(isPaused)
            {
                Time.timeScale = 1;                                                 // Configura a escala de tempo para tempo real.
                isPaused = false;                                                   // Atualiza o estado do jogo.
            }
            else
            {
                Time.timeScale = 0;                                                 // Configura a escala de tempo para congelado.
                isPaused = true;                                                    // Atualiza o estado do jogo.
            }   
        }

        //---------------------------------------------------------------------------------------------------------------
    }

    //-------------------------------------------------------------------------------------------------------------------
}
    