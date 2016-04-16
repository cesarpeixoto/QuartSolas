/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável pela interface gráfica customizada da Classe FaceDirection no inspector

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

[CustomEditor(typeof(FaceDirection))]
public class FaceDirectionEditor : Editor 
{
	private ReorderableList list;			// ReorderableList de comandos

	//---------------------------------------------------------------------------------------------------------------
	// Evento acionado toda vez que a interface for habilitada
	private void OnEnable()
	{
		list = new ReorderableList (serializedObject, serializedObject.FindProperty ("inputControls"), true, true, true, true);	// Inicializa a lista
		list.drawHeaderCallback  += OnDrawHeaderCallback;			// Adiciona a lista de callbacks, para definir o Header da ReorderableList
		list.onRemoveCallback    += RemoveCallback;					// Adiciona a lista de callbacks, para o evento de remover itens da ReorderableList
		list.drawElementCallback += OnDrawCallback;					// Adiciona a lista de callbacks, para o evento de render da ReorderableList
	}

	//---------------------------------------------------------------------------------------------------------------
	// Evento acionado toda vez que a interface for desabilitada
	// Do contrário, toda ver que o painel for habilitado, será somado novo evento, criando redundância 
	private void OnDisable()
	{
		if (list != null) 
		{
			list.onRemoveCallback    -= RemoveCallback;			// Remove a lista de callbacks, para definir o Header da ReorderableList
			list.drawElementCallback -= OnDrawCallback;			// Remove a lista de callbacks, para o evento de remover itens da ReorderableList
			list.drawHeaderCallback  -= OnDrawHeaderCallback;	// Remove a lista de callbacks, para o evento de render da ReorderableList
		}
	}

	//---------------------------------------------------------------------------------------------------------------
	// Callback para deinir o header do ReorderableList

	private void OnDrawHeaderCallback(Rect rect)
	{
		EditorGUI.LabelField (rect, "Lista de Comandos");		// Define o conteudo do label para o Header da ReorderableList
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
		EditorGUILayout.Space ();														// Insere um espaço
		EditorGUILayout.LabelField ("Face Direction", EditorUITextStyles.titleStyle);	// Insere um label com estilo de título
		EditorGUILayout.Space ();														// Insere um espaço

		EditorGUILayout.LabelField ("Controla o comportamento que aponta para as direções quando o controle é pressionado. " +		// Insere um label com estilo de descrição
									"Os comandos devem ser inseridos obedecendo a ordem da matrix de InputManager.", EditorUITextStyles.messageStyle);
		EditorGUILayout.Space ();														// Insere um espaço
		list.DoLayoutList ();															// 
		serializedObject.ApplyModifiedProperties ();
		//DrawDefaultInspector ();
	}

	//---------------------------------------------------------------------------------------------------------------

}
