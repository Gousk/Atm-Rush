using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingKnife : MonoBehaviour
{ 
    Vector3 firstPos;

    private void Start() 
    {
        StartCoroutine(MoveKnife());
        firstPos = gameObject.transform.position;
    }
    public IEnumerator MoveKnife()
    {
        while (1 < 2)
        {
            Vector3 goalRotation = new Vector3(60,-90,-90);
            gameObject.transform.DORotate(goalRotation, 0.3f);
            gameObject.transform.DOMoveY(3f, 1f);  
            gameObject.transform.DOMoveX(10f, 1f).OnComplete(() =>
            gameObject.transform.DORotate(goalRotation, 0.3f).OnComplete(() =>
            gameObject.transform.DOMoveX(-10f, 0.3f).OnComplete(() =>
            gameObject.transform.DOMoveX(-20, 0.3f))));
            yield return new WaitForSeconds(2.5f);
        } 
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Collected")
        {

        }       
    }
}

