/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável pelo efeito Parallax nos Sprites de BackGround.
A velocidade do Ator é dividida por um divisor, e este parâmetro é a quantiade de pixels de movimento do BackGround.

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 03/04/2016
=============================================================================================================== */


using UnityEngine;
using System.Collections;

public class BgParallax : MonoBehaviour 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public float divider = 2;
	private Rigidbody2D _actorBody2D = null;

	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

	// Use this for initialization
	void Awake () 
	{
		GameObject temp = GameObject.FindGameObjectWithTag ("Actor");
		_actorBody2D = temp.GetComponent<Rigidbody2D> ();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float move = -_actorBody2D.velocity.x / divider;						// Recebe o valor do movimento em pixels inverso a velocidade
		Vector3 pos = transform.position;
		transform.position = new Vector3 (pos.x + move, pos.y, pos.z);			// Aplica o movimento recebido
	}

	//---------------------------------------------------------------------------------------------------------------
}
