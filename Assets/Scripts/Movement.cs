using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Collection collectionScript;
    [HideInInspector] public bool MoveByTouch, StartTheGame;
    private Vector3 mouseStartPos, PlayerStartPos;
    [SerializeField] public float leftRightSpeed, RoadSpeed;
    [SerializeField] GameObject Road;
    static Movement MovementInstance;
    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        collectionScript = gameObject.GetComponent<Collection>();
        MovementInstance = this;
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {     
        if (Input.GetMouseButtonDown(0))
        {
            StartTheGame = MoveByTouch = true;
        } 

        if (Input.GetMouseButtonUp(0)) 
        {
            MoveByTouch = false;
        }

        if (MoveByTouch)
        {
            var plane = new Plane(Vector3.up, 0f);
            
            float distance;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(plane.Raycast(ray, out distance))
            {
                Vector3 mousePos = ray.GetPoint(distance);
                Vector3 desirePso = mousePos - mouseStartPos;
                Vector3 move = PlayerStartPos + desirePso;

                move.x = Mathf.Clamp(move.x, -10f, 10f);
                move.z = -7f;

                var player = transform.position;

                player = new Vector3(Mathf.Lerp(player.x, move.x, Time.deltaTime * leftRightSpeed), player.y, player.z);

                transform.position = player;
            }
        }

        if (StartTheGame)
        {
            Road.transform.Translate(Vector3.forward * (RoadSpeed * -1 * Time.deltaTime));
        }          
    }

    private void LateUpdate() 
    {
        if (StartTheGame)
        {
            mainCam.transform.position = new Vector3(Mathf.Lerp(mainCam.transform.position.x, transform.position.x, (leftRightSpeed - 5f) * Time.deltaTime), mainCam.transform.position.y, mainCam.transform.position.z);
        }    
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Collect"))
        {
            other.transform.parent = null;
            other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<Collider>().isTrigger = true;
            other.tag = gameObject.tag;
            collectionScript.Foods.Add(other.transform);
        }   
    }

}