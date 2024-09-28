using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject[] collectables;
    public float timeGap;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
             
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeGap)
        {
            timer = 0;
            int ind = Random.Range(0, collectables.Length);
            Instantiate(collectables[ind], transform.position, Quaternion.identity, transform);
        }
    }
}
