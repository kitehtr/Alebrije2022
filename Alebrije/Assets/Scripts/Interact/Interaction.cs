using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Interaction : MonoBehaviour
{

    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public TextMeshProUGUI text;

    // Update is called once per frame

    private void start()
    {
        text.gameObject.SetActive(false);
    }
    void Update()
    {
        if(isInRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            text.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            text.gameObject.SetActive(false);
        }

    }
}
