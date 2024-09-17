using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatScript : MonoBehaviour
{
    public int damage;
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    Rigidbody2D rb;
    SpriteRenderer sr;
    SpriteRenderer wsr;
    public float offset;

    public GameObject Weapon;
    public GameObject GCheck;
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public GameObject impactEffect;
    GameObject impactEffectClone;
    Animator anim;
    Animator animG;

    public GameObject healEffect;
    GameObject healEffectClone;

    public bool onGround;
    public Transform GroundCheck;
    public BoxCollider2D GCCollider;
    public LayerMask Ground;

    public float thrust = 1f;
    public int ammo = 2;
    bool ss = true;
    public float sstime = 0.3f;

    public levelChanger LChen;

    bool shootfix;

    [SerializeField] private AudioSource ShotAudio;
    [SerializeField] private AudioSource FalseShotAudio;
    [SerializeField] private AudioSource DeathAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        wsr = Weapon.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        animG = Weapon.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        anim.SetBool("inAir", onGround);
        onButtonDown();
        CheckingGround();
        CatRotate(difference);
        Impuls(difference);

    }

    public void Impuls(Vector3 dif)
    {
        Vector2 Dir = Vector3.ClampMagnitude(dif, 1);


        if (Input.GetKeyDown(KeyCode.Mouse0) && (ammo > 0) && (ss == true) && (health > 0))
        {
            ShotAudio.Play();
            ammo -= 1;
            animG.SetInteger("am", ammo);
            rb.AddForce(-Dir.normalized * thrust, ForceMode2D.Impulse);
            Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && (ammo == 0) && (ss == true))
        {
            FalseShotAudio.Play();
        }
    }

    public void CatRotate(Vector3 dif)
    {
        

        float rotateZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        Weapon.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        Vector3 ChScale = transform.localScale;
        if (rotateZ > 90 || rotateZ < -90)
        {
            sr.flipX = true;
            wsr.flipY = true;
        }
        else
        {
            sr.flipX = false;
            wsr.flipY = false;
        }
        transform.localScale = ChScale;
    }

    public void Shoot()
    {
        shootfix = false;
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        if (hitInfo)
        {
            StartCoroutine(IMPeffect(hitInfo));

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);

            Target health = hitInfo.collider.GetComponent<Target>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100 );
        }
        StartCoroutine(Line());
    }

    IEnumerator Line()
    {
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.02f);
        lineRenderer.enabled = false;

        ss = false;
        yield return new WaitForSeconds(sstime);
        ss = true;
        shootfix = true;
    }


    IEnumerator IMPeffect(RaycastHit2D info)
    {
        impactEffectClone = Instantiate(impactEffect, info.point, Quaternion.identity);
        yield return new WaitForSeconds(0.21f);
        Destroy(impactEffectClone);
    }

    public IEnumerator Healing(int heal)
    {
        health += heal;

        healEffectClone = Instantiate(healEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.31f);
        Destroy(healEffectClone);
    }

    public IEnumerator TakingDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            anim.Play("take_damage");
            anim.SetInteger("hp", health);
            if (health <= 0)
            {
                DeathAudio.Play();
                wsr.enabled = false;
                yield return new WaitForSeconds(1f);
                LChen.levelReload();
            }
        }
    }


    public void onButtonDown()
    {
        if ((onGround == true) & (Input.GetKeyDown(KeyCode.R)) & (shootfix != false))
        {
            ammo = 2;
            animG.SetInteger("am", ammo);
        }
    }

    void CheckingGround()
    {
        onGround = Physics2D.OverlapBox(GroundCheck.position, GCCollider.size ,0, Ground);

        if ((onGround == true) & (ammo == 0) & (shootfix == true))
        {
            ammo = 2;
            animG.SetInteger("am", ammo);
        }
    }


    void FixedUpdate()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "badPlatform")
        {
            //gameObject.SetActive(false);
            LChen.levelReload();
        }
    }
}


