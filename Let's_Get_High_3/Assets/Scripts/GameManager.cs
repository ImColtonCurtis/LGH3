using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameStarted, levelFailed, levelPassed, usingMenuControls;
    [SerializeField] GameObject gameControls;
    [SerializeField] TouchInput menuControls;

    // ScreenSquare
    public SpriteRenderer screenSquareSR;

    private void Awake()
    {
        gameStarted = false;
        levelFailed = false;
        levelPassed = false;

        usingMenuControls = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator FadeScreenSquareOut()
    {
        float timer = 0, totalTime = 30;
        yield return new WaitForSecondsRealtime(0.3f);
        while (timer < totalTime)
        {
            screenSquareSR.color = Color.Lerp(Color.black, new Color(0, 0, 0, 0), timer / totalTime);
            yield return new WaitForFixedUpdate();
            timer++;
        }
    }
}
