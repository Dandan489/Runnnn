using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Diamanage : MonoBehaviour
{
    public Queue<string> sentences;
    public TextMeshProUGUI talk;
    public Animator ani;

    void Start()
    {
        ani.SetBool("IsOpen", false);
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogues dialogue)
    {
        FindObjectOfType<Gamemanager>().Pause();
        sentences.Clear();
        foreach (string a in dialogue.sentences)
        {
            sentences.Enqueue(a);
        }
        ani.SetBool("IsOpen", true);
        NextDialogue();
    }

    public void NextDialogue()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        talk.SetText(sentence);
    }

    public void EndDialogue()
    {
        ani.SetBool("IsOpen", false);
        FindObjectOfType<Gamemanager>().UnPause();
    }
}
