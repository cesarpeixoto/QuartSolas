/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe reponsável pela invocação do poder de movimento Horizontal

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 08/05/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;

public class PowerHorizontalMove : MasterBehaviour 
{

    //---------------------------------------------------------------------------------------------------------------
    // Propriedades da Classe

    public float lifeTime = 0f;
    private SimpleMovement selecton = null;                                         // Referencia da plataforma selecionada

    //---------------------------------------------------------------------------------------------------------------
    // Metodos abstrato do comportamento da invocação do poder

    public override void Behaviour ()
    {
        Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);        // Recebe a posição do clique do mouse, convertido para coordenada na fase
        RaycastHit2D hit = Physics2D.Raycast (position, Vector2.zero);
        if (hit.collider == null)                                                       // Se não atingiu um colisor, sai da função
            return;                                                                 

        SimpleMovement selected = hit.transform.GetComponent<SimpleMovement> ();                        // Pega o objeto atingido apenas se for do tipo Freeze
        if (selected == null)                                                           // Se for não Freeze, sai da função
            return;

        // TODO: se usar lista, adiciona ele na lista
        selecton = selected;                                                            // Se for Interactive, marca a seleção nele
        selecton.lifeTime = lifeTime;
        selecton.activeHorizontalMove();  
        MouseManager.masterPower = null;                                                // Desativa a habilidade no MouseManager
    }

    //---------------------------------------------------------------------------------------------------------------
}
