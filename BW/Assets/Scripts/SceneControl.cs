using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneControl : MonoBehaviour {


    // <summary>
    /// Player controls
    /// </summary>
    public KeyCode ResetKey;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(ResetKey))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
