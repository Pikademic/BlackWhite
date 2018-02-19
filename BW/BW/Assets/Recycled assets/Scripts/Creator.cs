using UnityEngine;
using System.Collections;

public class Creator : Player
{

    /// <summary>
    /// Wall prefab
    /// </summary>
    public GameObject wall;

    void Update()
    {

        // Move
        if (Move()) Instantiate(wall, transform.position, transform.rotation);
    }

}

