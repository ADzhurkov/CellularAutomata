using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    private Grid grid;
   
    private void Start(){
       grid = new Grid(50,50, 1f, new Vector3(0, 0));
      
    }

    private void Update(){
        if (Input.GetKey("q"))
        {
            grid.Loop();
        }
        if(Input.GetMouseButtonDown(0)){
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 2);

        }
        if(Input.GetMouseButtonDown(1)){
            // Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
            int x;
            int y;
            grid.GetXY(UtilsClass.GetMouseWorldPosition(),out x,out y);
            grid.ExecuteRule2(grid.Rule2(x,y),x,y);
        }
        
    }
}
