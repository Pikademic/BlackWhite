using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_script : MonoBehaviour {

    /// <summary>
    /// Movement speed
    /// </summary>
    public float speed;

    /// <summary>
    /// Tilemap
    /// </summary>
    public UnityEngine.Tilemaps.Tilemap tm;

    /// <summary>
    /// Tile that entity "paints"
    /// </summary>
    public UnityEngine.Tilemaps.Tile mytile;

    /// <summary>
    /// Future position
    /// </summary>
    Vector3 pos;


    protected void Move(Vector3 rel)
    {
        if (transform.position == pos) // if entity has finished its previous move
            if (tm.GetTile(Vector3Int.FloorToInt(pos + rel)) != mytile) // if entity is not attempting to move to a tile of its own color
            {
                tm.SetTile(Vector3Int.FloorToInt(pos), mytile); // place the entity's tile in its current position
                pos += rel; // set destination
            }
    }

    // Use this for initialization
    void Start()
    {

        pos = transform.position;
        tm = FindObjectOfType<UnityEngine.Tilemaps.Tilemap>();
        Debug.Log(tm);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Move
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
    

}
