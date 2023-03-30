using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletionBarScript : MonoBehaviour
{
    public GameObject playerHealthObject;
    public GameObject completionBarObject;

    private int seededSpires;
    private float completionPercentage;
    private RectTransform image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        seededSpires = playerHealthObject.GetComponent<PlayerHealth>().seededSpires;
        image.sizeDelta = new Vector2((1000 / 17) * seededSpires, 20);
    }
}
