using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGroundEnemy : MonoBehaviour
{
    public bool isExit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isExit = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isExit = true;
        }
       
    }
}
