using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public GameObject appendAt;
    public float verticalHeight;
    public float scrollSpeed;

    private Vector3 startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
       startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float ypos = transform.position.y - scrollSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, ypos, transform.position.z); 
        if (transform.position.y <= -10)
        {
            Debug.Log("GameObject" + gameObject.name);
            transform.position = new Vector3(appendAt.transform.position.x, appendAt.transform.position.y + verticalHeight, appendAt.transform.position.z);
        }
    }
}
