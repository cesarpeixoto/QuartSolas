using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathArea : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Actor"))
		{
			ActorStateManager.isDead = true;
		}
			
		//Destroy (other);
		//SceneManager.LoadScene(0);
		//SceneManager.LoadScene(SceneManager.GetSceneAt(0).path);
	}
}

