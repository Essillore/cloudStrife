using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public GameObject playerHealthObject;
    public GameObject healthBarObject;
    
    private int currHealth;

    private RectTransform image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        currHealth = playerHealthObject.GetComponent<PlayerHealth>().currentHealth;
        image.sizeDelta = new Vector2(currHealth, 20);
    }
}
