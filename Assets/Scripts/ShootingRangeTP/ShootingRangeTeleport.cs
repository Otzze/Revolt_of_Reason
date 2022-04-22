using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRangeTeleport : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
         
    }

    public void Link()
    {
        StartCoroutine("Teleport");
    }

    IEnumerator Teleport()
    {
        gameObject.GetComponent<PlayerScript>().disabled = true;
        yield return new WaitForSeconds(0.01f);

        gameObject.transform.position = new Vector3(12208, 150, -2200);
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<PlayerScript>().disabled = false;

    }
}
