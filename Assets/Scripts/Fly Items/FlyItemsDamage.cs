using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyItemsDamage : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(collision.gameObject.GetComponent<CatScript>().TakingDamage(1));

        }
    }
}

}