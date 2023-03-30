using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedBarScript : MonoBehaviour
{
    public GameObject playerHealthObject;
    public GameObject destroyedBarObject;

    private int destroyedSpires;
    private float destroyedPercentage;
    private RectTransform image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        destroyedSpires = playerHealthObject.GetComponent<PlayerHealth>().destroyedSpires;
        image.sizeDelta = new Vector2((1000 / 18) * destroyedSpires, 20);
    }
}
