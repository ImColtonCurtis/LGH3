using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRayLogic : MonoBehaviour
{
    public SpriteRenderer lightRays, lensFlare;
    public Material titleMat, threeMat;
    float tempH, tempS, tempV;

    public Transform titleTransform;

    bool semaphore;

    [SerializeField] Light faceLight, legLight;
    [SerializeField] Color faceLightColor;

    private void Awake()
    {
        semaphore = true;
        StartCoroutine(SpawnLightTitle());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameStarted && semaphore)
        {
            StartCoroutine(HideLightTitle());
            semaphore = false;
        }
    }

    IEnumerator SpawnLightTitle()
    {
        float timer = 0, totalTime = 15;

        Color startingColor = lightRays.color;
        startingColor = new Color(startingColor.r, startingColor.g, startingColor.b, 0);
        Color endingColor = lightRays.color;

        Color startingColor2 = lensFlare.color;
        startingColor = new Color(startingColor.r, startingColor.g, startingColor.b, 0);
        Color endingColor2 = lensFlare.color;

        Color startingColor3 = titleMat.color;
        Color endingColor3 = titleMat.color;

        startingColor3 = new Color(titleMat.color.r, titleMat.color.g, titleMat.color.b, 1);
        Color.RGBToHSV(startingColor3, out tempH, out tempS, out tempV);
        startingColor3 = Color.HSVToRGB(tempH, tempS, 0);

        lensFlare.color = startingColor2;
        titleMat.color = startingColor3;
        threeMat.color = startingColor3;
        lightRays.color = startingColor;

        titleMat.SetColor("_EmissionColor", new Color(0, 0, 0));
        threeMat.SetColor("_EmissionColor", new Color(0, 0, 0));
        titleMat.color = Color.Lerp(startingColor3, endingColor3, timer / totalTime);
        threeMat.color = Color.Lerp(startingColor3, endingColor3, timer / totalTime);

        faceLight.color = Color.black;
        legLight.color = Color.black;

        yield return new WaitForSecondsRealtime(0.75f);

        while (timer < totalTime)
        {
            faceLight.color = Color.Lerp(Color.black, faceLightColor, timer / totalTime);
            legLight.color = Color.Lerp(Color.black, faceLightColor, timer / totalTime);

            Color emissionColor = Color.Lerp(new Color(0,0,0), new Color(1.305826f, 1.305826f, 1.305826f), timer/totalTime);
            titleMat.SetColor("_EmissionColor", emissionColor);
            emissionColor = Color.Lerp(new Color(0, 0, 0), new Color(0.42f, 0.42f, 0.42f), timer / totalTime);
            threeMat.SetColor("_EmissionColor", emissionColor);
            titleMat.color = Color.Lerp(startingColor3, endingColor3, timer / totalTime);
            threeMat.color = Color.Lerp(startingColor3, endingColor3, timer / totalTime);

            lensFlare.color = Color.Lerp(startingColor2, endingColor2, timer / totalTime);
            lightRays.color = Color.Lerp(startingColor, endingColor, timer / totalTime);
            yield return new WaitForFixedUpdate();
            timer++;
        }
        StartCoroutine(Flicker());
    }

    IEnumerator HideLightTitle()
    {
        float timer = 0, totalTime = 15;

        Color startingColor = lightRays.color;
        startingColor = new Color(startingColor.r, startingColor.g, startingColor.b, 0);
        Color endingColor = lightRays.color;

        Color startingColor2 = lensFlare.color;
        startingColor2 = new Color(startingColor.r, startingColor.g, startingColor.b, 0);
        Color endingColor2 = lensFlare.color;

        Color startingColor3 = titleMat.color;
        Color endingColor3 = titleMat.color;

        startingColor3 = new Color(titleMat.color.r, titleMat.color.g, titleMat.color.b, 1);
        Color.RGBToHSV(startingColor3, out tempH, out tempS, out tempV);
        startingColor3 = Color.HSVToRGB(tempH, tempS, 0);

        Vector3 startingPos = titleTransform.localPosition;
        Vector3 endingPos = new Vector3(startingPos.x, startingPos.y, startingPos.z+0.1f);

        lensFlare.color = endingColor2;
        titleMat.color = endingColor3;
        threeMat.color = endingColor3;
        lightRays.color = endingColor;
        yield return new WaitForSecondsRealtime(0.74f);

        Color startTitleEmissionColor = titleMat.GetColor("_EmissionColor");
        Color startThreeEmissionColor = threeMat.GetColor("_EmissionColor");

        while (timer < totalTime)
        {
            titleTransform.localPosition = Vector3.Lerp(startingPos, endingPos, timer / totalTime);

            faceLight.color = Color.Lerp(faceLightColor, Color.black, timer / totalTime);
            legLight.color = Color.Lerp(faceLightColor, Color.black, timer / totalTime);

            Color emissionColor = Color.Lerp(startTitleEmissionColor, new Color(0, 0, 0), timer / totalTime);
            titleMat.SetColor("_EmissionColor", emissionColor);
            emissionColor = Color.Lerp(startThreeEmissionColor, new Color(0, 0, 0), timer / totalTime);
            threeMat.SetColor("_EmissionColor", emissionColor);

            titleMat.color = Color.Lerp(endingColor3, startingColor3, timer / totalTime);
            threeMat.color = Color.Lerp(endingColor3, startingColor3, timer / totalTime);

            lensFlare.color = Color.Lerp(endingColor2, startingColor2, timer / totalTime);
            lightRays.color = Color.Lerp(endingColor, startingColor, timer / totalTime);
            yield return new WaitForFixedUpdate();
            timer++;

            if (timer == 6)
                StartCoroutine(DownsizeLightTitle());
        }        
    }

    IEnumerator DownsizeLightTitle()
    {
        float timer = 0, totalTime = 22;

        Vector3 startingSize = titleTransform.localScale;
        Vector3 endingSize = new Vector3(0.64586f, 0.64586f, 0.64586f);

        while (timer < totalTime)
        {
            titleTransform.localScale = Vector3.Lerp(startingSize, endingSize, timer / totalTime);
            yield return new WaitForFixedUpdate();
            timer++;
        }
    }

    IEnumerator Flicker()
    {
        float timer = 0, totalTime = Random.Range(1, 9);

        Color startingColor = lightRays.color;
        Color endingColor;
        
        Color startingColor2 = titleMat.color;
        Color endingColor2;

        float flickerAmount;

        if (Random.Range(0, 2) == 0)
            flickerAmount = Random.Range(0.03f, 0.125f);
        else
            flickerAmount = Random.Range(-0.125f, -0.03f);

        endingColor = new Color(lightRays.color.r, lightRays.color.g, lightRays.color.b, lightRays.color.a + flickerAmount);

        if (endingColor.a >= 0.45f || endingColor.a < 0.30f)
        {
            if (endingColor.a >= 0.45f)
                endingColor = new Color(lightRays.color.r, lightRays.color.g, lightRays.color.b, 0.45f);
            else
                endingColor = new Color(lightRays.color.r, lightRays.color.g, lightRays.color.b, 0.3f);
        }

        endingColor2 = new Color(titleMat.color.r, titleMat.color.g, titleMat.color.b, 1);
        Color.RGBToHSV(endingColor2, out tempH, out tempS, out tempV);
        endingColor2 = Color.HSVToRGB(tempH, tempS, 0.89f + ((endingColor.a - 0.3f) / 0.15f * 0.11f));

        Color startColor3 = titleMat.GetColor("_EmissionColor");
        Color startColor4 = threeMat.GetColor("_EmissionColor");
        flickerAmount /= 3f;
        Color endColor3 = new Color(startColor3.r + flickerAmount, startColor3.g + flickerAmount, startColor3.b + flickerAmount);
        Color endColor4 = new Color(startColor4.r + flickerAmount, startColor4.g + flickerAmount, startColor4.b + flickerAmount);

        while (timer < totalTime)
        {
            Color emissionColor = Color.Lerp(startColor3, endColor3, timer / totalTime);
            titleMat.SetColor("_EmissionColor", emissionColor);
            emissionColor = Color.Lerp(startColor4, endColor4, timer / totalTime);
            threeMat.SetColor("_EmissionColor", emissionColor);

            lightRays.color = Color.Lerp(startingColor, endingColor, timer / totalTime);
            titleMat.color = Color.Lerp(startingColor2, endingColor2, timer / totalTime);
            threeMat.color = Color.Lerp(startingColor2, endingColor2, timer / totalTime);
            yield return new WaitForFixedUpdate();
            timer++;

            if (GameManager.gameStarted)
                break;
        }
        if (Random.Range(0, 8) == 0)
            yield return new WaitForSecondsRealtime(Random.Range(1f, 60f)/60f);

        if (!GameManager.gameStarted)
            StartCoroutine(Flicker());
    }
}
