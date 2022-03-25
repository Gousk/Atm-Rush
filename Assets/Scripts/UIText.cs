using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIText : MonoBehaviour
{
    GameObject player;
    Collection collectionRef;
    TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        collectionRef = player.GetComponent<Collection>();
        scoreText = gameObject.GetComponent<TMP_Text>();   
    }

    // Update is called once per frame
    void Update()
    {     
        scoreText.text = "Score <" + collectionRef.score.ToString() + ">";         
    }
}
