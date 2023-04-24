using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FollowPath : MonoBehaviour
{
    [SerializeField] PathCreator pathCreator;
    [SerializeField] float speed = 5;
    float distancedTravelled, rotSpeed;

    [SerializeField] float offsetDistance;

    bool hasOffset;

    private void OnEnable()
    {
        hasOffset = false;
        rotSpeed = Random.Range(7, 15);

        if (Random.Range(0, 2) == 0)
            rotSpeed *= -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (NanoGameManager.gameHasStarted)
        {
            distancedTravelled += speed * Time.deltaTime + offsetDistance;
            if (!hasOffset)
            {
                offsetDistance = 0;
                hasOffset = true;
            }

            transform.position = pathCreator.path.GetPointAtDistance(distancedTravelled);
            //transform.rotation = pathCreator.path.GetRotationAtDistance(distancedTravelled);

            if (NanoGameManager.playerWon)
            {
                transform.localEulerAngles += new Vector3(0, rotSpeed, 0);
            }
        }
    }
}
