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
	//public GameObject spawnavel = null;

	//Utilizar uma lista de poderes ou um dictionry, com referencias para MasterBehaviour, e passar apenas o key ou indice? melhor que ponteiro pra lá, ponteiro pra cá??????????????????????????????????????????????????
	public static MasterBehaviour masterPower = null;

	// Update is called once per frame
	void Update () 
	{
        
		if (!Input.GetMouseButtonDown (0))		                                        // Se não houver clique do mouse sai da função
			return;
        
        if (masterPower != null)
            masterPower.Behaviour ();       			
	}

    void OnDestroy()
    {
        MouseManager.masterPower = null;                                                // "Reseta" seu membro estático
    }
}
