/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável pela administração dos recursos de poderes do mestre.

OSB: 

Como é uma nova mecanica, a falta de planejamento prévio atrabalhou a integração desta classe ao sistema do jogo,
Antes, os recursos tinha um slot estático, e o gerenciamento de recursos era feito no próprio slot, o que 
facilitava o controle de quantidade. Agora, como é randômico, não tem como o próprio slot fazer o controle, pois 
o mesmo recursos pode ser distribuido em vários slots, obrigando a baixa do recurso ser calculado no momento exato
do uso. Para resolver este problema, vamos deixar a lista de recursos pública e estática e de ordem fixa (enum 
gerenciado a ordem), para que fique acessivel para todas as classes, para fazer a baixa do recurso no exato 
momento do uso.

O complexo não funcionou, apelamos para o ultra simples!!!!

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 22/04/2016
=============================================================================================================== */


using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PowersManager : MonoBehaviour 
{
	public enum ConstPowerList { Bomb, ClockBomb1, ClockBomb2, ClockBomb3, Spike, Confusion, Depleted }										// Enum para controlar os índices para os poderes

	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe
	public List<Resource> resources;
	public Image image = null;
	public Text count = null;

	public bool depleted = false;

	//---------------------------------------------------------------------------------------------------------------
	// Métodos herdados de MonoBehaviour


	// Update is called once per frame
	void Update () 
	{
	}

	void OnDestroy()
	{
		//resourceList.Clear ();
	}

	//---------------------------------------------------------------------------------------------------------------
	// Métodos para sortear o índice dos recursos

	private int sortPower()
	{
		int result = Random.Range (0, resources.Count);
		if (resources [result].quantity <= 0)
			result = sortPower ();

		return result;
	}
		
	//---------------------------------------------------------------------------------------------------------------
	// Métodos que retorna um poder sorteado aleatóriamente, fazendo ainda o controle dos recursos

	public ConstPowerList GetPower(out MasterBehaviour power)
	{		
		int pwrIndex = sortPower();

		Resource temp = resources [pwrIndex];							// Atualiza os dados no Controle de Recursos
		temp.quantity--;
		temp.distributed++;
		resources [pwrIndex] = temp;


		power = resources [pwrIndex].power;
		depleted = CtrlResources ();

		return (ConstPowerList)pwrIndex;
	}
		
	//---------------------------------------------------------------------------------------------------------------
	// Métodos que controla a integridade da lista powerList (usar após distribuição do poder)

	private bool CtrlResources()
	{
		foreach (Resource item in resources) 
			if (item.quantity > 0)
				return false;							

		return true;					
	}
		
	//---------------------------------------------------------------------------------------------------------------
	// Método para dar baixa no poder logo após ele ser efetivamente utilizado

	public void UpdateResource (ConstPowerList power)
	{
		Resource temp = resources [(int)power];							// Atualiza os dados no Controle de Recursos
		temp.distributed--;
		resources [(int)power] = temp;
	}
		
	//---------------------------------------------------------------------------------------------------------------

	[System.Serializable]
	public struct Resource
	{
		public string name;
		public MasterBehaviour power;
		public ConstPowerList powerIndex;
		public int quantity;
		public int distributed;
		public Sprite icon;
		public Sprite imageInfo;
	}

}
