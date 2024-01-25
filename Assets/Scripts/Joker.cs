using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Joker : Obstacle
{
    private float speedMultiplier = 1;
    [SerializeField] private float varyTime = 1;
    [SerializeField] private float varyRange = 3;
    [SerializeField] private float varyCut = 10;

    void Awake()
    {
        StartCoroutine(ChangeSpeed("start"));
    }

    override protected void DecideSpeed()
    {
        currentSpeed = speed * (1 + (float)GameObject.Find("Game Manager").GetComponent<GameManager>().score / 100) * speedMultiplier;
    }

    IEnumerator ChangeSpeed(string change)
    {
        float startTime = GameObject.Find("Game Manager").GetComponent<GameManager>().timer;
        for (float i = 0; i < varyTime;)
        {
            i += varyTime / varyCut;
            if(change == "plus")
            {
                speedMultiplier += varyRange / varyCut;
            }
            else if(change == "minus")
            {
                speedMultiplier -= varyRange / varyCut;
            }
            else if(change == "start")
            {
                speedMultiplier += varyRange / (varyCut * 2);
            }
            yield return new WaitForSeconds(varyTime / varyCut);
        }
        if(change == "plus")
            {
                StartCoroutine(ChangeSpeed("minus"));
            }
            else if(change == "minus")
            {
                StartCoroutine(ChangeSpeed("plus"));
            }
            else if(change == "start")
            {
                StartCoroutine(ChangeSpeed("minus"));
            }
    }
}
