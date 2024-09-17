using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealH : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.gameObject.tag == "Player")
        {
            StartCoroutine(player.GetComponent<CatScript>().Healing(1));
            gameObject.SetActive(false);
        }  
    }
}
