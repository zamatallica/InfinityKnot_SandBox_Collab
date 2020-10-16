using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class sc_aurora_wave_mesh : MonoBehaviour
{
    Mesh auroraMesh;
    Vector3[] auroraVerts;
    MeshCollider auroraMCollider;


    public float SinValue;
    //public float SinSpeed;


    // Start is called before the first frame update
    void Start()
    {
        auroraMesh = GetComponent<MeshFilter>().mesh;
        auroraVerts = auroraMesh.vertices;
        auroraMCollider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < auroraVerts.Length; i++)
        {
            auroraVerts[i].y = Mathf.Sin(SinValue * i + Time.time);

        }

        auroraMesh.vertices = auroraVerts;
        auroraMesh.RecalculateBounds();
        auroraMCollider.sharedMesh = auroraMesh;

    }
}
 