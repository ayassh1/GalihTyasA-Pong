using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {

        //gerakan object pakai input
        //Vector2 movement = GetInput();
        MoveObject(GetInput());


    }

    private Vector2 GetInput()
    {

        if (Input.GetKey(upKey))
        {
            //W = UP
            return Vector2.up * speed;
        }

        else if (Input.GetKey(downKey))
        {
            //S = DOWN
            return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        Debug.Log("TEST: " + movement);
        rig.velocity = movement;
    }
}
