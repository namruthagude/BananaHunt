using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMover : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float ypos = transform.position.y - speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, ypos, transform.position.z);
        if(transform.position.y < -15)
        {
            Destroy(this.gameObject);
        }
    }
}
