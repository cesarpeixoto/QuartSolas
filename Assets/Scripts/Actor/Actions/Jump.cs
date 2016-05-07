/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe do tipo action, que administra o comportamento de saltar, utilizando as classes inputManger e InputState
Serve de classe base para LongJump

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 27/03/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class Jump : ActionBehavior 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public float jumpSpeed = 380f;											// Velocidade do corpo ao saltar

	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour


	// Update is called once per frame
	protected virtual void FixedUpdate () 
	{
		bool  canJump  = _inputState.getControlValue (inputControls [0]);		// Recebe se o controle válido foi pressionado
		float holdTime = _inputState.getControlHoldTime (inputControls [0]);	// Recebe o tempo em que o controle foi pressionado

		if(_collisionState.isGrounded)											// Testa se o gameObject esta apoiado em superficie
			if(canJump && holdTime < 0.1f)										// Testa se a tecla foi pressionada e se mantida por pouco tempo // Podemos condicionar isso em caso de poder de autofire
				OnJump ();														// Executa o salto

	}

	// Método que executa o salto
	protected virtual void OnJump()
	{
		//Vector2 velocity = _thisBody2D.velocity;									// Recebe a velocidade atual do corpo 
		//_thisBody2D.velocity = new Vector2(velocity.x, jumpSpeed);					// Aplica a velocidade do salto no eixo Y
		_thisBody2D.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);

		//_thisBody2D.AddForce(new Vector2(0f, 200f));
	}

	//---------------------------------------------------------------------------------------------------------------
}
