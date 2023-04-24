using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMatOnSpawn : MonoBehaviour
{
    [SerializeField] MeshRenderer objMesh;
    [SerializeField] Material[] myMats;

    // Start is called before the first frame update
    void OnEnable()
    {
        // set object color
        int randMat = Random.Range(0, myMats.Length);
        objMesh.material = myMats[randMat];
    }
}
