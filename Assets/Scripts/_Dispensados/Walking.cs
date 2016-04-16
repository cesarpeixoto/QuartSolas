/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe do tipo action, que administra o comportamento de caminhar, utilizando as classes inputManger e InputState

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 22/03/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class Walking : MonoBehaviour 
{
	public float speed = 5f;
	public Controls[] input;

	private Rigidbody2D actorBody2d;
	private InputState inputState;


	// Use this for initialization
	void Start () 
	{
		actorBody2d = GetComponent<Rigidbody2D> ();						// Inicializa a referência
		inputState  = GetComponent<InputState>  ();						// Inicializa a referência
	}
	
	// Update is called once per frame
	void Update () 
	{
		bool right = inputState.getControlValue (input [0]);			// recebe o estado do controle setado na primeira posição no inpector
		bool left  = inputState.getControlValue (input [1]);			// recebe o estado do controle setado na segunda posição no inpector
		float velocityX = speed;

		if (right || left) 												// testa se os controles válidos foram pressionados
			velocityX *= left ? -1 : 1;									// Se foram, a velocidade negativa para andar para esquerda, positiva para andar para direita
		else
			velocityX = 0;												// Se não foram, a velocidade é zero

		actorBody2d.velocity = new Vector2 (velocityX, actorBody2d.velocity.y);  // Aplica a velocidade no corpo
	}
}
