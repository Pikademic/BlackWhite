using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_script : MonoBehaviour {

    /// <summary>
    /// Movement speed
    /// </summary>
    public float speed;

    /// <summary>
    /// Future position
    /// </summary>
    Vector3 pos;

    // <summary>
    /// Player controls
    /// </summary>
    public KeyCode UpKey, DownKey, LeftKey, RightKey;

    protected void Move()
    {
        bool up = Input.GetKey(UpKey);
        bool down = Input.GetKey(DownKey);
        bool left = Input.GetKey(LeftKey);
        bool right = Input.GetKey(RightKey);

        if (transform.position == pos)
        {
            if (up)
                pos += Vector3.up;
            else if (down)
                pos += Vector3.down;
            else if (left)
                pos += Vector3.left;
            else if (right)
                pos += Vector3.right;
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }

    // Use this for initialization
    void Start()
    {

        pos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        // Move
        Move();
    }

}
