using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_script : Entity_script
{

    // <summary>
    /// Player controls
    /// </summary>
    public KeyCode UpKey, DownKey, LeftKey, RightKey;




    private void Update()
    {
        // Move
        if      (Input.GetKeyDown(UpKey))       Move(Vector3.up);
        else if (Input.GetKeyDown(DownKey))     Move(Vector3.down);
        else if (Input.GetKeyDown(RightKey))    Move(Vector3.right);
        else if (Input.GetKeyDown(LeftKey))     Move(Vector3.left);

    }
    
}
