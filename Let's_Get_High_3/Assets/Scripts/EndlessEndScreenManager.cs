using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndlessEndScreenManager : MonoBehaviour
{
    [SerializeField] TextMeshPro endlessEndScreenPlayAgainText, endlessEndScreenHomeText;
    [SerializeField] GameObject endlessEndScreen;

    [SerializeField] SpriteRenderer screenCover;

    [SerializeField] Transform canvasHolder;

    const float defaultTextSize = 0.0004723505f;

    [SerializeField] TextMeshPro firstScore, secondScore, thirdScore, foourthScore, fifthScore;

    // TODO: Set highscores
    // TODO: fade screen out, zoom out

    private void OnEnable()
    {
        // set highscores
        if (PlayerPrefs.GetInt("NanoGameCount", 0) > PlayerPrefs.GetInt("EndlessHighScore5", 0))
        {
            if (PlayerPrefs.GetInt("NanoGameCount", 0) > PlayerPrefs.GetInt("EndlessHighScore4", 0))
            {
                if (PlayerPrefs.GetInt("NanoGameCount", 0) > PlayerPrefs.GetInt("EndlessHighScore3", 0))
                {
                    if (PlayerPrefs.GetInt("NanoGameCount", 0) > PlayerPrefs.GetInt("EndlessHighScore2", 0))
                    {
                        if (PlayerPrefs.GetInt("NanoGameCount", 0) > PlayerPrefs.GetInt("EndlessHighScore1", 0))
                        {
                            PlayerPrefs.SetInt("EndlessHighScore5", PlayerPrefs.GetInt("EndlessHighScore4", 0)); // set endless high score
                            PlayerPrefs.SetInt("EndlessHighScore4", PlayerPrefs.GetInt("EndlessHighScore3", 0)); // set endless high score
                            PlayerPrefs.SetInt("EndlessHighScore3", PlayerPrefs.GetInt("EndlessHighScore2", 0)); // set endless high score
                            PlayerPrefs.SetInt("EndlessHighScore2", PlayerPrefs.GetInt("EndlessHighScore1", 0)); // set endless high score
                            PlayerPrefs.SetInt("EndlessHighScore1", PlayerPrefs.GetInt("NanoGameCount", 0)); // set endless high score
                        }
                        else
                        {
                            PlayerPrefs.SetInt("EndlessHighScore5", PlayerPrefs.GetInt("EndlessHighScore4", 0)); // set endless high score
                            PlayerPrefs.SetInt("EndlessHighScore4", PlayerPrefs.GetInt("EndlessHighScore3", 0)); // set endless high score
                            PlayerPrefs.SetInt("EndlessHighScore3", PlayerPrefs.GetInt("EndlessHighScore2", 0)); // set endless high score
                            PlayerPrefs.SetInt("EndlessHighScore2", PlayerPrefs.GetInt("NanoGameCount", 0)); // set endless high score
                        }
                    }
                    else
                    {
                        PlayerPrefs.SetInt("EndlessHighScore5", PlayerPrefs.GetInt("EndlessHighScore4", 0)); // set endless high score
                        PlayerPrefs.SetInt("EndlessHighScore4", PlayerPrefs.GetInt("EndlessHighScore3", 0)); // set endless high score
                        PlayerPrefs.SetInt("EndlessHighScore3", PlayerPrefs.GetInt("NanoGameCount", 0)); // set endless high score
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("EndlessHighScore5", PlayerPrefs.GetInt("EndlessHighScore4", 0)); // set endless high score
                    PlayerPrefs.SetInt("EndlessHighScore4", PlayerPrefs.GetInt("NanoGameCount", 0)); // set endless high score
                }
            }
            else
            {
                PlayerPrefs.SetInt("EndlessHighScore5", PlayerPrefs.GetInt("NanoGameCount", 0)); // set endless high score
            }
        }

        // set highscore texts
        firstScore.text = PlayerPrefs.GetInt("EndlessHighScore1", 0).ToString();
        secondScore.text = PlayerPrefs.GetInt("EndlessHighScore2", 0).ToString();
        thirdScore.text = PlayerPrefs.GetInt("EndlessHighScore3", 0).ToString();
        foourthScore.text = PlayerPrefs.GetInt("EndlessHighScore4", 0).ToString();
        fifthScore.text = PlayerPrefs.GetInt("EndlessHighScore5", 0).ToString();

        GlobalNotifier.OnEndlessEndScreenPlayAgainButtonDown += EndlessEndScreenPlayAgainButtonDowned;
        GlobalNotifier.OnEndlessEndScreenPlayAgainButtonExit += EndlessEndScreenPlayAgainButtonExited;
        GlobalNotifier.OnEndlessEndScreenPlayAgainButtonUp += EndlessEndScreenPlayAgainButtonUpd;

        GlobalNotifier.OnEndlessEndScreenHomeButtonDown += EndlessEndScreenHomeButtonDowned;
        GlobalNotifier.OnEndlessEndScreenHomeButtonExit += EndlessEndScreenHomeButtonExited;
        GlobalNotifier.OnEndlessEndScreenHomeButtonUp += EndlessEndScreenHomeButtonUpd;
    }

    private void OnDisable()
    {
        GlobalNotifier.OnEndlessEndScreenPlayAgainButtonDown -= EndlessEndScreenPlayAgainButtonDowned;
        GlobalNotifier.OnEndlessEndScreenPlayAgainButtonExit -= EndlessEndScreenPlayAgainButtonExited;
        GlobalNotifier.OnEndlessEndScreenPlayAgainButtonUp -= EndlessEndScreenPlayAgainButtonUpd;

        GlobalNotifier.OnEndlessEndScreenHomeButtonDown -= EndlessEndScreenHomeButtonDowned;
        GlobalNotifier.OnEndlessEndScreenHomeButtonExit -= EndlessEndScreenHomeButtonExited;
        GlobalNotifier.OnEndlessEndScreenHomeButtonUp -= EndlessEndScreenHomeButtonUpd;
    }

    #region Base Button Calls
    void ButtonDowned(TextMeshPro myTMP)
    {
        StartCoroutine(GlobalFunctions.FadeTMP(myTMP, 9, myTMP.color.a, 0.5f));
        StartCoroutine(GlobalFunctions.TransformScale(myTMP.transform, 9, myTMP.transform.localScale.x, myTMP.transform.localScale.x * 0.9f));
    }

    void ButtonExited(TextMeshPro myTMP)
    {
        StartCoroutine(GlobalFunctions.FadeTMP(myTMP, 9, myTMP.color.a, 1f));
        StartCoroutine(GlobalFunctions.TransformScale(myTMP.transform, 9, myTMP.transform.localScale.x, myTMP.transform.localScale.x * (1f / .9f)));
    }

    void ButtonAppear(TextMeshPro myTMP, bool dir, float animLength)
    {
        if (dir)
        {
            StartCoroutine(GlobalFunctions.FadeTMP(myTMP, animLength, 0f, 1f));
            StartCoroutine(GlobalFunctions.TransformScale(myTMP.transform, animLength, myTMP.transform.localScale.x, defaultTextSize));
        }
        else
            StartCoroutine(GlobalFunctions.FadeTMP(myTMP, animLength, myTMP.color.a, 0f));
    }

    IEnumerator CameraZoom()
    {
        float timer = 0, animLength1 = 11, animLength2 = 31;
        Vector3 scale1 = canvasHolder.localScale;
        Vector3 scale2 = new Vector3(245f, 245f, 245f);
        Vector3 scale3 = new Vector3(840f, 840f, 840f);

        // zoom out
        while (timer <= animLength1)
        {
            canvasHolder.localScale = Vector3.Lerp(scale1,
                scale2,
                timer / animLength1);
            timer++;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSecondsRealtime(0.05f);
        // reset timer
        timer = 0;
        // zoom out
        while (timer <= animLength2)
        {
            if (timer == animLength2 - 8)
                StartCoroutine(GlobalFunctions.FadeColors(screenCover, animLength2 - timer, Color.black));

            canvasHolder.localScale = Vector3.Lerp(scale2,
                scale3,
                timer / animLength2);
            timer++;
            yield return new WaitForFixedUpdate();
        }

    }
    #endregion

    #region Endless End Screen Play Again Button
    void EndlessEndScreenPlayAgainButtonDowned()
    {
        ButtonDowned(endlessEndScreenPlayAgainText);
        // text gets darker
        Debug.Log("Endless End Screen Play Again Button Downed");
    }

    void EndlessEndScreenPlayAgainButtonExited()
    {
        ButtonExited(endlessEndScreenPlayAgainText);
        // text goes back to normal
        Debug.Log("Endless End Screen Play Again Button Exited");
    }

    void EndlessEndScreenPlayAgainButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(endlessEndScreenPlayAgainText, false, animLength);
        ButtonAppear(endlessEndScreenHomeText, false, animLength);

        StartCoroutine(GlobalFunctions.FadeTwoColors(screenCover, animLength, new Color(0, 0, 0, 0), Color.black));
        StartCoroutine(GlobalFunctions.DelayedActivate(endlessEndScreen, false, animLength));

        // set to 0, as we are now starting endless mode
        PlayerPrefs.SetInt("NanoGameCount", 0);

        // set to 1 if transitioning to nanogame from hub world
        PlayerPrefs.SetInt("HubWorld", 1);

        // set that the player is entering  endless mode
        PlayerPrefs.SetInt("GameMode", 1); // 0: story, 1: endless, 2: pass n play

        StartCoroutine(CameraZoom()); // zoom camera
        StartCoroutine(GlobalFunctions.DelayedSceneLoad(Random.Range(MenuManager.hubSceneAmnt, MenuManager.nanoGameSceneAmnt + MenuManager.hubSceneAmnt), 1f)); // enter random mini game

        // button selected
        Debug.Log("Single Player Button Upd");
    }
    #endregion

    #region Endless End Screen Home Button
    void EndlessEndScreenHomeButtonDowned()
    {
        ButtonDowned(endlessEndScreenHomeText);
        Debug.Log("Endless End Screen Home Button Downed");
    }

    void EndlessEndScreenHomeButtonExited()
    {
        ButtonExited(endlessEndScreenHomeText);
        Debug.Log("Endless End Screen Home Button Exited");
    }

    void EndlessEndScreenHomeButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(endlessEndScreenPlayAgainText, false, animLength);
        ButtonAppear(endlessEndScreenHomeText, false, animLength);

        StartCoroutine(GlobalFunctions.FadeTwoColors(screenCover, animLength + 3, new Color(0,0,0,0), Color.black));

        StartCoroutine(CameraZoom()); // zoom camera
        StartCoroutine(GlobalFunctions.DelayedSceneLoad(0, 0.5f));

        Debug.Log("Endless End Screen Home Button Upd");
    }
    #endregion
}
