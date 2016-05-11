/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe do tipo action, que administra o comportamento do escudo


//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 11/05/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class ActorShieldBehaviour : ItemActionAbstractBehaviour 
{

    protected override void Awake ()
    {
        base.Awake ();
        itemId = ItemID.Shield;
    }

    void OnEnable()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    void OnDisable()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }



	
	// Update is called once per frame
    protected override void Update()
    {
    }
}
