using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraControl : MonoBehaviour
{
    float rotationSpeed = 1f;
    public Transform Target, Player;
    float mouseX, mouseY;
    bool looking = true;
    public Itemscanner Scannerscript;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        CamControl();
    }

    //move camera with mouse
    void CamControl()
    {
        //only if the inventory of crafting is closed
        if (Scannerscript.Mouseactive == false)
        {
            mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -60, 60);


            //if rightclick only move camera not player
            if (Input.GetMouseButton(1))
            {
                transform.LookAt(Player);
                Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            }
            else
            {
                transform.LookAt(Target);
                Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
                Player.rotation = Quaternion.Euler(0, mouseX, 0);
            }
        }
    }

}