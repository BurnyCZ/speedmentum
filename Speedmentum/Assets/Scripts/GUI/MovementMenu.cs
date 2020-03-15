using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementMenu : MonoBehaviour
{
    //public GameObject movementMenu;
    public RectTransform movementMenuPos; //get position of the menu (by default its y is 1000, its hidden above the screen
    public bool isEnabled = false;

    void Start()
    {
        movementMenuPos.position = movementMenuPos.position + new Vector3(0, 1000, 0); //offset at first frame - done like this instead of having its default position somewhere else because if its the other case, it behaves differently on different resolutions for some reason so the movement menu does wont be in the middl of the screen if triggered
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            
            isEnabled = !isEnabled; //changing state of the is enabled bool which is false (disabled) by default
            
            if (isEnabled) movementMenuPos.position = movementMenuPos.position - new Vector3(0, 1000, 0); else movementMenuPos.position = movementMenuPos.position + new Vector3(0, 1000, 0); //makes the menu screen visible if it should be enabled (puts it from the above of the screen to the middle of the screen or the other way around

            //Debug.Log(movementMenuPos.position.y);
        }
    }
}

    