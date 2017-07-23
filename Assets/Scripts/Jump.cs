using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    /*these floats are the force you use to jump, the max time you want your jump to be allowed to happen,
     * and a counter to track how long you have been jumping*/
    public float jumpForce;
    public float jumpTime;
    public float jumpTimeCounter;
    /*this bool is to tell us whether you are on the ground or not
     * the layermask lets you select a layer to be ground; you will need to create a layer named ground(or whatever you like) and assign your
     * ground objects to this layer.
     * The stoppedJumping bool lets us track when the player stops jumping.*/
    public bool grounded;
    public LayerMask whatIsGround;
    public bool stoppedJumping;
 
    /*the public transform is how you will detect whether we are touching the ground.
     * Add an empty game object as a child of your player and position it at your feet, where you touch the ground.
     * the float groundCheckRadius allows you to set a radius for the groundCheck, to adjust the way you interact with the ground*/
 
    public Transform groundCheck;
    public float groundCheckRadius;
 
    //You will need a rigidbody to apply forces for jumping, in this case I am using Rigidbody 2D because we are trying to emulate Mario :)
	private Rigidbody2D rb;
	private Animator m_Anim;            // Reference to the player's animator component.
 
	public bool doubleJump = false;

    void Start()
    {
        //sets the jumpCounter to whatever we set our jumptime to in the editor
        jumpTimeCounter = jumpTime;
		rb = GetComponent<Rigidbody2D>();
		m_Anim = GetComponent<Animator>();
    }
 
    void Update()
    {
        //determines whether our bool, grounded, is true or false by seeing if our groundcheck overlaps something on the ground layer
        grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround); 
 
		m_Anim.SetBool("Ground", grounded);
		m_Anim.SetFloat("vSpeed", rb.velocity.y);
		m_Anim.SetFloat("Speed", rb.velocity.x);

        //if we are grounded...
        if(grounded)
        {
            //the jumpcounter is whatever we set jumptime to in the editor.
            jumpTimeCounter = jumpTime;
			stoppedJumping = false;
			doubleJump = false;
        }

		rb.velocity = new Vector2(10f, rb.velocity.y);

		// Debug CornerGrab
		if (rb.velocity.magnitude <= 0 && Time.timeSinceLevelLoad > 1) 
			rb.AddForce (new Vector2 (0f, jumpForce));
    }
 
    void FixedUpdate()
    {
        //I placed this code in FixedUpdate because we are using phyics to move.

		#if ( UNITY_IPHONE || UNITY_ANDROID )
		for (int i = 0; i < Input.touchCount; i++) {
			//if you press down the mouse button...
			if(Input.GetTouch(i).phase == TouchPhase.Began)
			{
				//and you are on the ground...
				if(grounded || !doubleJump)
				{
					//jump!
					rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
					stoppedJumping = false;

					if (!grounded)
						doubleJump = true;
				}
			}

			//if you keep holding down the mouse button...
			if((Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary) && !stoppedJumping)
			{
				//and your counter hasn't reached zero...
				if(jumpTimeCounter > 0)
				{
					//keep jumping!
					rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
					jumpTimeCounter -= Time.deltaTime;
				}
			}


			//if you stop holding down the mouse button...
			if(Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
			{
				//stop jumping and set your counter to zero.  The timer will reset once we touch the ground again in the update function.
				jumpTimeCounter = jumpTime;
				stoppedJumping = true;
			}
		}
		#else
        //if you press down the mouse button...
		if(Input.GetKeyDown(KeyCode.Space))
        {
            //and you are on the ground...
			if(grounded || !doubleJump)
            {
                //jump!
                rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
                stoppedJumping = false;

				if (!grounded)
					doubleJump = true;
            }
        }
 
        //if you keep holding down the mouse button...
		if((Input.GetKey(KeyCode.Space)) && !stoppedJumping)
        {
            //and your counter hasn't reached zero...
            if(jumpTimeCounter > 0)
            {
                //keep jumping!
                rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
 
 
        //if you stop holding down the mouse button...
		if(Input.GetKeyUp(KeyCode.Space))
        {
            //stop jumping and set your counter to zero.  The timer will reset once we touch the ground again in the update function.
			jumpTimeCounter = jumpTime;
            stoppedJumping = true;
        }
		#endif
    }
}
