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


    protected void Move(Vector3 rel)
    {
        if (transform.position == pos) pos += rel;
    }

    // Use this for initialization
    void Start()
    {

        pos = transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Move
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
    

}
