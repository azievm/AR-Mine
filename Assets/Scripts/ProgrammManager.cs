using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ProgrammManager : MonoBehaviour
{
    [Header("Put your planeMarker here")]
    [SerializeField] private GameObject ObjectPrefab;

    private ARRaycastManager ARRaycastManagerScript;
    
    private bool isClick = false;
    private bool isButtonClick = false;

    public Transform parent;

    public GameObject ToPutButtonObject;
    public GameObject TextHelp;

    void Start()
    {
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();

        ObjectPrefab.SetActive(false);
    }

    void Update()
    {
        // Присваиваем родителя всем блокам
    	GameObject[] objects = GameObject.FindGameObjectsWithTag("VOXEL");

		for (int i = 1; i < objects.Length;  i++) {
			GameObject object_voxel = objects[i];

			object_voxel.transform.SetParent(parent);
		}
        // Присваиваем родителя всем блокам


        // Проверка нажата ли кнопка, если нет, то вызываем функцию
    	if (isClick == false){
            SetObject();
    	}
        // Проверка нажата ли кнопка, если нет, то вызываем функцию
    }

    public void ToPutButton(){
        isButtonClick = true;
        isClick = true;
        ToPutButtonObject.SetActive(false);
        TextHelp.SetActive(false);
    }

    // Установка объекта
    void SetObject()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            ObjectPrefab.transform.position = hits[0].pose.position;
            ObjectPrefab.SetActive(true);
        }
       	
        if ((isButtonClick == true) &&(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began))
        {
        	isClick = true;
        }
    }
    // Установка объекта

}