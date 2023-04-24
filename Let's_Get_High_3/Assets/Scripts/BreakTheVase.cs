using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTheVase : MonoBehaviour
{
    bool actioned;

    [SerializeField] MeshRenderer objMesh;

    [SerializeField] Material[] myMats;

    [SerializeField] Rigidbody myRB;

    [SerializeField] Animator myAnim;

    [SerializeField] bool isSadTable;

    // Start is called before the first frame update
    void Start()
    {
        actioned = false;

        if (isSadTable)
            myAnim.SetBool("sadTable", true);
        else
            myAnim.SetBool("sadTable", false);

        int randMat = Random.Range(0, myMats.Length);
        objMesh.material = myMats[randMat];
    }

    void OnTouchDown()
    {
        if (NanoGameManager.gameHasStarted && !actioned && !NanoGameManager.playerLost)
        {
            Actions();
            actioned = true;
        }
    }

    void Actions()
    {
        // set gravity
        Physics.gravity = new Vector3(0, -38f, 0);

        // unfreeze RB
        myRB.constraints = RigidbodyConstraints.None;

        // knock table
        myAnim.SetTrigger("Knock");

        // turn rb gravity on
        myRB.useGravity = true;
    }
}
