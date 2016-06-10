/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável pelos poderes de movimento vertical e horizontal

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 07/05/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class SimpleMovement : MonoBehaviour 
{
    //---------------------------------------------------------------------------------------------------------------
    // Propriedades da Classe

    public bool canVerticalMove = false;
    public bool canHorizontalMove = false;
    public bool canLeftRotate = false;

    public float lifeTime = 5f;
    public float moveSpeed = 2f;
    public Vector2[] verticalRoute;
    public Color32 verticalDebugColor = Color.cyan;
    public Vector2[] horizontalRoute;
    public Color32 horizontalDebugColor = Color.red;
    public Color32 leftRotateDebugColor = Color.green;
    public float leftRotateAngle = 0;

    public bool _active = false;

    public GameObject selectable = null;
    private Vector2[] route = new Vector2[2];
    private Vector2 startPosition;
    private int indexPosition = 0;

    private float deltaTime = 0f;

    private bool isHorizontalMoving;
    private bool isVerticalMoving;

	// Use this for initialization
	void Awake () 
    {
        startPosition.x = transform.position.x;
        startPosition.y = transform.position.y;
	}
	
    // Update is called once per frame
    void Update () 
    {
        if (!_active && !transform.position.Equals(startPosition))                                                            // Se desativou fora da posição original
        {
            transform.position = Vector2.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);    // Retorna para posição original    
            return;
        }
        else if(!_active)                                                                                                // Se estiver na posição original e não ativado, sai
            return;

        deltaTime += Time.deltaTime;                                                                                    // Atualiza o tempo de vida

        if (lifeTime <= deltaTime)                                                                                      // Se alcançou o tempo de vida, desativa o movimento
            Deactive(); 

        // Vector2 position = new Vector2(transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, route[indexPosition], moveSpeed * Time.deltaTime);  // Procede a movimentação da plataforma

        if (new Vector2(transform.position.x, transform.position.y) == route[indexPosition])
            indexPosition = (++indexPosition) % route.Length;        
    }

    public void activeHorizontalMove()
    {
        if (isVerticalMoving)                                           // não deixa ativar os dois poderes ao mesmo tempo!!!
            return;
        
        if (canHorizontalMove)
        {
            route[0] = startPosition + horizontalRoute[0];
            route[1] = startPosition + horizontalRoute[1];
            Active();
            isHorizontalMoving = true;
        }
        else
            Debug.LogError("Este movimento não estão está permitido");
    }

    public void activeVerticalMove()
    {
        if (isHorizontalMoving)
            return;
        
        if (canVerticalMove)
        {
            route[0] = startPosition + verticalRoute[0];
            route[1] = startPosition + verticalRoute[1];
            Active();
            isVerticalMoving = true;
        }
        else
            Debug.LogError("Este movimento não estão está permitido");
    }


    private void Active()
    {
        if(_active)                                         // Se já estiver ativo, apenas reinicia a contagem de tempo de vida
        {
            deltaTime = 0;
            return;
        }
        _active = true;            
    }

    private void Deactive()
    {
        _active = false;
        deltaTime = 0;
        isHorizontalMoving = false;
        isVerticalMoving = false;
    }
        
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!_active)
            return;
        
        if(other.gameObject.CompareTag("Actor"))
        {
            other.transform.parent = transform;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (!_active)
            return;

        if(other.gameObject.CompareTag("Actor"))
        {
            other.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Actor"))
        {
            other.transform.parent = null;
        }
    }

    void OnDrawGizmos()
    {
        Vector3 size = new Vector3(GetComponent<PolygonCollider2D>().bounds.size.x, GetComponent<PolygonCollider2D>().bounds.size.y, 1);

        if(canVerticalMove)
        {
            Gizmos.color = verticalDebugColor;
            Vector3 center = new Vector3(transform.position.x + verticalRoute[0].x, transform.position.y + verticalRoute[0].y + 0.15f , 0);
            Gizmos.DrawWireCube(center, size);
            center = new Vector3(transform.position.x + verticalRoute[1].x, transform.position.y + verticalRoute[1].y + 0.15f , 0);
            Gizmos.DrawWireCube(center, size);            
        }
            
        if(canHorizontalMove)
        {
            Gizmos.color = horizontalDebugColor;
            Vector3 center = new Vector3(transform.position.x + horizontalRoute[0].x, transform.position.y + horizontalRoute[0].y + 0.15f , 0);
            Gizmos.DrawWireCube(center, size);
            center = new Vector3(transform.position.x + horizontalRoute[1].x, transform.position.y + horizontalRoute[1].y + 0.15f , 0);
            Gizmos.DrawWireCube(center, size);            
        }

        if(canLeftRotate)
        {
            Gizmos.color = leftRotateDebugColor;

            Vector2 positionA = new Vector2(transform.position.x - (size.x / 2) - 0.3f, transform.position.y + size.y/4);
            Vector2 positionB = new Vector2(transform.position.x + (size.x / 2) + 0.3f, transform.position.y + size.y/4);
            Gizmos.DrawLine(positionA, positionB);
        }
        //Gizmos.DrawCube(center, size);
        //Gizmos.DrawWireSphere(rote[0], 30.00f);
    }

    public void Select()
    {
        if(selectable != null)
            selectable.SetActive(true);
    }

    public void Deselect()
    {
        if(selectable != null)
            selectable.SetActive(false);
    }
        
}
