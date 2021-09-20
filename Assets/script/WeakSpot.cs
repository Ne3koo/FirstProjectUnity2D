using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destruction des parents du collider détruit
        if(collision.CompareTag("Player"))
        {
            Destroy(objectDestroy);
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
