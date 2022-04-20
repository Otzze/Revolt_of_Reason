using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ennemi : MonoBehaviourPunCallbacks
{
    public int health = 1000;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
            
    }

    [PunRPC]
    public void Damage(int p_damage)
    {
        health -= p_damage;
        Debug.Log(health);
    }
}
