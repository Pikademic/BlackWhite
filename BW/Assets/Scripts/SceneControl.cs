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
    public UnityEngine.Tilemaps.Tile landmark2;

    /// <summary>
    /// Tilemap
    /// </summary>
    private UnityEngine.Tilemaps.Tilemap tm;
    private BoundsInt tm_bounds;

    /// <summary>
    /// Next level
    /// </summary>
    public Scene nextLevel;

    /// <summary>
    /// "Fill" type level? Otherwise, "reach the landmark"
    /// </summary>
    public bool fill;

    // Use this for initialization
    void Start () {
        tm = FindObjectOfType<UnityEngine.Tilemaps.Tilemap>();
        tm_bounds = tm.cellBounds;
    }
	
	// Update is called once per frame
	void Update () {

        // Reset scene when reset key is pressed
        if (Input.GetKeyDown(ResetKey))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (Input.GetKeyDown(HardResetKey))
            SceneManager.LoadScene(0);



        // Advance level when landmark is reached, or all "landmark" is removed
        if (fill)
        {
            UnityEngine.Tilemaps.TileBase[] tm_array = tm.GetTilesBlock(tm_bounds);
            int num_lm_tiles = System.Array.FindAll<UnityEngine.Tilemaps.TileBase>(tm_array, x => x == landmark).Length;
            num_lm_tiles += System.Array.FindAll<UnityEngine.Tilemaps.TileBase>(tm_array, x => x == landmark2).Length;

            if (num_lm_tiles < 2)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
            if (tm.GetTile(Vector3Int.FloorToInt(player.transform.position)) == landmark)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
