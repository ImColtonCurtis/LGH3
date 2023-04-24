using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Color blueScreenColor, yellowScreenColor, greenScreenColor, redScreenColor, purpleScreenColor, pinkScreenColor, darkBlueScreenColor, blackScreenColor;

    [SerializeField] SpriteRenderer screenCover;

    [SerializeField] SpriteRenderer screenBG;

    [SerializeField] TextMeshPro singlePlayerText, multiplayerText, optionsText, mainMenuBackText;
    [SerializeField] GameObject mainMenu;

    [SerializeField] TextMeshPro storyText, endlessText, singlePlayerBackText;
    [SerializeField] GameObject singlePlayerMenu;

    [SerializeField] TextMeshPro endlessHighScoreText, endlessScoreText, endlessLetsGetHighText, endlessEndlessText, endlessPlayText, endlessBackText;
    [SerializeField] GameObject endlessMenu;

    [SerializeField] TextMeshPro passNPlayText, multiplayerBackText;
    [SerializeField] GameObject multiplayerMenu;

    [SerializeField] TextMeshPro playerCountText, twoText, threeText, fourText, fiveText, sixText, sevenText, eightText, playerCountBackText, okText;
    [SerializeField] BoxCollider okCol;
    [SerializeField] GameObject playerCountMenu;

    [SerializeField] TextMeshPro optionsBackText, applyText;
    [SerializeField] BoxCollider applyCol;
    [SerializeField] GameObject optionsMenu;

    [SerializeField] TextMeshPro playAgainText, postGameBackText;
    [SerializeField] GameObject postGameMenu;

    [SerializeField] Transform cameraHolder;

    const float defaultTextSize = 0.0004723505f;

    public static int hubSceneAmnt = 3;
    public static int nanoGameSceneAmnt = 16;

    private void OnEnable()
    {
        PlayerPrefs.SetInt("PassNPlayPlayerCount", 0);

        // set endless score text
        endlessScoreText.text = PlayerPrefs.GetInt("EndlessHighScore", 0).ToString();

        GlobalNotifier.OnSinglePlayerButtonDown += SinglePlayerButtonDowned;
        GlobalNotifier.OnSinglePlayerButtonExit += SinglePlayerButtonExited;
        GlobalNotifier.OnSinglePlayerButtonUp += SinglePlayerButtonUpd;

        GlobalNotifier.OnMultiplayerButtonDown += MultiplayerButtonDowned;
        GlobalNotifier.OnMultiplayerButtonExit += MultiplayerButtonExited;
        GlobalNotifier.OnMultiplayerButtonUp += MultiplayerButtonUpd;

        GlobalNotifier.OnOptionsButtonDown += OptionsButtonDowned;
        GlobalNotifier.OnOptionsButtonExit += OptionsButtonExited;
        GlobalNotifier.OnOptionsButtonUp += OptionsButtonUpd;

        GlobalNotifier.OnMainMenuBackButtonDown += MainMenuBackButtonDowned;
        GlobalNotifier.OnMainMenuBackButtonExit += MainMenuBackButtonExited;
        GlobalNotifier.OnMainMenuBackButtonUp += MainMenuBackButtonUpd;

        GlobalNotifier.OnStoryButtonDown += StoryButtonDowned;
        GlobalNotifier.OnStoryButtonExit += StoryButtonExited;
        GlobalNotifier.OnStoryButtonUp += StoryButtonUpd;

        GlobalNotifier.OnEndlessButtonDown += EndlessButtonDowned;
        GlobalNotifier.OnEndlessButtonExit += EndlessButtonExited;
        GlobalNotifier.OnEndlessButtonUp += EndlessButtonUpd;

        GlobalNotifier.OnSinglePlayerBackButtonDown += SinglePlayerBackButtonDowned;
        GlobalNotifier.OnSinglePlayerBackButtonExit += SinglePlayerBackButtonExited;
        GlobalNotifier.OnSinglePlayerBackButtonUp += SinglePlayerBackButtonUpd;

        GlobalNotifier.OnEndlessPlayButtonDown += EndlessPlayButtonDowned;
        GlobalNotifier.OnEndlessPlayButtonExit += EndlessPlayButtonExited;
        GlobalNotifier.OnEndlessPlayButtonUp += EndlessPlayButtonUpd;

        GlobalNotifier.OnEndlessBackButtonDown += EndlessBackButtonDowned;
        GlobalNotifier.OnEndlessBackButtonExit += EndlessBackButtonExited;
        GlobalNotifier.OnEndlessBackButtonUp += EndlessBackButtonUpd;

        GlobalNotifier.OnPassNPlayButtonDown += PassNPlayButtonDowned;
        GlobalNotifier.OnPassNPlayButtonExit += PassNPlayButtonExited;
        GlobalNotifier.OnPassNPlayButtonUp += PassNPlayButtonUpd;

        GlobalNotifier.OnMultiplayerBackButtonDown += MultiplayerBackButtonDowned;
        GlobalNotifier.OnMultiplayerBackButtonExit += MultiplayerBackButtonExited;
        GlobalNotifier.OnMultiplayerBackButtonUp += MultiplayerBackButtonUpd;

        GlobalNotifier.OnTwoButtonDown += TwoButtonDowned;
        GlobalNotifier.OnTwoButtonExit += TwoButtonExited;
        GlobalNotifier.OnTwoButtonUp += TwoButtonUpd;

        GlobalNotifier.OnThreeButtonDown += ThreeButtonDowned;
        GlobalNotifier.OnThreeButtonExit += ThreeButtonExited;
        GlobalNotifier.OnThreeButtonUp += ThreeButtonUpd;

        GlobalNotifier.OnFourButtonDown += FourButtonDowned;
        GlobalNotifier.OnFourButtonExit += FourButtonExited;
        GlobalNotifier.OnFourButtonUp += FourButtonUpd;

        GlobalNotifier.OnFiveButtonDown += FiveButtonDowned;
        GlobalNotifier.OnFiveButtonExit += FiveButtonExited;
        GlobalNotifier.OnFiveButtonUp += FiveButtonUpd;

        GlobalNotifier.OnSixButtonDown += SixButtonDowned;
        GlobalNotifier.OnSixButtonExit += SixButtonExited;
        GlobalNotifier.OnSixButtonUp += SixButtonUpd;

        GlobalNotifier.OnSevenButtonDown += SevenButtonDowned;
        GlobalNotifier.OnSevenButtonExit += SevenButtonExited;
        GlobalNotifier.OnSevenButtonUp += SevenButtonUpd;

        GlobalNotifier.OnEightButtonDown += EightButtonDowned;
        GlobalNotifier.OnEightButtonExit += EightButtonExited;
        GlobalNotifier.OnEightButtonUp += EightButtonUpd;

        GlobalNotifier.OnPlayerCountBackButtonDown += PlayerCountBackButtonDowned;
        GlobalNotifier.OnPlayerCountBackButtonExit += PlayerCountBackButtonExited;
        GlobalNotifier.OnPlayerCountBackButtonUp += PlayerCountBackButtonUpd;

        GlobalNotifier.OnOkButtonDown += OkButtonDowned;
        GlobalNotifier.OnOkButtonExit += OkButtonExited;
        GlobalNotifier.OnOkButtonUp += OkButtonUpd;

        GlobalNotifier.OnOptionsBackButtonDown += OptionsBackButtonDowned;
        GlobalNotifier.OnOptionsBackButtonExit += OptionsBackButtonExited;
        GlobalNotifier.OnOptionsBackButtonUp += OptionsBackButtonUpd;

        GlobalNotifier.OnApplyButtonDown += ApplyButtonDowned;
        GlobalNotifier.OnApplyButtonExit += ApplyButtonExited;
        GlobalNotifier.OnApplyButtonUp += ApplyButtonUpd;

        GlobalNotifier.OnPlayAgainButtonDown += PlayAgainButtonDowned;
        GlobalNotifier.OnPlayAgainButtonExit += PlayAgainButtonExited;
        GlobalNotifier.OnPlayAgainButtonUp += PlayAgainButtonUpd;

        GlobalNotifier.OnPostGameBackButtonDown += PostGameBackButtonDowned;
        GlobalNotifier.OnPostGameBackButtonExit += PostGameBackButtonExited;
        GlobalNotifier.OnPostGameBackButtonUp += PostGameBackButtonUpd;
    }

    private void OnDisable()
    {
        GlobalNotifier.OnSinglePlayerButtonDown -= SinglePlayerButtonDowned;
        GlobalNotifier.OnSinglePlayerButtonExit -= SinglePlayerButtonExited;
        GlobalNotifier.OnSinglePlayerButtonUp -= SinglePlayerButtonUpd;

        GlobalNotifier.OnMultiplayerButtonDown -= MultiplayerButtonDowned;
        GlobalNotifier.OnMultiplayerButtonExit -= MultiplayerButtonExited;
        GlobalNotifier.OnMultiplayerButtonUp -= MultiplayerButtonUpd;

        GlobalNotifier.OnOptionsButtonDown -= OptionsButtonDowned;
        GlobalNotifier.OnOptionsButtonExit -= OptionsButtonExited;
        GlobalNotifier.OnOptionsButtonUp -= OptionsButtonUpd;

        GlobalNotifier.OnMainMenuBackButtonDown -= MainMenuBackButtonDowned;
        GlobalNotifier.OnMainMenuBackButtonExit -= MainMenuBackButtonExited;
        GlobalNotifier.OnMainMenuBackButtonUp -= MainMenuBackButtonUpd;

        GlobalNotifier.OnStoryButtonDown -= StoryButtonDowned;
        GlobalNotifier.OnStoryButtonExit -= StoryButtonExited;
        GlobalNotifier.OnStoryButtonUp -= StoryButtonUpd;

        GlobalNotifier.OnEndlessButtonDown -= EndlessButtonDowned;
        GlobalNotifier.OnEndlessButtonExit -= EndlessButtonExited;
        GlobalNotifier.OnEndlessButtonUp -= EndlessButtonUpd;

        GlobalNotifier.OnSinglePlayerBackButtonDown -= SinglePlayerBackButtonDowned;
        GlobalNotifier.OnSinglePlayerBackButtonExit -= SinglePlayerBackButtonExited;
        GlobalNotifier.OnSinglePlayerBackButtonUp -= SinglePlayerBackButtonUpd;

        GlobalNotifier.OnEndlessPlayButtonDown -= EndlessPlayButtonDowned;
        GlobalNotifier.OnEndlessPlayButtonExit -= EndlessPlayButtonExited;
        GlobalNotifier.OnEndlessPlayButtonUp -= EndlessPlayButtonUpd;

        GlobalNotifier.OnEndlessBackButtonDown -= EndlessBackButtonDowned;
        GlobalNotifier.OnEndlessBackButtonExit -= EndlessBackButtonExited;
        GlobalNotifier.OnEndlessBackButtonUp -= EndlessBackButtonUpd;

        GlobalNotifier.OnPassNPlayButtonDown -= PassNPlayButtonDowned;
        GlobalNotifier.OnPassNPlayButtonExit -= PassNPlayButtonExited;
        GlobalNotifier.OnPassNPlayButtonUp -= PassNPlayButtonUpd;

        GlobalNotifier.OnMultiplayerBackButtonDown -= MultiplayerBackButtonDowned;
        GlobalNotifier.OnMultiplayerBackButtonExit -= MultiplayerBackButtonExited;
        GlobalNotifier.OnMultiplayerBackButtonUp -= MultiplayerBackButtonUpd;

        GlobalNotifier.OnTwoButtonDown -= TwoButtonDowned;
        GlobalNotifier.OnTwoButtonExit -= TwoButtonExited;
        GlobalNotifier.OnTwoButtonUp -= TwoButtonUpd;

        GlobalNotifier.OnThreeButtonDown -= ThreeButtonDowned;
        GlobalNotifier.OnThreeButtonExit -= ThreeButtonExited;
        GlobalNotifier.OnThreeButtonUp -= ThreeButtonUpd;

        GlobalNotifier.OnFourButtonDown -= FourButtonDowned;
        GlobalNotifier.OnFourButtonExit -= FourButtonExited;
        GlobalNotifier.OnFourButtonUp -= FourButtonUpd;

        GlobalNotifier.OnFiveButtonDown -= FiveButtonDowned;
        GlobalNotifier.OnFiveButtonExit -= FiveButtonExited;
        GlobalNotifier.OnFiveButtonUp -= FiveButtonUpd;

        GlobalNotifier.OnSixButtonDown -= SixButtonDowned;
        GlobalNotifier.OnSixButtonExit -= SixButtonExited;
        GlobalNotifier.OnSixButtonUp -= SixButtonUpd;

        GlobalNotifier.OnSevenButtonDown -= SevenButtonDowned;
        GlobalNotifier.OnSevenButtonExit -= SevenButtonExited;
        GlobalNotifier.OnSevenButtonUp -= SevenButtonUpd;

        GlobalNotifier.OnEightButtonDown -= EightButtonDowned;
        GlobalNotifier.OnEightButtonExit -= EightButtonExited;
        GlobalNotifier.OnEightButtonUp -= EightButtonUpd;

        GlobalNotifier.OnPlayerCountBackButtonDown -= PlayerCountBackButtonDowned;
        GlobalNotifier.OnPlayerCountBackButtonExit -= PlayerCountBackButtonExited;
        GlobalNotifier.OnPlayerCountBackButtonUp -= PlayerCountBackButtonUpd;

        GlobalNotifier.OnOkButtonDown -= OkButtonDowned;
        GlobalNotifier.OnOkButtonExit -= OkButtonExited;
        GlobalNotifier.OnOkButtonUp -= OkButtonUpd;

        GlobalNotifier.OnOptionsBackButtonDown -= OptionsBackButtonDowned;
        GlobalNotifier.OnOptionsBackButtonExit -= OptionsBackButtonExited;
        GlobalNotifier.OnOptionsBackButtonUp -= OptionsBackButtonUpd;

        GlobalNotifier.OnApplyButtonDown -= ApplyButtonDowned;
        GlobalNotifier.OnApplyButtonExit -= ApplyButtonExited;
        GlobalNotifier.OnApplyButtonUp -= ApplyButtonUpd;

        GlobalNotifier.OnPlayAgainButtonDown -= PlayAgainButtonDowned;
        GlobalNotifier.OnPlayAgainButtonExit -= PlayAgainButtonExited;
        GlobalNotifier.OnPlayAgainButtonUp -= PlayAgainButtonUpd;

        GlobalNotifier.OnPostGameBackButtonDown -= PostGameBackButtonDowned;
        GlobalNotifier.OnPostGameBackButtonExit -= PostGameBackButtonExited;
        GlobalNotifier.OnPostGameBackButtonUp -= PostGameBackButtonUpd;
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
        StartCoroutine(GlobalFunctions.TransformScale(myTMP.transform, 9, myTMP.transform.localScale.x, myTMP.transform.localScale.x * (1f/.9f)));
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
    void PlayerCountSelect(float animLength, int thisButtonNum)
    {
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);

        // enable "ok" button, if it isn't already enabled
        if (currentPlayerCount == 0)
        {
            okCol.enabled = true;
            StartCoroutine(GlobalFunctions.FadeTMP(okText, animLength, okText.color.a, 1f)); // set ok to be able to be pressed
        }
        // set buttons 3-8 back to normal (incase they had been selected)
        else
        {
            switch (currentPlayerCount)
            {
                case 2:
                    ButtonExited(twoText);
                    break;
                case 3:
                    ButtonExited(threeText);
                    break;
                case 4:
                    ButtonExited(fourText);
                    break;
                case 5:
                    ButtonExited(fiveText);
                    break;
                case 6:
                    ButtonExited(sixText);
                    break;
                case 7:
                    ButtonExited(sevenText);
                    break;
                case 8:
                    ButtonExited(eightText);
                    break;
                default:
                    Debug.LogError("Unusual Player Count Selected");
                    break;
            }
        }
    }

    IEnumerator CameraZoom()
    {
        float timer = 0, animLength1 = 11, animLength2 = 31;
        Vector3 position1 = cameraHolder.localPosition;
        Vector3 position2 = new Vector3(-1f, 3.79f, -1.59f);
        Vector3 position3 = new Vector3(-1f, 3.79f, 2.73f);

        // zoom out
        while (timer <= animLength1)
        {
            cameraHolder.localPosition = Vector3.Lerp(position1,
                position2,
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
            if (timer == animLength2-8)
                StartCoroutine(GlobalFunctions.FadeColors(screenCover, animLength2-timer, Color.black));

            cameraHolder.localPosition = Vector3.Lerp(position2,
                position3,
                timer / animLength2);
            timer++;
            yield return new WaitForFixedUpdate();
        }

    }
    #endregion

    #region Single Player Button
    void SinglePlayerButtonDowned()
    {
        ButtonDowned(singlePlayerText);
        // text gets darker
        Debug.Log("Single Player Button Downed");
    }

    void SinglePlayerButtonExited()
    {
        ButtonExited(singlePlayerText);
        // text goes back to normal
        Debug.Log("Single Player Button Exited");
    }

    void SinglePlayerButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(singlePlayerText, false, animLength);
        ButtonAppear(multiplayerText, false, animLength);
        ButtonAppear(optionsText, false, animLength);
        ButtonAppear(mainMenuBackText, false, animLength);

        StartCoroutine(GlobalFunctions.FadeColors(screenBG, 9, yellowScreenColor));

        StartCoroutine(GlobalFunctions.DelayedActivate(mainMenu, false, animLength));
        StartCoroutine(GlobalFunctions.DelayedActivate(singlePlayerMenu, true, animLength));

        ButtonAppear(storyText, true, animLength);
        ButtonAppear(endlessText, true, animLength);
        ButtonAppear(singlePlayerBackText, true, animLength);
        // button selected
        Debug.Log("Single Player Button Upd");
    }
    #endregion

    #region Multiplayer Button
    void MultiplayerButtonDowned()
    {
        ButtonDowned(multiplayerText);
        Debug.Log("Multiplayer Button Downed");
    }

    void MultiplayerButtonExited()
    {
        ButtonExited(multiplayerText);
        Debug.Log("Multiplayer Button Exited");
    }

    void MultiplayerButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(singlePlayerText, false, animLength);
        ButtonAppear(multiplayerText, false, animLength);
        ButtonAppear(optionsText, false, animLength);
        ButtonAppear(mainMenuBackText, false, animLength);

        StartCoroutine(GlobalFunctions.FadeColors(screenBG, 9, purpleScreenColor));

        StartCoroutine(GlobalFunctions.DelayedActivate(mainMenu, false, animLength));
        StartCoroutine(GlobalFunctions.DelayedActivate(multiplayerMenu, true, animLength));

        ButtonAppear(passNPlayText, true, animLength);
        ButtonAppear(multiplayerBackText, true, animLength);
        Debug.Log("Multiplayer Button Upd");
    }
    #endregion

    #region Options Button
    void OptionsButtonDowned()
    {
        ButtonDowned(optionsText);
        Debug.Log("Options Button Downed");
    }

    void OptionsButtonExited()
    {
        ButtonExited(optionsText);
        Debug.Log("Options Button Exited");
    }

    void OptionsButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(singlePlayerText, false, animLength);
        ButtonAppear(multiplayerText, false, animLength);
        ButtonAppear(optionsText, false, animLength);
        ButtonAppear(mainMenuBackText, false, animLength);

        StartCoroutine(GlobalFunctions.FadeColors(screenBG, 9, redScreenColor));

        StartCoroutine(GlobalFunctions.DelayedActivate(mainMenu, false, animLength));
        StartCoroutine(GlobalFunctions.DelayedActivate(optionsMenu, true, animLength));

        ButtonAppear(optionsBackText, true, animLength);
        applyCol.enabled = false;
        StartCoroutine(GlobalFunctions.FadeTMP(applyText, animLength, 0f, 0.3f)); // it should be greyed out as nothing has been affected yet

        Debug.Log("Options Button Upd");
    }
    #endregion

    #region Main Menu Back Button
    void MainMenuBackButtonDowned()
    {
        ButtonDowned(mainMenuBackText);
        Debug.Log("Main Menu Back Button Downed");
    }

    void MainMenuBackButtonExited()
    {
        ButtonExited(mainMenuBackText);
        Debug.Log("Main Menu Back Button Exited");
    }

    void MainMenuBackButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(singlePlayerText, false, animLength);
        ButtonAppear(multiplayerText, false, animLength);
        ButtonAppear(optionsText, false, animLength);
        ButtonAppear(mainMenuBackText, false, animLength);

        StartCoroutine(GlobalFunctions.FadeColors(screenBG, animLength, blackScreenColor));

        StartCoroutine(GlobalFunctions.FadeColors(screenCover, animLength+3, blackScreenColor));

        StartCoroutine(GlobalFunctions.DelayedSceneLoad(SceneManager.GetActiveScene().buildIndex, 0.5f));

        Debug.Log("Main Menu Back Button Upd");
    }
    #endregion

    #region Story Button
    void StoryButtonDowned()
    {
        ButtonDowned(storyText);
        Debug.Log("Story Button Downed");
    }

    void StoryButtonExited()
    {
        ButtonExited(storyText);
        Debug.Log("Story Button Exited");
    }

    void StoryButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(storyText, false, animLength);
        ButtonAppear(endlessText, false, animLength);
        ButtonAppear(singlePlayerBackText, false, animLength);

        StartCoroutine(GlobalFunctions.FadeColors(screenBG, 9, greenScreenColor));

        StartCoroutine(GlobalFunctions.DelayedActivate(singlePlayerMenu, false, animLength));

        // set that the player is entering  story mode
        PlayerPrefs.SetInt("GameMode", 0); // 0: story, 1: endless, 2: pass n play

        StartCoroutine(CameraZoom());

        StartCoroutine(GlobalFunctions.DelayedSceneLoad(1, 1f));

        Debug.Log("Story Button Upd");
    }
    #endregion

    #region Endless Button
    void EndlessButtonDowned()
    {
        ButtonDowned(endlessText);
        Debug.Log("Endless Button Downed");
    }

    void EndlessButtonExited()
    {
        ButtonExited(endlessText);
        Debug.Log("Endless Button Exited");
    }

    void EndlessButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(storyText, false, animLength);
        ButtonAppear(endlessText, false, animLength);
        ButtonAppear(singlePlayerBackText, false, animLength);

        StartCoroutine(GlobalFunctions.FadeColors(screenBG, 9, darkBlueScreenColor));

        StartCoroutine(GlobalFunctions.DelayedActivate(singlePlayerMenu, false, animLength));
        StartCoroutine(GlobalFunctions.DelayedActivate(endlessMenu, true, animLength));

        ButtonAppear(endlessHighScoreText, true, animLength);
        ButtonAppear(endlessScoreText, true, animLength);
        ButtonAppear(endlessLetsGetHighText, true, animLength);
        ButtonAppear(endlessEndlessText, true, animLength);
        ButtonAppear(endlessPlayText, true, animLength);
        ButtonAppear(endlessBackText, true, animLength);
        // button selected
        Debug.Log("Endless Button Upd");
    }
    #endregion

    #region Single Player Back Button
    void SinglePlayerBackButtonDowned()
    {
        ButtonDowned(singlePlayerBackText);
        Debug.Log("Single Player Back Button Downed");
    }

    void SinglePlayerBackButtonExited()
    {
        ButtonExited(singlePlayerBackText);
        Debug.Log("Single Player Back Button Exited");
    }

    void SinglePlayerBackButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(storyText, false, animLength);
        ButtonAppear(endlessText, false, animLength);
        ButtonAppear(singlePlayerBackText, false, animLength);

        StartCoroutine(GlobalFunctions.FadeColors(screenBG, 9, blueScreenColor));

        StartCoroutine(GlobalFunctions.DelayedActivate(singlePlayerMenu, false, animLength));
        StartCoroutine(GlobalFunctions.DelayedActivate(mainMenu, true, animLength));

        ButtonAppear(singlePlayerText, true, animLength);
        ButtonAppear(multiplayerText, true, animLength);
        ButtonAppear(optionsText, true, animLength);
        ButtonAppear(mainMenuBackText, true, animLength);

        Debug.Log("Single Player Back Button Upd");
    }
    #endregion

    #region Endless Play Button
    void EndlessPlayButtonDowned()
    {
        ButtonDowned(endlessPlayText);
        Debug.Log("Endless Play Button Downed");
    }

    void EndlessPlayButtonExited()
    {
        ButtonExited(endlessPlayText);
        Debug.Log("Endless Button Exited");
    }

    void EndlessPlayButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(endlessHighScoreText, false, animLength);
        ButtonAppear(endlessScoreText, false, animLength);
        ButtonAppear(endlessLetsGetHighText, false, animLength);
        ButtonAppear(endlessEndlessText, false, animLength);
        ButtonAppear(endlessPlayText, false, animLength);
        ButtonAppear(endlessBackText, false, animLength);

        StartCoroutine(GlobalFunctions.FadeColors(screenBG, 9, greenScreenColor));
        StartCoroutine(GlobalFunctions.DelayedActivate(endlessMenu, false, animLength));

        // set to 0, as we are now starting endless mode
        PlayerPrefs.SetInt("NanoGameCount", 0);

        // set to 1 if transitioning to nanogame from hub world
        PlayerPrefs.SetInt("HubWorld", 1);

        // set that the player is entering  endless mode
        PlayerPrefs.SetInt("GameMode", 1); // 0: story, 1: endless, 2: pass n play

        StartCoroutine(CameraZoom()); // zoom camera
        StartCoroutine(GlobalFunctions.DelayedSceneLoad(Random.Range(hubSceneAmnt, nanoGameSceneAmnt+ hubSceneAmnt), 1f)); // enter random mini game

        Debug.Log("Endless Play Button Upd");
    }
    #endregion

    #region Endless Back Button
    void EndlessBackButtonDowned()
    {
        ButtonDowned(endlessBackText);
        Debug.Log("Endless Back Button Downed");
    }

    void EndlessBackButtonExited()
    {
        ButtonExited(endlessBackText);
        Debug.Log("Endless Back Button Exited");
    }

    void EndlessBackButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(endlessHighScoreText, false, animLength);
        ButtonAppear(endlessScoreText, false, animLength);
        ButtonAppear(endlessLetsGetHighText, false, animLength);
        ButtonAppear(endlessEndlessText, false, animLength);
        ButtonAppear(endlessPlayText, false, animLength);
        ButtonAppear(endlessBackText, false, animLength);

        StartCoroutine(GlobalFunctions.FadeColors(screenBG, 9, yellowScreenColor));
        StartCoroutine(GlobalFunctions.DelayedActivate(endlessMenu, false, animLength));

        StartCoroutine(GlobalFunctions.DelayedActivate(singlePlayerMenu, true, animLength));

        ButtonAppear(storyText, true, animLength);
        ButtonAppear(endlessText, true, animLength);
        ButtonAppear(singlePlayerBackText, true, animLength);

        Debug.Log("Endless Back Button Upd");
    }
    #endregion

    #region Pass 'N Play Button
    void PassNPlayButtonDowned()
    {
        ButtonDowned(passNPlayText);
        Debug.Log("Pass 'N Play Button Downed");
    }

    void PassNPlayButtonExited()
    {
        ButtonExited(passNPlayText);
        Debug.Log("Pass 'N Play Button Exited");
    }

    void PassNPlayButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(passNPlayText, false, animLength);
        ButtonAppear(multiplayerBackText, false, animLength);

        StartCoroutine(GlobalFunctions.DelayedActivate(multiplayerMenu, false, animLength));
        
        StartCoroutine(GlobalFunctions.FadeColors(screenBG, 9, pinkScreenColor));

        StartCoroutine(GlobalFunctions.DelayedActivate(playerCountMenu, true, animLength));

        ButtonAppear(playerCountText, true, animLength);
        ButtonAppear(twoText, true, animLength);
        ButtonAppear(threeText, true, animLength);
        ButtonAppear(fourText, true, animLength);
        ButtonAppear(fiveText, true, animLength);
        ButtonAppear(sixText, true, animLength);
        ButtonAppear(sevenText, true, animLength);
        ButtonAppear(eightText, true, animLength);
        ButtonAppear(playerCountBackText, true, animLength);

        StartCoroutine(GlobalFunctions.FadeTMP(okText, animLength, 0f, 0.3f));  // it should be greyed out as nothing has been affected yet
        okCol.enabled = false;
        StartCoroutine(GlobalFunctions.TransformScale(okText.transform, animLength, okText.transform.localScale.x, defaultTextSize));

        Debug.Log("Pass 'N Play Button Upd");
    }
    #endregion

    #region Multiplayer Back Button
    void MultiplayerBackButtonDowned()
    {
        ButtonDowned(multiplayerBackText);
        Debug.Log("Multiplayer Back Button Downed");
    }

    void MultiplayerBackButtonExited()
    {
        ButtonExited(multiplayerBackText);
        Debug.Log("Multiplayer Back Button Exited");
    }

    void MultiplayerBackButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(passNPlayText, false, animLength);
        ButtonAppear(multiplayerBackText, false, animLength);

        StartCoroutine(GlobalFunctions.DelayedActivate(multiplayerMenu, false, animLength));

        StartCoroutine(GlobalFunctions.FadeColors(screenBG, 9, blueScreenColor));

        StartCoroutine(GlobalFunctions.DelayedActivate(mainMenu, true, animLength));

        ButtonAppear(singlePlayerText, true, animLength);
        ButtonAppear(multiplayerText, true, animLength);
        ButtonAppear(optionsText, true, animLength);
        ButtonAppear(mainMenuBackText, true, animLength);

        Debug.Log("Multiplayer Back Button Upd");
    }
    #endregion

    #region Two Button
    void TwoButtonDowned()
    {
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 2;
        if (thisButtonNum != currentPlayerCount)
            ButtonDowned(twoText);
        Debug.Log("Two Button Downed");
    }

    void TwoButtonExited()
    {
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 2;
        if (thisButtonNum != currentPlayerCount)
            ButtonExited(twoText);
        Debug.Log("Two Button Exited");
    }

    void TwoButtonUpd()
    {
        float animLength = 9;
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 2;
        if (thisButtonNum != currentPlayerCount)
        {
            PlayerCountSelect(animLength, thisButtonNum);
            PlayerPrefs.SetInt("PassNPlayPlayerCount", thisButtonNum);
        }
        Debug.Log("Two Button Upd");
    }
    #endregion

    #region Three Button
    void ThreeButtonDowned()
    {
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 3;
        if (thisButtonNum != currentPlayerCount)
            ButtonDowned(threeText);
        Debug.Log("Three Button Downed");
    }

    void ThreeButtonExited()
    {
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 3;
        if (thisButtonNum != currentPlayerCount)
            ButtonExited(threeText);
        Debug.Log("Three Button Exited");
    }

    void ThreeButtonUpd()
    {
        float animLength = 9;
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 3;
        if (thisButtonNum != currentPlayerCount)
        {
            PlayerCountSelect(animLength, thisButtonNum);
            PlayerPrefs.SetInt("PassNPlayPlayerCount", thisButtonNum);
        }
        Debug.Log("Three Button Upd");
    }
    #endregion

    #region Four Button
    void FourButtonDowned()
    {
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 4;
        if (thisButtonNum != currentPlayerCount)
            ButtonDowned(fourText);
        Debug.Log("Four Button Downed");
    }

    void FourButtonExited()
    {
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 4;
        if (thisButtonNum != currentPlayerCount)
            ButtonExited(fourText);
        Debug.Log("Four Button Exited");
    }

    void FourButtonUpd()
    {
        float animLength = 9;
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 4;
        if (thisButtonNum != currentPlayerCount)
        {
            PlayerCountSelect(animLength, thisButtonNum);
            PlayerPrefs.SetInt("PassNPlayPlayerCount", thisButtonNum);
        }
        Debug.Log("Four Button Upd");
    }
    #endregion

    #region Five Button
    void FiveButtonDowned()
    {
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 5;
        if (thisButtonNum != currentPlayerCount)
            ButtonDowned(fiveText);
        Debug.Log("Five Button Downed");
    }

    void FiveButtonExited()
    {
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 5;
        if (thisButtonNum != currentPlayerCount)
            ButtonExited(fiveText);
        Debug.Log("Five Button Exited");
    }

    void FiveButtonUpd()
    {
        float animLength = 9;
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 5;
        if (thisButtonNum != currentPlayerCount)
        {
            PlayerCountSelect(animLength, thisButtonNum);
            PlayerPrefs.SetInt("PassNPlayPlayerCount", thisButtonNum);
        }
        Debug.Log("Five Button Upd");
    }
    #endregion

    #region Six Button
    void SixButtonDowned()
    {
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 6;
        if (thisButtonNum != currentPlayerCount)
            ButtonDowned(sixText);
        Debug.Log("Six Button Downed");
    }

    void SixButtonExited()
    {
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 6;
        if (thisButtonNum != currentPlayerCount)
            ButtonExited(sixText);
        Debug.Log("Six Button Exited");
    }

    void SixButtonUpd()
    {
        float animLength = 9;
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 6;
        if (thisButtonNum != currentPlayerCount)
        {
            PlayerCountSelect(animLength, thisButtonNum);
            PlayerPrefs.SetInt("PassNPlayPlayerCount", thisButtonNum);
        }
        Debug.Log("Six Button Upd");
    }
    #endregion

    #region Seven Button
    void SevenButtonDowned()
    {
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 7;
        if (thisButtonNum != currentPlayerCount)
            ButtonDowned(sevenText);
        Debug.Log("Seven Button Downed");
    }

    void SevenButtonExited()
    {
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 7;
        if (thisButtonNum != currentPlayerCount)
            ButtonExited(sevenText);
        Debug.Log("Seven Button Exited");
    }

    void SevenButtonUpd()
    {
        float animLength = 9;
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 7;
        if (thisButtonNum != currentPlayerCount)
        {
            PlayerCountSelect(animLength, thisButtonNum);
            PlayerPrefs.SetInt("PassNPlayPlayerCount", thisButtonNum);
        }
        Debug.Log("Seven Button Upd");
    }
    #endregion

    #region Eight Button
    void EightButtonDowned()
    {
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 8;
        if (thisButtonNum != currentPlayerCount)
            ButtonDowned(eightText);
        Debug.Log("Eight Button Downed");
    }

    void EightButtonExited()
    {
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 8;
        if (thisButtonNum != currentPlayerCount)
            ButtonExited(eightText);
        Debug.Log("Eight Button Exited");
    }

    void EightButtonUpd()
    {
        float animLength = 9;
        int currentPlayerCount = PlayerPrefs.GetInt("PassNPlayPlayerCount", 0);
        int thisButtonNum = 8;
        if (thisButtonNum != currentPlayerCount)
        {
            PlayerCountSelect(animLength, thisButtonNum);
            PlayerPrefs.SetInt("PassNPlayPlayerCount", thisButtonNum);
        }
        Debug.Log("Eight Button Upd");
    }
    #endregion

    #region Player Count Back Button
    void PlayerCountBackButtonDowned()
    {
        ButtonDowned(playerCountBackText);
        Debug.Log("Player Count Back Button Downed");
    }

    void PlayerCountBackButtonExited()
    {
        ButtonExited(playerCountBackText);
        Debug.Log("Player Count Back Button Exited");
    }

    void PlayerCountBackButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(playerCountText, false, animLength);
        ButtonAppear(twoText, false, animLength);
        ButtonAppear(threeText, false, animLength);
        ButtonAppear(fourText, false, animLength);
        ButtonAppear(fiveText, false, animLength);
        ButtonAppear(sixText, false, animLength);
        ButtonAppear(sevenText, false, animLength);
        ButtonAppear(eightText, false, animLength);
        ButtonAppear(playerCountBackText, false, animLength);
        ButtonAppear(okText, false, animLength);

        StartCoroutine(GlobalFunctions.DelayedActivate(playerCountMenu, false, animLength));

        StartCoroutine(GlobalFunctions.FadeColors(screenBG, 9, purpleScreenColor));

        StartCoroutine(GlobalFunctions.DelayedActivate(multiplayerMenu, true, animLength));

        ButtonAppear(passNPlayText, true, animLength);
        ButtonAppear(multiplayerBackText, true, animLength);

        PlayerPrefs.SetInt("PassNPlayPlayerCount", 0);

        Debug.Log("Player Count Back Button Upd");
    }
    #endregion

    #region Ok Button
    void OkButtonDowned()
    {
        ButtonDowned(okText);
        Debug.Log("Ok Button Downed");
    }

    void OkButtonExited()
    {
        ButtonExited(okText);
        Debug.Log("Ok Button Exited");
    }

    void OkButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(playerCountText, false, animLength);
        ButtonAppear(twoText, false, animLength);
        ButtonAppear(threeText, false, animLength);
        ButtonAppear(fourText, false, animLength);
        ButtonAppear(fiveText, false, animLength);
        ButtonAppear(sixText, false, animLength);
        ButtonAppear(sevenText, false, animLength);
        ButtonAppear(eightText, false, animLength);
        ButtonAppear(playerCountBackText, false, animLength);
        ButtonAppear(okText, false, animLength);

        StartCoroutine(GlobalFunctions.DelayedActivate(playerCountMenu, false, animLength));

        StartCoroutine(GlobalFunctions.FadeColors(screenBG, animLength, greenScreenColor));

        // set that the player is entering  endless mode
        PlayerPrefs.SetInt("GameMode", 2); // 0: story, 1: endless, 2: pass n play

        StartCoroutine(CameraZoom()); // zoom camera
        StartCoroutine(GlobalFunctions.DelayedSceneLoad(3, 1f)); // enter pass n play hub world

        Debug.Log("Ok Button Upd");
    }
    #endregion

    #region Options Back Button
    void OptionsBackButtonDowned()
    {
        ButtonDowned(optionsBackText);
        Debug.Log("Options Back Button Downed");
    }

    void OptionsBackButtonExited()
    {
        ButtonExited(optionsBackText);
        Debug.Log("Options Back Button Exited");
    }

    void OptionsBackButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(optionsBackText, false, animLength);
        ButtonAppear(applyText, false, animLength);

        StartCoroutine(GlobalFunctions.DelayedActivate(optionsMenu, false, animLength));

        StartCoroutine(GlobalFunctions.FadeColors(screenBG, animLength, blueScreenColor));

        StartCoroutine(GlobalFunctions.DelayedActivate(mainMenu, true, animLength));

        ButtonAppear(singlePlayerText, true, animLength);
        ButtonAppear(multiplayerText, true, animLength);
        ButtonAppear(optionsText, true, animLength);
        ButtonAppear(mainMenuBackText, true, animLength);

        Debug.Log("Options Back Button Upd");
    }
    #endregion

    #region Apply Button
    void ApplyButtonDowned()
    {
        ButtonDowned(applyText);
        Debug.Log("Apply Button Downed");
    }

    void ApplyButtonExited()
    {
        ButtonExited(applyText);
        Debug.Log("Apply Button Exited");
    }

    void ApplyButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(optionsBackText, false, animLength);
        ButtonAppear(applyText, false, animLength);

        StartCoroutine(GlobalFunctions.DelayedActivate(optionsMenu, false, animLength));

        StartCoroutine(GlobalFunctions.FadeColors(screenBG, animLength, blueScreenColor));

        StartCoroutine(GlobalFunctions.DelayedActivate(mainMenu, true, animLength));

        ButtonAppear(singlePlayerText, true, animLength);
        ButtonAppear(multiplayerText, true, animLength);
        ButtonAppear(optionsText, true, animLength);
        ButtonAppear(mainMenuBackText, true, animLength);

        Debug.Log("Apply Button Upd");
    }
    #endregion

    #region Play Again Button
    void PlayAgainButtonDowned()
    {
        ButtonDowned(playAgainText);
        Debug.Log("Play Again Button Downed");
    }

    void PlayAgainButtonExited()
    {
        ButtonExited(playAgainText);
        Debug.Log("Play Again Button Exited");
    }

    void PlayAgainButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(playAgainText, false, animLength);
        ButtonAppear(postGameBackText, false, animLength);

        StartCoroutine(GlobalFunctions.DelayedActivate(postGameMenu, false, animLength));

        Debug.Log("Play Again Button Upd");
    }
    #endregion

    #region Post Game Back Button
    void PostGameBackButtonDowned()
    {
        ButtonDowned(postGameBackText);
        Debug.Log("Post Game Back Button Downed");
    }

    void PostGameBackButtonExited()
    {
        ButtonExited(postGameBackText);
        Debug.Log("Post Game Back Button Exited");
    }

    void PostGameBackButtonUpd()
    {
        float animLength = 9;

        ButtonAppear(playAgainText, false, animLength);
        ButtonAppear(postGameBackText, false, animLength);

        StartCoroutine(GlobalFunctions.DelayedActivate(postGameMenu, false, animLength));

        StartCoroutine(GlobalFunctions.FadeColors(screenBG, animLength, blueScreenColor));

        StartCoroutine(GlobalFunctions.DelayedActivate(mainMenu, true, animLength));

        ButtonAppear(singlePlayerText, true, animLength);
        ButtonAppear(multiplayerText, true, animLength);
        ButtonAppear(optionsText, true, animLength);
        ButtonAppear(mainMenuBackText, true, animLength);

        Debug.Log("Post Game Back Button Upd");
    }
    #endregion

}
