using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowWireTemp : MonoBehaviour
{
    [SerializeField] List<MeshRenderer> growWireMeshes;
    [SerializeField] float timeToGrow = 5;
    [SerializeField] float refreshRate = 0.05f;
    [Range(0,1)]
    [SerializeField] float minGrow = 0.2f;
    [Range(0, 1)]
    [SerializeField] float maxGrow = 1f;

    private List<Material> growWireMaterials = new List<Material>();
    private bool fullyGrown;

    [SerializeField] MeshRenderer buttonGlow;
    private Material newMat;
    [SerializeField] Color baseButtonColor, glowingButtonColor;

    [SerializeField] bool growNow, preGrown;

    // Start is called before the first frame update
    void Start()
    {
        // duplicate glow mat
        newMat = buttonGlow.material;
        buttonGlow.material = newMat;

        for (int i = 0; i < growWireMeshes.Count; i++)
        {
            for(int j = 0; j < growWireMeshes[i].materials.Length; j++)
            {
                if (growWireMeshes[i].materials[j].HasProperty("_Grow"))
                {
                    growWireMeshes[i].materials[j].SetFloat("_Grow", minGrow);
                    growWireMaterials.Add(growWireMeshes[i].materials[j]);
                }
            }
        }
        if (preGrown)
        {
            for (int i = 0; i < growWireMaterials.Count; i++)
            {
                growWireMaterials[i].SetFloat("_Grow", 1);
            }
            newMat.SetColor("_EmissionColor", glowingButtonColor * Mathf.Pow(2, 1.2f));
            fullyGrown = true;
        }
        else
            newMat.SetColor("_EmissionColor", baseButtonColor);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || growNow)
        {
            for (int i = 0; i < growWireMaterials.Count; i++)
            {
                StartCoroutine(GrowWire(growWireMaterials[i]));
            }
            growNow = false;
        }
    }

    IEnumerator GrowWire(Material mat)
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

        if (growValue >= maxGrow)
        {
            fullyGrown = true;
            StartCoroutine(GrowGlow(true));
        }
        else
        {
            fullyGrown = false;
            StartCoroutine(GrowGlow(false));
        }
    }

    IEnumerator GrowGlow(bool dir)
    {
        float timer = 0, totalTimer = 8;

        // calculation for hdr color intensity
        float intensity = 1.2f;
        float factor = Mathf.Pow(2, intensity);

        while (timer <= totalTimer)
        {
            Color newColor;
            if (dir)
                newColor = Color.Lerp(baseButtonColor, glowingButtonColor * factor, timer / totalTimer);
            else
                newColor = Color.Lerp(glowingButtonColor* factor, baseButtonColor, timer / totalTimer);
            newMat.SetColor("_EmissionColor", newColor);
            timer++;
            yield return new WaitForFixedUpdate();
        }
    }
}
