using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MM_Script : MonoBehaviour
{
    public Animator anim;
    [SerializeField] private AudioSource FX;

    void Start()
    {

    }

    public void clickPlay()
    {
        FX.Play();
        anim.SetTrigger("BTrigger");
    }

    public void clickOpt()
    {
        FX.Play();
        anim.SetTrigger("OTrigger");
    }

    public void clickExit()
    {
        FX.Play();
        Application.Quit();
    }

    public void clickLevel()
    {
        FX.Play();
    }
}
