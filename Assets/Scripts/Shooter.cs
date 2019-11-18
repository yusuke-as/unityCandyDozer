using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    const int SphereCandyFrequency = 3;
    const int MaxShotPower = 5;
    const int RecoverySeconds = 3;
    int sampleCandyCount;
    int shotPower = MaxShotPower;
    AudioSource shotSound;
    public GameObject[] candyPrefabs;
    public GameObject[] candySquarePrefabs;
    public CandyHolder candyHolder;
    public float shotSpeed;
    public float shotTorque;
    public float baseWidth;
    // Start is called before the first frame update
    void Start()
    {
        shotSound = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shot();
    }

    GameObject SampleCandy()
    {
        GameObject prefab = null;

        if (sampleCandyCount % SphereCandyFrequency == 0)
        {
            int index = Random.Range(0, candyPrefabs.Length);
            prefab = candyPrefabs[index];
        }
        else
        {
            int index = Random.Range(0, candyPrefabs.Length);
            prefab = candySquarePrefabs[index];
        }

        sampleCandyCount++;
        return prefab;
    }
    
    Vector3 GetInstantiatePosition()
    {
        float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);
    }

    void Shot()
    {
        if (candyHolder.GetCandyAmount() <= 0)
        {
            return;
        }
        if (shotPower <= 0)
        {
            return;
        }
        
        int n = Random.Range(1, 11);
        Debug.Log(n);
        //①何を ②どこに ③どの向きで
        if (n == 1)
        {
            for (int i = 0; i < 2; i++)
            {
                InstantiateCandy();
            }
        }else
        {
            InstantiateCandy();
        }        

        candyHolder.ConsumeCandy();
        ConsumePower();

        shotSound.Play();
    }
    void InstantiateCandy()
    {
        GameObject candy = (GameObject)Instantiate(
                  SampleCandy(),
                  GetInstantiatePosition(),
                  Quaternion.identity);
        //動的に親子関係を生成
        candy.transform.parent = candyHolder.transform;

        Rigidbody candyRigidbody = candy.GetComponent<Rigidbody>();
        //z軸の正方向が前。なのでtransform.forwardで前向きに。
        candyRigidbody.AddForce(transform.forward * shotSpeed);
        candyRigidbody.AddTorque(new Vector3(0, shotTorque, 0));
    }

    private void OnGUI()
    {
        GUI.color = Color.black;
        string label = "";
        for(int i = 0; i < shotPower; i++)
        {
            label = label + "+";
        }
        GUI.Label(new Rect(0, 15, 100, 30), label);
    }
    void ConsumePower()
    {
        shotPower--;
        StartCoroutine(RecoverPower());
    }
    IEnumerator RecoverPower()
    {
        yield return new WaitForSeconds(RecoverySeconds);
        shotPower++;
    }
}
