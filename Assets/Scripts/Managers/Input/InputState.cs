/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Conjuntos de classes para estados e container de armazenamento dos inputs capturados.
Tecnica adaptada de um tutorial de Lynda.com, de autoria de  Jesse Freeman

Primeira revisão de código: (em 07/04/2016)
Foi retirado da classe todas as informações que extrapolavam a sua função. Estas, foram alocadas em 
ActorStateManager. Também foram feitas algumas otimizações no código.
  
//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 22/03/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//---------------------------------------------------------------------------------------------------------------
// Classe de estrutura para os estados de controles que serão armazenados no container
public class ControlState
{	
	public bool value;											// Estado do Controle
	public float holdTime = 0.00f;								// Tempo em que permanece o estado
	public ControlState(bool val){value = val;}					// Construtor da Classe
}

//---------------------------------------------------------------------------------------------------------------
// Enum para representar a direção, de forma que não haja necessiadade de fazer testes nos demais scripts
public enum Directions{ Right = 1, Left = -1 }

//---------------------------------------------------------------------------------------------------------------
// Classe de container para guardar os estados dos inputs capturados.
public class InputState : MonoBehaviour 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe
	public Directions direction = Directions.Right;				// Armazena a Direção do gameObject (valor default aponta para direita)
	private Dictionary<Controls, ControlState> _controlStates = new Dictionary<Controls, ControlState> ();  // Registro de estados


	//---------------------------------------------------------------------------------------------------------------
	// Método para setar um estado de controle
	public void setControlValue(Controls key, bool value)		
	{
		if (!_controlStates.ContainsKey (key)) 					// Adiciona o registro se não existir
		{
			_controlStates.Add (key, new ControlState (value));
			return;
		}
			
		if (_controlStates [key].value && !value) 				// Se a tecla foi solta, reseta o cronometro
			_controlStates [key].holdTime = 0;
		
		else if (_controlStates [key].value && value) 			// Se a tecla continua pressionada, adiciona 
			_controlStates [key].holdTime += Time.deltaTime;	// o tempo em milesegundos

		_controlStates [key].value = value; 					// Atualiza o estado do controle
	}

	//---------------------------------------------------------------------------------------------------------------
	// Método que retorna o estado do controle
	public bool getControlValue (Controls key)					
	{
		if (_controlStates.ContainsKey (key))					// Se houver registro do controle, retorna estado do mesmo
			return _controlStates [key].value;
		else
			return false;										// Se não houver registro, retorna falso
	}

	//---------------------------------------------------------------------------------------------------------------
	// Método que retorna o tempo em que o controle está pressionado
	public float getControlHoldTime (Controls key)					
	{
		if (_controlStates.ContainsKey (key))					// Se houver registro do controle, retorna o tempo pressionado
			return _controlStates [key].holdTime;
		else
			return 0;											// Se não houver registro, retorna zero
	}

	//---------------------------------------------------------------------------------------------------------------
}
