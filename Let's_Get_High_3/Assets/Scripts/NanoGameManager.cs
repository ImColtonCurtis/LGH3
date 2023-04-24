using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NanoGameManager : MonoBehaviour
{
    public static bool gameHasStarted, playerWon, playerLost;

    [Range(3f, 8f)]
    [SerializeField] float gameTimer;

    [Range(0, 1)]
    [SerializeField] int gameType; // 0: survivable, 1: accomplish

    [SerializeField] Color borderColor, garageColor, doorColor, backgroundColor;

    [SerializeField] string instructionsString;

    [SerializeField] Camera myCam;

    [SerializeField] Image[] border;

    [SerializeField] TextMeshProUGUI countDownText, instructionsText;
    [SerializeField] Transform UIAutoSizer;

    [SerializeField] Transform dynamiteClockTransform;
    float clockRotAmount, totalGameTime;
    bool dynRotDir;

    [SerializeField] Image screenCover;

    bool fadedInstructionTextOut;

    [SerializeField] GameObject dynamiteClock, clockExplosion;

    [SerializeField] float rotSpeed;

    [SerializeField] Image[] garageDoor;
    [SerializeField] TextMeshProUGUI nanoGameCountText, nanoGameNextCountText;
    [SerializeField] Transform garageDoorTransform, garageTransform, currentScoreTransform, nextScoreTransform;
    [SerializeField] GameObject garageObj;

    [SerializeField] bool skipTransitions; // if true, skip transition for faster game creation

    // TODO: SET PlayerPrefs.SetInt("NanoGameCount", 5) SOMEWHERE
    // TODO: SET PlayerPrefs.SetInt("HubWorld", 0) SOMEWHERE if transitioning from hub world
    // TODO: SET PlayerPrefs.SetInt("GameMode", 0) SOMEWHERE 0: story, 1: endless, 2: pass n play

    private void OnEnable()
    {
        playerWon = false;
        playerLost = false;

        gameHasStarted = false;

        dynRotDir = false;
        if (Random.Range(0, 2) == 0)
            dynRotDir = true;

        fadedInstructionTextOut = false;

        dynamiteClock.SetActive(true);
        clockExplosion.SetActive(false);

        // set instructions
        instructionsText.text = instructionsString;

        // set border color
        foreach (Image image in border)
            image.color = borderColor;

        // set bg color
        myCam.backgroundColor = backgroundColor;

        // set garage color
        garageDoor[0].color = garageColor;
        // set door color
        garageDoor[2].color = doorColor;

        countDownText.text = Mathf.Round(gameTimer).ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        // check whether this is transitioning from a hub world or another nanogame
        float animLength = 45;
        if (PlayerPrefs.GetInt("HubWorld", 0) == 1)
        {
            StartCoroutine(GlobalFunctions.FadeImage(screenCover, animLength, 1, 0));
            //PlayerPrefs.SetInt("HubWorld", 0); // switch back to 0
        }

        // check if this is preforming the garage door transition or not
        if (PlayerPrefs.GetInt("GameMode", 0) >= 2) // 0: story, 1: endless, 2: pass n play
        {
            // set garage to invis
            garageObj.SetActive(false);
            GameStartedLit(); // start game
        }
        else
            StartCoroutine(GarageDoorOpen());
    }

    IEnumerator GarageDoorOpen()
    {
        // set garage to invis
        garageObj.SetActive(true);

        // zoom in garage
        float animLength = 16;
        // check if coming from a hub world, preform
        if (PlayerPrefs.GetInt("HubWorld", 0) == 1)
        {
            StartCoroutine(GlobalFunctions.TransformScale(garageTransform, animLength, 0.88f, 1f));
            PlayerPrefs.SetInt("HubWorld", 0); // switch back to 0
        }

        // set nanoGameCountText
        nanoGameCountText.text = PlayerPrefs.GetInt("NanoGameCount", 0).ToString();

        // hide next count text
        nanoGameNextCountText.color = new Color(1, 1, 1, 0);

        // wait a bit
        yield return new WaitForSeconds(1f);

        // if coming from story mode, count down
        if (PlayerPrefs.GetInt("GameMode", 0) == 0) // story mode
            PlayerPrefs.SetInt("NanoGameCount", PlayerPrefs.GetInt("NanoGameCount", 0) - 1);
        // else if coming from endless mode, count up
        else if (PlayerPrefs.GetInt("GameMode", 0) == 1) // endless mode
            PlayerPrefs.SetInt("NanoGameCount", PlayerPrefs.GetInt("NanoGameCount", 0) + 1);

        // transition nanoGameCountText either up 1 or down 1 (based on current gamemode)
        nanoGameNextCountText.text = PlayerPrefs.GetInt("NanoGameCount", 0).ToString();
        nanoGameNextCountText.color = new Color(1, 1, 1, 0); // set to hidden

        // move main text down a bit
        animLength = 9;
        StartCoroutine(GlobalFunctions.TransformPosition(currentScoreTransform.transform, animLength, new Vector3(-806.18f, 211f, 0f), new Vector3(-806.18f, 145.0f, 0f)));

        // wait a bit
        yield return new WaitForSeconds(0.15f);

        // transition text upwards
        animLength = 14;
        StartCoroutine(GlobalFunctions.TransformPosition(currentScoreTransform.transform, animLength, new Vector3(-806.18f, 145.0f, 0f), new Vector3(-806.18f, 815f, 0f)));
        StartCoroutine(GlobalFunctions.TransformPosition(nextScoreTransform.transform, animLength, new Vector3(-806.177f, -393f, 0), new Vector3(-806.177f, 211f, 0)));

        // fade old text out
        animLength = 19;
        StartCoroutine(GlobalFunctions.FadeTMPUGI(nanoGameCountText, animLength, 1, 0));

        // fade new text in
        StartCoroutine(GlobalFunctions.FadeTMPUGI(nanoGameNextCountText, animLength, 0, 1));

        // wait a bit
        yield return new WaitForSeconds(0.45f);

        // zoom out
        animLength = 22;
        StartCoroutine(GlobalFunctions.TransformScale(garageTransform, animLength, 1, 0.94f));

        // wait a bit
        yield return new WaitForSeconds(0.25f);

        // open garage door
        animLength = 24;
        StartCoroutine(GlobalFunctions.TransformPosition(garageDoorTransform, animLength, new Vector3(0,0,0), new Vector3(0, 3306, 0)));

        // zoom in
        animLength = 25;
        StartCoroutine(GlobalFunctions.TransformScale(garageTransform, animLength, 0.94f, 1.72f));

        // wait a bit
        yield return new WaitForSeconds(0.1f);

        // start game
        GameStartedLit();

        // wait a bit
        yield return new WaitForSeconds(0.95f);

        // fade out garage images
        animLength = 20;
        foreach (Image images in garageDoor)
            StartCoroutine(GlobalFunctions.FadeImage(images, animLength, 1, 0));
        StartCoroutine(GlobalFunctions.FadeTMPUGI(nanoGameCountText, animLength, 1, 0));
        StartCoroutine(GlobalFunctions.FadeTMPUGI(nanoGameNextCountText, animLength, 1, 0));
    }

    IEnumerator GarageDoorClose()
    {
        float animLength;

        // fade in garage images
        animLength = 20;
        foreach (Image images in garageDoor)
            StartCoroutine(GlobalFunctions.FadeImage(images, animLength, 0, 1));
        StartCoroutine(GlobalFunctions.FadeTMPUGI(nanoGameNextCountText, animLength, 0, 1));

        // wait a bit
        yield return new WaitForSeconds(0.25f);

        // bring garage back in
        // zoom out
        animLength = 22;
        StartCoroutine(GlobalFunctions.TransformScale(garageTransform, animLength, 1.72f, 1));

        // close garage door
        animLength = 20;
        StartCoroutine(GlobalFunctions.TransformPosition(garageDoorTransform, animLength, new Vector3(0, 3306, 0), new Vector3(0, 0, 0)));

        // wait a bit
        yield return new WaitForSeconds(0.25f);

        // end game
        StartCoroutine(GameEndedLit());

        animLength = 16;
        // check whether this is transitioning to a hub world or another nanogame (if player lost)
        if (PlayerPrefs.GetInt("HubWorld", 0) == 1)
        {
            StartCoroutine(GlobalFunctions.FadeImage(screenCover, animLength, 0, 1));
        }
    }

    void GameStartedLit()
    {
        // set total timer
        totalGameTime = gameTimer;

        // bring text in
        StartCoroutine(BringInText());

        // shake dyanmite
        StartCoroutine(ShakeDynamite());

        // start countdown timer
        StartCoroutine(GameTimerCountdown());

        gameHasStarted = true;

        // start zoom in 
        float animLength = 11;
        StartCoroutine(GlobalFunctions.TransformScale(UIAutoSizer, animLength, 0.86f, 1));
    }

    IEnumerator BringInText()
    {
        float timer = 0, totalTimer = 14;
        float startingFontSize = 850, endingFontSize = 322;
        float startingGap = 25, endingGap = 1;

        while (timer <= totalTimer)
        {
            instructionsText.fontSize = Mathf.Lerp(startingFontSize, endingFontSize, timer / totalTimer);
            instructionsText.characterSpacing = Mathf.Lerp(startingGap, endingGap, timer / totalTimer);
            yield return new WaitForFixedUpdate();
            timer++;
        }
    }

    IEnumerator ShakeDynamite()
    {
        float maxAngle = 7.2f;

        while (gameTimer > 0)
        {
            // rotate dynamite clock
            clockRotAmount = rotSpeed * Mathf.Clamp(1 -(gameTimer / totalGameTime) + 0.35f, 0.25f, 1.5f);

            float compAngle = dynamiteClockTransform.localEulerAngles.z;
            // correct angle
            if (compAngle > 330)
                compAngle -= 360;

            if (compAngle >= maxAngle)
                dynRotDir = false;
            else if (compAngle <= -maxAngle)
                dynRotDir = true;

            if (!dynRotDir)
                clockRotAmount *= -1;

            dynamiteClockTransform.localEulerAngles = new Vector3(0, 0, Mathf.Clamp(compAngle + clockRotAmount, -maxAngle, maxAngle));

            // fade text from white to yellow, and then from yellow to red
            if (1 - (gameTimer / totalGameTime) < 0.5f)
            {
                countDownText.color = Color.Lerp(Color.white, Color.yellow, Mathf.Clamp((1 - (gameTimer / totalGameTime)) * 2, 0, 1));
                //Debug.Log(1 - (gameTimer / totalGameTime));
            }
            else
                countDownText.color = Color.Lerp(Color.yellow, Color.red, Mathf.Clamp((1 - (gameTimer / totalGameTime)-0.5f) * 2, 0, 1));

            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator GameTimerCountdown()
    {
        float timeToFadeDirectionText = 1f, 
            fadeAnimLength = 8;

        while (gameTimer > 0) 
        {
            yield return new WaitForSeconds(0.1f);
            gameTimer -= 0.1f;

            // fade instrucion text out
            if (totalGameTime - gameTimer > timeToFadeDirectionText && !fadedInstructionTextOut)
            {
                StartCoroutine(GlobalFunctions.FadeTMPUGI(instructionsText, fadeAnimLength, 1, 0));
                fadedInstructionTextOut = true;
            }

            countDownText.text = Mathf.Round(gameTimer).ToString();
        }
        gameTimer = 0;

        // swap clock out for explosion
        dynamiteClock.SetActive(false);
        clockExplosion.SetActive(true);

        // timer is at 0
        // if player has not won, and this isn't a survivable game, then they have lost
        if (!playerWon && gameType != 0 || playerLost)
        {
            playerLost = true;
            PlayerPrefs.SetInt("HubWorld", 1); // player will be going back to a hub world
            Debug.Log("Player Lost");
        }
        // if player has not won, and this is a survivable game, then they have won
        else if ((!playerWon && gameType == 0 && !playerLost) || playerWon)
        {
            playerWon = true;
            Debug.Log("Player Won");
        }

        // wait a bit
        yield return new WaitForSeconds(0.35f);

        if (PlayerPrefs.GetInt("GameMode", 0) == 2) // 2: pass and play
        {
            StartCoroutine(GameEndedLit());
            float animLength = 16;
            StartCoroutine(GlobalFunctions.FadeImage(screenCover, animLength, 0, 1));
        }
        else
            StartCoroutine(GarageDoorClose());
    }

    IEnumerator GameEndedLit()
    {
        float zoomOutAnimLength = 11, zoomInAnimLength = 16,
            endScale1 = 1.08f, endScale2 = 0.82f;
        // start zoom out
        StartCoroutine(GlobalFunctions.TransformScale(UIAutoSizer, zoomOutAnimLength, 1, endScale1));

        for (int i = 0; i <= zoomOutAnimLength; i++)
            yield return new WaitForFixedUpdate();

        // start zoom in
        StartCoroutine(GlobalFunctions.TransformScale(UIAutoSizer, zoomInAnimLength, endScale1, endScale2));
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(0.3f);
        if (PlayerPrefs.GetInt("HubWorld", 0) == 1) // going to a hub world
        {
            PlayerPrefs.SetInt("HubWorld", 0); // switch back to '0'

            // Check which hub world we're going to: story mode, endless mode, or pass and play mode
            switch (PlayerPrefs.GetInt("GameMode", 0))
            {
                case 0: // story mode
                    SceneManager.LoadScene(1, LoadSceneMode.Single); // story mode
                    break;
                case 1: // endless mode
                    SceneManager.LoadScene(2, LoadSceneMode.Single); // endless mode
                    break;
                case 2: // pass n play mode
                    SceneManager.LoadScene(3, LoadSceneMode.Single); // pass n play mode
                    break;
                default: // story mode
                    Debug.LogError("Non-Existing Game Mode Selected");
                    SceneManager.LoadScene(0, LoadSceneMode.Single); // story mode
                    break;
            }
        }
        else
            SceneManager.LoadScene(Random.Range(MenuManager.hubSceneAmnt, MenuManager.nanoGameSceneAmnt + MenuManager.hubSceneAmnt), LoadSceneMode.Single); // some random mini game
    }
}
