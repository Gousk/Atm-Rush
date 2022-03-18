using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Collection : MonoBehaviour
{
    Movement movementScript;
    [SerializeField] float Distance;
    public List<Transform> Foods = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        movementScript = gameObject.GetComponent<Movement>();
        Foods.Add(gameObject.transform);      
    }

    // Update is called once per frame
    void Update()
    {
        if (Foods.Count > 1)
        for (int i = 1; i < Foods.Count; i++)
        {
            var FirstFood = Foods.ElementAt(i - 1);
            var SecFood = Foods.ElementAt(i);

            var DesireDistance = Vector3.Distance(SecFood.position, FirstFood.position);

            if (DesireDistance <= Distance)
            {
                SecFood.position = new Vector3(Mathf.Lerp(SecFood.position.x, FirstFood.position.x, movementScript.leftRightSpeed * Time.deltaTime), SecFood.position.y, Mathf.Lerp(SecFood.position.z, FirstFood.position.z + 0.5f, movementScript.leftRightSpeed * Time.deltaTime));
            }
        }
    }
}
