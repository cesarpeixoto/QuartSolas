/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe do tipo action, que administra o comportamento de salto longo, utilizando as classes inputManger e InputState

Primeira revisão de código: (em 07/04/2016)
Resolvido o bug do salto, bem como o bug de colisões. O TimeFixed foi ajustado de 0.02 para 0.01 em Project
Settings -> Time
Remodelado o sistema de salto, para a velocidade máxima ser sempre constante, evitando saltos de tamanho variados

Tudorial de auxilio: http://poemdexter.com/blog/jump-physics-games/

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 28/03/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class LongJump : Jump 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public float longJumpDelay = 0.15f;											// Tempo em que deve manter a tecla segura para executar o salto
	public float jumpBoostMultiplier = 1.50f;									// Indice que multiplica a velocidade do salto
	public bool  canLongJump;
	public bool  isLongJumping;

	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour e Jump
	
	// Update is called once per frame
	protected override void FixedUpdate () 
	{
		bool  canJump  = _inputState.getControlValue (inputControls [0]);			// Recebe se o controle válido foi pressionado
		float holdTime = _inputState.getControlHoldTime (inputControls [0]);		// Recebe o tempo em que o controle foi pressionado

		if (!canJump)																// se o controle válido não foi acionado, não pode dar pulo longo também.
			canLongJump = false;

		if (_collisionState.isGrounded && isLongJumping)							// e estiver saltando e já foi um salto longo, não poderá aplicar novamente os efeitos de salto longo
			isLongJumping = false;

		base.FixedUpdate ();																// Chama a função da classe base;

		if(canLongJump && !_collisionState.isGrounded && holdTime > longJumpDelay)	// Testa além do padrão, o tempo em que o controle se manteve pressionado
		{
			Vector2 velocity = _thisBody2D.velocity;
			_thisBody2D.velocity = new Vector2 (velocity.x, (jumpSpeed - (jumpSpeed / 8)) * jumpBoostMultiplier); // Aplica o multiplicador de Boost no salto	
			canLongJump = false;
			isLongJumping = true;
		}
	}

	//---------------------------------------------------------------------------------------------------------------
	// Métido que executa o Salto Longo
	protected override void OnJump ()
	{
		base.OnJump ();
		canLongJump = true;
	}
		
	//---------------------------------------------------------------------------------------------------------------


}
