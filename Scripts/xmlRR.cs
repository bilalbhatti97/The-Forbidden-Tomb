using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("Root")]
public class xmlRR 
{
    // Start is called before the first frame update
    [XmlElement("Round")]
    public int Round;

    [XmlElement("Coins")]
    public int Coins;

    public static xmlRR Load(string path)
    {
        var serializer = new XmlSerializer(typeof(xmlRR));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as xmlRR;
        }
    }

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(xmlRR));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
}
