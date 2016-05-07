/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável por tudo que é interativo com o Mestre


EM DESENVOLVIMENTO!!!!!!!!!!!!!! 

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 01/04/2016
=============================================================================================================== */


using UnityEngine;
using System.Collections;

public class Interactive : MonoBehaviour 
{
	// TODO: trabalhar depois o encapsulamento
	public bool selected = false;							// Controle de seleção
	public bool change = false;								// inverter seleção

	public bool canSelect = false;							// Só poderá selecionar se tiver clicado no poder específico

	public void select()
	{
		//if (canSelect) 
		//{
			selected = true;											     // Marca este objeto como selecionado
			foreach (Interaction selection in GetComponents<Interaction>())  // Cada comportamento associado a este objeto será marcado como selecionado
				selection.select ();
		//}
	}


	public void deselect()
	{
		selected = false;											   // Marca este objeto como deselecionado
		foreach(Interaction selection in GetComponents<Interaction>()) // Cada comportamento associado a este objeto será marcado como deselecionado
		{
			selection.deselect ();
		}
	}

	// Update is called once per frame
	void Update()
	{
		if(change)
		{
			change = false;
			if (selected)
				deselect ();
			else
				select ();
		}
	}

}
