/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe do tipo action, que administra o comportamento disparar projeteis


//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 08/04/2016
=============================================================================================================== */


using UnityEngine;
using System.Collections;

public class ActorGunBehaviour : ItemActionAbstractBehaviour
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	//public ItemID itemId = ItemID.Gun;
	public float shootDelay = 0.5f;										// Intervalo entre os tiros.
	public GameObject projectilePrefab = null;							// Referência para o projétil (modemos mudar com outros itens).
	public Vector2 shootPosition = Vector2.zero;						// Posição de onde o projétil será declarado.
	private float elapsedTime = 0.0f;									// Cronometro.

	// Para debug
	public Color debugColor = Color.cyan;						// Cor da localização para debug.
	public float debugRadius = 3.0f;											// Raio da posição para debug.


	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

	protected override void Awake ()
	{
		base.Awake ();
		itemId = ItemID.Gun;
	}
		
	// Update is called once per frame
	protected virtual void Update () 
	{
		if(projectilePrefab != null)
		{
			bool canFire = _inputState.getControlValue (inputControls [0]);

			if (canFire && elapsedTime > shootDelay)
			{
				CreateProjectile (CalculateShootPosition());
				elapsedTime = 0;
			}

			elapsedTime += Time.deltaTime;								
		}
	}

	//---------------------------------------------------------------------------------------------------------------
	// Método para calcular a posição do disparo
	private Vector2 CalculateShootPosition()
	{
		Vector2 position = shootPosition;
		position.x *= (float)_inputState.direction;
		position.x += transform.position.x;
		position.y += transform.position.y;

		return position;
	}
		
	//---------------------------------------------------------------------------------------------------------------
	// Método que cria e aponta o projétil que será disparado

	public void CreateProjectile(Vector2 position)
	{
		GameObject clone = (GameObject)Instantiate (projectilePrefab, this.transform.position, this.transform.rotation);
		clone.transform.localScale = new Vector3((float)this.GetComponent<ActorStateManager>().faceDirection, clone.transform.localScale.y, clone.transform.localScale.z);
	}

	//---------------------------------------------------------------------------------------------------------------
	// Método para debug

	void OnDrawGizmos()
	{
		Gizmos.color = debugColor;
		Vector2 position = shootPosition;
		if(_inputState != null)
			position.x *= (float)_inputState.direction;
		position.x += transform.position.x;
		position.y += transform.position.y;

		Gizmos.DrawWireSphere (position, debugRadius);
	}

	//---------------------------------------------------------------------------------------------------------------

}


