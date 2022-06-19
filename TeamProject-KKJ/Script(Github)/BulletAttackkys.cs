using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttack : MonoBehaviour
{
    [SerializeField] private GameObject go_BulletPrefab;
    private float createTime = 1f;
    private float currentCreateTime = 0;
 
  
    // Update is called once per frame
    void Update()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, 30f);
        if (col.Length > 0)
        {
            for (int i = 0; i < col.Length; i++)
            {
                Transform tf_Target = col[i].transform;

                if (tf_Target.tag == "Player")
                {
                    Quaternion rotation = Quaternion.LookRotation(tf_Target.position - transform.position);
                    transform.rotation = rotation;
                    currentCreateTime += Time.deltaTime;
                    if (currentCreateTime >= createTime)
                    {
                        Instantiate(go_BulletPrefab, transform.position, rotation);
                        currentCreateTime = 0;
                    }
                }
            }
        }
    }
}
