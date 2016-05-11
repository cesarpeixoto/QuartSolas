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

    public float distanceToActive = 2.5f;
    public LayerMask collisionMask;
    public int RayCount = 4;
    private CircleCollider2D _thisCollider = null;
    //private bool _active = false;

	//---------------------------------------------------------------------------------------------------------------
	// Método de comportamento herdado, com o comportamento da explosão da bomba

    protected override void Start()
    {
        base.Start();
        _thisCollider = GetComponent<CircleCollider2D>();
        _active = CheckDistance(_thisCollider);
        //if (!_active)
           // onInpact = false;
    }

    protected override void Update()
    {
        base.Update();
        //CheckDistance(_thisCollider);
    }



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
			Destroy (particles, 1f);						// Destroi as partículas depois de aguardar 1 segundos
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



    protected bool CheckDistance(Collider2D collider)
    {

        bool result = true;                                      // Função retorna o espaço para corrigir a posição do objeto!!!!!!!!!!!

        RayCastOrigins origins = GetRayCastOrigins(collider);
        float horizontalSpace = origins.size.x / (RayCount - 1);
        //float verticalSpace = origins.size.y / (RayCount - 1);

        for (int i = 0; i < RayCount; i++)              // Parte de baixo
        {
            Debug.DrawRay((origins.bottomLeft) + Vector2.right * horizontalSpace * i, Vector2.down, Color.cyan);
            RaycastHit2D hit = Physics2D.Raycast((origins.bottomLeft) + Vector2.right * horizontalSpace * i, Vector2.down, 10f, collisionMask);
            if(hit)
            {
                if (hit.distance < 2.5f)
                    result = false;

                Debug.Log(hit.distance);
                Debug.Log(result);
            }
        }
            
        return result;

    }



    //---------------------------------------------------------------------------------------------------------------
    // Método que retorna as dimenções do colisor.

    private RayCastOrigins GetRayCastOrigins(Collider2D collider)
    {
        RayCastOrigins result = new RayCastOrigins();
        Bounds bounds = collider.bounds;
        result.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        result.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        result.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        result.topRight = new Vector2(bounds.max.x, bounds.max.y);
        result.size.x = bounds.size.x;
        result.size.y = bounds.size.y;

        return result;
    }

    //---------------------------------------------------------------------------------------------------------------
    // Struct para armazenar as dimenções do colisor
    struct RayCastOrigins { public Vector2 topLeft, topRight, bottomLeft, bottomRight, size;}                


	//--------------------------------------------------------------------------------------------------------------

}
