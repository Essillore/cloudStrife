using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploAutoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(autoDestroyExplosion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator autoDestroyExplosion()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
