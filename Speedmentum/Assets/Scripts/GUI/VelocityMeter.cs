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
    [SerializeField] TextMeshProUGUI velocityXZGUI;
    [SerializeField] TextMeshProUGUI velocityYGUI;
    [SerializeField] TextMeshProUGUI velocityAboutToBeAppliedGUI;
    [SerializeField] TextMeshProUGUI velocityXZAboutToBeAppliedGUI;
    [SerializeField] TextMeshProUGUI velocityYAboutToBeAppliedGUI;
    [SerializeField] TextMeshProUGUI velocityModeGUI;
    int tickrate = 50;
    bool isRounded = true;
    enum VelocityModes
    {
        Default,
        Rounded,
        KmPerHour,
        MetPerSec,
        ChangeInPosPerTick
    }
    VelocityModes velocityMode = VelocityModes.Default;
    // Start is called before the first frame update
    void Start()
    {
        //playerLastPos = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!((int)velocityMode == Enum.GetNames(typeof(VelocityModes)).Length - 1))
                velocityMode = (VelocityModes)((int)velocityMode + 1);
            else
                velocityMode = VelocityModes.Default; // 0

            Debug.Log("Velocity mode changed to "+velocityMode);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            isRounded = !isRounded;

            Debug.Log("Velocity mode changed to " + velocityMode);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //this creates the gui's velocity meters
        // real xz          real xyz           real y
        // gameapplying xz  gameapplying xyz   gameapplying y
        //
        if (!isRounded)
        {
            velocityGUI.text = Convert.ToString(ConvertVelocityToCurrentMode(MovementModeController.velocity));
            velocityXZGUI.text = Convert.ToString(ConvertVelocityToCurrentMode(MovementModeController.velocityXZ));
            velocityYGUI.text = Convert.ToString(ConvertVelocityToCurrentMode(MovementModeController.velocityY));
            velocityAboutToBeAppliedGUI.text = Convert.ToString(ConvertVelocityToCurrentMode(MovementModeController.velocityAboutToBeApplied));
            velocityXZAboutToBeAppliedGUI.text = Convert.ToString(ConvertVelocityToCurrentMode(MovementModeController.velocityXZAboutToBeApplied));
            velocityYAboutToBeAppliedGUI.text = Convert.ToString(ConvertVelocityToCurrentMode(MovementModeController.velocityYAboutToBeApplied));
        }         
        else
        {
            velocityGUI.text = Convert.ToString(Math.Round(ConvertVelocityToCurrentMode(MovementModeController.velocity)));
            velocityXZGUI.text = Convert.ToString(Math.Round(ConvertVelocityToCurrentMode(MovementModeController.velocityXZ)));
            velocityYGUI.text = Convert.ToString(Math.Round(ConvertVelocityToCurrentMode(MovementModeController.velocityY)));
            velocityAboutToBeAppliedGUI.text = Convert.ToString(Math.Round(ConvertVelocityToCurrentMode(MovementModeController.velocityAboutToBeApplied)));
            velocityXZAboutToBeAppliedGUI.text = Convert.ToString(Math.Round(ConvertVelocityToCurrentMode(MovementModeController.velocityXZAboutToBeApplied)));
            velocityYAboutToBeAppliedGUI.text = Convert.ToString(Math.Round(ConvertVelocityToCurrentMode(MovementModeController.velocityYAboutToBeApplied)));
        }
        switch (velocityMode)
        {
            case VelocityModes.Default: velocityModeGUI.text = "u/s"; break;
            case VelocityModes.Rounded: velocityModeGUI.text = "rounded"; break;
            case VelocityModes.KmPerHour: velocityModeGUI.text = "km/h"; break;
            case VelocityModes.MetPerSec: velocityModeGUI.text = "m/s"; break;
            case VelocityModes.ChangeInPosPerTick: velocityModeGUI.text = "p/t"; break;
        }
    }

    float ConvertVelocityToCurrentMode(float velocity)
    {
        switch (velocityMode)
        {
            case VelocityModes.Rounded:
                return velocity * 10 * 5 / 6; //*5/6 rounds it from 120 default speed to 100
            case VelocityModes.ChangeInPosPerTick:
                return velocity / tickrate; //velocity tells how the position changes per second, so dividing it by the tickrate we get how far we moved in the last tick (physics update)
            case VelocityModes.MetPerSec:
                return velocity / 4; //if velocity is 12 it makes sense to make the speed 3m per sec
            case VelocityModes.KmPerHour:
                return velocity / 4 * 3.6f; //converting m/s to km/h
            default: //VelocityModes.Default:
                return velocity * 10;
        }
    }
}
