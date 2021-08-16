using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateStats : MonoBehaviour
{
   
    public SetStats setStats;
    public int maxHealth = 100;
    //public Stats stats;
    public int maxMood = 100;

    public int moodDownPerDay = 5;
    public int damagePerDay = 10;
    public int restMultiplier = 2;
    public int dept = 0;

    public Text DayText;
    public Text MoodText;
    public Text HealthText;
    public Text HoursText;
    public Text HoursLeftMenuText;
    public Text LogText;

    public LightsControl lights;

    /// <summary>
    /// //////////////////////AllStats
    /// </summary>
    public int currentHealth;
    public int currentMood;
    public int day;
    public int year;
    public int hoursLeft;
    public int neverShowAreUSureMenu;
   

    public List<string> logLine = new List<string>();
    public ActivateDeactivate activateDeactivate;
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        restMultiplier = 2;
        neverShowAreUSureMenu = 0;
        hoursLeft = 24;
        year = 0;
        day = 0;
        moodDownPerDay = 0;
        damagePerDay = 10;
        currentMood = maxMood;
        currentHealth = maxHealth;
        setStats.SetMaxHealth(maxHealth);
        setStats.SetMaxMood(maxMood);
        DayText.text = "Year " + year + " Day " + day;
        MoodText.text = "Mood:" + currentMood;
        HealthText.text = "Health:" + currentHealth;
        if (30 - hoursLeft >= 24)
        {
            HoursText.text = "Time: " + (6 - hoursLeft) + ":00" ;
        }
        else
        {
            HoursText.text = "Time: " + (30 - hoursLeft) + ":00";
        }

        InvokeRepeating("ClearLog", 120f, 120f);
        LogText.text = "";
    }


   



    private void Update()
    {
        AddTextToLog();

    }

    public void AddTextToLog()
    {
        string display = "";
        foreach (string msg in logLine)
        {
            

            display = display.ToString() + msg.ToString() + "\n";
        }
        LogText.text = display;
    }

    void ClearLog()
    {

        LogText.text = "";


    }



    public void MinusHealth(int damageHealth)
    {
        currentHealth = currentHealth - damageHealth;
        setStats.setHealth(currentHealth);
        if(currentHealth <= 0)
        {
            GameOver();
        }
        HealthText.text = "Health:" + currentHealth;
        if (damageHealth > 0)
        {
            // activateDeactivate.logUpdateMenustart();

            logLine.Add("- " + damageHealth + " <color=red>HP</color>.");
        }
    }

    public void AddHealth(int addHealth)
    {
        int damagedHealth;
        damagedHealth = maxHealth - currentHealth;
        if (addHealth > damagedHealth)
        {

            currentHealth = currentHealth + damagedHealth;
            setStats.setHealth(currentHealth);
            HealthText.text = "Health:" + currentHealth;
            //activateDeactivate.logUpdateMenustart();

            logLine.Add("+ " + damagedHealth + " <color=red>HP</color>.");
        } else
        {
            currentHealth = currentHealth + addHealth;
            setStats.setHealth(currentHealth);
            HealthText.text = "Health:" + currentHealth;

            // activateDeactivate.logUpdateMenustart();
            logLine.Add("+ " + addHealth + " <color=red>HP</color>.");
        }
        
    }

    public void AddMood(int addMood)
    {
        int damagedMood;
        damagedMood = maxMood - currentMood;
        if (addMood > damagedMood)
        {

            currentMood = currentMood + damagedMood;
            setStats.setMood(currentMood);
            MoodText.text = "Mood:" + currentMood;
            // activateDeactivate.logUpdateMenustart();

            logLine.Add("+ " + damagedMood + " <color=blue>Mood</color>.");
        }
        else
        {
            currentMood = currentMood + addMood;
            setStats.setMood(currentMood);
            MoodText.text = "Mood:" + currentMood;
            // activateDeactivate.logUpdateMenustart();

            logLine.Add("+ " + addMood + " <color=blue>Mood</color>.");
        }

    }

    public void MinusMood(int amount)
    {
        currentMood = currentMood - amount;
        setStats.setMood(currentMood);


        if (currentMood <= 0)
        {
            GameOver();
        }
        MoodText.text = "Mood:" + currentMood;
        if(amount > 0) {
            //activateDeactivate.logUpdateMenustart();

            logLine.Add("- " + amount + " <color=blue>Mood</color>.");
        }
        
    }

    public void MinusHours(int hoursToTake)
    {
        hoursLeft = hoursLeft - hoursToTake;
        if(hoursToTake == 1)
        {
            // activateDeactivate.logUpdateMenustart();

            logLine.Add("- " + hoursToTake + " <color=purple>hour</color>.");
        }
        else if(hoursToTake > 1)
        {
            // activateDeactivate.logUpdateMenustart();

            logLine.Add("- " + hoursToTake + " <color=purple>hours</color>.");
        }


        if (30 - hoursLeft >= 24)
        {
            HoursText.text = "Time: " + (6 - hoursLeft) + ":00";
        }
        else
        {
            HoursText.text = "Time: " + (30 - hoursLeft) + ":00";
        }

        if (hoursLeft <= 0)
        {
            timeStatsUpdateWithHours(hoursLeft);
        }

        lights.rotateLightObject();

    }



    public void HouseUpdate(int houseNumber)
    {
       // damagePerDay = damagePerDay - houseNumber;
    }


    public void YesAndNeverShowAreUSureMenuPressed()
    {
        neverShowAreUSureMenu = 1;
        timeStatsUpdate();
    }

    public void YesAndSkipToNextDayPressed()
    {
        hoursLeft = 0;
        timeStatsUpdate();
    }


    public void timeStatsUpdate()
    {
        if (neverShowAreUSureMenu == 0)
        {

            if (hoursLeft <= 0)
            {

                MinusHealth(damagePerDay);
                MinusMood(moodDownPerDay);
    

                hoursLeft = 24;
                day = day + 1;
                if (day == 50)
                {
                    year = year + 1;
                    day = 0;
                }
                DayText.text = "Year " + year + " Day " + day;
                MoodText.text = "Mood:" + currentMood;
                HealthText.text = "Health:" + currentHealth;
                if (30 - hoursLeft >= 24)
                {
                    HoursText.text = "Time: " + (6 - hoursLeft) + ":00";
                }
                else
                {
                    HoursText.text = "Time: " + (30 - hoursLeft) + ":00";
                }
            }
            else if (hoursLeft >= 1)
            {
                HoursLeftMenuText.text = "You have " + hoursLeft + " more hours left.";
                activateDeactivate.areYouSureToSkipDayMenustart();
            }
        }else if (neverShowAreUSureMenu == 1)
        {
   
                MinusHealth(damagePerDay);
                MinusMood(moodDownPerDay);
                hoursLeft = 24;
                day = day + 1;
                if (day == 50)
                {
                    year = year + 1;
                    day = 0;
                }
                DayText.text = "Year " + year + " Day " + day;
                MoodText.text = "Mood:" + currentMood;
                HealthText.text = "Health:" + currentHealth;
            if (30 - hoursLeft >= 24)
            {
                HoursText.text = "Time: " + (6 - hoursLeft) + ":00";
            }
            else
            {
                HoursText.text = "Time: " + (30 - hoursLeft) + ":00";
            }


        }



    }

    public void timeStatsUpdateWithHours(int hoursToTake)
    {
       
        if (neverShowAreUSureMenu == 0)
        {
            print("timeStatsWorks");
            if (hoursLeft <= 0)
            {
                MinusHealth(damagePerDay);
                MinusMood(moodDownPerDay);               
                hoursLeft = 24 + hoursToTake;
                day = day + 1;
                if (day == 50)
                {
                    year = year + 1;
                    day = 0;
                }
                DayText.text = "Year " + year + " Day " + day;
                MoodText.text = "Mood:" + currentMood;
                HealthText.text = "Health:" + currentHealth;
                if (30 - hoursLeft >= 24)
                {
                    HoursText.text = "Time: " + (6 - hoursLeft) + ":00";
                }
                else
                {
                    HoursText.text = "Time: " + (30 - hoursLeft) + ":00";
                }
            }
            else if (hoursLeft >= 1)
            {
                HoursLeftMenuText.text = "You have " + hoursLeft + " more hours left.";
                activateDeactivate.areYouSureToSkipDayMenustart();
            }
        }
        else if (neverShowAreUSureMenu == 1)
        {

            MinusHealth(damagePerDay);
            MinusMood(moodDownPerDay);
            hoursLeft = 24 + hoursToTake;
            day = day + 1;
            if (day == 50)
            {
                year = year + 1;
                day = 0;
            }
            DayText.text = "Year " + year + " Day " + day;
            MoodText.text = "Mood:" + currentMood;
            HealthText.text = "Health:" + currentHealth;
            if (30 - hoursLeft >= 24)
            {
                HoursText.text = "Time: " + (6 - hoursLeft) + ":00";
            }
            else
            {
                HoursText.text = "Time: " + (30 - hoursLeft) + ":00";
            }



        }



    }



    public void updateAllStats()
    {



        inventory.LoadInventory();
        currentHealth = ES3.Load<int>("hp");
       currentMood = ES3.Load<int>("mood");
        day = ES3.Load<int>("day");
        year = ES3.Load<int>("year");
        hoursLeft = ES3.Load<int>("hoursLeft");
        neverShowAreUSureMenu = ES3.Load<int>("neverShowAreUSureMenu");
        restMultiplier = ES3.Load<int>("restMultiplier");
        dept = ES3.Load<int>("dept");
         



    DayText.text = "Year " + year + " Day " + day;
        MoodText.text = "Mood:" + currentMood;
        HealthText.text = "Health:" + currentHealth;
        if (30 - hoursLeft >= 24)
        {
            HoursText.text = "Time: " + (6 - hoursLeft) + ":00";
        }
        else
        {
            HoursText.text = "Time: " + (30 - hoursLeft) + ":00";
        }

        setStats.SetMaxHealth(maxHealth);
        setStats.SetMaxMood(maxMood);
        setStats.setHealth(currentHealth);
        setStats.setMood(currentMood);

    }



    public void GameOver()
    {
        activateDeactivate.GameOverMenuStart();
    }

 





}
