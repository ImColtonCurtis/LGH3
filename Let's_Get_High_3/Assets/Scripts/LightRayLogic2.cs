using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRayLogic2 : MonoBehaviour
{
    public SpriteRenderer lightRays, lensFlare;
    public Material heartMat, textMat;
    float tempH, tempS, tempV;

    private void Awake()
    {
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        float timer = 0, totalTime = Random.Range(1, 9);

        Color startingColor = lightRays.color;
        Color endingColor;

        Color startingColor2 = textMat.color;
        Color endingColor2;

        Color startingColor3 = heartMat.color;
        Color endingColor3;

        if (Random.Range(0, 2) == 0)
            endingColor = new Color(lightRays.color.r, lightRays.color.g, lightRays.color.b, lightRays.color.a + Random.Range(0.03f, 0.125f));
        else
            endingColor = new Color(lightRays.color.r, lightRays.color.g, lightRays.color.b, lightRays.color.a + Random.Range(-0.125f, -0.03f));

        if (endingColor.a >= 0.45f || endingColor.a < 0.30f)
        {
            if (endingColor.a >= 0.45f)
                endingColor = new Color(lightRays.color.r, lightRays.color.g, lightRays.color.b, 0.45f);
            else
                endingColor = new Color(lightRays.color.r, lightRays.color.g, lightRays.color.b, 0.3f);
        }

        endingColor2 = new Color(textMat.color.r, textMat.color.g, textMat.color.b, 1);
        Color.RGBToHSV(endingColor2, out tempH, out tempS, out tempV);
        endingColor2 = Color.HSVToRGB(tempH, tempS, 0.89f + ((endingColor.a - 0.3f) / 0.15f * 0.11f));

        endingColor3 = new Color(heartMat.color.r, heartMat.color.g, heartMat.color.b, 1);
        Color.RGBToHSV(endingColor3, out tempH, out tempS, out tempV);
        endingColor3 = Color.HSVToRGB(tempH, tempS, 0.89f + ((endingColor.a - 0.3f) / 0.15f * 0.11f));

        while (timer < totalTime)
        {
            lightRays.color = Color.Lerp(startingColor, endingColor, timer / totalTime);
            textMat.color = Color.Lerp(startingColor2, endingColor2, timer / totalTime);
            heartMat.color = Color.Lerp(startingColor3, endingColor3, timer / totalTime);
            yield return new WaitForFixedUpdate();
            timer++;
        }
        if (Random.Range(0, 8) == 0)
            yield return new WaitForSecondsRealtime(Random.Range(1f, 60f) / 60f);

        StartCoroutine(Flicker());
    }
}
