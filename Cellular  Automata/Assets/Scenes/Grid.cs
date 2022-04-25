using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid {
private int width;
private int height;
private float CellSize;
private Vector3 originPosition;

private int[,] gridArray;
private int[,] gridArraySave;
List<Mesh> MeshList;
private TextMesh[,] debugTextArray;
    private Mesh[,] MeshArray;

   // private Mesh[] ArrayList[int,int] MeshArray;
private Material material;

public Grid(int width,int height, float CellSize, Vector3 originPosition){
    this.width = width;
    this.height = height;
    this.CellSize = CellSize;
    this.originPosition = originPosition;
   

    gridArray = new int[width,height];
    gridArraySave = new int[width, height];
    debugTextArray = new TextMesh[width,height];
    MeshArray = new Mesh[width, height];
    MeshList = new List<Mesh>(width*height);
        //quadMesh = new QuadMesh();
        int i = 0;
    for (int x = 0; x < gridArray.GetLength(0); x++){
        for(int y = 0; y < gridArray.GetLength(1); y++){
                // debugTextArray[x,y] = UtilsClass.CreateWorldText(gridArray[x,y].ToString(), null, GetWorldPosition(x, y) + new Vector3(CellSize, CellSize)*0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                //Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x, y + 1), Color.white,100f);
                //Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x + 1 ,y), Color.white,100f);
                
                
                int index = x*height + y;
                MeshList[index] = CreateMesh(x, y);
                Debug.Log("Index: " + index);
                //MeshArray[x,y] = CreateMesh(x, y);
                CreateGameObject(MeshList[index]);
                //CreateGameObject(MeshArray[x,y]);
                //i++;
               // CheckRule1(x, y);
              // Debug.Log(CheckRule1(x ,y));
            }
        }
    //Debug.DrawLine(GetWorldPosition(0,height), GetWorldPosition(width, height), Color.white,100f);
    //Debug.DrawLine(GetWorldPosition(width,0), GetWorldPosition(width ,height), Color.white,100f);

    }
  private Vector3 GetWorldPosition(int x, int y){
      return new Vector3(x, y) * CellSize + originPosition;
  }
  public void GetXY(Vector3 worldPosition, out int x, out int y){
      x = Mathf.FloorToInt((worldPosition - originPosition).x / CellSize);
      y = Mathf.FloorToInt((worldPosition - originPosition).y / CellSize);
      
  }

  public void SetValue(int x, int y, int value){
        if (value == 1 || value == 2)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
               
                if (gridArray[x, y] == value)
                {
                    return;
                }
                else
                {
                    gridArray[x, y] = value;
                    if (value == 2)
                    {
                        MeshArray[x, y].uv = BlackUVs();
                    }
                    if (value == 1)
                    {
                        MeshArray[x, y].uv = WhiteUVs();
                    }
                }
                //debugTextArray[x, y].text = gridArray[x, y].ToString();
            }
        }
  }
  public void SetValue(Vector3 worldPosition, int value){
      int x, y;

      GetXY(worldPosition, out x, out y);
      SetValue(x,y,value);
    
  }
  public int GetValue(int x, int y){
        if(x>=0 && x<width && y>=0 && y< height){
         
            Debug.Log(MeshArray[x, y].uv[0]);
            Debug.Log(MeshArray[x, y].uv[1]);
            Debug.Log(MeshArray[x, y].uv[2]);
            Debug.Log(MeshArray[x, y].uv[3]);
            return gridArray[x, y];
        }
      else
      {
          return -1;
      }
  }
  public int GetValue(Vector3 worldPosition){
      int x, y;
      GetXY(worldPosition, out x, out y);
      return GetValue(x, y);

  }
  
    public Mesh CreateMesh(int x, int y)
    {
        Vector3 Start = GetWorldPosition(x, y);
        Vector3 Diag = GetWorldPosition(x + 1, y + 1);
        Vector3[] vertices = new Vector3[4];
        
        int[] triangles = new int[6];

        vertices[0] = Start;
        vertices[1] = new Vector3(Start.x, Diag.y);
        vertices[2] = Diag;
        vertices[3] = new Vector3(Diag.x, Start.y);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        
        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        int weightedRandomNr = Random.Range(1, 100);

        if (weightedRandomNr < 99) { 
            mesh.uv = WhiteUVs();
            gridArray[x, y] = 1;
        }
        else {
            mesh.uv = BlackUVs();
            gridArray[x, y] = 2;
        }
        return mesh;
    }
    public void CreateGameObject(Mesh mesh)
    {
        GameObject gameObject = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));

      
        gameObject.transform.position += new Vector3(0, 0, -1);

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        material = Resources.Load("1", typeof(Material)) as Material;
        gameObject.GetComponent<MeshRenderer>().material = material;
    }
    public Vector2[] BlackUVs()
    {
        Vector2[] uv = new Vector2[4];
        uv[0] = new Vector2(0.5f, 0);
        uv[1] = new Vector2(0.5f, 1);
        uv[2] = new Vector2(1, 1);
        uv[3] = new Vector2(1, 0);
        return uv;
    }
    public Vector2[] WhiteUVs()
    {
        Vector2[] uv = new Vector2[4];
        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 0.5f);
        uv[2] = new Vector2(0.5f, 0);
        uv[3] = new Vector2(0.5f, 0.5f);
        return uv;
    }
    public bool CheckRule1(int x, int y)
    {
        if (x> 0 && x< width)
        {
            if ((gridArray[x, y] == 2) && (gridArray[x - 1, y] == 2) && (gridArray[x+1,y] == 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public void ExecuteRule1(bool Rule, int x, int y)
    {
        if(Rule == true)
        {
            SetValue(x, y, 1);
        }
   
    }
    public void Loop()
    {

        // create new grid with old data
        //
        gridArraySave = (int[,]) gridArray.Clone();
        // save old data to new grid
        //gridArraySave = gridArray;
        

        for (int x = 0; x < gridArraySave.GetLength(0); x++)
        {
            for (int y = 0; y < gridArraySave.GetLength(1); y++)
            {
                
                
                // use old data in this function 
                ExecuteRule2(Rule2(x, y), x,y);
            }
                    
        }
    }
    public int Rule2(int x, int y)
    {
        int blackCount = 0;
        
        //Mathf.Clamp(x, 1, width - 1);
        //Mathf.Clamp(y, 1, height - 1);
        if (x > 1 && x < width-1 && y > 1 && y < height- 1)
        {

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (gridArraySave[i, j] == 2)
                    {
                        blackCount++;
                    }
                }
            }
            if (gridArraySave[x, y] == 2) { blackCount += -1 ; }
        }

        return blackCount;            
    }
    public void ExecuteRule2(int blackCount, int x, int y)
    {
        
        if(blackCount == 2 || blackCount == 3)
        {
            Debug.Log("Set to black: " + blackCount);
            SetValue(x, y, 2);
        }
        else
        {
            Debug.Log("Set to white: " + blackCount);
            SetValue(x, y, 1);
        }
        Debug.Log("Out of loop:" + blackCount);
    }
}
