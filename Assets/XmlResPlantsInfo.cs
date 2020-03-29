using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;


public class XmlResPlantsInfo : MonoBehaviour
{
    // Members
    private string filename;
    private List<PlantInfo> Plants;
    private string path;
    private XmlDocument xmldoc;
    private TextAsset textxml;

    public struct PlantInfo
    {
        public string plantname; // this should be same as flash card text, e.g. IT_Tiger
        public string titletext;
        public string infotext;
        public string infoimage;
    };

    // Methods
    void Awake()
    {
        filename = "PlantsInfo";
        Plants = new List<PlantInfo>();
    }

    // Start is called before the first frame update
    void Start()
    {
        loadXMLFromAsset();
        readXml();        
    }

    // Read and store XML data in local data member
    private void readXml()
    {
        foreach (XmlElement node in xmldoc.SelectNodes("Plants/Plant"))
        {
            PlantInfo plant = new PlantInfo();
            plant.plantname = node.SelectSingleNode("name").InnerText;
            //tempPlayer.score = int.Parse(node.SelectSingleNode("score").InnerText);
            plant.titletext = node.SelectSingleNode("title").InnerText;
            plant.infotext = node.SelectSingleNode("info").InnerText;
            plant.infoimage = node.SelectSingleNode("infoimage").InnerText;
            Plants.Add(plant);
            //displayPlantData(plant);
        }
    }

    // On AR camera recognition, check if selected plant (flash card text) matches stored plant data
    public PlantInfo DisplayPlantData(string selplant)
    {
        PlantInfo plant = new PlantInfo();

        // Compare selplant name with plant list in "Plants" list and send data to update UI elements
        // This function is called on flash card recognition by AR camera
        foreach (PlantInfo tempplant in Plants)
        {
            if(tempplant.plantname == selplant)
            {
                plant = tempplant;
                break;
            }
        }
        return plant;
        //fileDataTextbox.text += tempPlayer.Id + "\t\t" + tempPlayer.name + "\t\t" + tempPlayer.score + "\n";
    }

    // Following method load xml file from resouces folder under Assets
    private void loadXMLFromAsset()
    {
        xmldoc = new XmlDocument();
        if (System.IO.File.Exists(getPath()))
        {
            xmldoc.LoadXml(System.IO.File.ReadAllText(getPath()));
        }
        else
        {
            textxml = (TextAsset)Resources.Load(filename, typeof(TextAsset));
            xmldoc.LoadXml(textxml.text);
        }
    }

    // Following method is used to retrive the relative path as device platform
    private string getPath()
    {
        #if UNITY_EDITOR
        return Application.dataPath + "/Resources/" + filename;
        #elif UNITY_ANDROID
        return Application.persistentDataPath+fileName;
        #elif UNITY_IPHONE
        return GetiPhoneDocumentsPath()+"/"+fileName;
        #else
        return Application.dataPath +"/"+ fileName;
        #endif
    }
}

