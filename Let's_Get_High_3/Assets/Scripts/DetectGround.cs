using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGround : MonoBehaviour
{
    [SerializeField] bool isToppleTheCans;

    private void OnTriggerEnter(Collider other)
    {
        if (isToppleTheCans && other.tag == "FinishLine")
        {
            ToppleTheCans.staticCansToTopple--;
            MeshCollider myMesh = transform.GetComponent<MeshCollider>();
            if (myMesh != null)
                myMesh.enabled = false;
            if (ToppleTheCans.staticCansToTopple <= 0 && !NanoGameManager.playerWon)
                NanoGameManager.playerWon = true;
        }
    }
}
