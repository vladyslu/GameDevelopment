using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonsToDeactivate : MonoBehaviour
{
    public GameObject buttonForrestShack;
    public GameObject villageHouseButton;
    public GameObject villageButton;
    public GameObject townButton;
    public GameObject abroadButton;
   

    public int forrestShack = 1;
    public int village = 0;
    public int town = 0;
    public int abroad = 0;
    public int villageHouse = 1;


    // Start is called before the first frame update
    void Start()
    {
        forrestShack = 1;
        villageHouse = 1;
    }

    public void forrestShackDiactivated()
    {
        forrestShack = 0;
        buttonForrestShack.SetActive(false);
    }

    public void villageHouseDiactivated()
    {
        villageHouse = 0;
        villageHouseButton.SetActive(false);
    }
    public void abroadDeactivate()
    {
        abroad = 0;
        abroadButton.SetActive(false);
    }

    public void villageActivated()
    {
        village = 1;
        villageButton.SetActive(true);
    }

    public void townActivated()
    {
        town = 1;
        townButton.SetActive(true);
    }

    public void abroadActivated()
    {
        abroad = 1;
        abroadButton.SetActive(true);
    }


    public void loadAllTheButtons()
    {
        forrestShack = ES3.Load<int>("forrestShack");
        if(forrestShack == 0)
        {
            buttonForrestShack.SetActive(false);
        }

        villageHouse = ES3.Load<int>("villageHouse");
        if (villageHouse == 0)
        {
            villageHouseButton.SetActive(false);
        }

        town = ES3.Load<int>("town");
        if (town == 1)
        {
            townButton.SetActive(true);
        }

        village = ES3.Load<int>("village");
        if (village == 1)
        {
            villageButton.SetActive(true);
        }

        abroad = ES3.Load<int>("abroad");
        if (abroad == 1)
        {
            abroadButton.SetActive(true);
        }




    }

    public void saveAllButtons()
    {
        ES3.Save<int>("forrestShack", forrestShack);
        ES3.Save<int>("town", town);
        ES3.Save<int>("village", village);
        ES3.Save<int>("abroad", abroad);
        ES3.Save<int>("villageHouse", villageHouse);
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
