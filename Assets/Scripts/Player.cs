using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    Animator animator;
    PlayerMovement pm;
    public bool jumpBool;
    public bool idleBool;
    public bool kickBool;
    public bool punchBool;
    public bool specialAttackBool;
    private bool isPlayer1;
    private float health;
    private List<GameObject> childs;
    private SpriteRenderer Srenderer;
    [SerializeField] private float damageStrength;
    [SerializeField] private float playerHealth;



    // Use this for initialization
    void Start()
    {
        pm = GetComponentInParent<PlayerMovement>();
        animator = this.gameObject.GetComponent<Animator>();
        Srenderer = this.gameObject.GetComponent<SpriteRenderer>();
        jumpBool = false;
        idleBool = false;

        health = 100;

        childs = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        setAnimations();
        addColliders();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.CompareTag("Player1"))
        {
            if (other.gameObject.CompareTag("Player2"))
            {
                this.damage(false);
            }
        }
        if (this.gameObject.CompareTag("Player2"))
        {
            if (other.gameObject.CompareTag("Player1"))
            {
                this.damage(false);
            }
        }
    }

    void setAnimations()
    {
        kickBool = Input.GetKey(pm.kick);
        punchBool = Input.GetKey(pm.punch);
        specialAttackBool = Input.GetKey(pm.specialAttack);
        jumpBool = Input.GetKey(pm.jump);

        print(pm.walkBool);

        animator.SetBool("Kick", kickBool);
        animator.SetBool("Punch", punchBool);
        animator.SetBool("Jump", jumpBool);
        animator.SetBool("Idle", idleBool);
        animator.SetBool("Walk", pm.walkBool);
    }
    
    void addColliders()
    {
        for(int i = 0; i< transform.childCount; i++)
        {
            childs.Add(transform.GetChild(i).gameObject);
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("_PlayerKick"))
        { 
           childs[1].GetComponent<Collider2D>().enabled = true;
        }
        else if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("_PlayerPunch"))
        {
            childs[0].GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            childs[1].GetComponent<Collider2D>().enabled = false;
            childs[0].GetComponent<Collider2D>().enabled = false;
        }
    }

    
    void damage(bool isSpecialAttack)
    {
        if (isSpecialAttack)
        {
            health -= 35;
        }
        else
        {
            health -= 10;
        }

        print(health);
       
    }

}
