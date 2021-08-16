using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NobleBackbone : MonoBehaviour
{
    public Text infoText;
    public Text logText;
    public Text logHelpText;
    public Text upgradeBunnerText;
    public Text getTowerText;
    public Text getCastleText;
    public Text getDomainText;

    public GameObject particles;
    public GameObject notEnoughHonor;
    public int clickMultiplier = 1;
    public int bunnerUpgradePrice = 10;
    public int towerPrice = 1000;
    public int towerAmount = 0;
    public int castlePrice = 10000;
    public int castleAmount = 0;

    public int domainPrice = 100000;
    public int domainAmount = 0;
    public int honor = 0;
    public int rank = 0; 
    
    public string title;
    public GameObject clickButton;
    public Sprite bunner0;
    public Sprite bunner1;
    public Sprite bunner2;
    public Sprite bunner3;
    public Sprite bunner4;
    public Sprite bunner5;
    public Sprite bunner6;

    // Start is called before the first frame update
    void Start()
    {
        towerPrice = 1000;
        bunnerUpgradePrice = 10;
        clickMultiplier = 1;
        honor = 0;
        towerAmount = 0;
        castlePrice = 10000;
        castleAmount = 0;
        domainPrice = 100000;
        domainAmount = 0;
        rank = -1;
    }

    public void upgradeBunner()
    {
        if (honor >= bunnerUpgradePrice) {
            honor = honor - bunnerUpgradePrice;
            if (clickMultiplier == 1)
            {
                clickMultiplier = 10;
                bunnerUpgradePrice = 50;
            }
            else
            {
                clickMultiplier = clickMultiplier + 10;
                bunnerUpgradePrice = bunnerUpgradePrice + 100;
            }
            
        }
        else
        {
            notEnoughHonor.SetActive(true);
        }


        
    }

    public void getTower()
    {
        if (honor >= towerPrice)
        {
            if (towerAmount == 0)
            {
                InvokeRepeating("towerIncome", 1f, 1f);
            }


                honor = honor - towerPrice;
            towerAmount = towerAmount + 1;
            
            towerPrice = towerPrice + 500;

        }
        else
        {
            notEnoughHonor.SetActive(true);
        }



    }


    public void towerIncome()
    {
        honor = honor + (100 * towerAmount);
    }





    public void getCastle()
    {
        if (honor >= castlePrice)
        {
            if (castleAmount == 0)
            {
                InvokeRepeating("castleIncome", 1f, 1f);
            }


            honor = honor - castlePrice;
            castleAmount = castleAmount + 1;

            castlePrice = castlePrice + 10000;

        }
        else
        {
            notEnoughHonor.SetActive(true);
        }



    }


    public void castleIncome()
    {
        honor = honor + (1000 * castleAmount);
    }






    public void getDomain()
    {
        if (honor >= domainPrice)
        {
            if (domainAmount == 0)
            {
                InvokeRepeating("domainIncome", 1f, 1f);
            }


            honor = honor - domainPrice;
            domainAmount = domainAmount + 1;

            domainPrice = domainPrice + 50000;

        }
        else
        {
            notEnoughHonor.SetActive(true);
        }



    }


    public void domainIncome()
    {
        honor = honor + (5000 * domainAmount);
    }













    public void click()
    {
        honor = honor + clickMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        var emission = particles.GetComponent<ParticleSystem>().emission;
        infoText.text = "Honor: " + honor + "\nTitle: " + title;
        upgradeBunnerText.text = "upgrade banner " + bunnerUpgradePrice + "hn";
        getTowerText.text = "get tower " + towerPrice + "hn";
        getCastleText.text = "get castle " + castlePrice + "hn";
        getDomainText.text = "get domain " + domainPrice + "hn";
        if (honor >= 1000000)
        {
            logText.text = "You are " + title + ".\n\n" +
                "You have:\n\n" +
                towerAmount + " towers;\n\n" +
               castleAmount + " castles;\n\n" +
               domainAmount + " domains;\n\n" +
               "You win this game.\n" +
               "You are the best. Thank you for playing.";
        }
        else
        {
            logText.text = "You are " + title + ".\n\n" +
                "You have:\n\n" +
                towerAmount + " towers;\n\n" +
               castleAmount + " castles;\n\n" +
               domainAmount + " domains;\n\n";
        }

        logHelpText.text = "\nEvery tower gives you 100 honor/second.\n\n" +
                "Every castle gives you 1000 honor/second.\n\n" +
                "Every domain gives you 5000 honor/second\n\n";


        if (honor < 1000 && rank <= -1)
        {
            title = "Warrior";
            rank = -1;
        }
        else if(honor >=1000 && honor < 3000 && rank < 0)
        {
            title = "Hero";
            rank = 0;
            particles.SetActive(true);
            
            emission.rateOverTime = 5f;
        }
        else if (honor >= 3000 && honor < 7000 && rank < 1)
        {
            title = "Knight";
            rank = 1;
            //var emission = particles.GetComponent<ParticleSystem>().emission;
            emission.rateOverTime = 10f;
        }
        else if (honor >= 7000 && honor < 11000 && rank < 2)
        {
            title = "Chevalier";
            rank = 2;
            // var emission = particles.GetComponent<ParticleSystem>().emission;
            emission.rateOverTime = 15f;
        }
        else if (honor >= 11000 && honor < 17000 && rank < 3)
        {
            title = "Baronet";
            rank = 3;
            // var emission = particles.GetComponent<ParticleSystem>().emission;
            emission.rateOverTime = 20f;
        }
        else if (honor >= 17000 && honor < 25000 && rank < 4)
        {
            title = "Baron";
            rank = 4;
            //  var emission = particles.GetComponent<ParticleSystem>().emission;
            emission.rateOverTime = 30f;
        }
        else if (honor >= 25000 && honor < 50000 && rank < 5)
        {
            title = "Viscount";
            rank = 5;
            // var emission = particles.GetComponent<ParticleSystem>().emission;
            emission.rateOverTime = 40f;
        }
        else if (honor >= 50000 && honor < 100000 && rank < 6)
        {
            title = "Count";
            rank = 6;
            // var emission = particles.GetComponent<ParticleSystem>().emission;
            emission.rateOverTime = 70f;
        }
        else if (honor >= 100000 && honor < 200000 && rank < 7)
        {
            title = "Marquis";
            rank = 7;
            // var emission = particles.GetComponent<ParticleSystem>().emission;
            emission.rateOverTime = 100f;
        }
        else if (honor >= 200000 && honor < 350000 && rank < 8)
        {
            title = "Duke";
            rank = 8;
            //  var emission = particles.GetComponent<ParticleSystem>().emission;
            emission.rateOverTime = 140f;
        }
        else if (honor >= 350000 && honor < 600000 && rank < 9)
        {
            title = "Arch-Duke";
            rank = 9;
            //  var emission = particles.GetComponent<ParticleSystem>().emission;
            emission.rateOverTime = 140f;
        }
        else if (honor >= 600000 && honor < 1000000 && rank < 10)
        {
            title = "Royal Highness";
            rank = 10;
            // var emission = particles.GetComponent<ParticleSystem>().emission;
            emission.rateOverTime = 140f;
        }
        else if (honor >= 1000000 && rank < 11)
        {
            title = "World Emperor";
            rank = 11;
            emission.rateOverTime = 200f;
        }


        //check for bunner upgrade levels
        if (clickMultiplier < 10)
        {
            clickButton.transform.GetComponent<Image>().sprite = bunner0;
        }
        else if (clickMultiplier >= 10 && clickMultiplier < 20)
        {
            clickButton.transform.GetComponent<Image>().sprite = bunner1;
        }
        else if (clickMultiplier >= 20 && clickMultiplier < 30)
        {
            clickButton.transform.GetComponent<Image>().sprite = bunner2;
        }
        else if (clickMultiplier >= 30 && clickMultiplier < 40)
        {
            clickButton.transform.GetComponent<Image>().sprite = bunner3;
        }
        else if (clickMultiplier >= 40 && clickMultiplier < 50)
        {
            clickButton.transform.GetComponent<Image>().sprite = bunner4;
        }
        else if (clickMultiplier >= 50 && clickMultiplier < 60)
        {
            clickButton.transform.GetComponent<Image>().sprite = bunner5;
        }
        else if (clickMultiplier >= 60)
        {
            clickButton.transform.GetComponent<Image>().sprite = bunner6;
        }


    }

    public void loadAll()
    {
        title = ES3.Load<string>("title");
        towerPrice = ES3.Load<int>("towerPrice"); 
        bunnerUpgradePrice = ES3.Load<int>("bunnerUpgradePrice");
        clickMultiplier = ES3.Load<int>("clickMultiplier");
        honor = ES3.Load<int>("honor");
        towerAmount = ES3.Load<int>("towerAmount");
        castlePrice = ES3.Load<int>("castlePrice");
        castleAmount = ES3.Load<int>("castleAmount");
        domainPrice = ES3.Load<int>("domainPrice");
        domainAmount = ES3.Load<int>("domainAmount");
        rank = ES3.Load<int>("rank");

        InvokeRepeating("towerIncome", 1f, 1f);
        InvokeRepeating("castleIncome", 1f, 1f);
        InvokeRepeating("domainIncome", 1f, 1f);
    }

    public void saveAll()
    {
        ES3.Save<string>("title", title);
        ES3.Save<int>("clickMultiplier", clickMultiplier);
        ES3.Save<int>("honor", honor);
        ES3.Save<int>("towerAmount", towerAmount);
        ES3.Save<int>("castlePrice", castlePrice);
        ES3.Save<int>("castleAmount", castleAmount);
        ES3.Save<int>("domainPrice", domainPrice);
        ES3.Save<int>("domainAmount", domainAmount);
        ES3.Save<int>("bunnerUpgradePrice", bunnerUpgradePrice);
        ES3.Save<int>("towerPrice", towerPrice);
        ES3.Save<int>("rank", rank);


    }


}
