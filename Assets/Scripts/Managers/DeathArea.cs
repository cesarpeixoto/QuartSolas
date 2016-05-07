/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável pela Deadh Area, que mata o Ator quando ele cai dos abismos


//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 04/04/2016
=============================================================================================================== */

using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathArea : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Actor"))
		{
			ActorStateManager.isDead = true;
		}
        else
            Destroy(other.gameObject);
	}
}

