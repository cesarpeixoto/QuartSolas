/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe reponsável pelo efeito de congelamento da plataforma

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 07/05/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class Freeze : MonoBehaviour 
{
    //---------------------------------------------------------------------------------------------------------------
    // Propriedades da Classe

    public PhysicsMaterial2D material = null;
    public GameObject effects = null;
    public float lifeTime = 5.0f;
    public bool _active = false;

    private float deltaTime = 0;
    private PolygonCollider2D _thisCollider = null;
    private Walk walk = null;

    //---------------------------------------------------------------------------------------------------------------
    // Metodos herdados de MonoBehaviour

	// Use this for initialization
	void Awake () 
    {
        _thisCollider = GetComponent<PolygonCollider2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!_active)
            return;
        
        deltaTime += Time.deltaTime;                       // Atualiza o tempo de vida

        if (lifeTime <= deltaTime)                          // Se alcançou o tempo de vida, chama função behaviour
            Deactive();      
	}
        
    public void Active()
    {
        if(_active)                                         // Se já estiver ativo, apenas reinicia a contagem de tempo de vida
        {
            deltaTime = 0;
            return;
        }
        _thisCollider.sharedMaterial = material;
        SimpleMovement[] platforms = GameObject.Find("Platforms").GetComponentsInChildren<SimpleMovement>();
        foreach (SimpleMovement selection in platforms)                 // Desceleciona todas as plataformas.
            selection.Deselect();
        _active = true;
        effects.SetActive(true);
    }

    private void Deactive()
    {
        _thisCollider.sharedMaterial = null;
        _active = false;
        if (walk != null)
            walk.frozzen = false;
        walk = null;
        deltaTime = 0;
        effects.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!_active)
            return;
        
        if(other.gameObject.CompareTag("Actor"))
        {
            walk = other.gameObject.GetComponent<Walk>();
            walk.frozzen = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (!_active)
            return;

        if(other.gameObject.CompareTag("Actor"))
        {
            walk = other.gameObject.GetComponent<Walk>();
            walk.frozzen = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (!_active)
            return;

        if(other.gameObject.CompareTag("Actor"))
        {
            walk.frozzen = false;
        }
    }

}
