/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável pela interface gráfica customizada da Classe Jump no inspector

Tutorial sobre ReorderableList:
http://va.lent.in/unity-make-your-lists-functional-with-reorderablelist/

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 31/03/2016
=============================================================================================================== */


using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(Jump))]
public class JumpEditor : Editor
{

	private ReorderableList list;

	//---------------------------------------------------------------------------------------------------------------
	// Evento acionado toda vez que a interface for habilitada
	private void OnEnable()
	{
		list = new ReorderableList (serializedObject, serializedObject.FindProperty ("inputControls"), true, true, true, true);
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

		EditorGUI.LabelField (new Rect(rect.x, rect.y, 70, EditorGUIUtility.singleLineHeight), "Comando " + index);
		EditorGUI.PropertyField ( new Rect(rect.x + 80, rect.y, 90, EditorGUIUtility.singleLineHeight),
			item, GUIContent.none );
	}

	//---------------------------------------------------------------------------------------------------------------
	// Callback para o evento remover do ReorderableList, onde exibe uma mensagem de confirmação da ação

	private void RemoveCallback(ReorderableList list)
	{
		if(EditorUtility.DisplayDialog("Warning!", "Você tem certeza que deseja excluir este comando?", "Yes", "No"))
			ReorderableList.defaultBehaviours.DoRemoveButton (list);		
	}

	//---------------------------------------------------------------------------------------------------------------
	// Evendo sobrescrito, onde encontra-se a programação dos elementos da Interface Gráfica do Usuário

	public override void OnInspectorGUI ()
	{
		//InputManager inputManager = target as InputManager;

		EditorGUILayout.Space ();
		EditorGUILayout.LabelField ("Jump", EditorUITextStyles.titleStyle);
		EditorGUILayout.Space ();

		EditorGUILayout.LabelField ("Controla o comportamento de salto longo quando o controle é pressionado. " +
			"Os comandos devem ser inseridos obedecendo a ordem da matrix de InputManager. A força " + 
			"do salto nesta ação também é ajustável", EditorUITextStyles.messageStyle);
		EditorGUILayout.Space ();

		EditorGUILayout.BeginVertical ("box");
		SerializedProperty speed = serializedObject.FindProperty ("jumpSpeed");
		EditorGUILayout.Slider(speed, 0f, 500f, "Força do Salto");
		EditorGUILayout.EndVertical ();

		EditorGUILayout.Space ();
		list.DoLayoutList ();
		serializedObject.ApplyModifiedProperties ();
		//DrawDefaultInspector ();
	}

	//---------------------------------------------------------------------------------------------------------------
}
