using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTheBall : MonoBehaviour
{
    [SerializeField] MeshRenderer objMesh;

    [SerializeField] Material[] myMats;

    [SerializeField] Transform[] blocks;

    bool hasStarted, inFirstPostion;

    // Start is called before the first frame update
    void Start()
    {
        inFirstPostion = false;

        // set gravity
        Physics.gravity = new Vector3(0, 0, 0);

        int randMat = Random.Range(0, myMats.Length);
        //objMesh.material = myMats[randMat];
    }

    private void Update()
    {
        if (NanoGameManager.gameHasStarted && !hasStarted)
        {
            Physics.gravity = new Vector3(0, -38f, 0);
            hasStarted = true;
        }
    }

    void OnTouchDown()
    {
        if (NanoGameManager.gameHasStarted && !NanoGameManager.playerLost)
            Actions();
    }

    void Actions()
    {
        // change block position
        float animLength = 16;
        if (inFirstPostion) {
            StartCoroutine(GlobalFunctions.TransformPosition(blocks[0], animLength, blocks[0].localPosition, new Vector3(0.492f, 9.75f, 4.527f)));

            StartCoroutine(GlobalFunctions.TransformPosition(blocks[1], animLength, blocks[1].localPosition, new Vector3(-0.59f, 9.215f, 4.43f)));

            StartCoroutine(GlobalFunctions.TransformPosition(blocks[2], animLength, blocks[2].localPosition, new Vector3(0.495f, 7.457f, 4.531f)));
            inFirstPostion = false;
        }
        else
        {
            StartCoroutine(GlobalFunctions.TransformPosition(blocks[0], animLength, blocks[0].localPosition, new Vector3(0.61f, 10.43f, 4.43f)));
            StartCoroutine(GlobalFunctions.TransformPosition(blocks[1], animLength, blocks[1].localPosition, new Vector3(-0.479f, 8.582f, 4.521f)));
            StartCoroutine(GlobalFunctions.TransformPosition(blocks[2], animLength, blocks[2].localPosition, new Vector3(0.62f, 8.15f, 4.44f)));
            inFirstPostion = true;
        }
    }
}
