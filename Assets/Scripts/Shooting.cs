using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public Player player;
    public bool canFire;
    public int magazineCapacity;
    public float firingCooldown;
    private float timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canFire) {
            timer += Time.deltaTime;
            if (timer >= firingCooldown) {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && canFire) {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }

    private void CheckWeaponType() 
    {
        //if player is unarmed
        if (player.pickedWeaponName == "M16") {
            firingCooldown = 0.3f;
        }
        else if (player.pickedWeaponName == "Uzi") {
            firingCooldown = 0.1f;
        }
        else if (player.pickedWeaponName == "Axe") {
            firingCooldown = 0.6f;
        }
        else {
            firingCooldown = 15.0f;
        }
    }
}
