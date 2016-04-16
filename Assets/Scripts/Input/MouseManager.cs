/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável pelo InputManager do Mestre. Gerencia os comandos do Mouse. Recebe os poderes que serão
invocados.

Tutoriais utilizados como base de estudos:
http://docs.unity3d.com/ScriptReference/Camera.ScreenPointToRay.html
http://answers.unity3d.com/questions/619090/touch-detection-in-2d-game.html
http://forum.unity3d.com/threads/how-to-use-ray2d-and-raycasthit2d.239895/
http://answers.unity3d.com/questions/847170/instantiate-object-in-2d-game.html

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 01/04/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections.Generic;

public class MouseManager : MonoBehaviour 
{
	public static bool canSelect = false;  // TODO: Trocar esta gambiarra pela maquina de estados Autoriza selecionar Objetos !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	public static bool canSpawn = false;  // TODO: Trocar esta gambiarra pela maquina de estados  Autoriza "spawnar" Objetos  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	public GameObject spawnavel = null;

	//Utilizar uma lista de poderes ou um dictionry, com referencias para MasterBehaviour, e passar apenas o key ou indice? melhor que ponteiro pra lá, ponteiro pra cá??????????????????????????????????????????????????
	public MasterBehaviour masterPower = null;


	//private List<Interactive> selections = new List<Interactive> ();  // Pode ter mais de uma seleção? se sim, usa lista, se não, usa o objeto;???????????????????????????????????????????????????????????????????????????
	//	private Interactive selecton = null;  // A principio vamos trabalhar apenas com este!!!!????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????


	// Update is called once per frame
	void Update () 
	{
		// Isso ocorre a cada frame no jogo, se não tiver o que fazer, tem que sair o mais rápido possível!!!!!!!! (Esplicar em cima e tirar daqui)

		if (!Input.GetMouseButtonDown (0))		// Se não houver clique do mouse sai da função
			return;

		if (masterPower != null)
			masterPower.Behaviour ();
		

		// TODO: checar se isso não interfere nos menus no futuro, e como fazer para evitar confusão!!!!!!!!!!!!!!!!!!!!!



		// TODO: trocar aqui pela maquina de estados

		/*
		if (canSelect)
		{
			// TODO: se tiver lista, checar se tem algo na lista e deselecionar tudo e limpar a lista de seleção !!!!!!!!!!!!!
			if (selecton != null)  // Se tiver algo selecionado, ele vai deselecionar!!!!
			{
				selecton.deselect ();
				selecton = null;
			}
				
			Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (position, Vector2.zero);
			if (hit.collider == null)													// Se não atingiu um colisor, sai da função
				return;																	// Aqui volta o tempo? ou erro fudeu??????????????????????????????????????????????????????????????????????????????????????????????

			Interactive interactive = hit.transform.GetComponent<Interactive> ();		// Pega o objeto atingido apenas se for do tipo Interactive
			if (interactive == null)													// Se for não Interactive, sai da função
				return;

			// TODO: se usar lista, adiciona ele na lista
			selecton = interactive;    													// Se for Interactive, marca a seleção nele
			selecton.select();	
			canSelect = false;
		}
		*/
		/*
		if (canSpawn) 
		{
			Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (position, Vector2.zero);
			if (hit.collider != null)													// Se atingiu um colisor, sai da função
				return;

			if (!hit) // é estranho, mas com raycast null = true
			{				
				//GameObject.Instantiate(GameObject.Find("Spawner"), hit.point, Quaternion.identity);
				GameObject.Instantiate (spawnavel, position, Quaternion.identity);
				canSpawn = false;

			}
			
		}
		*/


	}
}
