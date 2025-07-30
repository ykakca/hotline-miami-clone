using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private Player playerMovement;
    private float mod = 0.1f;
    private float zVal = 0.0f;

    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (playerMovement.isMoving) {
            Vector3 rotation = new Vector3(0, 0, zVal);
            this.transform.eulerAngles = rotation;
            zVal += mod;

            if (transform.eulerAngles.z >= 5.0f && transform.eulerAngles.z < 10.0f) {
                mod = -0.1f;
            }
            else if (transform.eulerAngles.z < 355.0f && transform.eulerAngles.z  > 350.0f) {
                mod = 0.1f;
            }
        }   
    }   
}
