using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollision : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D collider = gameObject.GetComponent<Collider2D>();
        Rigidbody2D rbody = gameObject.GetComponent<Rigidbody2D>();

        if (Input.GetKey("left shift") && player.transform.position.y <= Movement.GROUND_LEVEL_Y)
        {
            // Make ladder susceptible to pushing
            print("On ground and pushing");
            collider.isTrigger = false;
        } else
        {
            collider.isTrigger = true;
            rbody.velocity = Vector2.zero;
        }
    }
}
