using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollider : MonoBehaviour
{
    [SerializeField] GameObject player;
    Collection collectionS;

    void Start() 
    {
        collectionS = player.GetComponent<Collection>();
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.name == "Collectible")
        {
            collectionS.Foods.Remove(other.transform);
            Destroy(other.gameObject, 0f);

            if (other.transform.GetChild(0).GetComponent<Renderer>().enabled == true)
            {
                if(!other.transform.GetChild(3).GetComponent<ParticleSystem>().isPlaying) other.transform.GetChild(3).GetComponent<ParticleSystem>().Play();
            }
            if (other.transform.GetChild(1).GetComponent<Renderer>().enabled == true)
            {
                if(!other.transform.GetChild(4).GetComponent<ParticleSystem>().isPlaying) other.transform.GetChild(4).GetComponent<ParticleSystem>().Play();                 
            } 
            if (other.transform.GetChild(2).GetComponent<Renderer>().enabled == true)
            {
                if(!other.transform.GetChild(5).GetComponent<ParticleSystem>().isPlaying) other.transform.GetChild(5).GetComponent<ParticleSystem>().Play();        
            }  
        }   
    }  
}
