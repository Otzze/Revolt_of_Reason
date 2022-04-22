using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    [SerializeField]
    public int MaxArmor = 500;

    [SerializeField]
    public int CurrentPrice = 500;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ArmorUpgrade();
        }
    }

    public void ArmorUpgrade()
    {
        if (gameObject.GetComponent<PlayerMoney>().Money >= CurrentPrice)
        {
            MaxArmor += 500;
            gameObject.GetComponent<PlayerMoney>().DecreaseMoney(CurrentPrice);
            CurrentPrice *= 2;
        }
    }
}
