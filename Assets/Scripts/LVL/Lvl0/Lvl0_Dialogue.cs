using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Lvl0_Dialogue : MonoBehaviour
{
    private CatScript catScript;
    public bool SkipStart = false;
    public bool isFShoot = false;
    public bool isFReload = false;
    private int previousAmmo;
    public NPCConversation StarterConversation;
    public NPCConversation d_FirstShoot;
    public NPCConversation d_FReload;
    public NPCConversation d_DoubJump;
    public NPCConversation d_EnemySpot;
    public NPCConversation d_FHeal;
    public NPCConversation d_BigJump;
    public NPCConversation d_LevelNext;


    private void Awake()
    {
        catScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CatScript>();
        previousAmmo = catScript.ammo;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!SkipStart)
        {
            ConversationManager.Instance.StartConversation(StarterConversation);
        }
            
    }


    // Update is called once per frame
    void Update()
    {
        if (!isFShoot && Input.GetKeyDown(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
        {
            ConversationManager.Instance.StartConversation(d_FirstShoot);
            isFShoot = true;
        }

        // Проверяем попытку выстрела при пустом магазине
        if (!isFReload && Input.GetKeyDown(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject() && catScript.ammo == 0 && previousAmmo == 0 && catScript.onGround == false)
        {
            ConversationManager.Instance.StartConversation(d_FReload);
            isFReload = true;
        }

        previousAmmo = catScript.ammo;
    }

    public void DoubJump_Trig()
    {
        ConversationManager.Instance.StartConversation(d_DoubJump);
    }

    public void EnemySpot_Trig()
    {
        ConversationManager.Instance.StartConversation(d_EnemySpot);
    }

    public void FHeal_Trig()
    {
        ConversationManager.Instance.StartConversation(d_FHeal);
    }

    public void BigJump_Trig()
    {
        ConversationManager.Instance.StartConversation(d_BigJump);
    }
    
    public void LevelNext_Trig()
    {
        ConversationManager.Instance.StartConversation(d_LevelNext);
    }
}
