using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    Vector3 startPosition;

    public float amplitude;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //親要素に対する子要素の相対位置を取得
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float z = amplitude * Mathf.Sin(Time.time * speed);

        transform.localPosition = startPosition + new Vector3(0, 0, z);

        //trasnform.Translate(0,0,0.01f);
    }
}
