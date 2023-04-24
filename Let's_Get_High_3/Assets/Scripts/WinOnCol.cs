using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOnCol : MonoBehaviour
{
    [SerializeField] MeshRenderer myMR;
    [SerializeField] GameObject myPS;
    [SerializeField] Rigidbody myRB;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinishLine")
        {
            NanoGameManager.playerWon = true;
            myRB.useGravity = false;
            myRB.constraints = RigidbodyConstraints.FreezeAll;
            myPS.SetActive(true);
            myMR.enabled = false;
        }
    }
}
