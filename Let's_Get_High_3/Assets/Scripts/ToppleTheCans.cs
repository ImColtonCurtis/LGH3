using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppleTheCans : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab, confettingObj;
    [SerializeField] Transform spawnFolder;

    [SerializeField] MeshRenderer objMesh;
    [SerializeField] Material[] myMats;

    [SerializeField] int cansToTopple;
    public static int staticCansToTopple;

    bool winNotation;

    // Start is called before the first frame update
    void Start()
    {
        // set cans to topple
        staticCansToTopple = cansToTopple;

        // set gravity
        Physics.gravity = new Vector3(0, -31f, 0);

        winNotation = false;

        // set ground color
        int randMat = Random.Range(0, myMats.Length);
        objMesh.material = myMats[randMat];
    }

    private void Update()
    {
        if (!winNotation && NanoGameManager.playerWon)
        {
            confettingObj.SetActive(true);
            winNotation = true;
        }
    }

    void OnTouchDown(Vector3 point)
    {
        if (NanoGameManager.gameHasStarted && !NanoGameManager.playerLost && !NanoGameManager.playerWon)
        {
            Actions(point);
        }
    }

    void Actions(Vector3 point)
    {
        // fire ball
        GameObject tempObj = Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity, spawnFolder);
        // reset position
        tempObj.transform.localPosition = new Vector3(0, 7.7f, -2.47f);
        tempObj.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        // velocity application
        Rigidbody myRB = tempObj.GetComponent<Rigidbody>();
        if (myRB != null)
        {
            float forceZ = 350;
            float multiplyer = 500;
            float forceY =  Mathf.Clamp(((point.y+3.45f)/1.39f), -1, 1)* multiplyer;
            float forceX = Mathf.Clamp(point.x, -0.62f, 0.62f) * multiplyer;
            // apply launch velocity
            myRB.AddForce(new Vector3(forceX, forceY, forceZ), ForceMode.Impulse); // 2 was perfect
        }
    }
}
