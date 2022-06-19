using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPack : MonoBehaviour
{
    public GameObject ExpObj;
    public GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 25f);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Effect.SetActive(false);
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
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100f);
    }
}
