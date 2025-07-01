using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealH : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CatScript catScript = collision.gameObject.GetComponent<CatScript>();
        if (collision.gameObject.tag == "Player" && catScript.health != 3)
        {
            StartCoroutine(catScript.Healing(1));
            gameObject.SetActive(false);
        }  
    }
}
