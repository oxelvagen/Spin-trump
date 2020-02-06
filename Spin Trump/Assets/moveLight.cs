using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLight : MonoBehaviour
{
    Vector3 originalPos;
    public float lightSpeed = 8f;
    public float resetOffset = 100f;
    void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * lightSpeed));
        transform.Translate(Vector3.down * (Time.deltaTime * lightSpeed));
        if (transform.position.x > resetOffset)
        {
            gameObject.transform.position = originalPos;
        }
    }
}
