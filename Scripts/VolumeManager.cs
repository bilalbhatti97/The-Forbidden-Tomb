using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    int resSet;
    int QualSet;
    bool isFull;
    float vol;


    // Start is called before the first frame update
    private void Start()
    {
        ResolutionFinder();
        ReadInfo();
    }

    public void ResolutionSetter(int resolutionIndex)
    {
        resSet = resolutionIndex;
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }


    private void ResolutionFinder()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "X" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }



        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void setSettingsFromPrefab()
    {
        PlayerPrefs.GetInt("res");
        PlayerPrefs.GetFloat("vol");
        PlayerPrefs.GetInt("qual");
        PlayerPrefs.GetInt("res");
        setAllsetting(PlayerPrefs.GetInt("res"), PlayerPrefs.GetFloat("vol"), PlayerPrefs.GetInt("qual"), PlayerPrefs.GetInt("res") == 1 ? true : false);
    }


    public void setAllsetting(int res,float vol,int qul,bool full)
    {
        ResolutionSetter(res);
        SetVolume(vol);
        SetQuality(qul);
        SetFullscreen(full);
    }

    public void SetVolume(float volume)
    {
        vol = volume;
        Debug.Log(volume);
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualSet = qualityIndex;
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        isFull = isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void SaveSettings()
    {
        writeInfo();
    }
    public void writeInfo()
    {
       
        xmlRoundSave excuter = new xmlRoundSave();
        //excuter.tile.Clear();

        //for (int i = 0; i < Tiles.Count; i++)
        //{
        //    til Tile = new til();
        //    Tile.timeEntered = Tiles[i].GetComponent<VisitCounter>().NoOfTimesEntered;
        //    Tile.threat = Tiles[i].GetComponent<VisitCounter>().threat;
        //    excuter.tile.Add(Tile);

        //}
        excuter.volume = vol;
        excuter.ResolutionIndex = resSet;
        excuter.QualityIndex = QualSet;
        excuter.isFullscreen = isFull;
      

        excuter.Save(Path.Combine(Application.dataPath, "GameInfo.xml"));


    }
    public void ReadInfo()
    {
       
        if (File.Exists(Path.Combine(Application.dataPath, "GameInfo.xml")))
        {
            var setting = xmlRoundSave.Load(Path.Combine(Application.dataPath, "GameInfo.xml"));
            PlayerPrefs.SetInt("res", setting.ResolutionIndex);
            PlayerPrefs.SetFloat("vol", setting.volume);
            PlayerPrefs.SetInt("qual", setting.QualityIndex);
            PlayerPrefs.SetInt("res", setting.isFullscreen ? 1:0);
            setAllsetting(setting.ResolutionIndex, setting.volume, setting.QualityIndex, setting.isFullscreen);
           
        }
    }




}
