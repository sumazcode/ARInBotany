using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Vuforia
{
    public class dataTarget : MonoBehaviour
    {
        public GameObject xmlresobj;
        public Transform InfoPanel;
        public Transform TitleText;
        public Transform InfoText;
        public Transform InfoImage;
        public Transform InfoPanelBackButton;

        public Text titletext;
        public Text infotext;
        private Texture2D infoimagetex;
        private string teststr;

               
        /* public Transform InfoPanel_AloeVera;
        public Transform TitleText_AloeVera;
        public Transform InfoText_AloeVera;
        public Transform InfoImage_AloeVera;
        public Transform InfoPanelBackButton_AloeVera; */

        // Start is called before the first frame update
        void Start()
        {
            InfoPanel.gameObject.SetActive(false);
            InfoImage.gameObject.SetActive(false);
            InfoText.gameObject.SetActive(false);
            TitleText.gameObject.SetActive(false);
            InfoPanelBackButton.gameObject.SetActive(false);

            
            /* InfoPanel_AloeVera.gameObject.SetActive(false);
            InfoImage_AloeVera.gameObject.SetActive(false);
            InfoText_AloeVera.gameObject.SetActive(false);
            TitleText_AloeVera.gameObject.SetActive(false);
            InfoPanelBackButton_AloeVera.gameObject.SetActive(false); */
        }

        // Update is called once per frame
        void Update()
        {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();

            foreach (TrackableBehaviour tb in tbs)
            {
                string name = tb.TrackableName;
                ImageTarget it = tb.Trackable as ImageTarget;

                if (name.Equals("IT_Tiger") || name.Equals("IT_Cow") )
                {
                    titletext.GetComponent<UnityEngine.UI.Text>().text = xmlresobj.GetComponent<XmlResPlantsInfo>().DisplayPlantData(name).titletext;
                    infotext.GetComponent<UnityEngine.UI.Text>().text = xmlresobj.GetComponent<XmlResPlantsInfo>().DisplayPlantData(name).infotext;

                    teststr = "Images/" + xmlresobj.GetComponent<XmlResPlantsInfo>().DisplayPlantData(name).infoimage;
                    Debug.Log(teststr);
                    infoimagetex = Resources.Load<Texture2D>(teststr);
                    Debug.Log("Raw Image = " + InfoImage.gameObject.GetComponent<RawImage>());
                    Debug.Log("Texture = " + infoimagetex);
                    InfoImage.gameObject.GetComponent<RawImage>().texture = infoimagetex;

                    InfoPanel.gameObject.SetActive(true);
                    InfoImage.gameObject.SetActive(true);
                    InfoText.gameObject.SetActive(true);
                    TitleText.gameObject.SetActive(true);
                    InfoPanelBackButton.gameObject.SetActive(true);
                }

                /* if (name.Equals("IT_Cow"))
                {
                    InfoPanel_AloeVera.gameObject.SetActive(true);
                    InfoImage_AloeVera.gameObject.SetActive(true);
                    InfoText_AloeVera.gameObject.SetActive(true);
                    TitleText_AloeVera.gameObject.SetActive(true);
                    InfoPanelBackButton_AloeVera.gameObject.SetActive(true);
                }*/
            }
        }
    }
}
