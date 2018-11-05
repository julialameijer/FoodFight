using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    [Header("Player speed & Jumpheight")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    public KeyCode kick;
    public KeyCode punch;
    public KeyCode specialAttack;

    private Player player;
    private bool isGrounded;
    public bool walkBool;
    private bool isLeft;
    private bool isRight;
    private SpriteRenderer Srenderer;

    // Use this for initialization
    void Start () {
        player = GetComponentInChildren<Player>();
        Srenderer = this.gameObject.GetComponent<SpriteRenderer>();
        isGrounded = true;

        if (this.gameObject.CompareTag("Player1"))
        {
            isLeft = true;
        }

        if (this.gameObject.CompareTag("Player2"))
        {
            isRight = true;
        }

        if (isRight)
        {
            this.transform.localScale = new Vector3(-0.35f, transform.localScale.y, transform.localScale.z);
            left = KeyCode.LeftArrow;
            right = KeyCode.RightArrow;
            jump = KeyCode.UpArrow;
            kick = KeyCode.Alpha9;
            punch = KeyCode.Alpha0;
            specialAttack = KeyCode.Slash;
        }
        if (isLeft)
        {
            this.Srenderer.flipX = false;
            left = KeyCode.A;
            right = KeyCode.D;
            jump = KeyCode.W;
            kick = KeyCode.Alpha6;
            punch = KeyCode.Alpha7;
            specialAttack = KeyCode.LeftShift;
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

        //Movement
        walkBool = Input.GetKey(left);
        walkBool = Input.GetKey(right);

        if (Input.GetKey(left) && isLeft)
        {
            walkBool = true;
            Srenderer.flipX = true;
        }
        else if (Input.GetKey(right) && isLeft)
        {
            walkBool = true;
            Srenderer.flipX = false;
        }
        else if(Input.GetKey(left) && isRight)
        {
            walkBool = true;
            Srenderer.flipX = false;
        }
        else if (Input.GetKey(right) && isRight)
        {
            walkBool = true;
            Srenderer.flipX = true;
        }
        else
        {
            walkBool = false;
        }

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
