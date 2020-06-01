using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("GameInfo")]
public class xmlRoundSave
{
    [XmlElement("volume")]
    public float volume;

    [XmlElement("Fullscreen")]
    public bool isFullscreen;

    [XmlElement("Quality")]
    public int QualityIndex;

    [XmlElement("Resolution")]
    public int ResolutionIndex;

 
    // Start is called before the first frame update
    public static xmlRoundSave Load(string path)
    {
        var serializer = new XmlSerializer(typeof(xmlRoundSave));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as xmlRoundSave;
        }
    }

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(xmlRoundSave));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
}
