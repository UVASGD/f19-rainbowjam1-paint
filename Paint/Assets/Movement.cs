using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    const int GROUND_LEVEL_Y = 1;

    bool onLadder = false;

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
        else if (onLadder)
        {
            if (Input.GetKey("w") || Input.GetKey("up"))
            {
                transform.Translate(Vector2.up * Time.deltaTime);
            }
            else if ((Input.GetKey("s") || Input.GetKey("down")) && transform.position.y > GROUND_LEVEL_Y)
            {
                transform.Translate(Vector2.down * Time.deltaTime);
            }
        }

        if (!onLadder && transform.position.y > GROUND_LEVEL_Y)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onLadder = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        onLadder = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onLadder = false;
    }
}
