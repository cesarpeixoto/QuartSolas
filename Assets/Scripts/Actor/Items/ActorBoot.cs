/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe do item coletável - Botas.


//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 11/05/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class ActorBoot : Collectable 
{

    //---------------------------------------------------------------------------------------------------------------
    // Metodos herdados de MonoBehaviour

    void Awake ()
    {
        itemId = ItemID.Boot;                                                // Id do item
    }       

    //---------------------------------------------------------------------------------------------------------------
    // Metodos responsável responsável pela coleta do item, identificação e ativação do script de comportamento

    protected override void OnCollect (GameObject target)
    {
        //target.AddComponent<ActorGunBehaviour> ();

        ActorStateManager equipBehavior = target.GetComponent<ActorStateManager> ();

        if (equipBehavior.CurrentItemId != null)                            // Confere se existe algum item equipado.
            equipBehavior.CurrentItemId.enabled = false;                    // Se houver, desabilita o script de comportamento.

        equipBehavior.CurrentItemId = target.GetComponent<ActorBootBehaviour> ();    // Passa a referencia para controle interno da classe
        target.GetComponent<ActorBootBehaviour>().enabled = true;

    }
}
