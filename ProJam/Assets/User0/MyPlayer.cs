using System;
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
    public Material Seethrough;
    public Material normalMaterial;
    public bool normal = false;
    public bool isTransformed = false;
    bool isInteracting = false;
    MeshRenderer mesh;
    public List<Sprite> trojanPics;
    public List<Sprite> phishPics;
    public 
    float trojanF = 3;
    float phishF = 3;
    public GameObject sprite;
    float timer = 0;
    bool isPlaying = true;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
    }

    public void powerUpGot(int value) 
    { 
        if (value == 0) trojanF++;
        else if (value == 1) phishF++;
    }

    
    public void SetCheckpoint(GameObject m_check) { lastCheck = m_check; }

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0, 90, 0);
            rb.rotation = transform.rotation;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(0, -90, 0);
            rb.rotation = transform.rotation;
        }

    }

    void FixedUpdate()
    {
        if (!isCaptured)
        {
            readInput();
        }

        //if (Input.GetKey(KeyCode.P))
        //{
        //    StartCoroutine("capturedPlayer");
        //}
        if (Input.GetKey(KeyCode.T))
        {
            StartCoroutine("transformPlayer");
        }
        if(isPlaying) timer += Time.deltaTime;

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Interact>() != null && Input.GetKey(KeyCode.F) && !isInteracting)
        {
            other.GetComponent<Interact>().setCanvas(true);
            isInteracting = true;
        }
        else
        {
            mesh.material = normalMaterial;
            isInteracting = false;
        }
    }

    //public bool getInteracting() { return isInteracting; }
    //public void setInteracting(bool set) {  isInteracting = set; }

    void characterMovement(Vector3 move)
    {
        rb.MovePosition((Vector3)transform.position + (rb.rotation*move) * Time.deltaTime * movementSpeed * 2);
    }

    void readInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movement.z = Vector3.forward.z;
            
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movement.z = Vector3.back.z;
        }
        else if (!Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.W))
        {
            movement.z = 0;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = Vector3.right.x;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = Vector3.left.x;
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
    public IEnumerator transformPlayer()
    {

        isTransformed = true;
        normal = false;
        if(isTransformed)
        {
            trojanF--;
            transform.tag = "Untagged";
            sprite.SetActive(true);
        }

        mesh.material = Seethrough;


        yield return new WaitForSeconds(5);
        
        mesh.material = normalMaterial;
        transform.tag = "Player";

        isTransformed = false;
        normal = true;
        sprite.SetActive(false);

    }

    public float SetIsPlaying(bool v)
    {
        isPlaying = v;
        return timer;
    }
}
