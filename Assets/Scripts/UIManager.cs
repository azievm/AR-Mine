using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public GameObject MenuBlocks;
	
    public GameObject BuildImage;
    public GameObject DigImage;

    private bool isClick = false;

    private int old_block = 0;

    public GameObject[] Blocks_UI; 

    // Кнопки выбора блока

    public void Ground(){
    	PlayerPrefs.SetInt("Blocks", 0);

        Blocks_UI[old_block].GetComponent<Image>().color = new Color(0.454902f, 0.454902f, 0.454902f);
        Blocks_UI[0].GetComponent<Image>().color = new Color(0.3018868f, 0.2862228f, 0.2862228f);
    
        old_block = 0;
    }

    public void Stone(){
    	PlayerPrefs.SetInt("Blocks", 1);

        Blocks_UI[old_block].GetComponent<Image>().color = new Color(0.454902f, 0.454902f, 0.454902f);
        Blocks_UI[1].GetComponent<Image>().color = new Color(0.3018868f, 0.2862228f, 0.2862228f);        
    
        old_block = 1;
    }

    public void Wood(){
    	PlayerPrefs.SetInt("Blocks", 2);

        Blocks_UI[old_block].GetComponent<Image>().color = new Color(0.454902f, 0.454902f, 0.454902f);
        Blocks_UI[2].GetComponent<Image>().color = new Color(0.3018868f, 0.2862228f, 0.2862228f);        
    
        old_block = 2;
    }

    public void Glass(){
    	PlayerPrefs.SetInt("Blocks", 3);

        Blocks_UI[old_block].GetComponent<Image>().color = new Color(0.454902f, 0.454902f, 0.454902f);
        Blocks_UI[3].GetComponent<Image>().color = new Color(0.3018868f, 0.2862228f, 0.2862228f);        
    
        old_block = 3;
    }

    public void Brick(){
        PlayerPrefs.SetInt("Blocks", 4);

        Blocks_UI[old_block].GetComponent<Image>().color = new Color(0.454902f, 0.454902f, 0.454902f);
        Blocks_UI[4].GetComponent<Image>().color = new Color(0.3018868f, 0.2862228f, 0.2862228f);        
    
        old_block = 4;
    }

    // Кнопки выбора блока


    // Кнопки строительства
    public void Build(){
    	PlayerPrefs.SetInt("BuildBool", 1);

    	BuildImage.transform.localScale = new Vector3(1f, 1f, 1f);
    	DigImage.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }

    public void Dig(){
    	PlayerPrefs.SetInt("BuildBool", 0);

    	DigImage.transform.localScale = new Vector3(1f, 1f, 1f);
    	BuildImage.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }
    // Кнопки строительства

    // Кнопка бургер
    public void Menu(){
    	Debug.Log("YES");
    	if (isClick == false){
    		MenuBlocks.SetActive(true);
    		isClick = true;
    		Debug.Log("1");
    	}
    	else{
    		MenuBlocks.SetActive(false);
    		isClick = false;
    		Debug.Log("2");
    	}
    }
    // Кнопка бургер
}
