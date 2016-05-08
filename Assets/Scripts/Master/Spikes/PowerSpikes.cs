
/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe reponsável pela invocação do poder de criar espinhos no mapa.



//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 23/04/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class PowerSpikes : MasterBehaviour 
{

	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe
    public float lifeTime = 10;
	public GameObject spawnavel = null;

	//---------------------------------------------------------------------------------------------------------------
	// Método que cria o objeto na posição do mouse, quando ocorre um clique na tela

	public override void Behaviour ()
	{
		Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (position, Vector2.zero);
		if (hit.collider != null)													// Se atingiu um colisor, sai da função
			return;

		if (!hit) // Se não clicou em colisor, ele fará o spawn
		{ 
            GameObject temp = (GameObject)Instantiate (spawnavel, position, Quaternion.identity);
            temp.GetComponent<SpawnerSpikes>().lifeTime = lifeTime;
            MouseManager.masterPower = null;										// Desativa a habilidade no MouseManager

		}
	}

	//---------------------------------------------------------------------------------------------------------------
}
