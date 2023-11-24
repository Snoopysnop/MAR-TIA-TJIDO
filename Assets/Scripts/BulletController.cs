using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerController>().GotHit();
        //Destroy(this.gameObject, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
