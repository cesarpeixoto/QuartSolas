using UnityEngine;
using System.Collections;

public class ActiveSpikes : MonoBehaviour 
{

    public float lifeTime = 1.0f;
    public GameObject spkike = null;
    public float tempLifeTime = 0f;
    private float deltaTime = 0f;
    private bool _active = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(_active)
        {
            deltaTime += Time.deltaTime;                       // Atualiza o tempo de vida
            if (lifeTime <= deltaTime)
            {
                Destroy (this.gameObject);   
                GameObject temp = (GameObject)Instantiate (spkike, transform.position, transform.rotation);
                temp.GetComponent<SpawnerSpikes>().lifeTime = tempLifeTime;
            }                
        }
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        _active = true;
    }
}
