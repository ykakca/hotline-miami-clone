using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Vector3 cursorPos;
    public GameObject playerObj;
    public Player playerMovement;
    public bool followPlayer = true;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerMovement = playerObj.GetComponent<Player>();
    }

    void Update()
    {
        cursorPos = (Vector3)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if (Input.GetKey(KeyCode.LeftShift)) {
            followPlayer = false;
            playerMovement.SetIsMoving(false);
        }
        else {
            followPlayer = true;
        }

        if (followPlayer) {
            CamFollowPlayer();
        }
        else {
            LookFurther();
        }
    }

    public void SetFollowPlayer(bool val)
    {
        followPlayer = val;
    }

    void CamFollowPlayer()
    {
        Vector3 newPos = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y, this.transform.position.z);
        this.transform.position = newPos;
    }

    void LookFurther()
    {
        //Vector3 cameraPos = cam.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        cursorPos.z = -10;
        Vector3 dir = cursorPos;
        //if (playerObj.GetComponent<SpriteRenderer>().isVisible) {
            transform.Translate(dir*5*Time.deltaTime);
        //}
    }
}
