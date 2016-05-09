/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe do tipo action, que administra o comportamento da direção em que o Sprite irá apontar.
Utiliza a propriedade Scale do componente transform, (1 e -1) para inverter a imagem.

Primeira revisão de código: (em 07/04/2016)
Adicionado código para manter a escala quando o comportamento é acionado.

Segunda revisão de código: (em 22/04/2016)
Movimentos são tratados agora em FixedUpdate.

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 22/03/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CollisionStateManager))]
public class FaceDirection : ActionBehavior 
{
	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

	private void FixedUpdate () 
	{
		bool right = _inputState.getControlValue (inputControls [0]);				// recebe o estado do controle setado na primeira posição no inpector
		bool left  = _inputState.getControlValue (inputControls [1]);				// recebe o estado do controle setado na segunda posição no inpector

		OnFacing (left, right);
	}

	//---------------------------------------------------------------------------------------------------------------
	// Método que altera a direção apontada.

	private void OnFacing(bool left, bool right)
	{
		if (right) 																	// Se o controle for para direita, aponta o estado do objeto para direita		 														
			_inputState.direction = Directions.Right; 		
		else if(left)																// Se o controle for para esquerda, aponta o estado do objeto para esquerda
			_inputState.direction = Directions.Left; 

        if(!ActorStateManager.isDead)
        {
            Vector3 thisLocalScale = transform.localScale;                              // Recebe a escala atual                    
            thisLocalScale.x = Mathf.Abs(thisLocalScale.x) * (int)_inputState.direction;// Preserva a escala, alterando a direção de X
            transform.localScale = thisLocalScale;                                      // Atribui a nova escala
        }
		
	}

	//---------------------------------------------------------------------------------------------------------------
}
