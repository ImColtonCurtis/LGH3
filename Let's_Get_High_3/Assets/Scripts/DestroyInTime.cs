using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInTime : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    [SerializeField] GameObject particleObj;
    [SerializeField] bool hasParticles;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(WaitToDestroy());
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(timeToDestroy);
        if (hasParticles)
        {
            Vector3 wPos = particleObj.transform.position;
            if (transform.parent != null)
                particleObj.transform.SetParent(transform.parent);
            particleObj.transform.position = wPos;
            particleObj.SetActive(true);
        }
        Destroy(gameObject);
    }
}
