﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VedAstro.Library;

/// <summary>
/// Represents the mini strengths that mae the final strength of a house
/// </summary>
public class HouseSubStrength : IToJson
{
    public string Name = "";

    public Dictionary<HouseName, double> Power { get; }

    public HouseSubStrength(Dictionary<HouseName, double> power, string name)
    {
        Power = power;
        Name = name;
    }


    public JObject ToJson()
    {
        var returnList = new JArray();

        //add into a list for each house
        foreach (var houseData in Power)
        {
            //pack data nicely
            var temp = new JObject();
            temp["House"] = (int)houseData.Key; //show as number
            temp["Strength"] = houseData.Value; //show as number

            Console.WriteLine(temp.ToString());

            //add to main list
            returnList.Add(temp);
        }
        
        Console.WriteLine("POSSIBLE CRASH!!");

        //todo FAIL ALERT!!!!!
        //send list on its way
        var wrap = new JObject();
        wrap.Add(returnList);

        return wrap;
    }

}