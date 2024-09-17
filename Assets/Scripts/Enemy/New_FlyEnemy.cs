using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_FlyEnemy : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D _RBody;
    Rigidbody2D _PRBody;
    Animator EnAnim;


    // Start is called before the first frame update
    void Start()
    {
        _PRBody = player.GetComponent<Rigidbody2D>();
        _RBody = GetComponent<Rigidbody2D>();
        EnAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
    }

    private void Flip()
    {
        if (transform.position.x < player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    void wait() { }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(player.GetComponent<CatScript>().TakingDamage(1));
            if (player.GetComponent<CatScript>().health > 0)
            {
                EnAnim.Play("FlyAttack");
                if (transform.position.x < player.transform.position.x)
                    _PRBody.AddForce(Vector2.right * 7, ForceMode2D.Impulse);
                else
                    _PRBody.AddForce(Vector2.left * 7, ForceMode2D.Impulse);
            }

            //_RBody.AddForce(Vector2.up * 8000, ForceMode2D.Force);
        }
    }
}
