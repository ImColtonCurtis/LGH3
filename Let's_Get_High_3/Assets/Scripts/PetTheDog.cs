using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetTheDog : MonoBehaviour
{
    [SerializeField] Animator myAnim;

    bool actioned;

    [SerializeField] GameObject winParticles; // hearts
    [SerializeField] Transform parentTransform;

    [SerializeField] MeshRenderer objMesh;
    [SerializeField] Material[] myMats;

    // Start is called before the first frame update
    void Start()
    {
        actioned = false;

        // set gravity
        Physics.gravity = new Vector3(0, -31f, 0);

        // set ground color
        int randMat = Random.Range(0, myMats.Length);
        objMesh.material = myMats[randMat];
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
        // animate claw opening
        myAnim.SetTrigger("pet");
    }

    void FinishedLevelMechanics()
    {
        winParticles.SetActive(true);
    }
}
