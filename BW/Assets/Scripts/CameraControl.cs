using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    /// <summary>
    /// Player object (to track)
    /// </summary>
    private GameObject player;

    /// <summary>
    /// Offset (for tracking player)
    /// </summary>
    private Vector3 offset;

    /// <summary>
    /// Camera component
    /// </summary>
    public Bounds cameraBounds;


    /// <summary>
    /// Camera states
    /// </summary>
    public enum cameraStates { DEFAULT, FOLLOW }
    public cameraStates state;

	// Use this for initialization
	void Start ()
    {
        player  = FindObjectOfType<Player_script>().gameObject;
        offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        
        switch (state)
        {
            case cameraStates.DEFAULT:
                if (!cameraBounds.Contains(player.transform.position)) state = cameraStates.FOLLOW;
                break;
            case cameraStates.FOLLOW:
                transform.position = Vector3.Lerp(player.transform.position + offset, transform.position, 0.9f);
                break;
            default:
                break;
        }
        
		
	}

    //// Get camera bounds
    //Bounds getCameraBounds()
    //{
    //    float vertExtent = Camera.main.orthographicSize;
    //    float horzExtent = vertExtent * Screen.width / Screen.height;
    //    Vector3 extent = new Vector3(vertExtent, horzExtent, 0);

    //    Bounds b = new Bounds(transform.position, ;
    //    b.Encapsulate()


    //    return b;
    //}

}
