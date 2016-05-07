/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe do tipo action, que administra o comportamento de duplo salto, utilizando as classes inputManger e InputState
Este comportamento tomará lugar do LongJump

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 22/04/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CollisionStateManager), typeof(FaceDirection), typeof(Walk))]
public class DoubleJump : ActionBehavior 
{

	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public float jumpForce = 6;												// Força do salto
	public float jumpDelay = 0.2f;											// Tempo mínimo entre os saltos
	public int 	 jumpCount = 2;												// Numero de saltos permitidos na ação

	private float lastJumpTime = 0f;                                        // Cronômetro para calculo de tempo mínimo de segundo salto
	private int   jumpsRemaning = 0;                                        // Saltos restantes

	//---------------------------------------------------------------------------------------------------------------
	// Métodos herdados de MonoBehaviour

	// Update is called once per frame
	private void Update () 
	{
		bool  canJump  = _inputState.getControlValue (inputControls [0]);			// Recebe se o controle válido foi pressionado
		float holdTime = _inputState.getControlHoldTime (inputControls [0]);		// Recebe o tempo em que o controle foi pressionado

		if(_collisionState.isGrounded)												// Testa se o gameObject esta apoiado em superficie
		{
			if(canJump && holdTime < 0.1f)											// Testa se a tecla foi pressionada e se mantida por pouco tempo // Podemos condicionar isso em caso de poder de autofire
			{
				jumpsRemaning = jumpCount -1;										// (jumpCount -1) porque o primeiro salta é executado no chão (partiu do chão, é sempre isso)
				OnJump ();															// Executa o salto
			} 
		}
		else 																		// Agora temos a habilidade de saltar no ar	
		{
			if(canJump && holdTime < 0.1f && (Time.time - lastJumpTime) > jumpDelay)// Testa também o tempo do ultimo salto
			if(jumpsRemaning > 0)
			{
				jumpsRemaning--;													// Decrementa saltos restantes
				OnJump ();															// Executa o salto no ar
			}
		}	
			
	}

	//---------------------------------------------------------------------------------------------------------------
	// Método que executa o salto

	private void OnJump()
	{
		lastJumpTime = Time.time;													// Cromometro do ultimo salto.

		if (jumpsRemaning == jumpCount -1)
		{
			Vector2 velocity = _thisBody2D.velocity;								// Recebe a velocidade atual do corpo 
			_thisBody2D.velocity = new Vector2(velocity.x, jumpForce );				// Aplica a velocidade do salto no eixo Y para os demais saltos
		}			
			//_thisBody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);	// Aplica a força para o salto
		else
		{
			//_thisBody2D.AddForce(new Vector2(0, jumpForce * 2), ForceMode2D.Impulse);
			Vector2 velocity = _thisBody2D.velocity;								// Recebe a velocidade atual do corpo 
			_thisBody2D.velocity = new Vector2(velocity.x, jumpForce );				// Aplica a velocidade do salto no eixo Y para os demais saltos

		}
	}

	//---------------------------------------------------------------------------------------------------------------
}
