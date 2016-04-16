/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

BUG CONHECIDO!!! AWAKE NÃO ESTÁ FUNCIONANDO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


Classe reponsável pela invocação do poderes do Mestre.

Vai serr acoplada ao painel no HUD para invocar o poder, 
- vai ter uma referencia da imagem do icone nela

	Referencia vai ser enciada para mousemanager para invocar o poder




// // // // // // SOBRE SELEÇÃO DE PODER NO PAINEL // // //// // //// // //// // //// // //// // //// // //// // //// // //// // //// // //// // //// // //
na seleção de qual poder para qual painel, fazer uma lista com os poderes, criar o poder da lista e excluir o poder da lista
para selecionar outros


//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 12/04/2016
=============================================================================================================== */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class MasterBehaviour : MonoBehaviour
{

	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public float delayTime = 0;							// Tempo de recarga do poder
	public int quantity = 0;							// Quantidade de poderes disponíveis

	private float currentTime =1000;					// tempo atual
	private bool canActivate = true;					// Se a ativação do poder está disponível
	private bool depleted = false;

	public MouseManager mouseManager = null;			// Referência para MouseManager
	public Button button = null;
	public Image image = null;

	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

	protected virtual void Awake()
	{
		button = GetComponent<Button> ();
		currentTime = delayTime;
	}

	protected virtual void Update()
	{
		if (!depleted) 
		{
			currentTime += Time.deltaTime;					// Incrementa o cronômetro

			if (!canActivate && currentTime >= delayTime) 	// Checa se o tempo de espera foi alcançado, caso positivo:
			{	
				image.fillAmount = 1f;						// Barra de tempo completa
				canActivate = true;							// Caso positivo, permite a ativação do poder novamente
				button.interactable = true;					// Ativa o botão
			} 
			else 
				image.fillAmount = currentTime / delayTime;	// Atualiza a posição do da barra de tempo
		}
	}
	 
	//---------------------------------------------------------------------------------------------------------------
	// Metodos invocado no clique do botão

	public void OnClick ()
	{
		if(quantity > 0 && canActivate)					// Checa a possibilidade de avitação do poder e se há quantidade disponível, caso positivo:
		{
			quantity--;									// Decrementa a quantidade de poderes
			canActivate = false;						// Desabilita a capacidade de ativação do poder
			currentTime = 0;							// Reseta o cronômetro
			button.interactable = false;				// Desativa o botão
			mouseManager.masterPower = this;			// Passa a referência desse poder para o MouseManager

			if (quantity <= 0)							// Checa se os recursos foram esgotados, caso positivo:
			{
				depleted = true;						// Seta os recursos como esgotados
				image.fillAmount = 0;					// Esgota a barra de tempo
			}
		}
	}

	//---------------------------------------------------------------------------------------------------------------
	// Metodos abstrato do comportamento da invocação do poder

	abstract public void Behaviour ();

	//---------------------------------------------------------------------------------------------------------------
}
