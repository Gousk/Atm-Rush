using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ATMRush : MonoBehaviour
{
    public static ATMRush instance;
    public List<GameObject> foods = new List<GameObject>();
    private void Awake() 
    {
        if (instance = null)
        {
            instance = this;
        }    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StackFood (GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = foods[index].transform.localPosition;
        newPos.z += 1;
        other.transform.localPosition = newPos; 
        StartCoroutine(MakeObjectsBigger());
    }

    public IEnumerator MakeObjectsBigger()
    {
        for (int i = foods.Count-1; i > 0; i--)
        {
            Vector3 firstScale = foods[i].transform.localScale;
            Vector3 Scale = firstScale * 2f;

            foods[i].transform.DOScale(Scale, 0.1f).OnComplete(() => 
             foods[i].transform.DOScale(firstScale, 0.1f));
            yield return new WaitForSeconds(0.1f);
        }
    }
}
