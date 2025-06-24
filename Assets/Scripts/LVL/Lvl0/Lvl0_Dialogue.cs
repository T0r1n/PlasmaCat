using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Lvl0_Dialogue : MonoBehaviour
{
    public bool isFShoot = false;
    public NPCConversation StarterConversation;
    public NPCConversation d_FirstShoot;
    // Start is called before the first frame update
    void Start()
    {
        ConversationManager.Instance.StartConversation(StarterConversation);
    }


    // Update is called once per frame
    void Update()
    {
    if (!isFShoot && Input.GetKeyDown(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
        {
            ConversationManager.Instance.StartConversation(d_FirstShoot);
            isFShoot = true;
        }
    }
}
