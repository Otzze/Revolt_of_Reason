using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Player_Healthy : MonoBehaviour
{
    public int health = 100;
    private Text MyHealth;
    private Text OtHealth;
    private PhotonView _view;
      
    // Start is called before the first frame update
    void Start()
    {
        MyHealth = GameObject.Find("MyHealth").GetComponent<Text> ();
        OtHealth = GameObject.Find("OtHealth").GetComponent<Text> ();
        _view = GetComponent<PhotonView> ();

    }

    // Update is called once per frame
    void OnCollisionEnter(Collision Coly)
    {
        if (Coly.gameObject.CompareTag("Coly") /*&& _view.isMine*/)
        {
            health -= 10; 
            MyHealth.text = "My Health : " + (health >= 0 ? health : 0) + "%";  //Opération ternaire : si health est positive alors l'afficher sinon afficher 0
        }
    }
}

