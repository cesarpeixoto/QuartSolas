/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe do tipo action, que administra o comportamento da direção em que o Sprite irá apontar

Primeira revisão de código: (em 07/04/2016)
Adicionado código para manter a escala quando o comportamento é acionado.

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 22/03/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class FaceDirection : ActionBehavior 
{
	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

	// Update is called once per frame
	void Update () 
	{
		bool right = _inputState.getControlValue (inputControls [0]);				// recebe o estado do controle setado na primeira posição no inpector
		bool left  = _inputState.getControlValue (inputControls [1]);				// recebe o estado do controle setado na segunda posição no inpector

		if (right) 																	// Se o controle for para direita, aponta o estado do objeto para direita		 														
			_inputState.direction = Directions.Right; 		
		else if(left)																// Se o controle for para esquerda, aponta o estado do objeto para esquerda
			_inputState.direction = Directions.Left; 

		Vector3 thisLocalScale = transform.localScale;								
		thisLocalScale.x = Mathf.Abs(thisLocalScale.x) * (int)_inputState.direction;// Preserva a escala, alterando a direção de X
		transform.localScale = thisLocalScale;
	}

	//---------------------------------------------------------------------------------------------------------------
}
