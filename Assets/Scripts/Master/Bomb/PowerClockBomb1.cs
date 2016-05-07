/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe reponsável pela invocação do poder de criar bombas relágio de 1 segundo.

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 22/04/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class PowerClockBomb1 : MasterBehaviour 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public GameObject spawnavel = null;

	//---------------------------------------------------------------------------------------------------------------
	// Método do comportamento da Bomba

	public override void Behaviour ()
	{
		Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (position, Vector2.zero);
		if (hit.collider != null)													// Se atingiu um colisor, sai da função
			return;

		if (!hit) // é estranho, mas com raycast null = true
		{ 
			GameObject.Instantiate (spawnavel, position, Quaternion.identity);
			MouseManager.masterPower = null;										// Desativa a habilidade no MouseManager
			//PowersManager.UpdateResource(PowersManager.ConstPowerList.ClockBomb1);
		}
	}

	//---------------------------------------------------------------------------------------------------------------
}

