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
    this.gameObject.transform.position = new Vector3(1973, -27, 2243);
    trigNum = 4;
   }

   if (trigNum == 2)
   {
    this.gameObject.transform.position = new Vector3(4061, -18, 2191);
    trigNum = 3;
   }

   if (trigNum == 1)
   {
    this.gameObject.transform.position = new Vector3(4019, -11, -276);
    trigNum = 2;
   }

   if (trigNum == 0)
   {
    this.gameObject.transform.position = new Vector3(1929, -20, -321);
    trigNum = 1;
   }
  }
 }
}

