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
    private List<GameObject> childs;
    [SerializeField] private float damageStrength;
    [SerializeField] private float playerHealth;



    // Use this for initialization
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        pm = GetComponentInParent<PlayerMovement>();
        jumpBool = false;
        idleBool = false;
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
                this.damage();
            }
        }
        if (this.gameObject.CompareTag("Player2"))
        {
            if (other.gameObject.CompareTag("Player1"))
            {
                this.damage();
            }
        }
    }

    void setAnimations()
    {
        kickBool = Input.GetKey(pm.kick);
        punchBool = Input.GetKey(pm.punch);
        specialAttackBool = Input.GetKey(pm.specialAttack);
        jumpBool = Input.GetKey(pm.jump);

        animator.SetBool("Kick", kickBool);
        animator.SetBool("Punch", punchBool);
        //animator.SetBool("SpecialAttack", specialAttackBool);
        animator.SetBool("Jump", jumpBool);
        animator.SetBool("Idle", idleBool);
    }
    
    void addColliders()
    {
        for(int i = 0; i< transform.childCount; i++)
        {
            childs.Add(transform.GetChild(i).gameObject);
            print(childs[i] + " " + i);
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

    
    void damage()
    {

        print("autsj!");

    }

}
