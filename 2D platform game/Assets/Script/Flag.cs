using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private bool already=false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (already == false)
        {
            FindObjectOfType<DiaTrigger>().TriggerDialogue();
            already = true;
        }
    }
}
