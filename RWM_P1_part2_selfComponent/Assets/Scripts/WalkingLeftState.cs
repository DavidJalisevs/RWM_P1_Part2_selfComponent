using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingLeftState : State
{
    private MovingStateMachine _sm;
    public GameManager gm;

    public WalkingLeftState(MovingStateMachine stateMachine) : base("moving", stateMachine)
    {
        _sm = stateMachine;

    }

public override void Enter()
    {
        base.Enter();
        handleLeftInput();

        Vector3 temp = _sm.transform.localScale;
        if (temp.x > 0) { temp.x *= -1; }
        _sm.transform.localScale = temp;
        gm = GameObject.FindObjectOfType<GameManager>();

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

		if (gm.sprintIsActive) // get boolean from antoher place
		{
			moveLeft();
		}
		else
		{
			moveLeftSlowly();
		}

		if (gm.dashIsActivated) // get boolean from antoher place
		{
			dash();
		}


		_sm.movementController.setTimeSinceLastButtonPress(_sm.movementController.getTimeSinceLastButtonPress() + Time.deltaTime);

        if (Input.GetKeyUp(_sm.movementController.leftKey))
        {
            _sm.movementController.setVelocity(_sm.movementController.getRigidBody().velocity);
            _sm.movementController.setWalkLeft(false);
            stateMachine.ChangeState(_sm.idleState);
        }
        else if (Input.GetKeyDown(_sm.movementController.rightKey))
        {
            _sm.movementController.setWalkLeft(false);
            _sm.movementController.setTimeSinceLastButtonPress(0.0f);
            stateMachine.ChangeState(_sm.movementRight);
        }
        else if (Input.GetKeyDown(_sm.movementController.jumpKey) )
        {
            stateMachine.ChangeState(_sm.jumping);
        }
    }

    public void handleLeftInput()
    {
        if (_sm.movementController.getIsMovingRight())
        {
            _sm.movementController.setTimeLeft(_sm.movementController._movementTime * 2.0f);
        }
        else
        {
            _sm.movementController.setTimeLeft(_sm.movementController._movementTime);
            if (_sm.movementController.getVelocity().x < 0.0f)
            {
                _sm.movementController.setTimeLeft(_sm.movementController._MAX_WALKING_SPEED - _sm.movementController.getVelocity().x / _sm.movementController.acclearation); // t = v - u / a.
            }
        }
        _sm.movementController.setWalkLeft(true);
        _sm.movementController.setWalkRight(false);
    }

    public void moveLeft()
    {
        Vector2 temp = _sm.movementController.getVelocity();
        if (_sm.movementController.getTimeSinceLastButtonPress() < _sm.movementController.getTimeLeft())
        {
            temp = _sm.movementController.getVelocity();
            temp = _sm.movementController.getRigidBody().velocity;
            temp.x = -getVel(_sm.movementController.getTimeSinceLastButtonPress(), temp.y).x;
            _sm.movementController.setRigidBodyVelocity(temp);
            _sm.movementController.setVelocity(temp);
           _sm.movementController.setRigidBodyVelocity(new Vector2(Mathf.Clamp(temp.x, -_sm.movementController._MAX_WALKING_SPEED, _sm.movementController._MAX_WALKING_SPEED), temp.y)); // Clamp speed.
        }
        else
        {
            temp = _sm.movementController.getRigidBody().velocity;
            temp.x = -_sm.movementController._MAX_WALKING_SPEED;
            _sm.movementController.setRigidBodyVelocity(temp);
            _sm.movementController.setVelocity(temp);
        }
		Debug.Log("Walking Left State");

	}


    public void moveLeftSlowly()
    {
        Vector2 temp = _sm.movementController.getVelocity();
        if (_sm.movementController.getTimeSinceLastButtonPress() < _sm.movementController.getTimeLeft())
        {
            temp = _sm.movementController.getVelocity();
            temp = _sm.movementController.getRigidBody().velocity;
            temp.x = -getVel(_sm.movementController.getTimeSinceLastButtonPress(), temp.y).x;
            _sm.movementController.setRigidBodyVelocity(temp);
            _sm.movementController.setVelocity(temp);
            _sm.movementController.setRigidBodyVelocity(new Vector2(Mathf.Clamp(temp.x, -_sm.movementController._LOWEST_SLOWWALKING_SPEED, 
                                                                                _sm.movementController._MAX_SLOWWALKING_SPEED), temp.y)); // Clamp speed.
        }
        else
        {
            temp = _sm.movementController.getRigidBody().velocity;
            temp.x = -_sm.movementController._MAX_SLOWWALKING_SPEED;
            _sm.movementController.setRigidBodyVelocity(temp);
            _sm.movementController.setVelocity(temp);
        }
        Debug.Log("Walking Left State SLOWLY");

    }

    public void dash()
    {
        //Vector2 temp = _sm.movementController.getVelocity();

        //temp = _sm.movementController.getVelocity();
        //temp = _sm.movementController.getRigidBody().velocity;
        //temp.x = getVel(_sm.movementController.getTimeSinceLastButtonPress(), temp.y).x;
        //_sm.movementController.setRigidBodyVelocity(temp);
        //_sm.movementController.setVelocity(temp);
        //_sm.movementController.setRigidBodyVelocity(new Vector2(Mathf.Clamp(temp.x, -30, 30), temp.y)); // Clamp speed.
        _sm.transform.position = new Vector2(_sm.transform.position.x - 2, _sm.transform.position.y);

        Debug.Log("DASHHHHH");
    }



 




    Vector2 getVel(float time, float t_yVel)
    {
        return new Vector3(_sm.movementController.acclearation * time, t_yVel, 0.0f); // v = u + at.
    }
}