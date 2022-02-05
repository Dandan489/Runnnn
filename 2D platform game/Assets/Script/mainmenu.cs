using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mainmenu : MonoBehaviour
{
    public GameObject set;
    public GameObject rule;
    public GameObject rule2;
    public GameObject main;
    public TMP_Text bt;
    public AudioSource audi;
    public GameObject music_player;
    private float btf;

    private void Start()
    {
        main.SetActive(true);
        set.SetActive(false);
        rule.SetActive(false);
        rule2.SetActive(false);
        btf = GameValue.best_time;
        Debug.Log(btf);
        if (btf==0)
            bt.text = "Best Time: NONE";
        else
            bt.text = "Best Time: " + btf.ToString("f1");
    }
    public void Quit()
    {
        Debug.Log("i quit");
        Application.Quit();
    }

    public void Setting()
    {
        main.SetActive(false);
        set.SetActive(true);
    }

    public void Rule()
    {
        main.SetActive(false);
        rule.SetActive(true);
    }

    public void Rule2()
    {
        rule.SetActive(false);
        rule2.SetActive(true);
    }

    public void Continue()
    {
        GameValue.music_time = audi.time;
        Debug.Log(GameValue.music_time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Mainn()
    {
        GameValue.music_time = audi.time;
        Debug.Log(GameValue.music_time);
        SceneManager.LoadScene(0);
    }

    public void Back()
    {
        main.SetActive(true);
        set.SetActive(false);
    }
}
