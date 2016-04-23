/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe reponsável pela invocação do poder confusão, que gera uma inversão nos controles do ator

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 12/04/2016
=============================================================================================================== */


using UnityEngine;
using System.Collections;

public class PowerConfusion : MasterBehaviour 
{

	public float lifeTime = 5;

	private bool _active = false;
	private float _elapsedTime = 0;
	private GameObject _interactive = null;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_active)
		{
			_elapsedTime += Time.deltaTime;
			if(_elapsedTime >= lifeTime)
				Deactive();
		}
	}


	public override void Behaviour ()
	{

		Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (position, Vector2.zero);
		if (hit.collider == null)													// Se não atingiu um colisor, sai da função
			return;																	// Aqui volta o tempo? ou erro fudeu??????????????????????????????????????????????????????????????????????????????????????????????

		_interactive = hit.transform.gameObject;

		if (!_interactive.CompareTag ("Actor"))										// Se o objeto atingido não é o ator, sai
		{
			_interactive = null;
			MouseManager.masterPower = null;											// Desativa a habilidade no MouseManager
			return;
		}			

		_elapsedTime = 0;
		active ();
	}

	private void active()
	{
		_interactive.GetComponent<FaceDirection> ().inputControls [0] = Controls.Left;
		_interactive.GetComponent<FaceDirection> ().inputControls [1] = Controls.Right;


		_active = true;
	}

	private void Deactive()
	{
		_interactive.GetComponent<FaceDirection> ().inputControls [0] = Controls.Right;
		_interactive.GetComponent<FaceDirection> ().inputControls [1] = Controls.Left;
		_interactive.GetComponent<DoubleJump> ().inputControls [0] = Controls.Jump;
		_interactive.GetComponent<ActorGunBehaviour> ().inputControls [0] = Controls.Action;
		_active = false;
	}

}
