using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    Rigidbody rb;
    public float movementSpeed = 3.0f;
    public GameObject lastCheck;
    Vector3 movement = Vector3.zero;
    bool isCaptured = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void SetCheckpoint(GameObject m_check) { lastCheck = m_check; }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isCaptured)
        {
            readInput();
        }

        if (Input.GetKey(KeyCode.P))
        {
            StartCoroutine("capturedPlayer");
        }
    }

    void characterMovement(Vector3 move)
    {
        rb.MovePosition((Vector3)transform.position + move * Time.deltaTime * movementSpeed * 2);
    }

    void readInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
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
            movement.x = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1;
        }
        else if (!Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.A))
        {
            movement.x = 0;
        }
        characterMovement(movement);
    }

    public IEnumerator capturedPlayer()
    {
        isCaptured = true;
        yield return new WaitForSeconds(1);
        if (lastCheck != null)
            transform.position = lastCheck.transform.position + new Vector3(0, 0.5f, 0);
        else
            transform.position = new Vector3(0,1,0);
        isCaptured = false;

    }
}
