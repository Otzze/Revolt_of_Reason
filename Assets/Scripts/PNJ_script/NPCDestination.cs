using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDestination : MonoBehaviour
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
    this.gameObject.transform.position = new Vector3(336, 7281, -8987);
    trigNum = 4;
   }

   if (trigNum == 2)
   {
    this.gameObject.transform.position = new Vector3(198, 7281, -8987);
    trigNum = 3;
   }

   if (trigNum == 1)
   {
    this.gameObject.transform.position = new Vector3(198, 7281, -9235);
    trigNum = 2;
   }

   if (trigNum == 0)
   {
    this.gameObject.transform.position = new Vector3(350, 7281, -9235);
    trigNum = 1;
   }
  }
 }
}

