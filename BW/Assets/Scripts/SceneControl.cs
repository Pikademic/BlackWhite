using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneControl : MonoBehaviour {


    // <summary>
    /// Player controls
    /// </summary>
    public KeyCode ResetKey, HardResetKey;

    /// <summary>
    /// THe player gameobject
    /// </summary>
    public GameObject player;

    /// <summary>
    /// The goal tile
    /// </summary>
    public UnityEngine.Tilemaps.Tile landmark;

    /// <summary>
    /// Tilemap
    /// </summary>
    private UnityEngine.Tilemaps.Tilemap tm;
    private BoundsInt tm_bounds;

    /// <summary>
    /// Objective modes
    /// </summary>
    public enum objective { FILL, GOAL, EXIT }
    public objective obj;

    // Use this for initialization
    void Start () {
        tm = FindObjectOfType<UnityEngine.Tilemaps.Tilemap>();
        tm_bounds = tm.cellBounds;
    }
	
	// Update is called once per frame
	void Update () {

        // Reset scene when reset key is pressed
        if (Input.GetKeyDown(ResetKey)) relativeLevel(0);

        if (Input.GetKeyDown(HardResetKey)) relativeLevel(1);



        // Advance level when landmark is reached, or all "landmark" is removed
        switch (obj)
        {
            case objective.FILL:
                UnityEngine.Tilemaps.TileBase[] tm_array = tm.GetTilesBlock(tm_bounds);
                int num_lm_tiles = System.Array.FindAll<UnityEngine.Tilemaps.TileBase>(tm_array, x => x == landmark).Length;

                if (num_lm_tiles < 2) relativeLevel(1);
                break;

            case objective.GOAL:
                if (tm.GetTile(Vector3Int.FloorToInt(player.transform.position)) == landmark)   relativeLevel(1);
                break;

            case objective.EXIT:
                if (tm.GetTile(Vector3Int.FloorToInt(player.transform.position)) == landmark)   relativeLevel(0);

                if (!tm_bounds.Contains(Vector3Int.FloorToInt(player.transform.position)))      relativeLevel(1);

                break;

            default:
                break;
        }   
    }

    // Next level
    private void relativeLevel(int rel)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + rel);
    }

    // Get camera bounds
    private Vector3 cameraBounds()
    {

        Camera camera = GetComponent<Camera>();
        Vector3 p = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        return p;
    }

}
