/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe reponsável pela invocação do poder de seleção de plataformas no mapa

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 12/04/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class PowerSelection : MasterBehaviour 
{

	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	private Interactive selecton = null;  // A principio vamos trabalhar apenas com este!!!!????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????


	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MasterBehaviour

	// Use this for initialization
	protected override void Awake () 
	{
		base.Awake ();
		delayTime = 2;
		quantity = 5;
	}

	// Update is called once per frame
	protected override void Update ()
	{
		base.Update ();
	} 

	//---------------------------------------------------------------------------------------------------------------

	public override void Behaviour ()
	{
		// TODO: se tiver lista, checar se tem algo na lista e deselecionar tudo e limpar a lista de seleção !!!!!!!!!!!!!
		if (selecton != null)  // Se tiver algo selecionado, ele vai deselecionar!!!!
		{
			selecton.deselect ();
			selecton = null;
		}

		Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (position, Vector2.zero);
		if (hit.collider == null)													// Se não atingiu um colisor, sai da função
			return;																	// Aqui volta o tempo? ou erro fudeu??????????????????????????????????????????????????????????????????????????????????????????????

		Interactive interactive = hit.transform.GetComponent<Interactive> ();		// Pega o objeto atingido apenas se for do tipo Interactive
		if (interactive == null)													// Se for não Interactive, sai da função
			return;

		// TODO: se usar lista, adiciona ele na lista
		selecton = interactive;    													// Se for Interactive, marca a seleção nele
		selecton.select();	
		mouseManager.masterPower = null;											// Desativa a habilidade no MouseManager
	}

	//---------------------------------------------------------------------------------------------------------------
}
