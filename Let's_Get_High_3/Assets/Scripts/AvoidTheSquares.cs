using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidTheSquares : MonoBehaviour
{
    Vector3 prevPoint = Vector3.zero;

    [SerializeField]
    Transform rotationTransform, planeTransform;

    float rotationSpeed = 1, delta;

    bool centeringPlane = false, startedCentering, completedCentering, touchedDown;

    public static bool fastTap = false;

    float flySpeed = 0.0825f, baseTurnSpeed = 2.2f; // was 3150


    // Start is called before the first frame update
    void Start()
    {
        touchedDown = false;

        // set gravity
        Physics.gravity = new Vector3(0, -38f, 0);
    }

    // plane rotating

    private void FixedUpdate()
    {
        if (NanoGameManager.gameHasStarted && !NanoGameManager.playerLost && !NanoGameManager.playerWon)
        {
            // move plane up
            planeTransform.localPosition += new Vector3(0, flySpeed, 0);

            // bring plane to even wings
            if (!centeringPlane && Mathf.Abs(planeTransform.localPosition.x) > 270)
            {
                centeringPlane = true;
                completedCentering = false;
                StartCoroutine(BringToCenter());
            }
            // carry out movement
            if (Mathf.Abs(delta) > 0)
            {
                delta -= delta * 0.0667f;
                rotationSpeed = (Mathf.Abs(delta) / 10) + baseTurnSpeed; // was 2000
                rotationTransform.Translate(Vector3.left * delta * rotationSpeed);

                // clamp
                rotationTransform.localPosition = new Vector3(Mathf.Clamp(rotationTransform.localPosition.x, -1.35f, 1.35f), 0, 0);

                if (!startedCentering && !completedCentering)
                {
                    rotationSpeed = (Mathf.Abs(delta) / 10) + (baseTurnSpeed / 2); // was 1000
     //               planeTransform.Rotate(Vector3.forward * delta * rotationSpeed);

                    // clamp
     //               planeTransform.localEulerAngles = new Vector3(0, 0, Mathf.Clamp(planeTransform.localEulerAngles.z, -25f, 25f));
                }
            }
        }
        else if (NanoGameManager.gameHasStarted)
        {

        }

    }
    void OnTouchDown()
    {
        touchedDown = true;
    }

    void OnTouchUp()
    {
        touchedDown = false;
    }

    void OnTouchExit()
    {
        touchedDown = false;
    }

    void OnTouchStay(Vector3 point)
    {

        if (prevPoint == Vector3.zero)
            prevPoint = point;

        delta = Mathf.Clamp(point.x - prevPoint.x, -0.045f, 0.045f);

        prevPoint = point;

        if (NanoGameManager.gameHasStarted && !NanoGameManager.playerLost && !NanoGameManager.playerWon)
        {
            rotationSpeed = (Mathf.Abs(delta) / 10) + baseTurnSpeed; // was 2000
            rotationTransform.Translate(Vector3.left * delta * rotationSpeed * Time.fixedDeltaTime * 50);

            // clamp
            rotationTransform.localPosition = new Vector3(Mathf.Clamp(rotationTransform.localPosition.x, -1.35f, 1.35f), 0, 0);

            rotationSpeed = (Mathf.Abs(delta) / 10) + (baseTurnSpeed / 2); // was 1000
 //           planeTransform.Rotate(Vector3.forward * delta * rotationSpeed * Time.fixedDeltaTime * 50);

            // clamp
 //           planeTransform.localEulerAngles = new Vector3(0, 0, Mathf.Clamp(planeTransform.localEulerAngles.z, -25f, 25f));
        }
        else if (NanoGameManager.gameHasStarted)
        {

        }        
    }

    IEnumerator BringToCenter()
    {
        float timer = 0, totalTime = Mathf.Max(Mathf.Abs(delta) * 1000, 22);
        yield return new WaitForSeconds(Mathf.Max(3, totalTime / 2) / 60);
        startedCentering = true;
        float startingAngle = planeTransform.localEulerAngles.x;
        Vector3 startingPosition = planeTransform.localPosition;
        if (NanoGameManager.playerWon)
            startingAngle = planeTransform.localEulerAngles.z;

        while (timer <= totalTime && !touchedDown && (!NanoGameManager.playerWon))
        {
            float newAngle = Mathf.Lerp(startingAngle, 270, timer / totalTime);

            if (!NanoGameManager.playerWon)
                planeTransform.localEulerAngles = new Vector3(Mathf.Clamp(newAngle, 270, 307), planeTransform.localEulerAngles.y, planeTransform.localEulerAngles.z);
            else
            {
                // correct angle
                newAngle = Mathf.Lerp(startingAngle, 180, timer / totalTime);
                planeTransform.localEulerAngles = new Vector3(planeTransform.localEulerAngles.x, planeTransform.localEulerAngles.y, Mathf.Clamp(newAngle, 143f, 217f));
                // correct position
                planeTransform.localPosition = Vector3.Lerp(new Vector3(startingPosition.x, planeTransform.localPosition.y, planeTransform.localPosition.z), new Vector3(0, planeTransform.localPosition.y, planeTransform.localPosition.z), timer / totalTime);
            }
            yield return new WaitForFixedUpdate();
            timer++;

            if (touchedDown && !NanoGameManager.playerWon)
                break;
        }
        completedCentering = true;
        startedCentering = false;
        centeringPlane = false;
    }
}
