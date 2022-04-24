using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int trigNum;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            if (trigNum == 4)
            {
                trigNum = 0;
            }

            if (trigNum == 3)
            {
                this.gameObject.transform.position = new Vector3(337, 7283, -8966);
                trigNum = 4;
            }

            if (trigNum == 2)
            {
                this.gameObject.transform.position = new Vector3(223, 7283, -8964);
                trigNum = 3;
            }

            if (trigNum == 1)
            {
                this.gameObject.transform.position = new Vector3(218, 7283, -9233);
                trigNum = 2;
            }

            if (trigNum == 0)
            {
                this.gameObject.transform.position = new Vector3(-124, 7284, -9233);
                trigNum = 1;
            }
        }
    }
}


