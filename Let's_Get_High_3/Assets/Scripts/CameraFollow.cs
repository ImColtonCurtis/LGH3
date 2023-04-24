using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;    // The object the camera will follow
    [SerializeField] float smoothSpeed = 1.5f;    // The smoothness of the camera movement
    private Vector3 velocity = Vector3.zero;
    [SerializeField] Vector3 offset;    // The offset of the camera from the target

    void LateUpdate()
    {
        if (NanoGameManager.gameHasStarted && !NanoGameManager.playerWon && !NanoGameManager.playerLost)
        {
            Vector3 desiredPosition = target.position + offset;    // Calculate the desired position of the camera
                                                                   //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);    // Smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            transform.position = smoothedPosition;    // Set the position of the camera to the smoothed position
        }
    }
}
