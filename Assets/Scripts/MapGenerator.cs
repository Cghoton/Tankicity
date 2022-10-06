using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject SmartBox;

    [SerializeField]
    private GameObject FirstAid;

    [SerializeField]
    private NavMeshSurface Surface;

    [SerializeField]
    private int GenerateCount = 50;

    private void Awake()
    {
        Generator(SmartBox, GenerateCount);
        Generator(FirstAid, 5);
    }

    void Generator(GameObject _gm, int _loopAmount)
    {
        for (int i = 0; i < _loopAmount; i++)
        {
            Instantiate(_gm, transform.position + new Vector3(Random.Range(1, 50f), 0, Random.Range(1, 50f)), transform.rotation);
        }
        Surface.BuildNavMesh();
    }
}
