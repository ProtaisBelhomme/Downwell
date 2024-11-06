using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Schema of the input controller
//https://europe1.discourse-cdn.com/unity/original/3X/5/8/58e7b2a50ec35ea142ae9c4d27c9df2d372cd1f3.jpeg

//This script is an exemple of how to use the Input class to detect various types of input
public class Exemple_InputController : MonoBehaviour
{
    [InputAxis] public string eastPadButtonName = "EastPadButton";
    [InputAxis] public string southPadButtonName = "SouthPadButton";
    [InputAxis] public string westPadButtonName = "WestPadButton";
    [InputAxis] public string northPadButtonName = "NorthPadButton";
    [HorizontalLine(color: EColor.Red)]

    public UnityEvent onEastPadButton;
    public UnityEvent onSouthPadButton;
    public UnityEvent onWestPadButton;
    public UnityEvent onNorthPadButton;
    [HorizontalLine(color: EColor.Blue)]
    public UnityEvent<Vector2> onMove;

    private void Update()
    {
        if(Input.GetButtonDown(eastPadButtonName))
        {
            Debug.Log("East Pad Button is pressed");
            onEastPadButton?.Invoke();
        }
        if (Input.GetButtonDown(southPadButtonName))
        {
            Debug.Log("South Pad Button is pressed");
            onSouthPadButton?.Invoke();
        }
        if (Input.GetButtonDown(westPadButtonName))
        {
            Debug.Log("West Pad Button is pressed");
            onWestPadButton?.Invoke();
        }
        if (Input.GetButtonDown(northPadButtonName))
        {
            Debug.Log("North Pad Button is pressed");
            onNorthPadButton?.Invoke();
        }

        // Check for Joystick input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);

        float deadZone = 0.1f;
        if (movement.magnitude > deadZone)
        {
            // Normalize the movement vector if its magnitude is greater than 1
            // This ensures that diagonal movement is not faster than horizontal/vertical movement
            if (movement.magnitude > 1)
            {
                movement.Normalize();
            }

            // Perform action based on movement input
            Debug.Log("Movement input: " + movement);
            onMove?.Invoke(movement);
        }
    }
}
