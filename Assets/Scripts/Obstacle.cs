using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float currentSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        DecideSpeed();
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * currentSpeed);

        //Destroy when out of bounds
        if(transform.position.x < -5)
        {
            Destroy(gameObject);
        }
    }

    virtual protected void DecideSpeed()
    {
        currentSpeed = speed * (1 + (float)GameObject.Find("Game Manager").GetComponent<GameManager>().score / 100);
    }
}
