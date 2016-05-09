/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Script para aplicar um comportamento "AutoSize" no componente Grid Layout Group.
Retirado do tutorial: https://www.youtube.com/watch?v=nmz8LjN40MY

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 08/05/2016
=============================================================================================================== */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DynamicGrid : MonoBehaviour 
{
    public RectTransform parent = null;

	// Use this for initialization
	void Start () 
    {
        //RectTransform parent = GetComponent<RectTransform>();
        GridLayoutGroup grid = GetComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(parent.rect.xMax * 2 - 70, grid.cellSize.y);

	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
