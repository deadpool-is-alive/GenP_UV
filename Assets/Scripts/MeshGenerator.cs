using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class MeshGenerator : MonoBehaviour
{
    Vector3[] vertices = new Vector3[10000];
    public int horizontal = 100;
    public int vertical = 100;
    
    int[] triangles;

    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    // This piece of code renders the height and width you given by to the 
    /* void CreateShape()
    {
        *//*vertices = new Vector3[15]
        {
            new Vector3(0,0,0),
            new Vector3(0,0,1),
            new Vector3(1,0,0),
            new Vector3(1,0,1)
        };
        vertices[3] = new Vector3(1, 0, 1);*//*
        int index = 0;
        for (int k = 0; k < vertical; k++)
        {
            for (int i = 0; i < horizontal; i++)
            {
                vertices[index] = new Vector3(i, 0, k);
                index++;
            }
        }
        int size = (horizontal - 1) * (vertical - 1) * 6;
        triangles = new int[size];
        *//*triangles = new int[]
        {
            0,1,2,
            1,3,2
        };*/
        /*index = 0;
        for (int i = 0; i < horizontal * (vertical-1)  ; i++)
        {   
            if( (i + 1) % (horizontal) == 0)
            { continue; }


            triangles[index++] = i;
            triangles[index++] = i + horizontal;
            triangles[index++] = i + 1;

            triangles[index++] = i + 1;
            triangles[index++] = i + horizontal;
            triangles[index++] = i + 1 + horizontal;
        }
    }*/

    void CreateShape()
    {
        /*vertices = new Vector3[]
        {
            new Vector3 (0, 0, 0),
            new Vector3 (0, 0, 1),
            new Vector3 (1, 0, 0),
            new Vector3 (0, 1, 0),
            new Vector3 (1, 0, 1),
            new Vector3 (0, 1, 1),
            new Vector3 (1, 1, 0),
            new Vector3 (1, 1, 1)
        };

        triangles = new int[]
        {
            // bottom x-z
            0,1,2,
            1,4,2,
            // front x-y
            0,3,6,
            0,6,2,
            // side y-z
            0,1,3,
            3,1,5,
            //another side y-z
            2,6,4,
            6,7,4,
            // anther back x-y
            7,5,1,
            4,7,1,
            // ceil x-z
            7,5,3,
            3,6,7
        };*/

        /*vertices = new Vector3[]
        {
            new Vector3 (0, 10, 0),
            new Vector3 (10, 0, 0),
            new Vector3 (-5, 0, 8),
            new Vector3 (-5, 0 , -8)

        };

        triangles = new int[]
        {
            0,2,1,
            0,3,2,
            0,1,3,
            1,2,3
        };*/

        vertices = new Vector3[]
        {
            new Vector3 (0, 0, 10),
            new Vector3 (0, 0, -10),
            new Vector3 (3, 4, 8),
            new Vector3 (3, 4, -8),
            new Vector3 (-3, 4, 8),
            new Vector3 (-3, 4, -8),
            new Vector3 (0, 5, 12),
            new Vector3 (0, 5, -12)
        };

        triangles = new int[]
        {
            0,4,1,
            1,4,5,
            3,2,0,
            0,1,3,
            1,5,7,
            0,6,4,
            0,2,6,
            1,7,3,


        };
    }
    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
    
}
