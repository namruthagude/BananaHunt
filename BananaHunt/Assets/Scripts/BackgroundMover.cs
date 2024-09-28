using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public GameObject prefab;
    public float verticalHeight;
    public float scrollSpeed;

    private Vector3 startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Instantiate(prefab, new Vector3(transform.position.x , transform.position.y + verticalHeight , transform.position.z), Quaternion.identity);   
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, verticalHeight);
        transform.position = startPosition + Vector3.down * newPosition;
        if (transform.position.y <= -20)
        {
            Destroy(this.gameObject);
        }
    }
}
