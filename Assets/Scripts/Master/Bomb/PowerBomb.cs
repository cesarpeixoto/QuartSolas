
/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe reponsável pela invocação do poder de criar bombas instantâneas no mapa.



//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 12/04/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class PowerBomb : MasterBehaviour 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public GameObject spawnavel = null;


	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MasterBehaviour

	/*
	// Use this for initialization
	protected override void Awake () 
	{
		base.Awake ();
		delayTime = 5;
		quantity = 3;
	}

	// Update is called once per frame
	protected override void Update ()
	{
		base.Update ();
	} 

	*/
	//---------------------------------------------------------------------------------------------------------------

	public override void Behaviour ()
	{
		Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (position, Vector2.zero);
		if (hit.collider != null)													// Se atingiu um colisor, sai da função
			return;

		if (!hit) // se não atingiu nada
		{ 
			GameObject.Instantiate (spawnavel, position, Quaternion.identity);
			MouseManager.masterPower = null;										// Desativa a habilidade no MouseManager
			//PowersManager.UpdateResource(PowersManager.ConstPowerList.Bomb);
		}
	}

	//---------------------------------------------------------------------------------------------------------------
}
