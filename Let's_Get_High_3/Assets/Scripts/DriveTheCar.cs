using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveTheCar : MonoBehaviour
{
    bool actioned, startObjects;

    float movementSpeed = 5.0f;
    [SerializeField] Transform carTransform;

    [SerializeField] MeshRenderer objMesh;
    [SerializeField] Material[] myMats;

    [SerializeField] bool stopTheCar, finishTheRace;

    // Start is called before the first frame update
    void Start()
    {
        actioned = false;

        int randMat = Random.Range(0, myMats.Length);
        objMesh.material = myMats[randMat];

        // reset gravity
        Physics.gravity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // start lit
        if (NanoGameManager.gameHasStarted && !startObjects)
        {
            // reset gravity
            Physics.gravity = new Vector3(0, -25f, 0);
            startObjects = true;
        }

        // preform action
        if (!stopTheCar && !finishTheRace)
        {
            if (actioned && NanoGameManager.gameHasStarted && !NanoGameManager.playerLost && !NanoGameManager.playerWon)
            {
                carTransform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            else if (actioned && (NanoGameManager.playerLost || NanoGameManager.playerWon))
            {
                actioned = false;
            }
        }
        else if (stopTheCar)
        {
            if (!actioned && NanoGameManager.gameHasStarted && !NanoGameManager.playerLost && !NanoGameManager.playerWon)
            {
                carTransform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            else if (!actioned && (NanoGameManager.playerLost || NanoGameManager.playerWon))
            {
                actioned = true;
            }
        }
        else if (finishTheRace)
        {
            if (!actioned && NanoGameManager.gameHasStarted && !NanoGameManager.playerLost && !NanoGameManager.playerWon)
            {
                carTransform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            if (NanoGameManager.playerWon)
            {
                carTransform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
                //carTransform.localEulerAngles += new Vector3(0, 10, 0);
            }
        }
    }

    void OnTouchDown()
    {
        if (!actioned)
        {
            actioned = true;
        }
    }

    void OnTouchUp()
    {
        if (actioned)
        {
            actioned = false;
        }
    }

    void OnTouchExit()
    {
        if (actioned)
        {
            actioned = false;
        }
    }
}
