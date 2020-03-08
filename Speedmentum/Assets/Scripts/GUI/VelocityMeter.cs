using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VelocityMeter : MonoBehaviour
{
    public CharacterController controler;
    //public Transform player;
    //public Vector3 playerLastPos;
    public float playerVelocity;
    [SerializeField] TextMeshProUGUI velocityGUI;
    float convertTochangeInPosPerTick = 3490448 + 1 / 3;
    // Start is called before the first frame update
    void Start()
    {
        //playerLastPos = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        //playerVelocity = Convert.ToInt32((Math.Abs((player.position.x - playerLastPos.x) * Time.deltaTime) + Math.Abs(player.position.y - playerLastPos.y) * Time.deltaTime + Math.Abs(player.position.z - playerLastPos.z) * Time.deltaTime) * 100000);
        //velocityGUI.text = Convert.ToString(playerVelocity);
        //playerLastPos = player.position;


        //Debug.Log(playerVelocity);

        ///*    
        //THIS DOESNT WORK BECAUSE ONLY Y HAS SOME VALUE
        //Debug.Log("x " + Convert.ToInt32(controler.velocity.x * 100));
        //Debug.Log("y " + Convert.ToInt32(controler.velocity.y * 100));
        //Debug.Log("z " + Convert.ToInt32(controler.velocity.z * 100));
        //Debug.Log("total " + Convert.ToInt32(controler.velocity.magnitude * 100));



        velocityGUI.text = Convert.ToString(MovementModeController.velocity/100 * convertTochangeInPosPerTick);//*/



        //Debug.Log("bla" + MovementModeController.velocity);
        //Math.Round
        //converttoint
    }
}
