using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StoryModeManager : MonoBehaviour
{
    [SerializeField] Image screenCover;
    [SerializeField] Transform cameraHolder;

    [SerializeField] SpriteRenderer[] playStorySR, homeStorySR, settingsStorySR;

    // struct for each nanogame
    struct NanoGame
    {
        bool HasBeenPlayed; // whether the nanogame has been played
        int TimePlayed; // the order in which the game was played via PlayerPrefs.GetInt("timePlayed", 0)
        bool HasBeenPassed; // whether the nanogame has been passed

        public NanoGame(bool hasBeenPlayed, int timePlayed, bool hasBeenPassed)
        {
            HasBeenPlayed = hasBeenPlayed;
            TimePlayed = timePlayed;
            HasBeenPassed = hasBeenPassed;
        }
    }

    // struct for each level
    struct LevelData
    {
        Vector3 ButtonPos; // the position of the button for the level
        int NanoGameCount; // the amount of nanogames in the level
        int WorldCount; // the world the level exists in

        public LevelData(Vector3 buttonPos, int nanoGameCount, int worldCount)
        {
            ButtonPos = buttonPos;
            NanoGameCount = nanoGameCount;
            WorldCount = worldCount;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GlobalFunctions.FadeImage(screenCover, 45, 1, 0));
        StartCoroutine(GlobalFunctions.TransformPosition(cameraHolder, 75, new Vector3(0, 0, -0.87f), new Vector3(0, 0, 0)));
    }

    private void OnEnable()
    {
        GlobalNotifier.OnPlayStoryButtonDown += PlayStoryButtonDowned;
        GlobalNotifier.OnPlayStoryButtonExit += PlayStoryButtonExited;
        GlobalNotifier.OnPlayStoryButtonUp += PlayStoryButtonUpd;

        GlobalNotifier.OnHomeStoryButtonDown += HomeStoryButtonDowned;
        GlobalNotifier.OnHomeStoryButtonExit += HomeStoryButtonExited;
        GlobalNotifier.OnHomeStoryButtonUp += HomeStoryButtonUpd;

        GlobalNotifier.OnSettingsStoryButtonDown += SettingsStoryButtonDowned;
        GlobalNotifier.OnSettingsStoryButtonExit += SettingsStoryButtonExited;
        GlobalNotifier.OnSettingsStoryButtonUp += SettingsStoryButtonUpd;
    }

    private void OnDisable()
    {
        GlobalNotifier.OnPlayStoryButtonDown -= PlayStoryButtonDowned;
        GlobalNotifier.OnPlayStoryButtonExit -= PlayStoryButtonExited;
        GlobalNotifier.OnPlayStoryButtonUp -= PlayStoryButtonUpd;

        GlobalNotifier.OnHomeStoryButtonDown -= HomeStoryButtonDowned;
        GlobalNotifier.OnHomeStoryButtonExit -= HomeStoryButtonExited;
        GlobalNotifier.OnHomeStoryButtonUp -= HomeStoryButtonUpd;

        GlobalNotifier.OnSettingsStoryButtonDown -= SettingsStoryButtonDowned;
        GlobalNotifier.OnSettingsStoryButtonExit -= SettingsStoryButtonExited;
        GlobalNotifier.OnSettingsStoryButtonUp -= SettingsStoryButtonUpd;
    }

    #region Base Button Calls
    void ButtonDowned(SpriteRenderer[] mySR)
    {
        for (int i = 0; i < mySR.Length; i++)
        {
            Color mySRColor = mySR[i].color;
            StartCoroutine(GlobalFunctions.FadeColors(mySR[i], 9, new Color(mySRColor.r, mySRColor.g, mySRColor.b, 0.5f)));
            if (i == 0)
                StartCoroutine(GlobalFunctions.TransformScale(mySR[i].transform, 9, mySR[i].transform.localScale.x, mySR[i].transform.localScale.x * 0.95f));
        }
    }

    void ButtonExited(SpriteRenderer[] mySR)
    {
        for (int i = 0; i < mySR.Length; i++)
        {
            Color mySRColor = mySR[i].color;
            StartCoroutine(GlobalFunctions.FadeColors(mySR[i], 9, new Color(mySRColor.r, mySRColor.g, mySRColor.b, 1)));
            if (i == 0)
                StartCoroutine(GlobalFunctions.TransformScale(mySR[i].transform, 9, mySR[i].transform.localScale.x, mySR[i].transform.localScale.x * (1f / .95f)));
        }
    }
    #endregion

    #region Play Story Button
    void PlayStoryButtonDowned()
    {
        ButtonDowned(playStorySR);
        Debug.Log("Story Button Downed");
    }

    void PlayStoryButtonExited()
    {
        ButtonExited(playStorySR);
        Debug.Log("Story Button Exited");
    }

    void PlayStoryButtonUpd()
    {
        float animLength = 9;

        Debug.Log("Story Button Upd");
    }
    #endregion

    #region Home Story Button
    void HomeStoryButtonDowned()
    {
        ButtonDowned(homeStorySR);
        Debug.Log("Story Button Downed");
    }

    void HomeStoryButtonExited()
    {
        ButtonExited(homeStorySR);
        Debug.Log("Story Button Exited");
    }

    void HomeStoryButtonUpd()
    {
        float animLength = 9;

        Debug.Log("Story Button Upd");
    }
    #endregion

    #region Settings Story Button
    void SettingsStoryButtonDowned()
    {
        ButtonDowned(settingsStorySR);
        Debug.Log("Settings Story Button Downed");
    }

    void SettingsStoryButtonExited()
    {
        ButtonExited(settingsStorySR);
        Debug.Log("Settings Story Button Exited");
    }

    void SettingsStoryButtonUpd()
    {
        float animLength = 9;

        Debug.Log("Settings Story Button Upd");
    }
    #endregion
}
