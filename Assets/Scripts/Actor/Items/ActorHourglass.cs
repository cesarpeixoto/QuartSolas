/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe do item coletável - Ampubleta.


//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 11/05/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class ActorHourglass : Collectable 
{
    public float timeDiscount = 10;
    public HUDRoundTime hudTimer = null;

    //---------------------------------------------------------------------------------------------------------------
    // Metodos herdados de MonoBehaviour

    void Awake ()
    {
        itemId = ItemID.hourglass;                                                // Id do item
    }       

    //---------------------------------------------------------------------------------------------------------------
    // Metodos responsável responsável pela coleta do item, identificação e ativação do script de comportamento

    protected override void OnCollect (GameObject target)
    {
        //target.AddComponent<ActorGunBehaviour> ();

        hudTimer.time -= timeDiscount;
    }
}
