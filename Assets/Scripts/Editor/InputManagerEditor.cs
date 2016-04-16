/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável pela interface gráfica customizada da Classe InputManager no inspector

Tutorial sobre ReorderableList:
http://va.lent.in/unity-make-your-lists-functional-with-reorderablelist/

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 30/03/2016
=============================================================================================================== */


using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(InputManager))]
public class InputManagerEditor : Editor 
{

	private ReorderableList list;

	//---------------------------------------------------------------------------------------------------------------
	// Evento acionado toda vez que a interface for habilitada
	private void OnEnable()
	{
		list = new ReorderableList (serializedObject, serializedObject.FindProperty ("inputs"), true, true, true, true);
		list.drawHeaderCallback += OnDrawHeaderCallback;
		list.onRemoveCallback += RemoveCallback;
		list.drawElementCallback += OnDrawCallback;
	}

	//---------------------------------------------------------------------------------------------------------------
	// Evento acionado toda vez que a interface for desabilitada

	private void OnDisable()
	{
		if (list != null) 
		{			
			list.onRemoveCallback -= RemoveCallback;
			list.drawElementCallback -= OnDrawCallback;
			list.drawHeaderCallback -= OnDrawHeaderCallback;
		}
	}

	//---------------------------------------------------------------------------------------------------------------
	// Callback para deinir o header do ReorderableList

	private void OnDrawHeaderCallback(Rect rect)
	{
		EditorGUI.LabelField (rect, "Lista de Comandos");
	}


	//---------------------------------------------------------------------------------------------------------------
	// Callback para definir o que vai ser renderizado na exibição do ReorderableList

	private void OnDrawCallback(Rect rect, int index, bool isActive, bool isFocused)
	{
		SerializedProperty item = list.serializedProperty.GetArrayElementAtIndex (index);

		EditorGUI.PropertyField ( new Rect(rect.x, rect.y, 90, EditorGUIUtility.singleLineHeight),
								  item.FindPropertyRelative("axisName"),
								  GUIContent.none );

		EditorGUI.PropertyField ( new Rect(rect.x + 100, rect.y, 15, EditorGUIUtility.singleLineHeight),
								  item.FindPropertyRelative("offValue"),
								  GUIContent.none	);		

		EditorGUI.PropertyField ( new Rect(rect.x + 125, rect.y, 60, EditorGUIUtility.singleLineHeight),
								  item.FindPropertyRelative("control"),
								  GUIContent.none );		

		EditorGUI.PropertyField ( new Rect(rect.x + 125 + 70, rect.y, 70, EditorGUIUtility.singleLineHeight),
								  item.FindPropertyRelative("condition"),
								  GUIContent.none );		
	}

	//---------------------------------------------------------------------------------------------------------------
	// Callback para o evento remover do ReorderableList, onde exibe uma mensagem de confirmação da ação

	private void RemoveCallback(ReorderableList list)
	{
		if(EditorUtility.DisplayDialog("Warning!", "Você tem certeza que deseja excluir este elemento?", "Yes", "No"))
			ReorderableList.defaultBehaviours.DoRemoveButton (list);		
	}

	//---------------------------------------------------------------------------------------------------------------
	// Evendo sobrescrito, onde encontra-se a programação dos elementos da Interface Gráfica do Usuário

	public override void OnInspectorGUI ()
	{
		InputManager inputManager = target as InputManager;

		EditorGUILayout.Space ();
		EditorGUILayout.LabelField ("Input Manager", EditorUITextStyles.titleStyle);
		EditorGUILayout.Space ();

		EditorGUILayout.LabelField ("Insira todos os comandos que estarão disponíveis para os controles do jogo. Os campos " +
									"obedecem a mesma lógica do InputManager do Unity, inserindo em ordem o nome do Eixo, " + 
									"o valor do neutro, o comando pressionado e a condição no eixo.", EditorUITextStyles.messageStyle);
		EditorGUILayout.Space ();
		list.DoLayoutList ();
		serializedObject.ApplyModifiedProperties ();
		EditorGUILayout.Space ();

		EditorGUILayout.LabelField ("Insira o GameObject contendo o InputState que será administrado.", EditorUITextStyles.messageStyle);

		EditorGUILayout.BeginVertical ("box");
		//SerializedProperty inputState = serializedObject.FindProperty ("inputState");
		//GUIContent property = new GUIContent ();
		//property.text = "Input State Target";
		//EditorGUILayout.PropertyField (inputState, property);

		inputManager.inputState = EditorGUILayout.ObjectField ("Input State Target", inputManager.inputState, typeof(InputState), true) as InputState;
		EditorGUILayout.EndVertical ();

		//DrawDefaultInspector ();
	}

	//---------------------------------------------------------------------------------------------------------------
}
