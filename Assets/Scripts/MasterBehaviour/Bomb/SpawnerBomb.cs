/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe reponsável pelo comportamento das bombas criadas no mapa.
Ciclo de vida é herdado da classe base, e representa o tempo que a bomba leva para explodir.

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 03/04/2016
=============================================================================================================== */


using UnityEngine;
using System.Collections;

public class SpawnerBomb : SpawnerBehaviour 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public float explosionRadius = 0.13f;					// Raio da explosão
	public LayerMask collisionLayer;						// Layer do Ator, onde só tenha ele para colidir
	public GameObject explosionParticles = null;			// Prefab das partículas de explosão

	//---------------------------------------------------------------------------------------------------------------
	// Método de comportamento herdado, com o comportamento da explosão da bomba

	public override void behaviour ()
	{
		if (explosionParticles != null)
		{
			GameObject particles = (GameObject)Instantiate (explosionParticles, this.transform.position, this.transform.rotation);	// Cria instancia das partículas

			Vector2 position = Vector2.zero;				// Mesmo processo da classe CollisionState
			position.x += transform.position.x;				
			position.y += transform.position.y;				

			bool boom = Physics2D.OverlapCircle (position, explosionRadius, collisionLayer);

			if(boom)										// Se houve colisão o Ator morre
			{
				GameObject temp = GameObject.FindGameObjectWithTag ("Actor");
				temp.GetComponent<ActorStateManager> ().OnHit ();
			}
				

			Destroy (this.gameObject);						// Destroi a bomba
			Destroy (particles, 1f);						// Destroi as partículas depois de aguardar 2 segundos
		}

	}

	//---------------------------------------------------------------------------------------------------------------
	// Método de debug para visualizar o raio de explosão da bomba

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Vector2 position = Vector2.zero;				// referencia para bottomPosition;
		position.x += transform.position.x;				// Adiciona o offset em X do gameObject
		position.y += transform.position.y;				// Adiciona o offset em Y do gameObject
		Gizmos.DrawWireSphere (position, explosionRadius);
	}

	//--------------------------------------------------------------------------------------------------------------

}
