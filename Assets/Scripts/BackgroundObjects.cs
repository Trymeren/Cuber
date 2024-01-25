using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move(Vector3.up));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move(Vector3 direction)
    {
        for(float i = 0; i < 1.5f;)
        {
            i += Time.deltaTime;
            transform.Translate(direction * Time.deltaTime * Time.deltaTime);
        }
        yield return new WaitForSeconds(0);

        if(direction == Vector3.up)
        {
            StartCoroutine(Move(Vector3.down));
        }
        else if(direction == Vector3.down)
        {
            StartCoroutine(Move(Vector3.up));
        }
        
    }
}
