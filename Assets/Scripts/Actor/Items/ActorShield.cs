/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe do item coletável - Escudo.


//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 08/04/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class ActorShield : Collectable 
{
	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

	void Awake ()
	{
		itemId = ItemID.Shield;												// Id do item
	}	


	protected override void OnCollect (GameObject target)
	{
        ActorStateManager equipBehavior = target.GetComponent<ActorStateManager> ();

        if (equipBehavior.CurrentItemId != null)                            // Confere se existe algum item equipado.
            equipBehavior.CurrentItemId.enabled = false;                    // Se houver, desabilita o script de comportamento.

        equipBehavior.isShieled = true;
        //equipBehavior.CurrentItemId = target.GetComponent<ActorShieldBehaviour> ();    // Passa a referencia para controle interno da classe
        target.GetComponent<ActorShieldBehaviour>().enabled = true;


        //ItemActionAbstractBehaviour temp = new ItemActionAbstractBehaviour();
        //temp.itemId = ItemID.Shield;
        //target.GetComponent<ActorStateManager>().CurrentItemId = temp;    //.isShieled = true;
	}

}
