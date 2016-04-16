using UnityEngine;
using System.Collections;

public class teste : MonoBehaviour {

	Rigidbody2D body = null;

	// Use this for initialization
	void Start ()
	{
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float speed = 10;
		float directio = Input.GetAxis ("Horizontal");
		body.velocity = new Vector2 (speed * directio, body.velocity.y);






	}
}
