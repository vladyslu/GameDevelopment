using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions : MonoBehaviour
{
    public int currentHouse = 0;
    public int lastHouse = 0;
    private int forestShack = 2;
    private int box = 1;
    public updateStats updateStats; 
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void homeBox()
    {
        lastHouse = currentHouse;
        currentHouse = box - lastHouse;
        updateStats.HouseUpdate(currentHouse);
    }


    public void homeForestShack()
    {
        lastHouse = currentHouse;
        currentHouse = forestShack - lastHouse;
        updateStats.HouseUpdate(currentHouse);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
