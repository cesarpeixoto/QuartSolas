/* ==============================================================================================================
Projeto Integrado II
Curso: Tecnologia em Jogos Digitais - 2o Semestre - 2016
Professor: Enric Llagostera
//---------------------------------------------------------------------------------------------------------------

Classe responsável por gerenciar os estados do Ator, inventário e auxiliar no Debug

//---------------------------------------------------------------------------------------------------------------

$Creator: Cesar Peixoto $
$Notice: (C) Copyright 2016 by Cesar Peixoto. All Rights Reserved. $     Finalizado em 08/04/2016
=============================================================================================================== */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(InputState))]
public class ActorStateManager : MonoBehaviour 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	// Informações para Debug:
	public Directions faceDirection;								// Exibe o status do FaceDirection
	public float absolutVelocityX = 0f;								// Velocidade Absoluta no eixo X
	public float absolutVelocityY = 0f;								// Velocidade Absoluta no eixo Y
	public bool isGrounded = true;

    // Ator escorregar
    public static bool Slide = false;

	// Gestão dos Itens:
	private ItemActionAbstractBehaviour _currentItem = null;
	public bool isShieled = false;  // talvez colocar statico, para tratar o shield no local da colisão
    public GameObject shieldParticles;

	// Morte do Ator.
	public static bool isDead = false;  

	private Rigidbody2D _thisBody2D = null;							// Referencia para RigidBody2D
	private InputState _thisInputState = null;						// Referencia para InputState
	private CollisionStateManager _thisCollisionState;				// Referencia para CollisionStateManager
	//private Animator _thisAnimator;									// Referencia para Animator

	//---------------------------------------------------------------------------------------------------------------
	// Properts Get e Set

	public ItemActionAbstractBehaviour CurrentItemId
	{
		get { return _currentItem; }
		set 
		{             
			_currentItem = value; 			
		    //_thisAnimator.SetInteger ("EquippedItem", (int)_currentItem.itemId);	// Altera a animação para animação com o item.
		}
	}
        
	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

	void Awake()
	{
		_thisBody2D 		= GetComponent<Rigidbody2D> ();					// Inicializa a referência
		_thisInputState 	= GetComponent<InputState> ();
		_thisCollisionState = GetComponent<CollisionStateManager> ();
		//_thisAnimator		= GetComponent<Animator> ();
 	}
		
	// Update is called once per frame
	void FixedUpdate () 
	{
		// Para visualizar no Debug.
		faceDirection = _thisInputState.direction;					// Atualiza a posição de FaceDirection
		absolutVelocityX = Mathf.Abs (_thisBody2D.velocity.x);		// Calculo de velocidade absoluta no eixo X
		absolutVelocityY = Mathf.Abs (_thisBody2D.velocity.y);		// Calculo de velocidade absoluta no eixo Y
		isGrounded = _thisCollisionState.isGrounded;
	}

	//---------------------------------------------------------------------------------------------------------------
	// Método que administra dano sofrido pelo Ator

	public void OnHit()
	{
        if(!ActorStateManager.isDead)
        {
            Vector2 velocity = _thisBody2D.velocity;
            if (velocity.y == 0)
                velocity.y = -1;
            /*
            if (velocity.y > 3)
                velocity.y = 3;
            if (velocity.y < -3)
                velocity.y = -3;
            */

            //_thisBody2D.AddForce(-(velocity* 10));
            _thisBody2D.AddForce((velocity * -5), ForceMode2D.Impulse);
        }

		if(!isShieled)
			ActorStateManager.isDead = true;
		else
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y + 0.11f, -1.0f);          // recebe posição
            GameObject brokenShield = (GameObject)Instantiate(shieldParticles, position, Quaternion.identity);  // Cria instancia das particulas
            //this.transform.GetChild(0).gameObject.SetActive(false);                                             // Desativa a renderização do sprite do escudo
            GetComponent<ActorShieldBehaviour>().enabled = false;
            Destroy(brokenShield, 1.7f);                                                                        // Destroi as particulas no tempó: Duration + StartLifetime
            isShieled = false;                                                                                  // Configura o estado de escudo para falso
        }
			

	}

	//---------------------------------------------------------------------------------------------------------------
	// Método que invoca a morte do Ator

	public void die()
	{
		Invoke ("restart", 1.0f);
	}

	//---------------------------------------------------------------------------------------------------------------
	// Método para reiniciar o lével ------------------------------ ALTERAR NO FUTURO, QUAL SERÁ O PROXIMO LEVEL, ENVIAR STATUS, ETC -------------------------

	private void restart()
	{
		//GameObject actor = GameObject.FindGameObjectWithTag ("Actor");
		Destroy (gameObject);
		//SceneManager.LoadScene(0);
		ActorStateManager.isDead = false;
        Managers.GameManagerMatchSummary.actorWins = false;
        Managers.GameManagerMain.GetInstance().CallEventMatchSummary();
	}

	//---------------------------------------------------------------------------------------------------------------
}
