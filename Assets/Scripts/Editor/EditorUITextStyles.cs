/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe de auxilio que contem os estílos de textos

Tutorial sobre estilos:
http://answers.unity3d.com/questions/199662/how-to-get-a-bold-labelfield-editorguistyle.html

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 30/03/2016
=============================================================================================================== */


using UnityEngine;
using System.Collections;

public class EditorUITextStyles 
{
	//---------------------------------------------------------------------------------------------------------------
	// Método que retorna um estilo de texto padrão para títulos, tamanho 14, negrito e itálico
	public static GUIStyle titleStyle
	{
		get
		{
			GUIStyle titleStyle = new GUIStyle (GUI.skin.label);
			titleStyle.normal.textColor = Color.black;
			titleStyle.fontStyle = FontStyle.BoldAndItalic;
			titleStyle.fontSize = 14;
			titleStyle.fixedHeight = 20;
			return titleStyle;
		}
	}

	//---------------------------------------------------------------------------------------------------------------
	// Método que retorna um estilo de texto padrão para explicação, com quebra de linhas automáticas
	public static GUIStyle messageStyle
	{
		get
		{
			GUIStyle messageStyle = new GUIStyle (GUI.skin.label);
			messageStyle.wordWrap = true;
			return messageStyle;
		}
	}

	//---------------------------------------------------------------------------------------------------------------
}
