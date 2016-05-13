/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável por habilitar as janelas corretas para os Menus.

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 11/05/2016
=============================================================================================================== */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Managers
{
    public class GameManagerWindowManagers : MonoBehaviour 
    {
        public GameObject itemGlossary = null;
        public GameObject PowerGlossary = null;
        public GameObject ResumeMatch = null;


        // Use this for initialization
        void Start () 
        {

        }

        // Update is called once per frame
        void Update () 
        {

        }

        void OnEnable()
        {
            GameManagerMain.GetInstance().MasterPowersGlossaryEvent += OnWindowsGlossary;
            GameManagerMain.GetInstance().ActorItemGlossaryEvent += OnWindowsGlossary;
            GameManagerMain.GetInstance().MatchSummaryEvent += OnWindowsGlossary;
        }

        void OnDisable()
        {
            GameManagerMain.GetInstance().MasterPowersGlossaryEvent -= OnWindowsGlossary;
            GameManagerMain.GetInstance().ActorItemGlossaryEvent -= OnWindowsGlossary;
            GameManagerMain.GetInstance().MatchSummaryEvent -= OnWindowsGlossary;
        }

        // Poderes
        void OnWindowsGlossary()
        {
            // painel ativa se nos flags estiver true, do contrário desativa, se os flags estiverem false!!!!
            PowerGlossary.SetActive(GameManagerMain.GetInstance().isMasterPowersGlossaryOn);
            itemGlossary.SetActive(GameManagerMain.GetInstance().isActorItemGlossaryOn);
            ResumeMatch.SetActive(GameManagerMain.GetInstance().isMatchSummaryOn);
        }                   
    }
}




