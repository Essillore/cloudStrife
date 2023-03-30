using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingRecharge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
            {
            GetComponentInParent<Spire>().healing = true;
            collision.GetComponent<PlayerHealth>().activelyHealing = true;
        }

    }
    private void OnTriggerExit(Collider collision)
    { if (collision.CompareTag("Player"))
        { GetComponentInParent<Spire>().healing = false;
            collision.GetComponent<PlayerHealth>().activelyHealing = false;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().activelyHealing = true;
        }
    }
}
