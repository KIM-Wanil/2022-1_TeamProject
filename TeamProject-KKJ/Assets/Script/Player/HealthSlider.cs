using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthSlider : MonoBehaviour
{
    public Slider healthBarSlider;
    // Start is called before the first frame update
    void Start()
    {
        //healthBarSlider.value -= .001f;
        if (healthBarSlider.value == 0)
        {
            SceneManager.LoadScene("Failure");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBarSlider.value == 0)
        {
            SceneManager.LoadScene("Failure");
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy" && healthBarSlider.value > 0)
        {
            healthBarSlider.value -= 0.0111f;
        }
        if (collision.gameObject.tag == "BombEnemy" && healthBarSlider.value > 0)
        {
            healthBarSlider.value -= 0.0051f;
        }
        if (collision.gameObject.tag == "Health")
        {
            healthBarSlider.value += 0.01f;
  
        }
        

        if (healthBarSlider.value == 0)
        {
            SceneManager.LoadScene("Failure");
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "BigEnemy")
        {
            healthBarSlider.value -= 0.1061f;

        }
    }
}
