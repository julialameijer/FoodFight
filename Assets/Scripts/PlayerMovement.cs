using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    [Header("Player speed & Jumpheight")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;

    [Header("Player movement")]
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] public KeyCode jump;

    [Header("Player abilities")]
    [SerializeField] public KeyCode kick;
    [SerializeField] public KeyCode punch;
    [SerializeField] public KeyCode specialAttack;

    private Player player;
    private bool isGrounded;
    private SpriteRenderer Srenderer;

    // Use this for initialization
    void Start () {
        player = GetComponentInChildren<Player>();
        Srenderer = this.gameObject.GetComponent<SpriteRenderer>();
        isGrounded = true;

        if (this.gameObject.CompareTag("Player2"))
        {
            this.Srenderer.flipX = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Floor")
        {
            isGrounded = true;
            player.idleBool = true;
        }
    }


    // Update is called once per frame
    void Update () {
        //print(isGrounded);

        //Movement
        if (Input.GetKey(right))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(left))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);  
        }
        if (Input.GetKey(jump) && isGrounded)
        {
            player.idleBool = false;
            transform.Translate(Vector3.up * Time.deltaTime * jumpHeight);
            isGrounded = false;

        }

    }
    
}
