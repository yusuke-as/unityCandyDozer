using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideStageMove : MonoBehaviour
{
    public float waitTime;
    Transform transForm;
    Vector3 vector;
    // Start is called before the first frame update
    void Start()
    {
        transForm = this.transform;
        vector = transForm.localScale;
        StartCoroutine(MoveStage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveStage()
    {
        while (true)
        {
            if(vector.z <= 4.0f)
            {
                for (int i = 4; i <= 16; i++)
                {
                    vector.z += 1.0f;
                    transForm.localScale = vector;
                    yield return new WaitForSeconds(waitTime);
                }
                           
            }
            if (vector.z >= 17.0f)
            {
                for(int i = 16; i >= 4; i--)
                {
                    vector.z -= 1.0f;
                    transForm.localScale = vector;
                    yield return new WaitForSeconds(waitTime/2);
                }              
            }        
        }     
    }
}
