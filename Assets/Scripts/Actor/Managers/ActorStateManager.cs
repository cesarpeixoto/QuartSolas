using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ActorStateManager : MonoBehaviour 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	// Informações para Debug:
	public Directions faceDirection;								// Exibe o status do FaceDirection
	public float absolutVelocityX = 0f;								// Velocidade Absoluta no eixo X
	public float absolutVelocityY = 0f;								// Velocidade Absoluta no eixo Y
	public bool isGrounded = true;

	// Gestão dos Itens:
	private ItemActionAbstractBehaviour _currentItem = null;
	public bool isShieled = false;  // talvez colocar statico, para tratar o shield no local da colisão

	// Morte do Ator.
	public static bool isDead = false;  

	private Rigidbody2D _thisBody2D = null;							// Referencia para RigidBody2D
	private InputState _thisInputState = null;						// Referencia para InputState
	private CollisionStateManager _thisCollisionState;				// Referencia para CollisionStateManager
	private Animator _thisAnimator;									// Referencia para Animator

	//---------------------------------------------------------------------------------------------------------------
	// Métodos Get e Set

	public ItemActionAbstractBehaviour CurrentItemId
	{
		get { return _currentItem; }
		set 
		{ 
			_currentItem = value; 
			if (_currentItem.itemId == ItemID.Shield) 									// Checa se o item é um escudo
			{
				isShieled = true;
				_currentItem = null;
			}
			else	
				_thisAnimator.SetInteger ("EquippedItem", (int)_currentItem.itemId);	// Altera a animação para animação com o item.
		}
	}

	//---------------------------------------------------------------------------------------------------------------
	// Metodos herdados de MonoBehaviour

	void Awake()
	{
		_thisBody2D 		= GetComponent<Rigidbody2D> ();					// Inicializa a referência
		_thisInputState 	= GetComponent<InputState> ();
		_thisCollisionState = GetComponent<CollisionStateManager> ();
		_thisAnimator		= GetComponent<Animator> ();
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
		if(!isShieled)
			ActorStateManager.isDead = true;
		else
			isShieled = false;
	}

	//---------------------------------------------------------------------------------------------------------------
	// Método que invoca a morte do Ator

	public void die()
	{
		Invoke ("restart", 1.7f);
	}

	//---------------------------------------------------------------------------------------------------------------
	// Nétodo para reiniciar o lével ------------------------------ ALTERAR NO FUTURO, QUAL SERÁ O PROXIMO LEVEL, ENVIAR STATUS, ETC -------------------------

	private void restart()
	{
		//GameObject actor = GameObject.FindGameObjectWithTag ("Actor");
		Destroy (gameObject);
		SceneManager.LoadScene(0);
		ActorStateManager.isDead = false;
	}

	//---------------------------------------------------------------------------------------------------------------
}
