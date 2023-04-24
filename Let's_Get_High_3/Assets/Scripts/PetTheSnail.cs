using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetTheSnail : MonoBehaviour
{
    [SerializeField] Animator snailMoveAnim, snailMothAnim;

    bool actioned;

    int petCount = 3;

    [SerializeField] GameObject winParticles; // hearts

    [SerializeField] MeshRenderer objMesh;
    [SerializeField] Material[] myMats;

    // Start is called before the first frame update
    void Start()
    {
        actioned = false;

        // set ground color
        int randMat = Random.Range(0, myMats.Length);
        objMesh.material = myMats[randMat];
    }

    void OnTouchDown()
    {
        if (NanoGameManager.gameHasStarted && !actioned && !NanoGameManager.playerLost && !NanoGameManager.playerWon)
        {
            Actions(); // preform some actions
            actioned = true;
        }
    }

    void OnTouchUp()
    {
        actioned = false;
    }

    void OnTouchExit()
    {
        actioned = false;
    }

    void Actions()
    {
        petCount--;
        snailMoveAnim.enabled = false;

        if (petCount <= 0)
        {
            NanoGameManager.playerWon = true;
            snailMothAnim.SetTrigger("smile");
            StartCoroutine(FinishedLevelMechanics());
        }
        else
        {
            snailMothAnim.SetTrigger("medium");
            StartCoroutine(WaitABit());
        }
    }

    IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(0.4f);
        // turn smile off and start moving snail again if player hasn't yet won
        if (!NanoGameManager.playerWon)
        {
            snailMothAnim.SetTrigger("frown");
            snailMoveAnim.enabled = true;
        }
    }

    IEnumerator FinishedLevelMechanics()
    {
        yield return new WaitForSeconds(0.15f);
        winParticles.SetActive(true);
    }
}
