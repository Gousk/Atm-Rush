using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool MoveByTouch, StartTheGame;
    private Vector3 mouseStartPos, PlayerStartPos;
    [SerializeField] public float leftRightSpeed, RoadSpeed;
    [SerializeField] GameObject Road;
    [SerializeField] float Distance;
    static GameManager GameManagerInstance;
    Camera mainCam;
    
    public List<Transform> Foods = new List<Transform>();

    private void OnCollisionEnter(Collision other) {
       Debug.Log("Triggered"); 
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManagerInstance = this;
        mainCam = Camera.main;
        Foods.Add(gameObject.transform); 
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

        if (Foods.Count > 1)
        {
            for (int i = 1; i < Foods.Count; i++)
            {
                Transform element = Foods[i - 1];

                var FirstFood = Foods.ElementAt(i - 1);
                var SecFood = Foods.ElementAt(i);

                var DesireDistance = Vector3.Distance(SecFood.position, FirstFood.position);

                if (DesireDistance <= Distance)
                {
                    SecFood.position = new Vector3(Mathf.Lerp(SecFood.position.x, FirstFood.position.x, leftRightSpeed * Time.deltaTime), SecFood.position.y, Mathf.Lerp(SecFood.position.z, FirstFood.position.z + 1.5f, leftRightSpeed * Time.deltaTime));
                }
            } 
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
        if (other.tag == "Collect")
        {
            Debug.Log("Triggered");
            other.transform.parent = null;
            other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<Collider>().isTrigger = true;
            other.tag = gameObject.tag;
            Foods.Add(other.transform);
        }   
    }

    

}

