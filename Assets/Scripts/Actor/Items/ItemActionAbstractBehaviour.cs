using UnityEngine;
using System.Collections;

public class ItemActionAbstractBehaviour: ActionBehavior 
{
	//---------------------------------------------------------------------------------------------------------------
	// Propriedades da Classe

	public ItemID itemId = ItemID.Notting;
    public float lifeTime = 30;

    private float deltaTime = 0;

	protected virtual void Update ()
	{
        deltaTime += Time.deltaTime;

        if (deltaTime >= lifeTime)
        {
            this.enabled = false;
            deltaTime = 0;
        }
            
	}


}
