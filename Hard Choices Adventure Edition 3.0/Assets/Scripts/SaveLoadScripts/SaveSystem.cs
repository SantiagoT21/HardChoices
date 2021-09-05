using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using BayatGames.SaveGameFree;

public static class SaveSystem
{

    public static int version=0;
    public static string auxVersion = "";

    public static void SaveGameplay(Vector2 mov, float DevelopsSpeed1, string identifier1)
    {
        try
        {
            auxVersion = SaveGame.Load<string>("LastVersion.txt", "version");
        }catch(Exception e)
        {
            SaveGame.Save<string>("LastVersion.txt", "" + version); //identificador
            auxVersion = "0";
        }

        if (auxVersion == "")
        {
            version = 0;
            auxVersion = ""+version;
        }

        version = int.Parse(auxVersion);
        version++;

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/GlobalData_version" + version + ".gd";

        Debug.Log("El numero de partida golbal es: "+version);
        Debug.Log(path);

        FileStream stream = new FileStream(path , FileMode.Create);

        GlobalData data = new GlobalData(mov, DevelopsSpeed1, identifier1);

        formatter.Serialize(stream, data);

        SaveGame.Save<string>("LastVersion.txt", ""+version); //identificador

        stream.Close();

    }

    public static GlobalData LoadGameplay(int i, Vector2 mov, float DevelopsSpeed1, string identifier1)
    {

        string path = Application.persistentDataPath + "/GlobalData_version" + i + ".gd";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GlobalData data = formatter.Deserialize(stream) as GlobalData;
            stream.Close();

            return data;
            
        }
        else
        {
            SaveGameplay(mov, DevelopsSpeed1, identifier1);
            Debug.Log("Save file not found in " + path);
            Debug.Log("Try again");
            return null;
        }
    }
}
