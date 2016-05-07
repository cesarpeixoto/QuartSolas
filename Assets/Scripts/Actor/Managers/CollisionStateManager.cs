/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável por administrar as colisões abstratas. Através destas, descobrimos se o gameObject está em 
contato com o solo ou se houve contato lateral.

Tecnica adaptada de um tutorial de Lynda.com, de autoria de Jesse Freeman

Primeira revisão de código: (em 07/04/2016)
Melhor adequação do nome da classe, e pequenos ajustes e otimizações para configurar diretamente pelo inspector.
As coordenadas são adquiridas proporcionalmente aos colisores

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 03/04/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider2D), typeof(CircleCollider2D), typeof(ActorStateManager))]
public class CollisionStateManager : MonoBehaviour 
{

	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public LayerMask collisionLayer;
	public bool isGrounded;												// Flag para saber se esta apoiado em superficie

	public bool leftCollided = false;
	public bool rightCollided = false;

	public float collisionBottomRadius = 10.00f;						// Raio do Colisior Grounded
	public Vector2 bottomPosition = new Vector2(-0.01f, -0.18f);		// Offset para colisor Grounded

	public float sizeOffset = 0.001f;									// Offset para reduzir as extremidades
	public float bottomOffset = 0.001f;									// Offset para compensar a posição do CircleCollider2D

	public Color debugCollisionColor = Color.red;						// Cor dos colisores para debug

	// Estes dois precisa ver melhor

	private BoxCollider2D _thisBoxCollider2D = null;
	private CircleCollider2D _thisCircleCollider2D = null;



	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

	void Awake()
	{
		_thisBoxCollider2D = GetComponent<BoxCollider2D> ();
		_thisCircleCollider2D = GetComponent<CircleCollider2D> ();
	}
		
	void FixedUpdate()
	{
		Vector2 position = bottomPosition;								// referencia para bottomPosition;
		position.x += transform.position.x + 0.01f;								// Adiciona o offset em X do gameObject
		position.y += transform.position.y;								// Adiciona o offset em Y do gameObject

		isGrounded = Physics2D.OverlapCircle (position, collisionBottomRadius, collisionLayer); // Detecta colisão para o chão
		leftCollided = false;
		rightCollided = false;

		if (!isGrounded)
		{
			Vector2 pointA = Vector2.zero;									// Vetor de auxilio para detectar colisão
			Vector2 pointB = Vector2.zero;									// Vetor de auxilio para detectar colisão

			// Calculo da area de colisão do lado direito
			pointA.x = _thisBoxCollider2D.bounds.max.x;
			pointB.x = _thisBoxCollider2D.bounds.max.x + 0.005f;
			pointA.y = (_thisBoxCollider2D.bounds.max.y) - sizeOffset;

			float groundOffset = isGrounded ? 0.005f : 0.0f;
			pointB.y = (_thisBoxCollider2D.bounds.min.y - (_thisCircleCollider2D.radius / 2)) + groundOffset; 

			rightCollided = Physics2D.OverlapArea (pointA, pointB, collisionLayer);				// Detecta colisão do lado direito
			Debug.DrawLine (pointA, pointB);													// Desenha esta linha para debug

			// Calculo da area de colisão do lado direito
			pointA.x = _thisBoxCollider2D.bounds.min.x;
			pointB.x = _thisBoxCollider2D.bounds.min.x - 0.005f;

			leftCollided = Physics2D.OverlapArea (pointA, pointB, collisionLayer);  			// Detecta colisão para lateral esquerda
			Debug.DrawLine (pointA, pointB);													// Desenha esta linha para debug
		}			
	}

	//---------------------------------------------------------------------------------------------------------------

	void OnDrawGizmos()
	{
		Gizmos.color = debugCollisionColor;
		Vector2 position = bottomPosition;							// referencia para bottomPosition;
		position.x += transform.position.x + 0.01f;							// Adiciona o offset em X do gameObject
		position.y += transform.position.y;							// Adiciona o offset em Y do gameObject
		Gizmos.DrawWireSphere (position, collisionBottomRadius);	// Desenha o colisor do chão para debub
	}

	//---------------------------------------------------------------------------------------------------------------
}
