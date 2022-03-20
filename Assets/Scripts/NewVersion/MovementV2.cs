using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementV2 : MonoBehaviour
{
    [SerializeField] float swipeSpeed;
    [SerializeField] float moveSpeed;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;    
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            Move();
        }    
    }

    private void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;

        Ray ray = cam.ScreenPointToRay(mousePos);

        RaycastHit hit;
        //if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //{
            //GameObject firstObject = ATMRush.instance.foods[0];
            //Vector3 hitVec = hit.point;
            //hitVec.y = firstObject.transform.localPosition.y;
            //hitVec.z = firstObject.transform.localPosition.z;

            //firstObject.transform.localPosition = Vector3.MoveTowards(firstObject.transform.localPosition, hitVec, Time.deltaTime * swipeSpeed);
        //}
    }
}
