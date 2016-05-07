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
		//target.AddComponent<ActorGunBehaviour> ();

        ItemActionAbstractBehaviour temp = new ItemActionAbstractBehaviour();
        temp.itemId = ItemID.Shield;
        target.GetComponent<ActorStateManager>().CurrentItemId = temp;    //.isShieled = true;
	}

}
