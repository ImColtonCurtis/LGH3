using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera2D : MonoBehaviour
{
    [SerializeField] Transform target;    // The object the camera will follow
    [SerializeField] float smoothSpeed;    // The smoothness of the camera movement
    private Vector3 velocity = Vector3.zero;
    [SerializeField] Vector3 offset;    // The offset of the camera from the target

    [SerializeField] bool lockToZ;

    void LateUpdate()
    {
        if (NanoGameManager.gameHasStarted && !NanoGameManager.playerWon && !NanoGameManager.playerLost)
        {
            Vector3 desiredPosition = target.position + offset;    // Calculate the desired position of the camera

            if (lockToZ)
                desiredPosition = new Vector3(0, desiredPosition.y, 0);

            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed); // Smoothly move the camera towards the desired position
            transform.position = smoothedPosition;    // Set the position of the camera to the smoothed position
        }
    }
}
