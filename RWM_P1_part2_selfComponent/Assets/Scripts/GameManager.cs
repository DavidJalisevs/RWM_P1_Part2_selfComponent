using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public PlayerScript player;
    public TextMeshProUGUI jumpModeText;
    public Canvas bgCanvas;
    public float targetTime = 0.5f;

    public static GameManager instance;
    private string deviceID;
    public bool continuesJump = false;
    public int jumpStateIs = 0;
    public bool doubleJumpCount = true;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        jumpModeText.text = "Normal Jump";
        jumpStateIs = 4;
        instance.player = FindObjectOfType<PlayerScript>();
    }


    // Update is called once per frame
    void Update()
    {
        if (instance != null)
        {

        }

        checkForJumpSwitch();

        targetTime -= Time.deltaTime;

        switch (jumpStateIs)
        {
            case 0:
                jumpModeText.text = "Normal Jump";
                break;
            case 1:
                jumpModeText.text = "Front Jump";
                break;
            case 2:
                jumpModeText.text = "Back Jump";
                break;
            case 3:
                jumpModeText.text = "high Jump";
                break;
            case 4:
                jumpModeText.text = "double Jump";
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }

    public void checkForJumpSwitch()
    {
        if (targetTime <= 0.0f)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                //continuesJump ^= true ;
                // continuesJump = !continuesJump;

                Debug.Log("JUMP is " + continuesJump);
                jumpStateIs = jumpStateIs + 1;
                targetTime = 0.5f;

            }

        }

        if (jumpStateIs > 4)
        {
            jumpStateIs = 0;
        }


        

 

        Debug.Log("NUMBER IS : " + jumpStateIs);

    }
}