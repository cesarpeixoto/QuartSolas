/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável pelo comportamento (ação) de ativar o efeito visual de seleção


EM DESENVOLVIMENTO!!!!!!!!!!!!!! 

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 01/04/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class MarkSelection : Interaction 
{

	public GameObject showItem;							// Referencia para o Sprite de seleção do objeto


	public override void select ()
	{
		showItem.SetActive (true);						// Ativa o Sprite de seleção quando o objeto for selecionado (entra naquele foreat)
	}

	public override void deselect ()
	{
		showItem.SetActive (false);						// desativa o Sprite de seleção quando o objeto for deselecionado (entra naquele foreat)
	}


	// Use this for initialization
	void Start () 
	{
		showItem.SetActive (false);
	}
	

}
