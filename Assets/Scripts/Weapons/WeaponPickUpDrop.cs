using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUpDrop : MonoBehaviour
{
    public Player player;
    public AnimatePlayer animation;
    public Animator animator;
    public SpriteArrayController spriteArrays;
    public Rigidbody2D rb;
    public bool picked;
    public float pickUpRange;
    public Vector3 distanceToPlayer;
    
    public bool canPickUp = false;

    void Start()
    {
        player = FindObjectOfType<Player>();
        // player = GameObject.FindGameObjectWithTag("Player");
        animator = player.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        pickUpRange = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = player.transform.position - this.transform.position;
        if (!picked && distanceToPlayer.magnitude <= pickUpRange && Input.GetKey(KeyCode.Mouse1) && !player.hasWeapon) {
            PickUpWeapon();
        }
        else if (picked && Input.GetKey(KeyCode.Mouse1) && player.hasWeapon) {
            DropWeapon();
        }
        
        CheckWeaponName();
        DropWeapon();
    }

    private void OnTriggerStay2D(Collider2D other) 
    {   
        if (other.gameObject.CompareTag("Player")) {
            if (!player.hasWeapon) {
                if (Input.GetKey(KeyCode.Mouse1)) {
                    player.SetHasWeapon(true);              //
                    gameObject.SetActive(false);            //
                    player.SetWeaponName(gameObject.tag);   //
                    SetIsPicked(true);
                    picked = true;
                    rb.isKinematic = true;
                }
            }
        }
    }

    private void SetIsPicked(bool isPicked)
    {
        this.picked = isPicked;
    }

    private void WeaponPickedOrNot()
    {
        if (!picked && Input.GetKey(KeyCode.Mouse1) && !player.hasWeapon) {
            player.SetHasWeapon(true);
            player.SetWeaponName(gameObject.tag);
            gameObject.SetActive(false);
        }
        else if (picked && Input.GetKey(KeyCode.Space)) {
            
        }
    }

    private void PickUpOrDrop()
    {
        // Vector3 distanceToPlayer = player.position - transform.position;
        // if (distanceToPlayer.magnitude <= pickUpRange && )

        if (!player.hasWeapon && Input.GetKey(KeyCode.Mouse1)) {
            DropWeapon();
        }
    }


    private void PickUpWeapon()
    {
        player.SetHasWeapon(true);              
        gameObject.SetActive(false);            
        player.SetWeaponName(gameObject.tag);   
        SetIsPicked(true);
        rb.isKinematic = true;
    }

    private void DropWeapon()
    {
        if (picked) {
            if (Input.GetKey(KeyCode.Mouse1)) {
                player.SetHasWeapon(false);
                player.SetWeaponName("unarmed");
                this.gameObject.SetActive(true);
                SetIsPicked(false);
                rb.isKinematic = false;
                //rb.
                transform.position = player.transform.position;
                //animation.S
            }
            player.SetHasWeapon(false);
            gameObject.SetActive(true);
            player.SetWeaponName("unarmed");
            SetIsPicked(false);
            rb.isKinematic = false;
        }
    }
    private void CheckDropWeapon()
    {
        if (player.hasWeapon && Input.GetKey(KeyCode.Space)) {
            DropWeapon();
        }
    }

    

    private void CheckWeaponName()
    {
        if (player.pickedWeaponName == "unarmed") {
            animator.SetInteger("WeaponNum", 0);
        }
        else if (player.pickedWeaponName == "Axe") {
            animator.SetInteger("WeaponNum", 1);
        }
        else if (player.pickedWeaponName == "Uzi") {
            animator.SetInteger("WeaponNum", 2);
        }
        else if (player.pickedWeaponName == "M16") {
            animator.SetInteger("WeaponNum", 3);
        }
    }
}