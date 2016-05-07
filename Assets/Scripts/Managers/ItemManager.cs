/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável por spawnar itens nas áreas de spawn, de forma aleatória.

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 30/04/2016
=============================================================================================================== */

using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour 
{
    //---------------------------------------------------------------------------------------------------------------
    // Propriedades da Classe

    private List<Transform> _itemSpawArea;                          // Lista de áreas onde os itens podem ser spawnados
    public Collectable[] resources;                                 // Array que armazena todos os itens que podem ser spawnados

    public float initialTimeInterval = 0;                           // Termo inicial para intervalos de tempo para novo spawn
    public float finalTimeInvervalEnd = 0;                          // Termo final para intervalos de tempo para novo spawn
    public float timeToItemAutoDestroy = 0;                         // Temo de auto destruição do item se o mesmo não for colatado

    private float _nextTimeToSpawn = 0;                             // Tempo para o  próximo spawn
    private float _elapsedTime = 0;                                 // Cronômetro

    //---------------------------------------------------------------------------------------------------------------
    // Métodos herdados de MonoBehaviour

	// Use this for initialization
	void Start () 
    {
        _itemSpawArea = transform.OfType<Transform>().ToList();     // Recebe a lista de todos os Game Objects Filhos
        _nextTimeToSpawn = SortTimeToSpawn();                       // Configura o tempo para o próximo spawn de item
	}
	
	// Update is called once per frame
	void Update () 
    {
        _elapsedTime += Time.deltaTime;                             // incrementa o cronômetro

        if(_elapsedTime >= _nextTimeToSpawn)                        // Se o cronômetro alcança o tempo para spawn
        {
            _elapsedTime = 0;                                       // Reseta o cronômetro
            SpawnRandomItem();                                      // Spawna item aletarório em área spawnavel aleatória
            _nextTimeToSpawn = SortTimeToSpawn();
        }	
	}

    //---------------------------------------------------------------------------------------------------------------
    // Método que sorteia um item aleatóriamente

    private Collectable SortIten()
    {
        int randomIndex = Random.Range(0, resources.Length);        // Sorteia o índice aleatório do array de itens
        resources[randomIndex].timeToAutoDestroy = timeToItemAutoDestroy;
        return resources[randomIndex];
    }

    //---------------------------------------------------------------------------------------------------------------
    // Método que sorteia uma área spawnavel aleatóriamente

    private Vector3 SortArea()
    {
        int randomIndex = Random.Range(0, _itemSpawArea.Count);     // Sorteia o índice da aleatório da lista de itens
        return _itemSpawArea[randomIndex].position;
    }

    //---------------------------------------------------------------------------------------------------------------
    // Método que spawna um item aleatório em uma área aleatória

    private void SpawnRandomItem()
    {
        Instantiate (SortIten(), SortArea(), this.transform.rotation);
    }

    //---------------------------------------------------------------------------------------------------------------
    // Método que retorna um tempo aleatório dentro dos intervalos definidos

    private float SortTimeToSpawn()
    {
        return Random.Range(initialTimeInterval, finalTimeInvervalEnd);
    }

    //---------------------------------------------------------------------------------------------------------------
}
