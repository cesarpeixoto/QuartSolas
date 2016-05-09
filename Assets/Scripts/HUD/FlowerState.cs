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
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class FlowerState : MonoBehaviour
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	private MasterBehaviour thisPower = null;

	public PowersManager powerManager = null;
	private PowersManager.ConstPowerList pwrSelected; 

    public Image icon = null;


	private bool _active = true;									// Controla se o poder pode ser acionado
	private float _elapsedTime = 0.0f;								// Cronômetro
	private float _deltaTime = 0.0f;								// Tempo de espera


	//public MouseManager _mouseManager = null;						// Referência para MouseManager
	private Animator _thisAnimator = null;							// Referência para Animator

	//---------------------------------------------------------------------------------------------------------------
	// Métodos herdados de MonoBehaviour

	// Use this for initialization
	protected virtual void Awake () 
	{
		_thisAnimator = GetComponent<Animator> ();					// Inicializa a referência
	}


	protected virtual void Start()
	{
		OnLoadPower ();       
	}

	// Update is called once per frame
	protected virtual void Update () 
	{
		if (powerManager.depleted)
			return;
		
		if(!_active)
		{
			_elapsedTime += Time.deltaTime;
			if(_elapsedTime >= _deltaTime)
			{
				OnLoadPower ();
			}
		}
	}
        
	//---------------------------------------------------------------------------------------------------------------
	// Método que carrega o poder e as informações

	void OnLoadPower()
	{
		if(!powerManager.depleted)
		{
			pwrSelected = powerManager.GetPower(out thisPower);
            icon.enabled = true;
            //icon.GetComponent<Image>().sprite = powerManager.resources [(int)pwrSelected].icon;
            icon.sprite = powerManager.resources [(int)pwrSelected].icon;
            //icon.enabled = false;
            _thisAnimator.SetInteger ("powerFlag", (int)pwrSelected);
            _thisAnimator.SetBool ("isOpen", true);
            _active = true;
			//aqui nós vamos tratar as imagens;

		}			
	}		

	//---------------------------------------------------------------------------------------------------------------
	// Método para ser invocado no clique do botão de poder do Mestre

	public void OnClick()
	{
        _thisAnimator.SetInteger ("powerFlag", (int)pwrSelected);
		_thisAnimator.SetBool ("isOpen", false);       
		_elapsedTime = 0.0f;
		_active = false;

		MouseManager.masterPower = thisPower;
		SetDeltaTime ();
		powerManager.UpdateResource (pwrSelected); //////////////////////////////// AQUI ESTÁ A BAIXA DOS PODERES NOS RECURSOS  //////////////////////////////////////////////////

		// Configura a imagem e o label e o icone
		//icon.enabled = false;
		powerManager.image.sprite = powerManager.resources [(int)pwrSelected].imageInfo;
		powerManager.count.text = Convert.ToString(powerManager.resources [(int)pwrSelected].quantity + powerManager.resources [(int)pwrSelected].distributed);
	}
        
	//---------------------------------------------------------------------------------------------------------------
	// Metodos que gera um delta time randômico

	private void SetDeltaTime()
	{
		_deltaTime = UnityEngine.Random.Range (0.5f, 10.0f);
	}

}
