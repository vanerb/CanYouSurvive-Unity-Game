using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{

    public static float time;
    public Text textCrono;
    public Text res;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        textCrono.text = "" + time.ToString("f0")+" s";

        res.text = "Has aguantado: " + time.ToString("f0")+" Segundos";
    }
}
