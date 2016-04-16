/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável pela interface gráfica customizada da Classe InputState no inspector

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 31/03/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(InputState))]
public class InputStateEditor : Editor 
{

	//---------------------------------------------------------------------------------------------------------------
	// Evendo sobrescrito, onde encontra-se a programação dos elementos da Interface Gráfica do Usuário

	public override void OnInspectorGUI ()
	{
		//InputState inputState = target as InputState;


		EditorGUILayout.Space ();
		EditorGUILayout.LabelField ("Input State", EditorUITextStyles.titleStyle);
		EditorGUILayout.Space ();

		EditorGUILayout.LabelField ("Controla os estados do Ator e exibe em tempo real", EditorUITextStyles.messageStyle);
		EditorGUILayout.Space ();

		GUIContent property = new GUIContent ();
		SerializedProperty direction = serializedObject.FindProperty ("direction");
		property.text = "Direção";
		EditorGUILayout.PropertyField (direction, property);

		/*
		SerializedProperty absolutVelocityX = serializedObject.FindProperty ("absolutVelocityX");
		property.text = "Veloc. Abs. em X";
		EditorGUILayout.PropertyField (absolutVelocityX, property);

		SerializedProperty absolutVelocityY = serializedObject.FindProperty ("absolutVelocityY");
		property.text = "Veloc. Abs. em Y";
		EditorGUILayout.PropertyField (absolutVelocityY, property);
		*/

		//DrawDefaultInspector ();
	}

	//---------------------------------------------------------------------------------------------------------------
}
