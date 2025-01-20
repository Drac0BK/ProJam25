using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    Rigidbody rb;
    public float movementSpeed = 7.0f;
    Vector3 move = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Forward");
            move += Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Back");
            move += Vector3.back;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Right");
            move += Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Left");
            move += Vector3.left;
        }

        rb.MovePosition((Vector3)transform.position + move * Time.deltaTime * movementSpeed);
        //move = Vector3.zero;
    }
}
