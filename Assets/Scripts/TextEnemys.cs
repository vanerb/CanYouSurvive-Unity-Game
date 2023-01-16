using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextEnemys : MonoBehaviour
{

    public string[] texts;
    public int randomNum;
    public Text dialogue;
    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(0, texts.Length);
        this.enabled = true;
        dialogue.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Activate();
        Invoke("Desactivate", 2f);
    }

    void Activate()
    {
        dialogue.text = "" + texts[randomNum];
    }

    void Desactivate()
    {
        dialogue.enabled = false;
        this.enabled = false;
    }

    
}
