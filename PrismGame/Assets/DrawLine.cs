using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField]
    private GameObject lineGeneratorPrefab;
    [SerializeField]
    private GameObject linePointPrefab;
    [SerializeField]
    private GameObject Spawn;
    [SerializeField]
    private GameObject Target;


    private void Start()
    {
        SpawnLineGenerator();
    }

    private void SpawnLineGenerator()
    {
        Vector3 SpawnPosition = Spawn.transform.position;
        Vector3 TargetPosition = Target.transform.position;

        GameObject newLineGen = Instantiate(lineGeneratorPrefab);
        LineRenderer lRend = newLineGen.GetComponent<LineRenderer>();

        lRend.SetPosition(0, SpawnPosition);
        lRend.SetPosition(1, TargetPosition); 
    }

}
