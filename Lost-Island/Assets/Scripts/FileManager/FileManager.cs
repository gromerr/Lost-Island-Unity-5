using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;


public abstract class FileManager
{

    protected string pathFile;
    protected string fileName;
    protected BinaryFormatter biniaryFormatter;
    protected FileStream fileStream;


    public FileManager()
    {

        biniaryFormatter = new BinaryFormatter();
        pathFile = Application.dataPath + "/";
    }

    /// <summary>
    /// Checks the file exist.
    /// </summary>
    /// <returns><c>true</c>, if file exist was checked, <c>false</c> otherwise.</returns>
    private bool CheckFileExist()
    {

        return File.Exists(pathFile);
    }

    /// <summary>
    /// Saves the custum component data from application.
    /// It must be implemented in a class that inherits.
    /// </summary>
    protected abstract void SaveCustomData();

    /// <summary>
    /// Loads the custom component data to application.
    /// It must be implemented in a class that inherits.
    /// </summary>
    protected abstract void LoadCustomData();

    /// <summary>
    /// Gets the global custom data.
    /// It must be implemented in a class that inherits.
    /// </summary>
    protected abstract void GetGlobalCustomData();

    /// <summary>
    /// Sets the global custom data.
    /// It must be implemented in a class that inherits.
    /// </summary>
    protected abstract void SetGlobalCustomData();

    /// <summary>
    /// Reads content from application if it is first time or file don't exist.
    /// </summary>
    protected abstract void ReadFromApplication();

    /// <summary>
    /// Files the initialization.
    /// </summary>
    protected void FileInitialization()
    {

        if (CheckFileExist())
        {
            Load();
        }
        else
        {
            ReadFromApplication();
            Save();
        }
    }

    /// <summary>
    /// Save this instance.
    /// </summary>
    public void Save()
    {

        try
        {
            fileStream = File.Create(pathFile);
            SaveCustomData();

            fileStream.Close();
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);

            //TODO something with expetion on Save
        }
    }

    /// <summary>
    /// Load this instance.
    /// </summary>
    public void Load()
    {

        try
        {
            fileStream = File.Open(pathFile, FileMode.Open);
            LoadCustomData();

            fileStream.Close();
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);

            ReadFromApplication();
            Save();
        }
    }

}
