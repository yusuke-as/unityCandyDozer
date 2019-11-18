using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    float x;
    float y;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        //coroutineは同時起動可能！
        //StartCoroutine(RotateCube());
        //StartCoroutine(RotateCube());
        //StartCoroutine(RotateCube());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            StartCoroutine(RotateCube());
          
        }
        transform.Rotate(x,y,z);
    }

    IEnumerator RotateCube()
    {
        for(int i = 0; i < 3; i++)
        {
            y += 1.0f;
            yield return new WaitForSeconds(1.0f);
        }
        y = 0;

        /*
        x = 1.0f;
        yield return new WaitForSeconds(2.0f);
        x = 0;
        y = 1.0f;
        yield return new WaitForSeconds(3.0f);
        y = 0;
        z = 1.0f;
        */
    }
}
