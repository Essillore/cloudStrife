using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float destroyCounter = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destroyCounter);
    }
}
