using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMonsterSP4 : MonoBehaviour
{
    public GameObject obstaclePrefab;
    bool levelcheck;
    bool spawn;
    Player player;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void Start()
    {
        levelcheck = false;
        spawn = false;
    }
    void Update()
    {
        if(player.level == 10)
        {
            levelcheck = true;
        }

        if(spawn == false && levelcheck)
        {
            float Rnd = Random.Range(-75f, 75f);
            float rnd = Random.Range(-75f, 75f);
            this.transform.position = new Vector3(Rnd, 1.0f, rnd);
            Instantiate(obstaclePrefab, transform.position, transform.rotation);
            spawn = true;
        }
    }
}

