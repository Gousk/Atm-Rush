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
                    SecFood.position = new Vector3(Mathf.Lerp(SecFood.position.x, FirstFood.position.x, movementScript.leftRightSpeed * Time.deltaTime), SecFood.position.y, Mathf.Lerp(SecFood.position.z, FirstFood.position.z + 2f, movementScript.leftRightSpeed * Time.deltaTime));
                }    
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Collect"))
        {
            if (!Foods.Contains(other.gameObject.transform))
            {
                other.transform.parent = null;
                other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
                other.gameObject.GetComponent<Collider>().isTrigger = false;
                other.gameObject.AddComponent<Collect>();
                other.tag = "Collected";
                Foods.Add(other.transform); 
                StartCoroutine(MakeObjectsBigger());
            }
                          
        }   
    }

    public IEnumerator MakeObjectsBigger()
    {
        for (int i = Foods.Count-1; i > 0; i--)
        {
            Vector3 firstScale = Foods[i].transform.localScale;
            Vector3 Scale = firstScale * 2f;

            Foods[i].transform.DOScale(Scale, 0.1f).OnComplete(() => 
            Foods[i].transform.DOScale(firstScale, 0.1f));
            yield return new WaitForSeconds(0.1f);
        }
    }
}
