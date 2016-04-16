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
	protected float deltaTime = 0.00f; 						// Tempo decorrido
	private bool runing = false;

	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

	// Update is called once per frame
	protected virtual void Update () 
	{
		deltaTime += Time.deltaTime;						// Atualiza o tempo de vida

		if (lifeTime <= deltaTime && !runing)							// Se alcançou o tempo de vida, chama função behaviour
		{
			behaviour ();
			runing = true;
		}
	}

	//---------------------------------------------------------------------------------------------------------------
	// Método abstrato puro

	public abstract void behaviour ();					// Irá receber o comportamento a ser aplicado

	//---------------------------------------------------------------------------------------------------------------
}
