using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private string TakeFirstEightID(string id)
    {
        string finalID = id.Substring(0, 8);
        return finalID;
    }

    private string BalanceNumberToString(double balance)
    {
        if (balance >= 1000000000) // for B
        {
            int i = (int)(balance / 1000000000);
            return $"{i}B";
        }
        else if (balance >= 1100000) // for 1.2/1.3/2.4 M
        {
            int i = (int)(balance / 1000000);
            int balanceI = i * 1000000;
            int lastBalance = (int)(balance - balanceI);
            int j = (int)(lastBalance / 100000);
            return $"{i}.{j}M";
        }
        else if (balance >= 1000000)
        {
            int i = (int)(balance / 1000000);
            return $"{i}M";
        }
        else if (balance >= 1100)
        {
            int i = (int)(balance / 1000);
            int balanceI = i * 1000;
            int lastBalance = (int)(balance - balanceI);
            int j = (int)(lastBalance / 100);
            return $"{i}.{j}K";
        }
        else if (balance >= 1000)
        {
            int i = (int)(balance / 1000);
            return $"{i}K";
        }
        else if (balance >= 1)
        {
            int i = (int)balance;
            return i.ToString();
        }
        else
        {
            return "0";
        }
    }
}
