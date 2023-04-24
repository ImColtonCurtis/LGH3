using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision2d : MonoBehaviour
{
    [SerializeField] GameObject triangleObj, particleObj, pastParticles;

    bool turnedOff;

    private void Start()
    {
        turnedOff = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && !NanoGameManager.playerLost && !NanoGameManager.playerWon)
        {
            NanoGameManager.playerLost = true;
            triangleObj.SetActive(false);
            // set particles to true
            particleObj.SetActive(true);
            pastParticles.SetActive(false);
        }
    }

    private void Update()
    {
        if (!turnedOff && NanoGameManager.playerWon)
        {
            pastParticles.SetActive(false);
            turnedOff = true;
        }
    }
}
