using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadMesh
{
    private Material material;
    
    public QuadMesh()
    {

        //Vector3 Position, Vector3 Diagonal


        //Vector3 Start = new Vector3(x, y);

        //VectorCalc(float CellSize, Vector3 worldPosition);
        //Vector3 Diagonal = new Vector3(x + CellSize, y + CellSize);
        Debug.Log("Test Constructur?");
        /*
        
        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = new Vector3(0, 0);
        vertices[1] = new Vector3(0, 1);
        vertices[2] = new Vector3(1, 1);
        vertices[3] = new Vector3(1, 0);

        uv[0] = new Vector2(0, 0);
        uv[0] = new Vector2(0, 1);
        uv[0] = new Vector2(1, 1);
        uv[0] = new Vector2(1, 0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        Debug.Log("Test Handler");
        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;


        GameObject gameObject = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));

        gameObject.transform.localScale = new Vector3(30, 30, 1);
        gameObject.GetComponent<MeshFilter>().mesh = mesh;

        gameObject.GetComponent<MeshRenderer>().material = material;

        */
    }
    public void CreateMesh(Vector3 Start, Vector3 Diag)
    {
        
        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = Start;
        vertices[1] = new Vector3(Start.x, Diag.y);
        vertices[2] = Diag;
        vertices[3] = new Vector3(Diag.x, Start.y);

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 0.5f);
        uv[2] = new Vector2(0.25f, 0.5f);
        uv[3] = new Vector2(0.25f, 0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        Debug.Log("Test Handler");
        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;


        GameObject gameObject = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));

        //gameObject.transform.localScale = new Vector3(Diag.x-Start.x,Diag.y-Start.y, 1);
        //gameObject.transform.position = new Vector3(Start.x, Start.y, -1);
        gameObject.transform.position += new Vector3(0, 0, -1);

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        material = Resources.Load("1", typeof(Material)) as Material;
        gameObject.GetComponent<MeshRenderer>().material = material;

    }
}
    