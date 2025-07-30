using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    public Player player;
    public SpriteArrayController spriteArrays;
    public SpriteRenderer srLegs, srTorso;
    public Sprite[] spriteLegs, spriteUnarmed, spriteTempArr, spriteTempAttack;
    public int legCounter = 0, walkCounter = 0, attackCounter = 0;
    public float legTimer = 0.05f, walkTimer = 0.1f, attackTimer = 0.05f;

    void Start()
    {
        spriteLegs = spriteArrays.GetSpriteLegs();
        spriteUnarmed = spriteArrays.GetSpriteUnarmed();
        srTorso.sprite = spriteUnarmed[0];
        
    }

    void Update()
    {
        AnimateLegs();
        //AnimateWalk();
        //AnimateBody();
    }

    private void AnimateLegs()
    {
        if (player.isMoving) {
            srLegs.sprite = spriteLegs[legCounter];
            legTimer -= Time.deltaTime;
            if (legTimer <= 0) {
                if (legCounter < spriteLegs.Length-1) {
                    legCounter++;
                }
                else {
                    legCounter = 0;
                }
                legTimer = 0.05f;
            }
        }
        else {
            srLegs.sprite = spriteLegs[0];
        }
    }
/*
    private void AnimateUnarmedWalk()
    {
        if (player.isMoving) {
            srTorso.sprite = spriteUnarmed[unarmedCounter];
            unarmedTimer -= Time.deltaTime;
            if (unarmedTimer <= 0) {
                if (unarmedCounter < spriteUnarmed.Length-1) {
                    unarmedCounter++;
                }
                else {
                    unarmedCounter = 0;
                }
                unarmedTimer = 0.1f;
            }            
        }
        else {
            srTorso.sprite = spriteUnarmed[0];
        }
    }
    */
    
    // CODE BELOW IS REDUNDANT!!!

    /*

    private void AnimateWalk()
    {
        if (player.isMoving) {
            switch (player.pickedWeaponName)
            {
                case "Axe":
                    spriteTempArr = spriteArrays.spriteWalkWithAxe;
                    break;
                case "Uzi":
                    spriteTempArr = spriteArrays.spriteWalkWithUzi;
                    break;
                case "unarmed":
                    spriteTempArr = spriteUnarmed;
                    break;
                default:
                    break;
            }

            srTorso.sprite = spriteTempArr[walkCounter];
            walkTimer -= Time.deltaTime;
            if (walkTimer <= 0) {
                if (walkCounter < spriteTempArr.Length-1) {
                    walkCounter++;
                }
                else {
                    walkCounter = 0;
                }
                walkTimer = 0.1f;
            }            
        }
        else {
            //srTorso.sprite = spriteTempArr[0];
        }
    }
/*
    private void MeleeAttack()
    {
        switch (player.pickedWeaponName)
        {
            case "unarmed":
                spriteTempAttack = spriteArrays.spritePunch;
                break;            
            case "Axe":
                spriteTempAttack = spriteArrays.spriteAttackWithAxe;
                break;
            default:
                spriteTempAttack = spriteArrays.spritePunch;
                break;
        }

    }
*/
    /*
    private void AnimateBody()
    {
        switch (player.pickedWeaponName)
            {
                case "Axe":
                    spriteTempAttack = spriteArrays.spriteAttackWithAxe;
                    break;
                case "Uzi":
                    spriteTempAttack = spriteArrays.spriteAttackWithUzi;
                    break;
                case "unarmed":
                    spriteTempAttack = spriteArrays.spritePunch;
                    break;
                default:
                    break;
            }

        if (Input.GetKey(KeyCode.Mouse0)) {
            srTorso.sprite = spriteTempAttack[attackCounter];
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0) {
                if (attackCounter < spriteTempAttack.Length-1) {
                    attackCounter++;
                }
                else {
                    attackCounter = 0;
                }
                attackTimer = 0.05f;
            }
            //attackCounter = 0;
            //attackTimer = 1.0f;
        }
        else {
            AnimateWalk();
            //srTorso.sprite = spriteTempArr[0];
        }
    }

    */

}
