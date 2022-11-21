using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : State
{
    public InputForDiffMove gm;

    private MovingStateMachine _sm;
    public JumpingState(MovingStateMachine stateMachine) : base("moving", stateMachine)

    {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        gm = GameObject.FindObjectOfType<InputForDiffMove>();

        if (_sm._isIdle)
        {
            _sm._MovingWhileJumpingSpeed = 0;
        }
        else if (_sm._isMovingLeft)
        {
            _sm._MovingWhileJumpingSpeed = -_sm.movementController._MAX_WALKING_SPEED;
        }
        else
        {
            _sm._MovingWhileJumpingSpeed = _sm.movementController._MAX_WALKING_SPEED;
        }
        handleJumpInput();
   
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Input.GetKeyDown(_sm.movementController.leftKey))
        {
            _sm.movementController.setRigidBodyVelocity(_sm.movementController.getVelocity());
            _sm.movementController.setTimeSinceLastButtonPress(0.0f);
            stateMachine.ChangeState(_sm.movementLeft);
        }
        else if (Input.GetKeyDown(_sm.movementController.rightKey))
        {
            _sm.movementController.setRigidBodyVelocity(_sm.movementController.getVelocity());
            _sm.movementController.setTimeSinceLastButtonPress(0.0f);
            stateMachine.ChangeState(_sm.movementRight);
        }

        /////
        /////
        ///// Check for different jump modes
        /////
        /////
        if (gm.jumpStateIs == 1) // get boolean from antoher place
        {
            if (Input.GetKey(_sm.movementController.jumpKey) && _sm.movementController.getIsJumping()) // if space is pressed over long period of time
            {
            }
        }

        if (gm.jumpStateIs == 1) // get boolean from antoher place
        {
            if (Input.GetKey(_sm.movementController.jumpKey) && _sm.movementController.getIsJumping()) // if space is pressed over long period of time
            {
                continuousJump();
            }
        }
        if (gm.jumpStateIs == 2) // get boolean from antoher place
        {
            if (Input.GetKey(_sm.movementController.jumpKey) && _sm.movementController.getIsJumping()) // if space is pressed over long period of time
            {
                backJump();
            }
        }
        if (gm.jumpStateIs == 3) // get boolean from antoher place
        {
            if (Input.GetKey(_sm.movementController.jumpKey) && _sm.movementController.getIsJumping()) // if space is pressed over long period of time
            {
                highJump();
            }
        }

        if (gm.jumpStateIs == 4) // get boolean from antoher place
        {
            if (Input.GetKey(_sm.movementController.jumpKey))
            {
                doubleJump();
            }

        }

        if (gm.jumpStateIs == 5) // get boolean from antoher place
        {
            if (Input.GetKey(_sm.movementController.jumpKey) && _sm.movementController.getIsJumping()) // if space is pressed over long period of time
            {
                lowGravityJump();
            }
        }


        if (Input.GetKeyUp(_sm.movementController.jumpKey))
        {
            _sm.movementController.setIsJumping(false);
        }
        else if (_sm.movementController.getIsGrounded() && Input.GetKey(_sm.movementController.rightKey))
        {
            _sm.movementController.setRigidBodyVelocity(_sm.movementController.getVelocity());
            _sm.movementController.setWalkLeft(false);
            _sm.movementController.setWalkRight(true);
            stateMachine.ChangeState(_sm.movementRight);
        }
        else if (_sm.movementController.getIsGrounded() && Input.GetKey(_sm.movementController.leftKey))
        {
            _sm.movementController.setRigidBodyVelocity(_sm.movementController.getVelocity());
            _sm.movementController.setWalkLeft(true);
            _sm.movementController.setWalkRight(false);
            stateMachine.ChangeState(_sm.movementLeft);
        }
        else if (_sm.movementController.getIsGrounded())
        {
            _sm.movementController.setRigidBodyVelocity(_sm.movementController.getVelocity());
            _sm.movementController.setWalkLeft(false);
            _sm.movementController.setWalkRight(false);
            stateMachine.ChangeState(_sm.idleState);
        }

    }

    public void handleJumpInput()
    {

		Vector3 temp = _sm.movementController.getRigidBody().velocity;
		temp = Vector2.up * _sm.movementController.impluseJumpVel; // Impluse megaman into the air by a set amount.
		temp.x = _sm.movementController.getRigidBody().velocity.x;

		_sm.movementController.setRigidBodyVelocity(temp);
		_sm.movementController.setJumpTimeCounter(_sm.movementController.TimeToReachMaxHeight); // reset jumptimecounter.
		_sm.movementController.setIsJumping(true);
		_sm.movementController.setIsGrounded(false);
        _sm.movementController.setRigidBodyGravity(1);



    }


    public void highJump()
    {
        if (_sm.movementController.getJumpTimeCounter() > 0)
        {
            Vector3 temp = _sm.movementController.getRigidBody().velocity;
            temp.y = Vector2.up.y * _sm.movementController.impluseJumpVel * 2.3f;

            _sm.movementController.setRigidBodyVelocity(temp);
            _sm.movementController.setJumpTimeCounter(_sm.movementController.getJumpTimeCounter() - Time.deltaTime);
            _sm.movementController.setRigidBodyGravity(1);

        }
        else // Else he is falling.
        {
            _sm.movementController.setIsJumping(false);
        }
    }

    public void doubleJump()
    {

            Debug.Log("WOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
            Vector3 temp = _sm.movementController.getRigidBody().velocity;
            temp.y = Vector2.up.y * _sm.movementController.impluseJumpVel * 0.8f;

            _sm.movementController.setRigidBodyVelocity(temp);
            _sm.movementController.setIsJumping(true);
            _sm.movementController.setIsGrounded(false);
            _sm.movementController.setRigidBodyGravity(1);

    }




    public void continuousJump()
    {
        if (_sm.movementController.getJumpTimeCounter() > 0)
        {
            Vector3 temp = _sm.movementController.getRigidBody().velocity;
            temp = Vector2.up * _sm.movementController.impluseJumpVel * 1.3f;
            temp.x = _sm._MovingWhileJumpingSpeed;
            _sm.movementController.setRigidBodyVelocity(temp);
            _sm.movementController.setJumpTimeCounter(_sm.movementController.getJumpTimeCounter() - Time.deltaTime);
            _sm.movementController.setRigidBodyGravity(1);

        }
        else // Else he is falling.
        {
            _sm.movementController.setIsJumping(false);
        }
    }



    public void backJump()
    {
        if (_sm.movementController.getJumpTimeCounter() > 0)
        {
            Vector3 temp = -_sm.movementController.getRigidBody().velocity;
            temp = Vector2.up * _sm.movementController.impluseJumpVel * 1.3f;
            temp.x = -_sm._MovingWhileJumpingSpeed;
            _sm.movementController.setRigidBodyVelocity(temp);
            _sm.movementController.setJumpTimeCounter(_sm.movementController.getJumpTimeCounter() - Time.deltaTime);
            _sm.movementController.setRigidBodyGravity(1);
        }
        else // Else he is falling.
        {
            _sm.movementController.setIsJumping(false);
        }
    }

    public void lowGravityJump()
    {
        if (_sm.movementController.getJumpTimeCounter() > 0)
        {
            Vector3 temp = _sm.movementController.getRigidBody().velocity;
            temp.y = Vector2.up.y * _sm.movementController.impluseJumpVel * 1.0f;

            _sm.movementController.setRigidBodyVelocity(temp);
            _sm.movementController.setJumpTimeCounter(_sm.movementController.getJumpTimeCounter() - Time.deltaTime);
            _sm.movementController.setRigidBodyGravity(0.1f);

        }
        else // Else he is falling.
        {
            _sm.movementController.setIsJumping(false);
        }
    }


}