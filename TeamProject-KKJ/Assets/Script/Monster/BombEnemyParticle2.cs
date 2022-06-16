using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ExpObj;
    void Start()
    {
        Destroy(gameObject, 25f);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ExpObj.SetActive(true);
            //transform.GetComponent<MeshRenderer>().enabled = false;
            Invoke("DestObj", 0.1f);
            //Destroy(this.gameObject);
        }
    }
    void DestObj()
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
