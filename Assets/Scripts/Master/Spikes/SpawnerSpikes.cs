/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe Classe responsável pelo comportamento dos espinhos.

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 03/04/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class SpawnerSpikes : SpawnerBehaviour 
{
    //---------------------------------------------------------------------------------------------------------------
    // Metodos herdados de MonoBehaviour
	
	protected override void Start ()
	{
        base.Start();
        deltaTime = 0.0f;
        _active = true;
	}
        
	protected override void Update ()
	{                
		deltaTime += Time.deltaTime;						// Atualiza o tempo de vida

		if (lifeTime <= deltaTime)							// Se alcançou o tempo de vida, chama função behaviour
			Destroy (this.gameObject);		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Actor"))                      // Se o Ator pisar no colisor superior, sofrerá dano
        {
            //GameObject temp = GameObject.FindGameObjectWithTag ("Actor");
            other.GetComponent<ActorStateManager>().OnHit();
        }
    }

    //---------------------------------------------------------------------------------------------------------------
    // Metodo herdado de MasterBehaviour, sem utilização nesta classe específica

	public override void behaviour ()
	{


	}

    //---------------------------------------------------------------------------------------------------------------
}
