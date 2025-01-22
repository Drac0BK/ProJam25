using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    Rigidbody rb;
    public float movementSpeed = 3.0f;
    Vector3 movement = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        readInput();   
    }

    void characterMovement(Vector3 move)
    {
        rb.MovePosition((Vector3)transform.position + move * Time.deltaTime * movementSpeed * 2);
    }

    void readInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("f");
            movement.z = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement.z = -1;
        }
        else if (!Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.W))
        {
            movement.z = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("r");
            movement.x = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("l");
            movement.x = -1;
        }
        else if (!Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.A))
        {
            movement.x = 0;
        }
        Debug.Log(movement);
        characterMovement(movement);
    }
}
