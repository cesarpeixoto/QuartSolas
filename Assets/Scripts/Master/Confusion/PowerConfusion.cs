/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe reponsável pela invocação do poder confusão, que gera uma inversão nos controles do ator

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 12/04/2016
=============================================================================================================== */


using UnityEngine;
using System.Collections;

public class PowerConfusion : MasterBehaviour 
{
    //---------------------------------------------------------------------------------------------------------------
    // Propriedades da Classe

	public float lifeTime = 5;                                              // Tempo de vida do poder.
    public GameObject particles = null;                                     // Referência do prefab das partículas.

	private bool _active = false;                                           // Estado do poder.
	private float _elapsedTime = 0;                                         // Cronômetro.
	private GameObject _interactive = null;                                 // Referência do objeto atingido.
    private GameObject confusionParticles = null;                           // Referência para instância das partículas.

    //---------------------------------------------------------------------------------------------------------------
    // Metodos herdados de MonoBehaviour

	void Update () 
	{
		if (_active)                                                        // Interage apenas se o poder estiver ativado.
		{
            Vector3 position = new Vector3(_interactive.transform.position.x - 0.15f, _interactive.transform.position.y + 0.30f, -1);   
            confusionParticles.transform.position = position;               // Faz as partículas seguirem o Ator.

			_elapsedTime += Time.deltaTime;                                 // Controle do cronômetro.
			if(_elapsedTime >= lifeTime)
				Deactive();                                                 // Se ultrapassou o tempo de vida, desativa o poder.
		}
	}

    //---------------------------------------------------------------------------------------------------------------
    // Método de comportamento herdado, identificação do objeto clicado

	public override void Behaviour ()
	{
        if(_active)                                                                 // Se o poder já estiver ativado, apenas reinicia o cronômetro.
        {
            _elapsedTime = 0;
            return;
        }

		Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (position, Vector2.zero);
		if (hit.collider == null)													// Se não atingiu um colisor, sai da função.
			return;																	

		_interactive = hit.transform.gameObject;                                    // Atingindo um colisor, passa a referência.

		if (!_interactive.CompareTag ("Actor"))										// Se o objeto atingido não é o ator, sai.
		{
			_interactive = null;
			MouseManager.masterPower = null;										// Desativa a habilidade no MouseManager.
			return;
		}			

		_elapsedTime = 0;
		active ();                                                                  // Chegando até aqui, ativa o poder.
	}

    //---------------------------------------------------------------------------------------------------------------
    // Método para ativação do poder

	private void active()
	{
        Vector3 position = new Vector3(_interactive.transform.position.x - 0.15f, _interactive.transform.position.y + 0.30f, -1);          // recebe posição.
        Vector3 rotation = new Vector3(270, 0, 0);
        Vector3 scale = new Vector3(1, 1, 1);
        confusionParticles = (GameObject)Instantiate(particles, position, Quaternion.identity);        // Cria instancia das particulas.
        //confusionParticles.transform.parent = _interactive.transform;
        confusionParticles.transform.localScale = scale;
        confusionParticles.transform.localEulerAngles = rotation;

		_interactive.GetComponent<FaceDirection> ().inputControls [0] = Controls.Left;                 // Reconfigura os controles do Ator
		_interactive.GetComponent<FaceDirection> ().inputControls [1] = Controls.Right;

		_active = true;
	}

    //---------------------------------------------------------------------------------------------------------------
    // Método para desativação do poder

	private void Deactive()
	{
        //this.transform.GetChild(0).gameObject.SetActive(false); 
        //_interactive.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Stop();
        Destroy(confusionParticles);

        _interactive.GetComponent<FaceDirection> ().inputControls [0] = Controls.Right;             // Restaura os controles do Ator para os parâmetros originais.
		_interactive.GetComponent<FaceDirection> ().inputControls [1] = Controls.Left;
		_interactive.GetComponent<DoubleJump> ().inputControls [0] = Controls.Jump;
		_interactive.GetComponent<ActorGunBehaviour> ().inputControls [0] = Controls.Action;
		_active = false;
	}

    //---------------------------------------------------------------------------------------------------------------
}
