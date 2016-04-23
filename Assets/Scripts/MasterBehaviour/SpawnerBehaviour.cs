/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe abstrata para ser a base de todos os actions do Mestre relacionado a invocação de objetos no mapa, que serão programados.

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 03/04/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public abstract class SpawnerBehaviour : MonoBehaviour 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public float lifeTime = 0.00f; 							// Tempo de vida da ação;
	public bool onInpact = false;
	protected float deltaTime = 0.00f; 						// Tempo decorrido
	private bool runing = false;

	protected BoxCollider2D _thisBoxCollider2D = null;


	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

	protected virtual void Start()
	{
		_thisBoxCollider2D = GetComponent<BoxCollider2D> ();
	}

	// Update is called once per frame
	protected virtual void Update () 
	{
		if (onInpact)
			return;
		deltaTime += Time.deltaTime;						// Atualiza o tempo de vida

		if (lifeTime <= deltaTime && !runing)							// Se alcançou o tempo de vida, chama função behaviour
		{
			behaviour ();
			runing = true;
		}
	}

	protected virtual void OnCollisionEnter2D(Collision2D other)
	{
		if (onInpact)
			behaviour ();
	}

	//---------------------------------------------------------------------------------------------------------------
	// Método abstrato puro

	public abstract void behaviour ();					// Irá receber o comportamento a ser aplicado

	//---------------------------------------------------------------------------------------------------------------
}
