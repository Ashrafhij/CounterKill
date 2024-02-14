using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class newInputManager : MonoBehaviour
{

    private newController controller;
    [HideInInspector]public float vertical;
    [HideInInspector] public float horizontal;
    [HideInInspector] public float xValue, yValue;

    private bool pause;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controller = GetComponent<newController>();

    }

    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) pauseGame();

        if (pause)
        {
            vertical = 0;
            horizontal = 0;
            xValue = 0;
            yValue = 0;
        }
        else {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
            xValue = CrossPlatformInputManager.GetAxis("Mouse Y");
            yValue = CrossPlatformInputManager.GetAxis("Mouse X");

            if (Input.GetKeyDown(KeyCode.Space)) controller.Jump();
        }
    }

    private void pauseGame()
    {
        if (pause)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pause = false;
            return;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pause = true;
        }

    }
}
