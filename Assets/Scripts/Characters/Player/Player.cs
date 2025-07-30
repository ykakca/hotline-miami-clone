using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AnimatePlayer anim;
    public Animator animator;
    public bool isMoving;
    public float speed = 7.0f;
    public bool hasWeapon = false;
    public bool isAttacking;
    public bool nearWeapon;
    public string pickedWeaponName = "unarmed";
    private Rigidbody2D r2d;
    //private AnimatedSprite animator;
    private Vector2 moveDirection;

    private void Awake()
    {
        r2d = GetComponent<Rigidbody2D>();
        //animator = GetComponent<AnimatedSprite>();
    }

    void Start()
    {
        anim = FindObjectOfType<AnimatePlayer>();
    }

    void Update()
    {
        //Movement();
        //AnimateWhenMoving();
        ProcessInputs();
        CheckIsMoving();
        CheckIsAttacking();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void ProcessInputs()
    {
        float moveAlongX = Input.GetAxisRaw("Horizontal");
        float moveAlongY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveAlongX, moveAlongY); //todo
    }

    void Movement()
    {
        r2d.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    public void SetIsMoving(bool moving)
    {
        this.isMoving = moving;
    }

    public void CheckIsMoving() 
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
            SetIsMoving(true);
            animator.SetFloat("Speed", 1);
        }
        else {
            SetIsMoving(false);
            animator.SetFloat("Speed", 0);
        }
    }

    public void SetIsAttacking(bool attacking) 
    {
        this.isAttacking = attacking;
    }

    public void CheckIsAttacking() 
    {
        if (Input.GetKey(KeyCode.Mouse0)) {
            SetIsAttacking(true);
        }
        else {
            SetIsAttacking(false);
            //anim.
        }
    }

    public void SetHasWeapon(bool armed)
    {
        this.hasWeapon = armed;
    }

    public void SetWeaponName(string name) 
    {
        if (hasWeapon) {
            this.pickedWeaponName = name;
        } 
        else {
            this.pickedWeaponName = "unarmed";
        }
    }
/*
    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Weapon")) {
            if (Input.GetKey(KeyCode.Mouse1)) {
                if (hasWeapon) {
                    var weapon : GameObject = GameObject.Find(pickedWeaponName);
                    weapon.SetActive(true);
                    SetHasWeapon(false);
                    SetWeaponName("unarmed");
                }
            }
        }
    }
/*
    public void DropWeapon()
    {
        var weapon : GameObject = GameObject.Find(pickedWeaponName);
        weapon.SetActive(true);
        SetHasWeapon(false);
        SetWeaponName("unarmed");
    }
*/
    
/*
    public void DropWeapon()
    {
        if (hasWeapon) {
            if (Input.GetKey(KeyCode.Mouse1)) {

            }
        }
    }
    */
}

