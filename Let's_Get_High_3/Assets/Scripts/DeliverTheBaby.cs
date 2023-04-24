using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverTheBaby : MonoBehaviour
{
    [SerializeField] Animator myAnim, clawAnim;

    bool actioned, finishedLevel;

    [SerializeField] GameObject babyObj, winParticles;
    [SerializeField] Transform parentTransform;

    // Start is called before the first frame update
    void Start()
    {
        actioned = false;
        finishedLevel = false;

        // set gravity
        Physics.gravity = new Vector3(0, -31f, 0);
    }

    private void Update()
    {
        if (!finishedLevel && NanoGameManager.playerWon)
        {
            FinishedLevelMechanics();
            finishedLevel = false;
        }
    }

    void OnTouchDown()
    {
        if (NanoGameManager.gameHasStarted && !actioned)
        {
            Actions(); // preform some actions
            actioned = true;
        }
    }

    void Actions()
    {
        // change baby transform
        babyObj.transform.SetParent(parentTransform);

        // animate claw opening
        myAnim.SetTrigger("open");

        // turn off claw moving animation
        clawAnim.enabled = false;
    }

    void FinishedLevelMechanics()
    {
        winParticles.SetActive(true);
    }
}
