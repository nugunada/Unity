using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_B : MonoBehaviour
{
    private int enemyDistance = 0;
    private int enemyCount = 10 ;

    private string[] enemies = new string[5] ;

    private int weaponID = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            //EnemySearch();
            //EnemyDestruction();
            //EnemyScan();
            //EnemyRoster();
            WeaponSearch();
        }
    }

    void EnemySearch()
    {        
        for(int i = 0; i < 5; i ++)
        {
            enemyDistance = Random.Range (1,10);
            if(enemyDistance >=8)
            {
                print("An enemy is far away!");
            }
            if(enemyDistance >=4 && enemyDistance <= 7)
            {
                print("An enemy is medium range!");
            }if(enemyDistance <4)
            {
                print("An enemy is very close by");
            }
        }
            
    }

    void EnemyDestruction()
    {
        while(enemyCount > 0)
        {
            print("There is an ememy, destroy");
            enemyCount --;
        }
    }

    void EnemyScan()
    {
        bool isAlive = false; //이니셜라이즈함, 이 안쪽에서만 사용가능

        do
        {
            print("Scanning fo enemies!"); 
        }
        while(isAlive == true);
    }

    void EnemyRoster()
    {
        enemies[0] = "Orc";
        enemies[1] = "Dragon1";
        enemies[2] = "Dragon2";
        enemies[3] = "Dragon3";
        enemies[4] = "Dragon4";

        foreach(string enemy in enemies)
        {
            print(enemy);
        }
    }

    void WeaponSearch()
    {
        weaponID = Random.Range(0,8);

        switch(weaponID)
        {
            case 1:
                print("You found a sword");
                break;            
            case 2:
                print("You found a sword2");
                break;
            case 3:
                print("You found a sword3");
                break;
            case 4:
                print("You found a sword4");
                break;
            default:
                print("You didn't find anyting");
                break;
            

        }   
    }
    
}
