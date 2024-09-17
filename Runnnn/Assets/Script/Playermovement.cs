using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float speed = 10f;
    public float movedire = 0f;
    public float jumpforce = 10f;
    public bool grounded = true;
    public bool canmove = true;
    public Rigidbody2D rigi;
    public Transform player;
    public GameObject cam;
    public Animator ani;
    Vector3 movement;
    Vector3 pos;

    private void Start()
    {
        player.transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (GameValue.have_boot)
            speed = 12f;
        float tmp = Input.GetAxisRaw("Horizontal");
        movement = new Vector3(tmp, 0f, 0f);
        if (tmp == 1 && canmove)
        {
            ani.SetBool("isRunning", true);
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (tmp == -1 && canmove)
        {
            ani.SetBool("isRunning", true);
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            ani.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate()
    {
        if (canmove)
        {
            Jump();
            transform.position += movement * speed * Time.fixedDeltaTime;
        }
        
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && grounded){
            //Debug.Log("Jump!");
            ani.SetBool("isJumping", true);
            Vector2 jump = new Vector2(0f, jumpforce);
            rigi.AddForce(jump, ForceMode2D.Impulse);
            grounded = false;
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 validDirection = Vector3.up;
        float contactThreshold = 30;

        if (collision.collider.tag == "Water")
        {
            Debug.Log("I die");
            canmove = false;
            cam.GetComponent<Gamemanager>().Die();
        }

        if (collision.collider.tag == "Ground")
        {
            for (int k = 0; k < collision.contacts.Length; k++)
            {
                if (Vector3.Angle(collision.contacts[k].normal, validDirection) <= contactThreshold)
                {
                    grounded = true;
                    ani.SetBool("isJumping", false);
                    break;
                }
            }
        }

        if (collision.collider.tag == "Chest")
        {
            Debug.Log("I win");
            canmove = false;
            cam.GetComponent<Gamemanager>().Win();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("I die");
            canmove = false;
            cam.GetComponent<Gamemanager>().Die();
        }

        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("I pick");
            collision.gameObject.SetActive(false);
            collision.transform.position = new Vector3(-100f, -100f, -100f);
            cam.GetComponent<Gamemanager>().coinc++;
        }

        if (collision.gameObject.tag == "flag")
        {
            Debug.Log("I pick");
            pos = collision.transform.position;
        }
    }

    public void Reset()
    {

        player.transform.position = new Vector3(0, 0, 0);
        pos = new Vector3(0, 0, 0);
        canmove = true;

    }

    public void Respawn()
    {
        player.transform.position = pos;
        canmove = true;
    }
}
