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

    /// <summary>
    /// Future position
    /// </summary>
    private Vector3 pos;

    /// <summary>
    /// Entity sprite states
    /// </summary>
    protected enum spriteState { NORMAL, FADEGRAY, FADEBACK }
    protected spriteState sp_st = spriteState.FADEGRAY;
    protected SpriteRenderer sp;
    public float fadeSpeed;
    private float nextFadeTime;

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
        sp = GetComponent<SpriteRenderer>();
        pos = transform.position;
        tm = FindObjectOfType<UnityEngine.Tilemaps.Tilemap>();

        nextFadeTime = Time.time;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        Debug.Log(Time.time);
        // Update sprite color
        switch (sp_st)
        {
            
            case spriteState.NORMAL:
                //if (transform.position == pos) sp_st = spriteState.FADEGRAY;
                break;
            case spriteState.FADEGRAY:
                sp.color = Vector4.MoveTowards(sp.color, Color.gray, fadeSpeed);
                if (sp.color == Color.gray) sp_st = spriteState.FADEBACK;
                break;
            case spriteState.FADEBACK:
                sp.color = Vector4.MoveTowards(sp.color, mytile.color, fadeSpeed);
                if (sp.color == mytile.color) sp_st = spriteState.NORMAL;
                break;
        }

        // Update object position
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}