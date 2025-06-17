using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerItems : MonoBehaviour
{
    public GameObject Item;
    void OnTriggerEnter2D(Collider2D other)
{
        if (other.CompareTag("Player"))
        {
            Item.SetActive(true);
           

    }
}

}
