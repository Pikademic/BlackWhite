using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Entity_script : MonoBehaviour
{

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

    /// <summary>
    /// Entity sprite states
    /// </summary>
    protected enum spriteState { NORMAL, FADEGRAY, FADEBACK }
    protected spriteState sp_st = spriteState.NORMAL;
    protected SpriteRenderer sp;
    private float fadeSpeed = 0.01f;
    private float nextFadeTime; // set to Time.time in Start for bvehaviour between levels

    /// <summary>
    /// Attempt to move
    /// </summary>
    /// <param name="rel"></param>
    /// <returns> Whether the entitiy moved </returns>
    protected bool Move(Vector3 rel)
    {
        // Check if entity has finished its previous move
        if (transform.position == pos)
        {
            // Check if desired move is valid
            UnityEngine.Tilemaps.TileBase nextTile = tm.GetTile(Vector3Int.FloorToInt(pos + rel));
            if ((nextTile != mytile) && (nextTile != null))
            {
                // Execute the move
                tm.SetTile(Vector3Int.FloorToInt(pos), mytile); // place the entity's tile in its current position
                pos += rel; // set destination

                nextFadeTime = Time.time + 3f;
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Inutialize variables
    /// </summary>
    void Start()
    {
        // Get sprite renderer
        sp = GetComponent<SpriteRenderer>();

        // Get "desired" positon
        pos = transform.position;

        // Get tilemap
        tm = FindObjectOfType<UnityEngine.Tilemaps.Tilemap>(); // there can only be one!!

        // Initialize next fade time
        nextFadeTime = Time.time;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Update sprite color
        switch (sp_st) // sprite state
        {
            
            case spriteState.NORMAL:

                // If entity has not moved for a while, start fading
                if (Time.time > nextFadeTime && transform.position == pos) sp_st = spriteState.FADEGRAY;
                break;

            case spriteState.FADEGRAY:

                // Fade to gray
                sp.color = Vector4.MoveTowards(sp.color, Color.gray, fadeSpeed);

                // If faded, start fading back to proper color
                if (sp.color == Color.gray) sp_st = spriteState.FADEBACK;
                break;

            case spriteState.FADEBACK:

                // Fade to mytile color
                sp.color = Vector4.MoveTowards(sp.color, mytile.color, fadeSpeed);

                // If proper color, reset state
                if (sp.color == mytile.color) sp_st = spriteState.NORMAL;
                break;
        }

        // Update entity position
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);

        // If desired position is reached, and that position contains a reversal tile, change color.
        if (transform.position == pos)
            if (tm.GetTile(Vector3Int.FloorToInt(transform.position)) == reversaltile)
                StartCoroutine("ReverseColor");
    }


    /// <summary>
    /// Reverses color of entity
    /// </summary>
    /// <returns></returns>
    IEnumerator ReverseColor()
    {
        Debug.Log("switching color");
        if (mytile == originalTile) mytile = othertile;
        else mytile = originalTile;
        GetComponent<SpriteRenderer>().color = mytile.color;
        tm.SetTile(Vector3Int.FloorToInt(transform.position), mytile);
        yield return null;
    }

    /// <summary>
    /// Is the entity at desired position?
    /// </summary>
    /// <returns>bool</returns>
    protected bool atPos()
    {
        return transform.position == pos;
    }
}