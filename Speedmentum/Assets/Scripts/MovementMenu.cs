using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementMenu : MonoBehaviour
{
    public GameObject movementMenu;
    public bool onAndOff = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            //Debug.Log(onAndOff);
            movementMenu.SetActive(onAndOff);
            //Debug.Log(onAndOff);
            onAndOff = !onAndOff;
        }
    }
}

    