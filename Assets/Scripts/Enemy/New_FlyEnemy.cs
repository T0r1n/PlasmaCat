using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_FlyEnemy : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D _RBody;
    Rigidbody2D _PRBody;
    Animator EnAnim;
    public AudioSource audioSource;
    public float maxDistance = 35f;
    public float minDistance = 3f;


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
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= maxDistance)
        {
            audioSource.volume = 1f - (distance / maxDistance);

            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
        }
        // float distance = Vector2.Distance(transform.position, player.transform.position);

        // if (distance <= maxDistance)
        // {
        //     if (distance <= minDistance)
        //     {
        //         audioSource.volume = 1f; // Максимальная громкость внутри minDistance
        //     }
        //     else
        //     {
        //         // Плавное затухание от minDistance до maxDistance
        //         audioSource.volume = 1f - (distance - minDistance) / (maxDistance - minDistance);
        //     }

        //     if (!audioSource.isPlaying)
        //         audioSource.Play();
        // }
        // else
        // {
        //     if (audioSource.isPlaying)
        //         audioSource.Stop();
        // }
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
