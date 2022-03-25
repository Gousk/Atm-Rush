using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class Collection : MonoBehaviour
{
    Movement movementScript;
    [SerializeField] float Distance;
    public List<Transform> Foods = new List<Transform>();
    public int score = 0;

    void Start()
    {
        movementScript = gameObject.GetComponent<Movement>();
        Foods.Add(gameObject.transform);
    }

    void Update()
    {
        if (Foods.Count > 1)
        {
            for (int i = 1; i < Foods.Count; i++)
            {  
                var FirstFood = Foods.ElementAt(i - 1);
                var SecFood = Foods.ElementAt(i);

                var DesireDistance = Vector3.Distance(SecFood.position, FirstFood.position);

                if (DesireDistance <= Distance)
                {
                    SecFood.position = new Vector3(Mathf.Lerp(SecFood.position.x, FirstFood.position.x, movementScript.leftRightSpeed * Time.deltaTime), SecFood.position.y, Mathf.Lerp(SecFood.position.z, FirstFood.position.z + 3f, movementScript.leftRightSpeed * Time.deltaTime));
                }    
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Collect")
        {
            if (!Foods.Contains(other.gameObject.transform))
            {
                other.enabled = false;
                other.transform.parent = null;
                other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
                other.gameObject.GetComponent<Collider>().isTrigger = false;
                other.gameObject.AddComponent<Collect>();
                other.tag = "Collected";
                Foods.Add(other.transform); 
                StartCoroutine(MakeObjectsBigger(other));
            }
                          
        }

        if (other.name == "SAAT")
        {
            Destroy(other.gameObject, 0f);
            score+= 100;
        }   
    }

    public IEnumerator MakeObjectsBigger(Collider other)
    {
        for (int i = Foods.Count-1; i > 0; i--)
        {
            Vector3 firstScale = Foods[i].transform.localScale;
            Vector3 Scale = firstScale * 1.5f;

            Foods[i].transform.DOScale(0.9f, 0f).OnComplete(() =>
            Foods[i].transform.DOScale(Scale, 0.06f).OnComplete(() => 
            Foods[i].transform.DOScale(0.9f, 0.06f)));
            other.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
