using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTheObject : MonoBehaviour
{
    [SerializeField] Animator myAnimator;

    [SerializeField] Rigidbody myRB;

    bool startObjects, grabbed;

    [SerializeField] MeshRenderer objMesh, obj2Mesh;

    [SerializeField] Material[] myMats;

    // Start is called before the first frame update
    void Start()
    {
        startObjects = false;
        grabbed = false;
    }

    private void Update()
    {
        if (NanoGameManager.gameHasStarted && !startObjects)
        {
            StartCoroutine(RandomDelay());
            startObjects = true;
        }
    }

    void OnTouchDown()
    {
        if (NanoGameManager.gameHasStarted && !grabbed && !NanoGameManager.playerLost)
        {
            myAnimator.SetTrigger("purple_grab");
            grabbed = true;
        }
    }

    IEnumerator RandomDelay()
    {
        Physics.gravity = new Vector3(0, -19f, 0);
        myRB.mass = Random.Range(5f, 40f);
        int randMat = Random.Range(0, myMats.Length);
        objMesh.material = myMats[randMat];
        obj2Mesh.material = myMats[randMat];
        yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
        myRB.useGravity = true;
    }
}
