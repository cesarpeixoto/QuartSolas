/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável pelo gerenciamento das animações do Actor, de acordo com suas ações
Tecnica adaptada de um tutorial de Lynda.com, de autoria de Jesse Freeman

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 26/03/2016
=============================================================================================================== */


using UnityEngine;
using System.Collections;

//---------------------------------------------------------------------------------------------------------------
// Enum que representa os etados de animação
public enum AnimationState {Idle, Walk, Jump, Dead}

[RequireComponent(typeof(Animator), typeof(ActorStateManager), typeof(CollisionStateManager))]
public class ActorAnimationManager : MonoBehaviour 
{

	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe
	//private InputState _inputState;							// Referência para um componente InputState
	private Animator _animator;									// Referência para um componente Animator
	private CollisionStateManager _collisionState;				// Referência para um componente CollisionState
	private ActorStateManager _actorState;						// Referência para um componente ActorStateManager

	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

	void Awake()
	{
		//_inputState     = GetComponent<InputState> ();			// Inicializa a referência
		_animator       = GetComponent<Animator> ();				// Inicializa a referência
		_collisionState = GetComponent<CollisionStateManager> ();	// Inicializa a referência
		_actorState 	= GetComponent<ActorStateManager> ();		// Inicializa a referência
	}
		
	// Update is called once per frame
	void Update () 
	{
		if(!ActorStateManager.isDead)
		{
			if ( _collisionState.isGrounded && _actorState.absolutVelocityX == 0) 		// Animação é Idle só acionada se estiver no chão, e a velocidade absoluta em X for zero
				changeAnimationState (AnimationState.Idle);

			else if (_actorState.absolutVelocityX > 0 && _collisionState.isGrounded)	// Se a velocidade absoluta em X é maior que zero, o estado da animação é Walk
				changeAnimationState (AnimationState.Walk);

			else if (_actorState.absolutVelocityY > 0 && !_collisionState.isGrounded)	// Se a velocidade absoluta em Y é maior que zero, o estado da animação é Jump
				changeAnimationState (AnimationState.Jump);			
		}
		else if (ActorStateManager.isDead)															
		{
			changeAnimationState (AnimationState.Dead);
			die ();
		}
			
	}

	//---------------------------------------------------------------------------------------------------------------
	// Métodos que procede a alteração das animações

	void changeAnimationState(AnimationState value)
	{
		_animator.SetInteger ("AnimationState", (int)value);						// Altera o set de animações no Animator
	}

	//---------------------------------------------------------------------------------------------------------------
	// Métodos do tipo trigger, invocado após a animação da morte do Ator.

	int die()
	{
		_actorState.die ();
		return 0;
	}
		
	//---------------------------------------------------------------------------------------------------------------
}
