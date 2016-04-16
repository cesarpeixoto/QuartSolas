/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe do item tiro da arma.


//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 01/04/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public Vector2 velocity = new Vector2 (250, 0);
	private Rigidbody2D _thisBody2D;

	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

	void Awake()
	{
		_thisBody2D = GetComponent<Rigidbody2D> ();
	}


	// Use this for initialization
	void Start () 
	{
		float startVelocityX = velocity.x * transform.localScale.x;
		_thisBody2D.velocity = new Vector2 (startVelocityX, 0);
	}

	//---------------------------------------------------------------------------------------------------------------
	// Método que destroi o objeto quando ocorre colisão

	void OnCollisionEnter2D(Collision2D target)
	{
		Destroy (gameObject);
	}

	//---------------------------------------------------------------------------------------------------------------
}
