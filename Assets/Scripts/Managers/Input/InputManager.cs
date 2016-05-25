/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Esta classe faz uma "false interface" com o InputManager da Unity, fornecendo uma camada de abstração que
permite o mapeamento dos comandos Input diretamente em outras classes, permitindo que as ações que dependam 
de comandos possam ser programadas em classes separadas, atuando de forma autonoma.
Este tipo de técnica é comum quando utiliza-se frameworks e bibliotecas.

Tecnica adaptada de um tutorial de Lynda.com, de autoria de Jesse Freeman

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 22/03/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

//---------------------------------------------------------------------------------------------------------------
// Enum para representar os comandos válidos
public enum Controls { Right, Left, Up, Down, Jump, Action, X, Y }

//---------------------------------------------------------------------------------------------------------------
// Enum para representat a condição (pisotiva ou negatica) no Axis
public enum Condition { Positive, Negative }


//---------------------------------------------------------------------------------------------------------------
// Struct que serve de interface entre o InputManager do Unity e nosso InputManager, para expor os 
// controles diretamente na classe, visualizando no inspector. 
//---------------------------------------------------------------------------------------------------------------
[System.Serializable]
public struct AxisState
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe
	public string axisName;				// Nome do Axis para interagir com o InputManager do Unity
	public float offValue; 				// Valor neutro do Axis (quando não ha ação).
	public Controls control;			// Enum para fazer os controle do dispositivos de Input
	public Condition condition;			// Enum para comparar valores positivos e negativos no Axis pretendido

	//---------------------------------------------------------------------------------------------------------------
	// Método que checa o estado (valor) do input no eixo, retornando da condição (positiva ou negativa) no eixo do Axis pretendido
	public bool state
	{
		get
		{
			float value = Input.GetAxis (axisName);					// Recebe o valor do eixo diretamente de InputManager do Unity
			switch(condition)
			{
			case Condition.Positive:								// Valida a condição em caso de eixo positivo
				return (value > offValue);
			case Condition.Negative:								// Valida a condição em caso de eixo negativo
				return (value < offValue);
			default:
				return false;
			}
		}

	}
	//---------------------------------------------------------------------------------------------------------------
}
	
//---------------------------------------------------------------------------------------------------------------
// Classe principal

public class InputManager : MonoBehaviour 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public AxisState[] inputs;											// Array de Axis, similar ao InputManager do Unity
	public InputState inputState;										// Classe do tipo InputState que armazena os estados dos comandos
    public bool isActive = true;

	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour e Jump

	// Update is called once per frame
	void Update () 
	{        
        foreach (AxisState input in inputs)
        {
            inputState.setControlValue (input.control, input.state);    // Controla a interface com o InputManager do Unity
        }
                        
	}

	//---------------------------------------------------------------------------------------------------------------
}
