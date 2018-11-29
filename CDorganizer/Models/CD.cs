using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using CDorganizer;

namespace CDorganizer.Models
{
 public class CD
  {
    private string _cdTitle;
    private int _id;
    private static List<CD> _instances = new List<CD> {};
    

    public CD (string cdTitle)
    {
        _cdTitle = cdTitle;
        _instances.Add(this);
        _id = _instances.Count;
    }

    public string GetTitle()
    {
        return _cdTitle;
    }

    public void SetTitle(string newTitle)
    {
        _cdTitle = newTitle;
    }

    public int GetID()
    {
        return _id;
    }
    
    public static List<CD> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static CD Find(int searchId)
    {
      return _instances[searchId-1];
    }

 }
}
