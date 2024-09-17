using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformcon : MonoBehaviour
{
    public GameObject plat;
    Vector3 a;
    public float dire=1;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        a = plat.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(dire, 0f, 0f);
        transform.position += movement * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "goba")
        {
            if (dire == 1)
                dire = -1;
            else
                dire = 1;
        }
    }
}
