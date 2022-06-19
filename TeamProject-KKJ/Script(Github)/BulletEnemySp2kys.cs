using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemySp2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstaclePrefab;
    public float interval;

    IEnumerator Start()
    {
        while (true)
        {

            float Rnd = Random.Range(-75f, 75f);
            float rnd = Random.Range(-75f, 75f);
            this.transform.position = new Vector3(Rnd, 1.0f, rnd);
            Instantiate(obstaclePrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(interval);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
