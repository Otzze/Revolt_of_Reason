using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenu : MonoBehaviour
{
    public GameObject UiObject;

    // Start is called before the first frame update
    void Start()
    {
        UiObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            UiObject.SetActive(true);

            other.GetComponent<Armor>();
                
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            UiObject.SetActive(false);
        }
    }
}
