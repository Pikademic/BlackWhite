using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{


    /// <summary>
    /// Time till next move
    /// </summary>
    public float moveTime;

    /// <summary>
    /// Time at next move
    /// </summary>
    private float nextTime;

    /// <summary>
    /// Size of movement grid
    /// </summary>
    public float gridsize;

    // <summary>
    /// Player controls
    /// </summary>
    public KeyCode UpKey, DownKey, LeftKey, RightKey;

    protected bool Move()
    {
        bool up = Input.GetKey(UpKey);
        bool down = Input.GetKey(DownKey);
        bool left = Input.GetKey(LeftKey);
        bool right = Input.GetKey(RightKey);

        if (Time.time > nextTime && (up || down || left || right))
        {
            if (up)
                transform.position += Vector3.up * gridsize;
            if (down)
                transform.position += Vector3.down * gridsize;
            if (left)
                transform.position += Vector3.left * gridsize;
            if (right)
                transform.position += Vector3.right * gridsize;

            nextTime = Time.time + moveTime;
            return true;
        }
        return false;
    }

    // Use this for initialization
    void Start()
    {

        nextTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {

        // Move
        Move();
    }

}

