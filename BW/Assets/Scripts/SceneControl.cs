using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneControl : MonoBehaviour {


    // <summary>
    /// Player controls
    /// </summary>
    public KeyCode ResetKey;

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

    /// <summary>
    /// Next level
    /// </summary>
    public Scene nextLevel;
    

    // Use this for initialization
    void Start () {
        tm = FindObjectOfType<UnityEngine.Tilemaps.Tilemap>();
    }
	
	// Update is called once per frame
	void Update () {

        // Reset scene when reset key is pressed
        if (Input.GetKeyDown(ResetKey))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Advance level when landmark is reached
        if (tm.GetTile(Vector3Int.FloorToInt(player.transform.position)) == landmark)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
