using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartBox : MonoBehaviour
{
    [SerializeField]
    private List<Material> materials;

    private int stateNumber = 0;

    void Start()
    {
        if (stateNumber == 0)
        {
            stateNumber = Mathf.FloorToInt(Random.Range(0, materials.Count));
        }
        GetComponent<Renderer>().material = materials[stateNumber];
        if (stateNumber == 2)
        {
            WaterState();
        }
        float boxX = transform.position.x;
        float boxZ = transform.position.z;

        boxX = Mathf.Floor(boxX / 3) * 3;
        boxZ = Mathf.Floor(boxZ / 3) * 3;
        transform.position = new Vector3(boxX, transform.position.y, boxZ);

        Invoke("CheckCubes", Random.Range(0,1f));
    }
    void CheckCubes()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale / 3, Quaternion.identity);
        if(hitColliders.Length > 1 && hitColliders[1].GetComponent<SmartBox>() != null)
        {
            Destroy(gameObject);
        }
    }

    void WaterState()
    {
        transform.Translate(Vector3.up * -2f);
        GetComponent<Collider>().isTrigger = true;
    }
    void OnTriggerStay(Collider other)
    {
        Moving moving = other.GetComponent<Moving>();
        if(moving != null)
        {
            moving.SlowDown();
        }
    }
    void OnTriggerExit(Collider other)
    {
        Moving moving = other.GetComponent<Moving>();
        if (moving != null)
        {
            moving.SpeedUp();
        }
    }
    public void TryDestroy()
    {
        if(stateNumber == 1)
        {
            Destroy(gameObject);
        }
    }
    public void StayBrick()
    {
        stateNumber = 1;
    }
}
