using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QunechTheFire : MonoBehaviour
{
    bool growed;

    [SerializeField] List<MeshRenderer> growObjMeshes;
    [SerializeField] float timeToGrow = 5;
    [SerializeField] float refreshRate = 0.05f;
    [Range(0, 1)]
    [SerializeField] float minGrow = 0.39f;
    [Range(0, 1)]
    [SerializeField] float maxGrow = 1f;

    private List<Material> growObjMaterials = new List<Material>();
    private bool fullyGrown;

    [SerializeField] Animator poAnim;

    [SerializeField] MeshRenderer objMesh;

    [SerializeField] Material[] myMats;

    [SerializeField] GameObject fireParticles, darkSmokeParticles;

    // Start is called before the first frame update
    void Start()
    {
        growed = false;

        fullyGrown = true;

        // set ground color
        int randMat = Random.Range(0, myMats.Length);
        objMesh.material = myMats[randMat];

        for (int i = 0; i < growObjMeshes.Count; i++)
        {
            for (int j = 0; j < growObjMeshes[i].materials.Length; j++)
            {
                if (growObjMeshes[i].materials[j].HasProperty("_Grow"))
                {
                    growObjMeshes[i].materials[j].SetFloat("_Grow", minGrow);
                    growObjMaterials.Add(growObjMeshes[i].materials[j]);
                }
            }
        }

        // grow objects
        for (int i = 0; i < growObjMaterials.Count; i++)
        {
            // set plant height
            growObjMaterials[i].SetFloat("_Grow", maxGrow);
        }
    }

    void OnTouchDown()
    {
        if (NanoGameManager.gameHasStarted && !growed && !NanoGameManager.playerLost)
        {
            Actions();
            growed = true;
        }
    }

    void Actions()
    {
        // set gravity
        Physics.gravity = new Vector3(0, -31f, 0);

        // turn pot
        poAnim.SetTrigger("Turn");

        StartCoroutine(WaitToPreform());
    }

    IEnumerator WaitToPreform()
    {
        yield return new WaitForSeconds(0.75f);

        if (!NanoGameManager.playerLost)
        {
            // set player won to true
            NanoGameManager.playerWon = true;

            // grow objects
            for (int i = 0; i < growObjMaterials.Count; i++)
            {
                StartCoroutine(GrowObject(growObjMaterials[i]));
            }
        }

        fireParticles.SetActive(false);
        darkSmokeParticles.SetActive(true);
        yield return new WaitForSeconds(1f);
        // smoke particles
        fireParticles.SetActive(false);
        darkSmokeParticles.SetActive(true);
    }

    IEnumerator GrowObject(Material mat)
    {
        float growValue = mat.GetFloat("_Grow");

        if (!fullyGrown)
        {
            while (growValue < maxGrow)
            {
                growValue += 1 / (timeToGrow / refreshRate);
                mat.SetFloat("_Grow", growValue);

                yield return new WaitForSeconds(refreshRate);
            }
        }
        else
        {
            while (growValue > minGrow)
            {
                growValue -= 1 / (timeToGrow / refreshRate);
                mat.SetFloat("_Grow", growValue);

                yield return new WaitForSeconds(refreshRate);
            }
        }
    }
}
