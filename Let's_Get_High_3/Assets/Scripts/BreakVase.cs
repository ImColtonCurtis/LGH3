using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakVase : MonoBehaviour
{
    [SerializeField] GameObject cleanObj, brokenObj, holderObj;

    [SerializeField] bool dontBreak;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            // set player won to true
            if (dontBreak)
                NanoGameManager.playerLost = true;
            else
                NanoGameManager.playerWon = true;

            brokenObj.SetActive(true);
            holderObj.transform.position = cleanObj.transform.position;
            brokenObj.transform.localEulerAngles = cleanObj.transform.localEulerAngles;

            cleanObj.SetActive(false);
        }
    }
}
