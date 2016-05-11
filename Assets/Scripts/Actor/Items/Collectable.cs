/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe base para definir o comportamento dos itens que serão colecionaveis 
Podemos definir a Tag de quem pode coletar o iem


//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 04/04/2016
=============================================================================================================== */


using UnityEngine;
using System.Collections;

public enum ItemID { Notting, Gun, Shield, Boot, hourglass }

public class Collectable : MonoBehaviour 
{

	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public string targetTag = "Actor";									// Tag que define quem pode coletar o item
	public ItemID itemId = ItemID.Notting;
    public float timeToAutoDestroy = 0;

    private float _elapsedTime = 0;

	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

    void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= timeToAutoDestroy)                        // Se o cronômetro alcança o tempo de auto destruição
            Destroy(gameObject);
    }


	void OnCollisionEnter2D(Collision2D target)
	{
		if(target.gameObject.tag == targetTag)							// Compara a Tag o objeto que colidiu
		{
			OnCollect (target.gameObject);
			OnDestroy ();
		}
	}

	//---------------------------------------------------------------------------------------------------------------
	// Método que será reponsável pela transferencia do item para o Ator

	protected virtual void OnCollect (GameObject target)
	{
		
	}

	//---------------------------------------------------------------------------------------------------------------
	// Método para destruir o próprio objeto

	protected virtual void OnDestroy()								
	{
		Destroy (gameObject);
	}

	//---------------------------------------------------------------------------------------------------------------
	
}
