using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemySp2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstaclePrefab;
    public float interval;
    bool waitdelay;
    float delay;
    float time;
    Player player;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void Start()
    {
        delay = interval;
        time = 0;
        waitdelay = false;
    }
    void Update()
    {
        time += Time.deltaTime;
        if (player.level >= 3)
        {
            if (waitdelay)
            {
                StartCoroutine("Spawn");
                waitdelay = false;
            }
            else if (waitdelay == false)
            {
                if (delay <= time)
                {
                    waitdelay = true;
                    time = 0;
                }
            }
        }
    }

    IEnumerator Spawn()
    {
        float Rnd = Random.Range(-75f, 75f);
        float rnd = Random.Range(-75f, 75f);
        this.transform.position = new Vector3(Rnd, 1.0f, rnd);
        Instantiate(obstaclePrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.5f);
    }
}
