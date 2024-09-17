using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaTrigger : MonoBehaviour
{
    public Dialogues dia;
    public void TriggerDialogue()
    {
        FindObjectOfType<Diamanage>().StartDialogue(dia);
    }
}
