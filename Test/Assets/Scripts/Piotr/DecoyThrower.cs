using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyThrower : MonoBehaviour
{
    public float throwForce = 30f;
    public GameObject Decoy;
    public GameObject[] enemies;
    public float timer;
    public float time=10f;

    private void Start()
    {
        time = 10f;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.G))
        {
            
            if (timer>=time)
            {
                ThrowDecoy();
                timer = 0f;
            }
            

        }
    }
    void ThrowDecoy()
    {
        GameObject decoy= Instantiate(Decoy, transform.position, transform.rotation);        
        Rigidbody rb = decoy.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        decoy.gameObject.tag = "Decoy";
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<GuardDetection>().decoy = decoy.transform;
        }
    }
    
}
