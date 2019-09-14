using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public const int GROUND_LEVEL_Y = 1;

    const int RUN_SPEED = 3;

    bool onLadder = false;
    public GameObject playerPrefab;
    List<GameObject> players = new List<GameObject>();
    List<Rigidbody2D> bodys = new List<Rigidbody2D>();

    void Start()
    {
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player")){
            players.Add (player);
            Rigidbody2D r = player.GetComponent<Rigidbody2D>();
            bodys.Add(r);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a")) //player 1 left
        {
            bodys[0].velocity = Vector2.left * RUN_SPEED;
        }
        if (Input.GetKey("d")) //player 1 right
        {
           bodys[0].velocity = Vector2.right * RUN_SPEED;
        }
        if (Input.GetKey("left"))//player 2 left
        {
            bodys[1].velocity = Vector2.left * RUN_SPEED;
        }
        if (Input.GetKey("right"))//player 2 right
        {
            bodys[1].velocity = Vector2.right * RUN_SPEED;
        }
        if (onLadder)
        {
            if (Input.GetKey("w"))//player 1 up
            {
                bodys[0].velocity = Vector2.up * RUN_SPEED;
            }
            if (Input.GetKey("s") && transform.position.y > GROUND_LEVEL_Y)//player 1 down
            {
                bodys[0].velocity = Vector2.down * RUN_SPEED;
            }
            if (Input.GetKey("up"))//plauer 2 up
            {
                bodys[1].velocity = Vector2.up * RUN_SPEED;
            }
            if (Input.GetKey("down") && transform.position.y > GROUND_LEVEL_Y)//player 2 down
            {
                bodys[1].velocity = Vector2.down * RUN_SPEED;
            }
        }

        if (!onLadder && transform.position.y > GROUND_LEVEL_Y)//gravity 
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

