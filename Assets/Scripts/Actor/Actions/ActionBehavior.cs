/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe abstrata para ser a base de todos os actions que serão programados.

Tecnica adaptada de um tutorial de Lynda.com, de autoria de Jesse Freeman

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 22/03/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public abstract class ActionBehavior : MonoBehaviour 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe
	public Controls[] inputControls;


	protected InputState _inputState;								// Referência para um componente InputState
	protected Rigidbody2D _thisBody2D;								// Referência para um componente RigidBody2D
	protected CollisionStateManager _collisionState;						// Referência para um componente CollisionState

	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

	protected virtual void Awake()
	{
		_inputState     = GetComponent<InputState> ();				// Inicializa a referência
		_thisBody2D     = GetComponent<Rigidbody2D> ();				// Inicializa a referência
		_collisionState = GetComponent<CollisionStateManager> ();			// Inicializa a referência
	}
		
	//---------------------------------------------------------------------------------------------------------------
}
