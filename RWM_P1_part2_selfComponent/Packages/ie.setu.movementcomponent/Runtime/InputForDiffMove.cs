using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InputForDiffMove : MonoBehaviour
{
    //public PlayerProp player;
    //public TextMeshProUGUI jumpModeText;
    //public Canvas bgCanvas;
    public float targetTime = 0.5f;

    public static InputForDiffMove instance;
    private string deviceID;
    public bool continuesJump = false;
    public int jumpStateIs = 0;
    public bool doubleJumpCount = true;
    public bool sprintIsActive = false;
    public bool dashIsActivated = false;


    // Start is called before the first frame update
    void Start()
    {
   
       // jumpModeText.text = "Normal Jump";
        jumpStateIs = 3;
    }


    // Update is called once per frame
    void Update()
    {
    
        targetTime -= Time.deltaTime;
        checkForJumpSwitch();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintIsActive = true;
        }
        else
        {
            sprintIsActive = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            dashIsActivated = true;
        }
        else
        {
            dashIsActivated = false;
        }


        // Debug.Log("Sprint is active : "+ sprintIsActive);

    }

    public void checkForJumpSwitch()
    {
        if (targetTime <= 0.0f)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                //continuesJump ^= true ;
                // continuesJump = !continuesJump;

              

				jumpStateIs = jumpStateIs + 1;
				if (jumpStateIs == 0)
				{
					Debug.Log("JUMP is Normal Jump");
				}
				if (jumpStateIs == 1)
				{
					Debug.Log("JUMP is Front Jump");
				}
				if (jumpStateIs == 2)
				{
					Debug.Log("JUMP is Back Jump");
				}
				if (jumpStateIs == 3)
				{
					Debug.Log("JUMP is high Jump");
				}
				if (jumpStateIs == 4)
				{
					Debug.Log("JUMP is double Jump");
				}
				if (jumpStateIs == 5)
				{
					Debug.Log("JUMP is Low Gravity Jump");
				}
				targetTime = 0.5f;

            }

        }

        if (jumpStateIs > 5)
        {
            jumpStateIs = 0;
        }

        switch (jumpStateIs)
        {
            case 0:
               // jumpModeText.text = "Normal Jump";
                break;
            case 1:
               // jumpModeText.text = "Front Jump";
                break;
            case 2:
              //  jumpModeText.text = "Back Jump";
                break;
            case 3:
               // jumpModeText.text = "high Jump";
                break;
            case 4:
              //  jumpModeText.text = "double Jump";
                break;
            case 5:
              //  jumpModeText.text = "Low Gravity Jump";
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }
}
