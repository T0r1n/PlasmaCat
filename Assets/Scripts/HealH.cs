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
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(collision.gameObject.GetComponent<CatScript>().Healing(1));
            gameObject.SetActive(false);
        }  
    }
}
