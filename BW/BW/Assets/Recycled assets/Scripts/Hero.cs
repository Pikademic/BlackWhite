using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

    public float force;

    private bool moving = false;

    private Rigidbody2D heroRb;

	// Use this for initialization
	void Start () {
        heroRb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (moving == true)
            heroRb.AddTorque(force);
    }

    /// <summary>
    /// Called when a the hero touches an object
    /// </summary>
    /// <param name="otherObject">The object collided with</param>
    internal void OnCollisionEnter2D(Collision2D collision)
    {
        //if (otherObject.CompareTag("Wall"))
            moving = true;


    }

}
