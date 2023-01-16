using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowePlayer : MonoBehaviour
{
    public AttackPLayer attack;
    public bool isFinish = false;
    public PowerObject powerObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(powerObject.isActive == true)
        {
            ActivateAttackPower();
            
            Invoke("DesactivatePower", 20f);
        }
    }

    void ActivateAttackPower()
    {
        attack.damage = 40;
    }

    void DesactivatePower()
    {
        
        attack.damage = 20;
    }
}
