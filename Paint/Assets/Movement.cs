using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    const int GROUND_LEVEL_Y = 1;

    const int RUN_SPEED = 3;

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
            transform.Translate(Vector2.left * Time.deltaTime * RUN_SPEED);
        }
        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            transform.Translate(Vector2.right * Time.deltaTime * RUN_SPEED);
        }
        else if (onLadder)
        {
            if (Input.GetKey("w") || Input.GetKey("up"))
            {
                transform.Translate(Vector2.up * Time.deltaTime * RUN_SPEED);
            }
            else if ((Input.GetKey("s") || Input.GetKey("down")) && transform.position.y > GROUND_LEVEL_Y)
            {
                transform.Translate(Vector2.down * Time.deltaTime * RUN_SPEED);
            }
        }

        if (!onLadder && transform.position.y > GROUND_LEVEL_Y)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 5);
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
