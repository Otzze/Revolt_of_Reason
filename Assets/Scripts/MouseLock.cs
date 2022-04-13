using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MouseLock : MonoBehaviourPunCallbacks
{
    PhotonView view;
    public float rotationX;
    public float rotationY;
    public float sensitivity = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMouseOut() && view.IsMine)
        {
            rotationX -= Input.GetAxis("Mouse Y") * (sensitivity+5);
            rotationY += Input.GetAxis("Mouse X") * (sensitivity+5);
            rotationX = Mathf.Clamp(rotationX, -90, 90);
        
            transform.rotation = Quaternion.Euler(rotationX,rotationY,0);
        }

    }

    private bool IsMouseOut()
    {
        if (Input.mousePosition.x <= 2 || Input.mousePosition.y <= 2 || Input.mousePosition.x > Screen.width - 1 ||
            Input.mousePosition.y > Screen.width - 1)
            return true;
        return false;
    }
}
