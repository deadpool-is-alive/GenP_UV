using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class parta : MonoBehaviour
{


    Vector3[] vertices;
    public int horizontal = 100;
    public int vertical = 100;

    int[] triangles;

    // float scale = 5f;
    Color[] colors;

    public float scale = 20f;
    public float width = 10f;
    public float height = 10f;

    public Gradient gradient;

    float minTerrainHeight;
    float maxTerrainHeight;
    Mesh mesh;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        
        //UpdateMesh();
        //StartCoroutine(CreateShape());
        
    }

    private void Update()
    {
        CreateShape();
        UpdateMesh();
    }
    /*private void Update()
    {
        UpdateMesh();
    }*/
    void CreateShape()
    {
        // Define the no of vertices which is equal to horizontal * vertical points
        vertices = new Vector3[horizontal * vertical];
        
        colors = new Color[vertices.Length];
        // intialize index for vertices array
        int index = 0;

        // Double for loop for adding every vertice to the vertices array
        for (int k = 0; k < vertical; k++)
        {
            for (int i = 0; i < horizontal; i++)
            {


                float y = Mathf.PerlinNoise( (float)i / width , (float) k / height ) * scale;
                vertices[index] = new Vector3(i, y, k);

                if( y> maxTerrainHeight)
                    maxTerrainHeight = y;
                if( y < minTerrainHeight)
                    minTerrainHeight = y;
                index++;
            }
        }


        int size = (horizontal - 1) * (vertical - 1) * 6;
        triangles = new int[size];


        index = 0;


            for (int i = 0; i < horizontal * (vertical - 1); i++)
            {

                if ((i + 1) % (horizontal) == 0)
                { continue; }

                // Here we are making 1 square, more precise 2 triangles from one vertex


                // Triangle 1
                triangles[index++] = i;
                triangles[index++] = i + horizontal;
                triangles[index++] = i + 1;

                // Triangle 2
                triangles[index++] = i + 1;
                triangles[index++] = i + horizontal;
                triangles[index++] = i + 1 + horizontal;
         
            // yield return new WaitForSeconds(.1f);
        }

        index = 0;
        for (int k = 0; k < vertical; k++)
        {
            for (int i = 0; i < horizontal; i++)
            {
                float height = Mathf.InverseLerp(minTerrainHeight, maxTerrainHeight, vertices[index].y);
                colors[index] = gradient.Evaluate(height);
                index++;
            }
        }


    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;

        mesh.RecalculateNormals();
    }


}