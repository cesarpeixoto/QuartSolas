/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe do item coletável - Arma.


//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 04/04/2016
=============================================================================================================== */


using UnityEngine;
using System.Collections;

public class ActorGun : Collectable 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public GameObject projectilePrefab = null;

	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

	void Awake ()
	{
		itemId = ItemID.Gun;												// Id do item
	}		

	//---------------------------------------------------------------------------------------------------------------
	// Metodos responsável responsável pela coleta do item, identificação e ativação do script de comportamento

	protected override void OnCollect (GameObject target)
	{
		//target.AddComponent<ActorGunBehaviour> ();

		ActorStateManager equipBehavior = target.GetComponent<ActorStateManager> ();

		if (equipBehavior.CurrentItemId != null)							// Confere se existe algum item equipado.
			equipBehavior.CurrentItemId.enabled = false;					// Se houver, desabilita o script de comportamento.

        equipBehavior.CurrentItemId = target.GetComponent<ActorGunBehaviour> ();	// Passa a referencia para controle interno da classe
		target.GetComponent<ActorGunBehaviour>().enabled = true;

	}
}





//target.GetComponent<ActorGunBehaviour>().itemId = itemId;
//target.GetComponent<ActorGunBehaviour>().projectilePrefab = projectilePrefab;


	/*
		ActorStateManager equipBehavior = target.GetComponent<ActorStateManager> ();
		if (equipBehavior != null)
			//equipBehavior.currentItemId = itemId; // AQUI PRECISA PASSAR A PORRA DO OBJETO ... INSTANCIAR ELE

		ShootProjectile shootBehavior = target.GetComponent<ShootProjectile> ();
		if(shootBehavior != null)
		{
			shootBehavior.projectilePrefab = projectilePrefab;
		}

	*/