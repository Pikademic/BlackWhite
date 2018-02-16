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

    /// <summary>
    /// Future position
    /// </summary>
    private Vector3 pos;

    /// <summary>
    /// Entity sprite states
    /// </summary>
    protected enum spriteState { NORMAL, PULSE, FADE, FADE_B, FADE_W }
    protected spriteState sp_st = spriteState.PULSE;
    protected SpriteRenderer sp;

    protected void Move(Vector3 rel)
    {
        // Revert sprite to normal
        if (sp_st == spriteState.PULSE)     sp_st = spriteState.FADE;


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
    }

    // Update is called once per frame
    void LateUpdate()
    {

        // Update sprite color
        if (sp_st == spriteState.PULSE)
            sp.color = Color.Lerp(mytile.color, InvertColor(mytile.color), Mathf.PingPong(Time.time/2, 1));
        if (sp_st == spriteState.FADE)
        {   sp.color = Color.Lerp(sp.color, mytile.color, 0.2f);
            if (Vector4.Distance(sp.color - mytile.color, Vector4.zero) < 0.01f)
            {
                sp.color = mytile.color;
                sp_st = spriteState.NORMAL;
            }
                
        }
        Debug.Log(Equals(transform.position, pos));
        // Update object position
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
    
    private Color InvertColor(Color c)
    {
        return new Color(1f - c.r, 1f - c.g, 1f - c.b, c.a);
    }

}
