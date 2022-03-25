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
    public string prevTag;
    ParticleSystem appleP;
    ParticleSystem pizzaP;
    ParticleSystem lollypopP;

    int currentState;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject;
        apple = self.transform.GetChild(0);
        pizza = self.transform.GetChild(1);
        lollypop = self.transform.GetChild(2);

        appleP = self.transform.GetChild(3).GetComponent<ParticleSystem>();
        pizzaP = self.transform.GetChild(4).GetComponent<ParticleSystem>();
        lollypopP = self.transform.GetChild(5).GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Converter"))
        {
            if (apple.GetComponent<Renderer>().enabled == true)
            {
                apple.GetComponent<Renderer>().enabled = false;
                pizza.GetComponent<Renderer>().enabled = true; 
                MakeObjectsBigger();
            }
            else if (pizza.GetComponent<Renderer>().enabled == true)
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
            Vector3 Scale = firstScale * 1.5f;

            transform.DOScale(0.9f, 0f).OnComplete(() =>
            transform.DOScale(Scale, 0.1f).OnComplete(() => 
             transform.DOScale(0.9f, 0.1f)));
    }
}
