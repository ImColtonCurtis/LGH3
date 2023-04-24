using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class InputManager : MonoBehaviour
{
    // ScreenSquare
    public SpriteRenderer screenSquareSR;

    // Menu Set-up
    // Camera Stuff
    [SerializeField] Transform cameraHolder, cameraFloat;
    bool goingUp;
    //[SerializeField] PostProcessVolume myPPV;
    //PostProcessProfile myPPP;
    //DepthOfField dph;

    // TV Screen
    public Transform tVScreenTransform;

    // Robot Animations
    public Animator robotAniml;

    // Button Items
    bool pressed;

    [SerializeField] GameObject gameControls;
    [SerializeField] TouchInput menuControls;

    private void Awake()
    {
        // Fade out squareScreen
        screenSquareSR.color = Color.black;
        StartCoroutine(FadeScreenSquareOut());

        // Camera Stuff
      //  myPPP = myPPV.profile;
      //  if (myPPP.TryGetSettings<DepthOfField>(out dph))
      //      dph.focusDistance.value = 4;

        StartCoroutine(ZoomCamera0());
 //       StartCoroutine(RackFocusCamera0());

        pressed = false;

        goingUp = true;

        StartCoroutine(CameraFloat());
    }


    void OnTouchDown()
    {
        if (!GameManager.gameStarted)
        {
            robotAniml.SetBool("FallNow", true);
            robotAniml.SetTrigger("Falling");
            pressed = true;
        }
    }

    void OnTouchUp()
    {
        if (pressed && !GameManager.gameStarted)
        {
            GameManager.gameStarted = true;
            StartCoroutine(ZoomCamera1());
//            StartCoroutine(RackFocusCamera1());
            StartCoroutine(RaiseTVScreen());
            StartCoroutine(FloatBackToZero());

            robotAniml.SetTrigger("Fall");
        }
    }

    void OnTouchExit()
    {
        if (pressed && !GameManager.gameStarted)
        {
            GameManager.gameStarted = true;
            StartCoroutine(ZoomCamera1());
 //           StartCoroutine(RackFocusCamera1());
            StartCoroutine(RaiseTVScreen());
            StartCoroutine(FloatBackToZero());

            robotAniml.SetTrigger("Fall");
        }
    }

    IEnumerator FadeScreenSquareOut()
    {
        float timer = 0, totalTime = 30;
        yield return new WaitForSecondsRealtime(0.3f);
        while (timer <= totalTime)
        {
            screenSquareSR.color = Color.Lerp(Color.black, new Color(0, 0, 0, 0), timer / totalTime);
            yield return new WaitForFixedUpdate();
            timer++;
        }
    }

    // Camera Movement/Focus Racking/Zoom Code
    IEnumerator ZoomCamera0()
    {
        float timer = 0, totalTimer = 480;
        cameraHolder.transform.localPosition = new Vector3(-1, 3.79f, -4.87f);
        while (timer <= totalTimer)
        {
            cameraHolder.transform.localPosition = Vector3.Lerp(cameraHolder.transform.localPosition, new Vector3(-1, 3.79f, -4), timer / totalTimer);
            yield return new WaitForFixedUpdate();
            timer++;
            if (timer > 68)
                break;
        }
        cameraHolder.transform.localPosition = new Vector3(-1, 3.79f, -4);
    }

    /*
    IEnumerator RackFocusCamera0()
    {
        float timer = 0, totalTimer = 68;

        while (timer <= totalTimer)
        {
            dph.focusDistance.value = Mathf.Lerp(4, 3.52f, timer / totalTimer);
            yield return new WaitForFixedUpdate();
            timer++;
        }
        dph.focusDistance.value = 3.52f;
        yield return new WaitForSecondsRealtime(0.8f);
    }
    */

    IEnumerator ZoomCamera1()
    {
        float timer = 0, totalTimer = 750; // was 480

        cameraHolder.transform.localPosition = new Vector3(-1, 3.79f, -4);
        while (timer <= totalTimer)
        {
            cameraHolder.transform.localPosition = Vector3.Lerp(cameraHolder.transform.localPosition, new Vector3(-1, 3.79f, -1.13f), timer / totalTimer);
            yield return new WaitForFixedUpdate();
            timer++;
            if (timer > 104)
                break;
        }
        menuControls.enabled = true;
        gameControls.SetActive(false);
        GameManager.usingMenuControls = true;

        cameraHolder.transform.localPosition = new Vector3(-1, 3.79f, -1.13f);
    }

    /*
    IEnumerator RackFocusCamera1()
    {
        float timer = 0, totalTimer = 68;

    // 6.44
    // 16.31

        while (timer <= totalTimer)
        {
            dph.focusDistance.value = Mathf.Lerp(3.52f, 2.84f, timer / totalTimer);
            yield return new WaitForFixedUpdate();
            timer++;
        }
        dph.focusDistance.value = 2.84f;
    }
    */

    // Raise TV Screen
    IEnumerator RaiseTVScreen()
    {
        float timer = 0, totalTimer = 960;

        tVScreenTransform.localPosition = new Vector3(-1, -4.7f, 3);
        while (timer <= totalTimer)
        {
            tVScreenTransform.localPosition = Vector3.Lerp(tVScreenTransform.localPosition, new Vector3(-1, 3.8f, 3), timer / totalTimer);
            yield return new WaitForFixedUpdate();
            timer++;
            if (timer > 106)
                break;
        }
        StartCoroutine(LowerTVScreen());
    }

    // Lower TV Screen
    IEnumerator LowerTVScreen()
    {
        float timer = 0, totalTimer = 18;
        Vector3 currentPos = tVScreenTransform.localPosition;
        while (timer <= totalTimer)
        {
            tVScreenTransform.localPosition = Vector3.Lerp(currentPos, new Vector3(-1, 3.78f, 3), timer / totalTimer);
            yield return new WaitForFixedUpdate();
            timer++;
        }
        tVScreenTransform.localPosition = new Vector3(-1, 3.78f, 3);
    }

    // Camera Float
    IEnumerator CameraFloat()
    {
        float timer = 0, totalTimer = Random.Range(1700, 2400);
        float timeCheck = Random.Range(94, 231);
        //Vector3 startingPos = cameraFloat.localPosition;
        Vector3 endingPos;
        if (goingUp)
            endingPos = new Vector3(0, 0.0425f, 0);
        else
            endingPos = new Vector3(0, -0.0425f, 0);

        while (timer <= totalTimer)
        {
            cameraFloat.localPosition = Vector3.Lerp(cameraFloat.localPosition, endingPos, timer / totalTimer);
            yield return new WaitForFixedUpdate();
            timer++;
            if (timer > timeCheck || GameManager.gameStarted)
                break;
        }
        cameraFloat.localPosition = endingPos;
        goingUp = !goingUp;
        if (!GameManager.gameStarted)
            StartCoroutine(CameraFloat());
    }

    IEnumerator FloatBackToZero()
    {
        float timer = 0, totalTimer = 240;
        Vector3 startingPos = cameraFloat.localPosition, endingPos = Vector3.zero;

        while (timer <= totalTimer)
        {
            cameraFloat.localPosition = Vector3.Lerp(startingPos, endingPos, timer / totalTimer);
            yield return new WaitForFixedUpdate();
            timer++;
        }
        cameraFloat.localPosition = Vector3.zero;
    }
}