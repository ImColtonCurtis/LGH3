using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGround2D : MonoBehaviour
{
    [SerializeField] bool isDeliverTheBaby;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDeliverTheBaby && collision.tag == "FinishLine")
        {
            if (!NanoGameManager.playerWon)
                NanoGameManager.playerWon = true;
        }
    }
}
