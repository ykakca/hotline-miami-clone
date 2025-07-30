using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegDirection : MonoBehaviour
{
    private Vector3 rotationVal;
    // Start is called before the first frame update
    void Start()
    {
        rotationVal = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) {
            rotationVal = new Vector3(0, 0, 45);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) {
            rotationVal = new Vector3(0, 0, 135);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) {
            rotationVal = new Vector3(0, 0, -45);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) {
            rotationVal = new Vector3(0, 0, -135);
        }
        else {
            if (Input.GetKey(KeyCode.W)) {
                rotationVal = new Vector3(0, 0, 90);
            }
            else if (Input.GetKey(KeyCode.S)){
                rotationVal = new Vector3(0, 0, 270);
            }
            else if (Input.GetKey(KeyCode.A)){
                rotationVal = new Vector3(0, 0, 180);
            }
            else if (Input.GetKey(KeyCode.D)){
                rotationVal = new Vector3(0, 0, 0);
            }
        }

        transform.eulerAngles = rotationVal;
    }
}



