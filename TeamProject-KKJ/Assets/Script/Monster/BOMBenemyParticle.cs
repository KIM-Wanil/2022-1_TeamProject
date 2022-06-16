using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOMBenemyParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            //transform.GetComponent<MeshRenderer>().enabled = false;
            Destroy(this.gameObject,0.8f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
