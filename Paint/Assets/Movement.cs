using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            transform.Translate(Vector2.left * Time.deltaTime);
        }
        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            transform.Translate(Vector2.right * Time.deltaTime);
        }
    }
}
