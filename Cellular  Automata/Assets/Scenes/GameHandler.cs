using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public Material material;
    // Start is called before the first frame update
    private void Start()
    {
       


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



    }

 
}
