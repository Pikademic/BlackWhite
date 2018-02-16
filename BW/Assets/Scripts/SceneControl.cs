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

        //Debug.Log(cameraBounds());
        Debug.Log(tm_bounds);
    }
	
	// Update is called once per frame
	void Update () {

        // Reset scene when reset key is pressed
        if (Input.GetKeyDown(ResetKey))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (Input.GetKeyDown(HardResetKey))
            SceneManager.LoadScene(0);



        // Advance level when landmark is reached, or all "landmark" is removed
        switch (obj)
        {
            case objective.FILL:
                UnityEngine.Tilemaps.TileBase[] tm_array = tm.GetTilesBlock(tm_bounds);
                int num_lm_tiles = System.Array.FindAll<UnityEngine.Tilemaps.TileBase>(tm_array, x => x == landmark).Length;

                if (num_lm_tiles < 2)
                    nextLevel();
                break;

            case objective.GOAL:
                if (tm.GetTile(Vector3Int.FloorToInt(player.transform.position)) == landmark)
                    nextLevel();
                break;

            case objective.EXIT:
                
                break;

            default:
                break;
        }   
    }

    // Next level
    private void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Get camera bounds
    private Vector3 cameraBounds()
    {

        Camera camera = GetComponent<Camera>();
        Vector3 p = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        return p;
    }

}
