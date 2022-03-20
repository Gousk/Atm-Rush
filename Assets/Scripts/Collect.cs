using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class Collect : MonoBehaviour
{
    GameObject playerObject;
    Collection collectionScript;
    Vector3 firstScale;
    void Start() 
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        firstScale = transform.localScale;
        collectionScript = playerObject.GetComponent<Collection>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Collect"))
        {
            if (!playerObject.GetComponent<Collection>().Foods.Contains(other.gameObject.transform))
            {
                other.transform.parent = null;
                other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
                other.gameObject.GetComponent<Collider>().isTrigger = false;
                other.gameObject.AddComponent<Collect>();
                other.gameObject.tag = "Collected";
                playerObject.GetComponent<Collection>().Foods.Add(other.transform);
                StartCoroutine(MakeObjectsBigger());
            }
        }
    }

    public IEnumerator MakeObjectsBigger()
    {
        for (int i = collectionScript.Foods.Count-1; i > 0; i--)
        {
            Vector3 firstScale = collectionScript.Foods[i].transform.localScale;
            Vector3 Scale = firstScale * 2f;

            collectionScript.Foods[i].transform.DOScale(Scale, 0.1f).OnComplete(() => 
             collectionScript.Foods[i].transform.DOScale(firstScale, 0.1f));
            yield return new WaitForSeconds(0.1f);
        }
    }
}

