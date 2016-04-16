/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe base responsável por tudo que é interativo com o Mestre


EM DESENVOLVIMENTO!!!!!!!!!!!!!! 

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 01/04/2016
=============================================================================================================== */


using UnityEngine;
using System.Collections;

public abstract class Interaction : MonoBehaviour 
{
	public abstract void select ();
	public abstract void deselect ();
}
