using UnityEngine;
using System.Collections;

public class SpawnerSpikes : SpawnerBehaviour 
{
	
	private Vector2 pointA = Vector2.zero;
	private Vector2 pointB = Vector2.zero;

	protected override void Start ()
	{
        base.Start();
	}
        
	protected override void Update ()
	{
        
         
		deltaTime += Time.deltaTime;						// Atualiza o tempo de vida

		if (lifeTime <= deltaTime)							// Se alcançou o tempo de vida, chama função behaviour
			Destroy (this.gameObject);		
	}

	public override void behaviour ()
	{


	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.CompareTag("Actor"))
        {
            //GameObject temp = GameObject.FindGameObjectWithTag ("Actor");
            other.GetComponent<ActorStateManager>().OnHit();
        }
	}
}
