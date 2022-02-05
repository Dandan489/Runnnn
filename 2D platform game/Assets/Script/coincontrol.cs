using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coincontrol : MonoBehaviour
{
    bool first = true;
    public GameObject coin;
    Vector3 a;

    public void Reset()
    {
        if (first)
        {
            a = coin.transform.position;
            first = false;
        }
        else
        {
            coin.transform.position = a;
            coin.SetActive(true);
        }
    }
}
