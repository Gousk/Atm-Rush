using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Converter : MonoBehaviour
{
    GameObject self;
    Transform apple;
    Transform pizza;
    Transform lollypop;

    int currentState;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject;
        apple = self.transform.GetChild(0);
        pizza = self.transform.GetChild(1);
        lollypop = self.transform.GetChild(2);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Converter"))
        {
            if (self.tag == "Collected")
            {
                self.tag = "Upgrade1";
                apple.GetComponent<Renderer>().enabled = false;
                pizza.GetComponent<Renderer>().enabled = true; 
                MakeObjectsBigger();
            }    
            else if (self.tag == "Upgrade1")
            {
                pizza.GetComponent<Renderer>().enabled = false;
                lollypop.GetComponent<Renderer>().enabled = true; 
                MakeObjectsBigger();
            }                 
        }   
    }

    void MakeObjectsBigger()
    {
            Vector3 firstScale = transform.localScale;
            Vector3 Scale = firstScale * 2f;

            transform.DOScale(Scale, 0.1f).OnComplete(() => 
             transform.DOScale(firstScale, 0.1f));
    }
}
