using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject ExpObj;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 25f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            ExpObj.SetActive(true);
            transform.GetComponent<MeshRenderer>().enabled = false;
            Invoke("DestObj", 0.1f);
            //Destroy(this.gameObject);
        }
    }
    void DestObj()
    {
        Destroy(this.gameObject);
    }
}
