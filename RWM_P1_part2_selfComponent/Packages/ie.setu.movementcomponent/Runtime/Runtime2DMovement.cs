﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//yes
public class Runtime2DMovement : MonoBehaviour
{
    private bool _moveRight;
    private bool _moveLeft;
    public bool _isJumping;
    public bool _isGrounded;
    private bool _stopMovement = false;

    public Rigidbody2D rb;
    private float jumpTimeCounter;
    private Vector2 _velocity = new Vector2(0.0f, 0.0f);
    private float _timeLeft;
    private float _declaration = 0.0f;
    private float _elaspedTimeSinceButtonPress;


    // VARIALBES THE USER CAN EDIT TO CREATE DIFFERENT JUMP ARCS/MOVEMENT
    public LayerMask _walkableSurfaceLayer;
    public GameObject raycastRight;
    public GameObject raycastLeft;

    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.Space;
    public float impluseJumpVel = 4.0f;
    public float TimeToReachMaxHeight = 5.5f;
    public float _movementTime = 0.100f;
    public float _MAX_WALKING_SPEED = 5.0f;
    public float _LOWEST_WALKING_SPEED = 0.3f;
    public float _MAX_SLOWWALKING_SPEED = 3.0f;
    public float _LOWEST_SLOWWALKING_SPEED = 1.6f;
    public float changeJumpHeightOnJump3 = 1.2f;
    public float raycastDistance = 0.55f;
    public float acclearation = 17.0f;
    public float playerGravity = 1.0f;
    // VARIALBES THE USER CAN EDIT TO CREATE DIFFERENT JUMP ARCS/MOVEMENT

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        // CHECK IF THE GAMEOBJECT HAS A RIGIDBODY IF NOT THEN CREATE ONE
        if (!rb)
        {
            gameObject.AddComponent<Rigidbody2D>();
            rb = GetComponent<Rigidbody2D>();
            rb.angularDrag = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = playerGravity;
            // test
        }

        // CHECK IF THE GAME OBJECT HAS A BOX COLLDER ATTACHED, IF NOT THEN CREATE ONE.
        if (!this.GetComponent<BoxCollider2D>())
        {
            gameObject.AddComponent<BoxCollider2D>();
        }
    }

	private void Update()
	{
       Debug.DrawRay(raycastRight.transform.position,Vector2.down * raycastDistance, Color.red);

       RaycastHit2D hitRight =  Physics2D.Raycast(raycastRight.transform.position, Vector2.down, raycastDistance, _walkableSurfaceLayer);
       RaycastHit2D hitLeft = Physics2D.Raycast(raycastLeft.transform.position, Vector2.down, raycastDistance, _walkableSurfaceLayer);


        if (hitRight.collider != null || hitLeft.collider != null)
        {
            _isGrounded = true;
            _isJumping = false;
        }
        else
        {
            //  _isGrounded = false;

        }
    }

	private void OnCollisionEnter2D(Collision2D collider)
    {
        //if (collider.gameObject.tag == _walkableSurfaceTagName && !_isGrounded)
        //{
        //     _isGrounded = true;
        //    _isJumping = false;
        //}


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
        }
    }


    private void OnCollisionExit2D(Collision2D walkableSurface)
    {
       // if (walkableSurface.gameObject.tag == _walkableSurfaceLayer && _isGrounded)
      //  {
       //     _isGrounded = false;
       // }
    }

    public void setStopMovement(bool t_stopMovement)
    {
        _stopMovement = t_stopMovement;
    }
	
	public void setWalkRight(bool t_moveRight)
	{
		_moveRight = t_moveRight;
	}

	public void setWalkLeft(bool t_moveLeft)
	{
		_moveLeft = t_moveLeft;
	}

	public void setIsJumping(bool t_isJumping)
    {
        _isJumping = t_isJumping;
		Debug.Log("Jumping State");

	}

	public bool getIsGrounded()
    {
        return _isGrounded;
    }

    public void setIsGrounded(bool t_isGrounded)
    {
        _isGrounded =t_isGrounded;
    }

    public bool getIsMovingRight()
    {
        return _moveRight;
    }

    public bool getIsMovingLeft()
    {
        return _moveLeft;
    }

    public bool getIsJumping()
    {
        return _isJumping;
    }

    public float getTimeSinceLastButtonPress()
    {
        return _elaspedTimeSinceButtonPress;
    }

    public void setTimeSinceLastButtonPress(float t_timeSinceLastUpdate)
    {
        _elaspedTimeSinceButtonPress = t_timeSinceLastUpdate;
    }

    public float getTimeLeft()
    {
        return _timeLeft;
    }

    public void setTimeLeft(float t_timeLeft)
    {
        _timeLeft = t_timeLeft;
    }

    public Vector2 getVelocity()
    {
        return _velocity;
    }

    public void setVelocity(Vector2 t_velocity)
    {
        _velocity = t_velocity;
    }

    public float getDeclaration()
    {
        return _declaration;
    }

    public void setDeclaration(float t_declaration)
    {
        _declaration = t_declaration;
    }

    public Rigidbody2D getRigidBody()
    {
        return rb;
    }

    public void setRigidBodyVelocity(Vector2 t_velocity)
    {
        rb.velocity = t_velocity;
    }

    public void setRigidBodyGravity(float t_gravity)
    {
        rb.gravityScale = t_gravity;
    }


    public void setJumpTimeCounter(float t_jumpTimeCounter)
    {
        jumpTimeCounter = t_jumpTimeCounter;
    }

    public float getJumpTimeCounter()
    {
        return jumpTimeCounter;
    }

}
