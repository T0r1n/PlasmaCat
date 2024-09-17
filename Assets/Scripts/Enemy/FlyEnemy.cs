using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    public int heals = 3;
    public float speed;
    public bool chase = false;
    public Transform startingPoint;
    private GameObject player;
    Animator EnAnim;
    Rigidbody2D rb;

    public float dist;

    void Start()
    {
        EnAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        ControllerChaos();
        if (player == null)
            return;
        if (chase == true)
            Chase();
        else
            ReturnStartPoint();
        Flip();
    }

    private void ControllerChaos()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= dist * 1f)
            chase = true;
        else
            chase = false;
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        //if (Vector2.Distance(transform.position, player.transform.position) <= 1.5f)
        //    speed = 0;
        //else
        //    speed = 5;
    }
    public void ReturnStartPoint()
    {
     transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }
    private void Flip()
    {
        if (transform.position.x < player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //speed = 0;
            EnAnim.Play("FlyAttack");
            StartCoroutine(player.GetComponent<CatScript>().TakingDamage(1));
            rb.AddForce(transform.up * 20, ForceMode2D.Impulse);
        }    
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Player"))
    //        speed = 5;
    //}
}
