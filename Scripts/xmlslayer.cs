using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("WorldInfo")]
public class xmlslayer
{
    [XmlArray("Tiles")]
    [XmlArrayItem("Tile")]
    public List<til> tile = new List<til>();

    
    // Start is called before the first frame update
  
    public static  xmlslayer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(xmlslayer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as xmlslayer;
        }
    }

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(xmlslayer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
}


