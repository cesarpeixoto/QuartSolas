/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável por criar as e rotacionar as partículas do efeito confusão.

Inspirado em tutorial de partículas de tufão

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 01/05/2016
=============================================================================================================== */


using UnityEngine;
using System.Collections;

public class GfxCircle : MonoBehaviour 
{
    //---------------------------------------------------------------------------------------------------------------
    // Propriedades da Classe

    public int frequency = 1;                   // taxa de repetição (1 = 360 graus)
    public float resolution = 20;                // quantidades de keys na curva (maior ou menor o circulo)
    public float amplitude = 1.0f;               // min / max altura da curva
    public float Zvalue = 0f;                    // velocidade

    //---------------------------------------------------------------------------------------------------------------
    // Metodos herdados de MonoBehaviour

	// Use this for initialization
	void Start () 
    {
        CreateCircle();
	}
	
    //---------------------------------------------------------------------------------------------------------------
    // Metodos responsável pela configuração das partículas que rotacionam

    void CreateCircle()
    {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        var velocity = particleSystem.velocityOverLifetime;
        velocity.enabled = true;
        velocity.space = ParticleSystemSimulationSpace.Local;
        particleSystem.startSpeed = 0f;
        velocity.z = new ParticleSystem.MinMaxCurve(10.0f, Zvalue);

        AnimationCurve curveX = new AnimationCurve();               // criou uma nova curva
        for(int i = 0; i < resolution; i++)
        {
            float newTime = (i / (resolution - 1));
            float value = amplitude * Mathf.Sin(newTime * ( frequency * 2) * Mathf.PI);

            curveX.AddKey(newTime, value);
        }

        velocity.x = new ParticleSystem.MinMaxCurve(10.0f, curveX);

        AnimationCurve curveY = new AnimationCurve();               // criou uma nova curva
        for(int i = 0; i < resolution; i++)
        {
            float newTime = (i / (resolution - 1));
            float value = amplitude * Mathf.Cos(newTime * ( frequency * 2) * Mathf.PI);

            curveY.AddKey(newTime, value);
        }

        velocity.y = new ParticleSystem.MinMaxCurve(10.0f, curveY);


    }

    //---------------------------------------------------------------------------------------------------------------
}
