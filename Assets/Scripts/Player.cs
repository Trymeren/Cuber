using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private int jumps;
    private int jumpsMax = 2;
    [SerializeField] private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(jumps > 0)
            {
                rb.velocity = Vector3.up * jumpForce;
                jumps -= 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().gameOver = true;
        }

        if(other.CompareTag("Ground"))
        {
            jumps = jumpsMax;
        }
    }
}
