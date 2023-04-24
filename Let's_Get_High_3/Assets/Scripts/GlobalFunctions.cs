using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalFunctions : MonoBehaviour
{
    public static IEnumerator FadeImage(Image myImage, float animLength, float startAlpha, float endAlpha)
    {
        float timer = 0;
        myImage.color = new Color(myImage.color.r, myImage.color.g, myImage.color.b, startAlpha);
        while (timer <= animLength)
        {
            myImage.color = Color.Lerp(new Color(myImage.color.r, myImage.color.g, myImage.color.b, startAlpha),
                new Color(myImage.color.r, myImage.color.g, myImage.color.b, endAlpha),
                timer / animLength);
            timer++;
            yield return new WaitForFixedUpdate();
        }
    }

    public static IEnumerator FadeTMPUGI(TextMeshProUGUI myTMP, float animLength, float startAlpha, float endAlpha)
    {
        float timer = 0;

        while (timer <= animLength)
        {
            myTMP.color = Color.Lerp(new Color(myTMP.color.r, myTMP.color.g, myTMP.color.b, startAlpha),
                new Color(myTMP.color.r, myTMP.color.g, myTMP.color.b, endAlpha),
                timer / animLength);
            timer++;
            yield return new WaitForFixedUpdate();
        }
    }

    public static IEnumerator FadeTMP(TextMeshPro myTMP, float animLength, float startAlpha, float endAlpha)
    {
        float timer = 0;

        while (timer <= animLength)
        {
            myTMP.color = Color.Lerp(new Color(myTMP.color.r, myTMP.color.g, myTMP.color.b, startAlpha),
                new Color(myTMP.color.r, myTMP.color.g, myTMP.color.b, endAlpha),
                timer / animLength);
            timer++;
            yield return new WaitForFixedUpdate();
        }
    }

    public static IEnumerator TransformScale(Transform myTransform, float animLength, float startScale, float endScale)
    {
        float timer = 0;

        while (timer <= animLength)
        {
            myTransform.localScale = Vector3.Lerp(new Vector3(startScale, startScale, startScale),
                new Vector3(endScale, endScale, endScale),
                timer / animLength);
            timer++;
            yield return new WaitForFixedUpdate();
        }
    }

    public static IEnumerator TransformPosition(Transform myTransform, float animLength, Vector3 startPos, Vector3 endPos)
    {
        float timer = 0;
        while (timer <= animLength)
        {
            myTransform.localPosition = Vector3.Lerp(startPos,
                endPos,
                timer / animLength);
            timer++;
            yield return new WaitForFixedUpdate();
        }
    }

    public static IEnumerator DelayedActivate(GameObject myObj, bool dir, float animLength)
    {
        float timer = 0;

        while (timer <= animLength)
        {
            timer++;
            yield return new WaitForFixedUpdate();
        }
        if (dir)
            myObj.SetActive(true);
        else
            myObj.SetActive(false);
    }

    public static IEnumerator FadeColors(SpriteRenderer mySR, float animLength, Color endColor)
    {
        float timer = 0;
        Color startColor = mySR.color;
        while (timer <= animLength)
        {
            mySR.color = Color.Lerp(startColor,
                endColor,
                timer / animLength);
            timer++;
            yield return new WaitForFixedUpdate();
        }
    }

    public static IEnumerator FadeTwoColors(SpriteRenderer mySR, float animLength, Color startColor, Color endColor)
    {
        float timer = 0;
        mySR.color = startColor;
        while (timer <= animLength)
        {
            mySR.color = Color.Lerp(startColor,
                endColor,
                timer / animLength);
            timer++;
            yield return new WaitForFixedUpdate();
        }
    }

    public static IEnumerator DelayedSceneLoad(int seneInt, float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        SceneManager.LoadScene(seneInt, LoadSceneMode.Single);
    }
}
