using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementMenu : MonoBehaviour
{
    //public GameObject movementMenu;
    public List<RectTransform> menus = new List<RectTransform>(); //get position of the menu (by default its y is 1000, its hidden above the screen
    enum Menus
    {
        modesMenu,
        modifiersMenu,
        addReplaceMenu,
        growthVariantsMenu,
        triggersOrMenu,
        triggerAndMenu,
        moreOrMenu
    }
    Menus currentMenu = Menus.modesMenu;
    bool isCurrentMenuEnabled = false;

    void Start()
    {
        for (int i = 0; i<menus.Count; i++)
        {
            // menus[(int)Menus.modesMenu].position = menus[(int)Menus.modesMenu].position + new Vector3(0, 1000, 0);
            menus[i].position = menus[i].position + new Vector3(0, 1000, 0);
        } //offset at first frame - done like this instead of having its default position somewhere else because if its the other case, it behaves differently on different resolutions for some reason so the movement menu does wont be in the middl of the screen if triggered
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!isCurrentMenuEnabled) menus[(int)currentMenu].position = menus[(int)currentMenu].position - new Vector3(0, 1000, 0);  //makes the current menu screen visible/invisible
            else menus[(int)currentMenu].position = menus[(int)currentMenu].position + new Vector3(0, 1000, 0);
            //Debug.Log(movementMenuPos.position.y);
        }

        if (currentMenu == Menus.modesMenu)
        {
            Input.GetKeyDown(KeyCode.M);
        }



        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    currentMenu = (Menus)((int)currentMenu + 1); //sets current menu variable to the next one
        //}
    }
}

