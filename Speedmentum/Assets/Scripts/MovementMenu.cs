using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementMenu : MonoBehaviour
{
    public Button button1;
    public Button button2;
    // Start is called before the first frame update
    void Start()
    {
        button1.GetComponentInChildren<Text>().text = "Basic";
        button2.GetComponentInChildren<Text>().text = "Faster";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
