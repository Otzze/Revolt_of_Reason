using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Sway : MonoBehaviourPunCallbacks
{
    public float intensity;
    public float smooth;
    private Quaternion origin_rotation;
    public bool IsMine;

    // Start is called before the first frame update
    void Start()
    {
        origin_rotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
            return;
        UpdateSway();
    }

    private void UpdateSway()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (!IsMine)
        {
            mouseX = 0;
            mouseY = 0;
        }

        //calcul du mouvement
        Quaternion t_adjX = Quaternion.AngleAxis(-intensity * mouseX, Vector3.up);
        Quaternion t_adjY = Quaternion.AngleAxis(-intensity * mouseY, Vector3.up);
        Quaternion target_rotation = origin_rotation * t_adjX * t_adjY;

        //rotation
        transform.localRotation = Quaternion.Lerp(transform.localRotation, target_rotation, Time.deltaTime * smooth);
    }
}
