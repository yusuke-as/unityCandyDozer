using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestroyer : MonoBehaviour
{
    public CandyHolder candyHolder;
    public int reward;
    public GameObject effectPrefab;
    public Vector3 effectRotation;
    int dropCount;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Candy")
        {
            candyHolder.AddCandy(reward);
            Destroy(other.gameObject);
            if (effectPrefab != null)
            {
                Instantiate(
                    effectPrefab,
                    other.transform.position,
                    Quaternion.Euler(effectRotation)
                    //Quaternion.LookRotation(Vector3.up)
                    );
                dropCount++;
            }
            
        }
    }
    void OnGUI()
    {
        GUI.color = Color.black;       
        string label = $"落としたキャンディー:{dropCount}";
        
        GUI.Label(new Rect(0, 30, 300, 30), label);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
