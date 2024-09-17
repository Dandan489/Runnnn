using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camcontrol : MonoBehaviour
{
    public Transform player;
    public Transform cam;
    Vector3 pla;

    // Start is called before the first frame update
    void Start()
    {
        pla = new Vector3(player.position.x, player.position.y + 5, -10);
        cam.position = pla;
    }

    // Update is called once per frame
    void Update()
    {
        pla = new Vector3 (player.position.x, pla.y, -10);
        cam.position = pla;
    }
}
