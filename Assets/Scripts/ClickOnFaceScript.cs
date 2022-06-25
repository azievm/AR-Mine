using UnityEngine;
using System.Collections;

public class ClickOnFaceScript : MonoBehaviour {

    private Vector3 delta;

    private int BuildBool;

    private int Blocks;

    private GameObject Ground;
    private GameObject Stone;
    private GameObject Wood;
    private GameObject Glass;
    private GameObject Brick;

    private string name_str;
    private float number = 0.1f;

    void Start() {
        name_str = gameObject.name;

        if (name_str == "Top"){
            delta = new Vector3(0, number, 0);
        }
        if (name_str == "Bottom"){
            delta = new Vector3(0, -number, 0);
        }
        if (name_str == "Right"){
            delta = new Vector3(number, 0, 0);
        }
        if (name_str == "Left"){
            delta = new Vector3(-number, 0, 0);
        }
        if (name_str == "Front"){
            delta = new Vector3(0, 0, -number);
        }
        if (name_str == "Back"){
            delta = new Vector3(0, 0, number);
        }                                

        Object Ground_Object = Resources.Load("Voxel", typeof(GameObject));
        Ground = Ground_Object as GameObject;

        Object Stone_Object = Resources.Load("Stone", typeof(GameObject));
        Stone = Stone_Object as GameObject;

        Object Wood_Object = Resources.Load("Wood", typeof(GameObject));
        Wood = Wood_Object as GameObject;

        Object Glass_Object = Resources.Load("Glass", typeof(GameObject));
        Glass = Glass_Object as GameObject;    

        Object Brick_Object = Resources.Load("Brick", typeof(GameObject));
        Brick = Brick_Object as GameObject;             
    }

    void OnMouseOver() {
        BuildBool = PlayerPrefs.GetInt("BuildBool"); // Нажата ли кнопка Build
        Blocks = PlayerPrefs.GetInt("Blocks"); // Какой блок выбран

        if (Input.GetMouseButtonDown(0)) {
        	if (BuildBool == 1){
                switch (Blocks) {

                    //Ground
                    case 0:
                        WorldGenerator.CloneAndPlace(this.transform.parent.transform.position + delta, 
                                         Ground.gameObject);
                        break; 
                    //Stone 
                    case 1:
                        WorldGenerator.CloneAndPlace(this.transform.parent.transform.position + delta, 
                                         Stone.gameObject); 
                        break; 
                    //Wood    
                    case 2:
                        WorldGenerator.CloneAndPlace(this.transform.parent.transform.position + delta, 
                                         Wood.gameObject);
                        break; 

                    //Glass    
                    case 3:
                        WorldGenerator.CloneAndPlace(this.transform.parent.transform.position + delta, 
                                         Glass.gameObject); 
                        break; 
                    //Brick
                    case 4:
                        WorldGenerator.CloneAndPlace(this.transform.parent.transform.position + delta, 
                                         Brick.gameObject); 
                        break;                    
                }                                                 
        	}

        	else {
        		Destroy(this.transform.parent.gameObject);
        	}
        }
    }
}