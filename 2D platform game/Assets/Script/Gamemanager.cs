using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    public GameObject repan;
    public GameObject winpan;
    public GameObject player;
    public GameObject tepa;
    public GameObject menu;
    public GameObject shop;
    public GameObject settings;
    public GameObject boots;
    public Text cotext;
    public Text titext;
    public TMP_Text fin;
    public AudioSource audi;
    public int coinc=0;
    public float ctime;
    public float timepool = 0;
    public bool stop = false;
    private int stopcount = 0;
    GameObject[] coins;
    // Start is called before the first frame update
    void Start()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
        Debug.Log(coins[0].transform.position);
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        cotext.text =  ""+coinc;
        if (!stop)
        {
            float t = Time.time - ctime + timepool;
            titext.text = t.ToString("f1");
        }
        
    }

    public void Die()
    {
        Debug.Log("Reset");
        tepa.SetActive(false);
        repan.SetActive(true);
        timepool += Time.time - ctime;
        ctime = Time.time;
    }

    public void Reset()
    {
        ctime = Time.time;
        timepool = 0;
        stopcount = 1;
        menu.SetActive(false);
        shop.SetActive(false);
        repan.SetActive(false);
        winpan.SetActive(false);
        tepa.SetActive(true);
        GameValue.have_boot = false;
        boots.SetActive(true);
        player.GetComponent<Playermovement>().Reset();
        Debug.Log("coin go home");
        foreach (GameObject coin in coins)
        {
            Debug.Log("coin goto home");
            coin.GetComponent<coincontrol>().Reset();
        }
        coinc = 0;
        UnPause();
    }

    public void Respawn()
    {
        ctime = Time.time;
        menu.SetActive(false);
        repan.SetActive(false);
        shop.SetActive(false);
        winpan.SetActive(false);
        tepa.SetActive(true);
        player.GetComponent<Playermovement>().Respawn();
    }

    public void Win()
    {
        Debug.Log("Win");
        float t = Time.time - ctime + timepool;
        float b = GameValue.best_time;
        if (t < b || b==0)
            GameValue.best_time = t;
        Debug.Log(b);
        fin.text = "Final Time: " + t.ToString("f1");
        winpan.SetActive(true);
        tepa.SetActive(false);
    }
    public void Continue()
    {
        GameValue.music_time = audi.time;
        Debug.Log(GameValue.music_time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Menu()
    {
        menu.SetActive(true);
        Pause();
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        UnPause();
    }

    public void MainMenu()
    {
        GameValue.music_time = audi.time;
        SceneManager.LoadScene(0);
    }

    public void OpenShop()
    {
        shop.SetActive(true);
        menu.SetActive(false);
    }

    public void CloseShop()
    {
        shop.SetActive(false);
        menu.SetActive(true);
    }
    public void OpenSetting()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void CloseSetting()
    {
        settings.SetActive(false);
        menu.SetActive(true);
    }

    public void Buy_boots()
    {
        if (!GameValue.have_boot && coinc>=4)
        {
            boots.SetActive(false);
            GameValue.have_boot = true;
            coinc -= 4;
        }
        
    }

    public void Pause()
    {
        Debug.Log(stopcount);
        stopcount++;
        if (!stop)
        {
            player.GetComponent<Playermovement>().canmove = false;
            stop = true;
            timepool += Time.time - ctime;
        }
    }

    public void UnPause()
    {
        Debug.Log(stopcount);
        stopcount--;
        if (stop && stopcount==0)
        {
            player.GetComponent<Playermovement>().canmove = true;
            stop = false;
            ctime = Time.time;
        }
    }
}
