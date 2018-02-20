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
    private UnityEngine.Tilemaps.Tilemap tm;
    
    /// <summary>
    /// Tile that entity "paints"
    /// </summary>
    public UnityEngine.Tilemaps.Tile mytile;
    public UnityEngine.Tilemaps.Tile reversaltile;
    public UnityEngine.Tilemaps.Tile originalTile;
    public UnityEngine.Tilemaps.Tile othertile;

    /// <summary>
    /// Future position
    /// </summary>
    private Vector3 pos;

    
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
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        if (transform.position == pos)
            if (tm.GetTile(Vector3Int.FloorToInt(transform.position)) == reversaltile)
                StartCoroutine("ReverseColor");
    }

    IEnumerator ReverseColor()
    {
        Debug.Log("switching color");
        if (mytile == originalTile) mytile = othertile;
        else mytile = originalTile;
        GetComponent<SpriteRenderer>().color = mytile.color;
        tm.SetTile(Vector3Int.FloorToInt(transform.position), mytile);
        yield return null;
    }
    

}
