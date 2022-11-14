using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite
{
	[UnityTest]
	public IEnumerator LeftMovementTest()
	{
		GameObject gm = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
		//gm.GetComponent<GameManager>().sprintIsActive = true;

		GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
		Vector3 position = player.GetComponent<Rigidbody2D>().transform.position;

		player.GetComponent<MovingStateMachine>().setInitalState(player.GetComponent<MovingStateMachine>().movementLeft);
		player.GetComponent<MovingStateMachine>().movementLeft.moveLeft();
		yield return new WaitForSeconds(1.0f);
		Assert.Less(player.GetComponent<Rigidbody2D>().position.x, position.x);
	}

	[UnityTest]
	public IEnumerator RightMovementTest()
	{
		GameObject gm = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
		//gm.GetComponent<GameManager>().sprintIsActive = true;

		GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
		Vector3 position = player.GetComponent<Rigidbody2D>().transform.position;



		player.GetComponent<MovingStateMachine>().setInitalState(player.GetComponent<MovingStateMachine>().movementRight);
		player.GetComponent<MovingStateMachine>().movementRight.moveRight();
		yield return new WaitForSeconds(1.0f);
		Assert.Greater(player.GetComponent<Rigidbody2D>().position.x, position.x);
	}


	[UnityTest]
	public IEnumerator IntialJumpTest()
	{
		GameObject gm = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));

		GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
		Vector3 position = player.GetComponent<Rigidbody2D>().transform.position;
		MovingStateMachine msm = player.GetComponent<MovingStateMachine>();
		player.GetComponent<MovingStateMachine>().setInitalState(player.GetComponent<MovingStateMachine>().jumping);
		player.GetComponent<MovingStateMachine>().jumping.handleJumpInput();
		yield return new WaitForSeconds(0.1f);
		Assert.Greater(player.GetComponent<Rigidbody2D>().position.y, position.y);
	}







}
