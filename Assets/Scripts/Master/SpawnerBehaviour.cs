/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe reponsável pela invocação do poder de seleção de plataformas no mapa do poder de espinhos.

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 03/04/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public abstract class SpawnerBehaviour : MonoBehaviour 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public float lifeTime = 0.00f; 							// Tempo de vida da ação;
	public bool onInpact = false;
	protected float deltaTime = 0.00f; 						// Tempo decorrido
	private bool runing = false;

    public LayerMask collisionMask;
    public int RayCount = 4;

	protected BoxCollider2D _thisBoxCollider2D = null;


	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

	protected virtual void Start()
	{
		_thisBoxCollider2D = GetComponent<BoxCollider2D> ();
	}

	// Update is called once per frame
	protected virtual void Update () 
	{
		if (onInpact)
			return;
		deltaTime += Time.deltaTime;						// Atualiza o tempo de vida

		if (lifeTime <= deltaTime && !runing)							// Se alcançou o tempo de vida, chama função behaviour
		{
			behaviour ();
			runing = true;
		}
	}

	protected virtual void OnCollisionEnter2D(Collision2D other)
	{
		if (onInpact)
			behaviour ();
	}

	//---------------------------------------------------------------------------------------------------------------
	// Método abstrato puro

	public abstract void behaviour ();					// Irá receber o comportamento a ser aplicado







    // Conjunto de funções para impedir o comportamente de spawn dentro das plataformas... A origem do Bug era outro
    // Todo este conjunto ficou em desuso.
	//---------------------------------------------------------------------------------------------------------------
    // Método que retorna posíveis invasões de colisão durante o Spawn, retornando um vector2D para corrigir a posição

    protected Vector2 CheckOffsetDistances(Collider2D collider)
    {

        Vector2 result = Vector2.zero;                                      // Função retorna o espaço para corrigir a posição do objeto!!!!!!!!!!!

        RayCastOrigins origins = GetRayCastOrigins(collider);
        float horizontalSpace = origins.size.x / (RayCount - 1);
        float verticalSpace = origins.size.y / (RayCount - 1);
        RayHitCount downCount = new RayHitCount();
        RayHitCount upCount = new RayHitCount();
        RayHitCount leftCount = new RayHitCount();
        RayHitCount rightCount = new RayHitCount();

        Vector2 offset = Vector2.zero;
        offset.y = (origins.size.y /2) + 0.0001f;                 // offset para origem ser no centro do objeto
        for (int i = 0; i < RayCount; i++)              // Parte de baixo
        {
            Debug.DrawRay((origins.bottomLeft + offset) + Vector2.right * horizontalSpace * i, Vector2.down, Color.cyan);
            RaycastHit2D hit = Physics2D.Raycast((origins.bottomLeft + offset) + Vector2.right * horizontalSpace * i, Vector2.down, (origins.size.y / 2), collisionMask);
            if(hit)
            {
                downCount.count++;
                if(downCount.distance < hit.distance)
                    downCount.distance = hit.distance;
            }
        }
        Debug.Log("DownCount: " + downCount.count + " e maior distancia: " + downCount.distance);

        for (int i = 0; i < RayCount; i++)
        {
            Debug.DrawRay((origins.topLeft - offset) + Vector2.right * horizontalSpace * i, Vector2.up, Color.cyan);
            RaycastHit2D hit = Physics2D.Raycast((origins.topLeft - offset) + Vector2.right * horizontalSpace * i, Vector2.down, (origins.size.y / 2), collisionMask);
            if(hit)
            {
                upCount.count++;
                if(upCount.distance < hit.distance)
                    upCount.distance = hit.distance;
            }
        }

        Debug.Log("UpCount: " + upCount.count + " e maior distancia: " + upCount.distance);
        Debug.Log("Posição: " + transform.position);


        for (int i = 0; i < RayCount; i++)
        {
            //Debug.DrawRay((origins.topRight) - Vector2.up * verticalSpace * i, Vector2.right, Color.cyan);
        }
                   
        for (int i = 0; i < RayCount; i++)
        {
            //Debug.DrawRay((origins.topLeft) - Vector2.up * verticalSpace * i, Vector2.left, Color.cyan);
        }


        if (downCount.count > upCount.count && downCount.count > leftCount.count && downCount.count > rightCount.count) //|| ((downCount.count == upCount.count && downCount.distance < upCount.distance)&& downCount.count > leftCount.count && downCount.count > rightCount.count))
        {
            Debug.Log("Moveu pra cima");
            Vector2 position = transform.position;
            position.y += downCount.distance *2;
            transform.position = position;
        }



        if (upCount.count > downCount.count && upCount.count > leftCount.count && upCount.count >rightCount.count) //|| ((upCount.count == downCount.count && upCount.distance < downCount.distance)&& upCount.count > leftCount.count && upCount.count > rightCount.count))
        {
            Debug.Log("Moveu pra baixo");
            Vector2 position = transform.position;
            position.y -= upCount.distance *2;
            transform.position = position;
            Debug.Log("Posição: " + transform.position);
        }
            

        return result;

        //CircleCollider2D temp = new CircleCollider2D();

        //Physics2D.OverlapArea
        //temp.bounds.
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

    //---------------------------------------------------------------------------------------------------------------
    // Struct para armazenar quantidade de pontos de colisão e maior distancia
    struct RayHitCount { public int count; public float distance; }

    //---------------------------------------------------------------------------------------------------------------
}
