using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPackSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float interval;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            //float rnd = Random.Range(0.0f, 20.0f); // 0.0~5.0 사이의 난수를 만들어낸다
            //
            float Rnd = Random.Range(-250f, 250f);
            float rnd = Random.Range(-250f, 250f);
            this.transform.position = new Vector3(Rnd, 1.0f, rnd);
            Instantiate(obstaclePrefab, transform.position, transform.rotation);

          
            yield return new WaitForSeconds(interval);
        }
    }
}
