/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe do tipo action, que administra o comportamento de caminhar, utilizando as classes inputManger e InputState

Primeira revisão de código: (em 07/04/2016)

OBS1: Em testes, descobri que o valor recebido por Input.GetAxis recebe desaceleração. Portanto, seu valor absoluto,
multiplicado pela direção do InputState, mantem a integradade de direções da classe abstrata (poder confusão do Mestre), 
com o comportamento de desaceleração desejado para o comportamento de caminhar. 

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 22/03/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class Walk : ActionBehavior 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public float speed = 7.00f;													// Velocidade do corpo ao caminhar

	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour
	
	// Update is called once per frame
	void Update () 
	{
		bool right = _inputState.getControlValue (inputControls [0]);					// Recebe o estado do controle setado na primeira posição no inpector
		bool left  = _inputState.getControlValue (inputControls [1]);					// Recebe o estado do controle setado na segunda posição no inpector

		bool lateralCollided = (_collisionState.leftCollided || _collisionState.rightCollided);

		if ((right || left) && !(lateralCollided && !_collisionState.isGrounded))
		{
			float velocityX = speed * Mathf.Abs (Input.GetAxis ("Horizontal")) * 			// Calcula a velocidade no eixo X (OBS1)
												 (int)_inputState.direction;	

			if(!((velocityX > 0) && _collisionState.rightCollided) && !((velocityX < 0) 	// Checa se não quer andar na direção da colisão
													  && _collisionState.leftCollided)) 
				_thisBody2D.velocity = new Vector2 (velocityX, _thisBody2D.velocity.y);		// Implementa o movimento de acordo com a velocidade
		}			
	}

	//---------------------------------------------------------------------------------------------------------------
}
