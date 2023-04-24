using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatTheHotdog : MonoBehaviour
{
    [SerializeField] MeshRenderer objMesh;

    [SerializeField] Material[] myMats;

    bool hasStarted, actioned;

    [SerializeField] Animator myAnim;

    int incrementor;

    // Start is called before the first frame update
    void Start()
    {
        actioned = false;

        incrementor = 0;

        // set gravity
        //Physics.gravity = new Vector3(0, 0, 0);

        int randMat = Random.Range(0, myMats.Length);
        objMesh.material = myMats[randMat];
    }

    private void Update()
    {
        if (NanoGameManager.gameHasStarted && !hasStarted)
        {
            hasStarted = true;
        }
    }

    private void FixedUpdate()
    {
        if (actioned && incrementor < 45)
        {
            incrementor++;
        }
        else if (incrementor >= 45 && !NanoGameManager.playerWon)
        {
            NanoGameManager.playerWon = true;
        }
        if (NanoGameManager.playerLost && myAnim.enabled)
        {
            myAnim.enabled = false;
        }
    }

    void OnTouchDown()
    {
        if (NanoGameManager.gameHasStarted && !NanoGameManager.playerLost && !actioned && !NanoGameManager.playerWon)
        {
            Actions();
            actioned = true;
        }
    }

    void OnTouchUp()
    {
        if (NanoGameManager.gameHasStarted && !NanoGameManager.playerLost && actioned && !NanoGameManager.playerWon)
        {
            UnActions();
            actioned = false;
        }
    }

    void OnTouchExit()
    {
        if (NanoGameManager.gameHasStarted && !NanoGameManager.playerLost && actioned && !NanoGameManager.playerWon)
        {
            UnActions();
            actioned = false;
        }
    }

    void Actions()
    {
        myAnim.SetTrigger("Eat");
        myAnim.enabled = true;
    }

    void UnActions()
    {
        myAnim.enabled = false;
    }
}
