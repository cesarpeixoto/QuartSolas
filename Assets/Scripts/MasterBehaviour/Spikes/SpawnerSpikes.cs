using UnityEngine;
using System.Collections;

public class SpawnerSpikes : SpawnerBehaviour 
{
	
	private Vector2 pointA = Vector2.zero;
	private Vector2 pointB = Vector2.zero;

	private EdgeCollider2D _dangerArea = null;

	protected override void Start ()
	{
		_dangerArea = GetComponent<EdgeCollider2D> ();
	}


	protected override void Update ()
	{
		deltaTime += Time.deltaTime;						// Atualiza o tempo de vida

		if (lifeTime <= deltaTime)							// Se alcançou o tempo de vida, chama função behaviour
			Destroy (this.gameObject);		
	}

	public override void behaviour ()
	{
		/*
		pointA.x = _thisBoxCollider2D.bounds.min.x;
		pointA.y = _thisBoxCollider2D.bounds.max.y;

		pointB.x = _thisBoxCollider2D.bounds.max.x;
		pointB.y = _thisBoxCollider2D.bounds.max.y - 0.005f;

		//Debug.DrawLine (pointA, pointB);



		//pointA.x = 

/*
		pointA.x = _thisBoxCollider2D.bounds.max.x;
		pointB.x = _thisBoxCollider2D.bounds.max.x + 0.005f;
		pointA.y = (_thisBoxCollider2D.bounds.max.y) - sizeOffset;

		float groundOffset = isGrounded ? 0.005f : 0.0f;
		pointB.y = (_thisBoxCollider2D.bounds.min.y - (_thisCircleCollider2D.radius / 2)) + groundOffset; 

		rightCollided = Physics2D.OverlapArea (pointA, pointB, collisionLayer);				// Detecta colisão do lado direito
		Debug.DrawLine (pointA, pointB);													// Desenha esta linha para debug
*/

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		GameObject temp = GameObject.FindGameObjectWithTag ("Actor");
		temp.GetComponent<ActorStateManager> ().OnHit ();
	}
}
