using UnityEngine;
using System.Collections;

public class Destroyer : Player {

    /// <summary>
    /// Called when a the player touches an object
    /// </summary>
    /// <param name="otherObject">The object collided with</param>
    internal void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.CompareTag("Wall")) Destroy(otherObject.gameObject);


    }
}
