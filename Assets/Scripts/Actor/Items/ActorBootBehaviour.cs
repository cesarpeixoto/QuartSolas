using UnityEngine;
using System.Collections;

public class ActorBootBehaviour : ItemActionAbstractBehaviour 
{

    public float walkSpeed = 0;
    public float jumpForce = 0;
    private float originalWalkSpeed;
    private float originalJumpForce;

	// Use this for initialization
    protected override void Awake ()
    {
        base.Awake ();
        originalWalkSpeed = GetComponent<Walk>().speed;
        originalJumpForce = GetComponent<DoubleJump>().jumpForce;
        itemId = ItemID.Boot;
    }
	
    void OnEnable()
    {
        GetComponent<Walk>().speed = walkSpeed;
        GetComponent<DoubleJump>().jumpForce = jumpForce;
    }

    void OnDisable()
    {
        GetComponent<Walk>().speed = originalWalkSpeed;
        GetComponent<DoubleJump>().jumpForce = originalJumpForce;
    }
        
}
