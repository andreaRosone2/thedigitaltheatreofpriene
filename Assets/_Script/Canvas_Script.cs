using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEditor;

public class Canvas_Script : MonoBehaviour
{
    string stateApp;
    int sceneToLoad;

    float t = 0f;

    int docPage = 0;

    GameObject image1;
    GameObject image2;

    [SerializeField] Sprite copertina;

    [SerializeField] Sprite mappa;

    [SerializeField] Sprite panoramica1;
    [SerializeField] Sprite panoramica2;
    [SerializeField] Sprite panoramica3;
    [SerializeField] Sprite panoramica4;

    [SerializeField] Sprite documentazione1;
    [SerializeField] Sprite documentazione2;
    [SerializeField] Sprite documentazione3;
    [SerializeField] Sprite documentazione4;
    [SerializeField] Sprite documentazione5;
    [SerializeField] Sprite documentazione6;
    [SerializeField] Sprite documentazione7;
    [SerializeField] Sprite documentazione8;
    [SerializeField] Sprite documentazione9;
    [SerializeField] Sprite documentazione10;
    [SerializeField] Sprite documentazione11;
    [SerializeField] Sprite documentazione12;
    [SerializeField] Sprite documentazione13;
    [SerializeField] Sprite documentazione14;

    readonly List<Sprite> documentazione = new();

    [SerializeField] Sprite crediti1;
    [SerializeField] Sprite crediti2;
    [SerializeField] Sprite crediti3;
    [SerializeField] Sprite crediti4;

    readonly List<Sprite> credits = new();

    GameObject button1;
    GameObject button2;
    GameObject button3;

    GameObject text1;
    GameObject text2;
    GameObject text3;

    GameObject imgButton1;
    GameObject imgButton2;
    GameObject imgButton3;
    GameObject imgButton4;

    GameObject imgButtonSelected;

    private void Awake()
    {
        image1 = GameObject.Find("Immagine1");
        image2 = GameObject.Find("Immagine2");

        button1 = GameObject.Find("Bottone1");
        button2 = GameObject.Find("Bottone2");
        button3 = GameObject.Find("Bottone3");

        imgButton1 = GameObject.Find("MapBottone1");
        imgButton2 = GameObject.Find("MapBottone2");
        imgButton3 = GameObject.Find("MapBottone3");
        imgButton4 = GameObject.Find("MapBottone4");

        button1.GetComponent<Button>().interactable = false;
        button2.GetComponent<Button>().interactable = false;
        button3.GetComponent<Button>().interactable = false;

        imgButton1.GetComponent<Button>().interactable = false;
        imgButton2.GetComponent<Button>().interactable = false;
        imgButton3.GetComponent<Button>().interactable = false;
        imgButton4.GetComponent<Button>().interactable = false;

        text1 = GameObject.Find("Testo1");
        text2 = GameObject.Find("Testo2");
        text3 = GameObject.Find("Testo3");

        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);

        imgButton1.SetActive(false);
        imgButton2.SetActive(false);
        imgButton3.SetActive(false);
        imgButton4.SetActive(false);

        stateApp = "LoadMainMenu";
        sceneToLoad = 1;

        documentazione.Add(documentazione1);
        documentazione.Add(documentazione2);
        documentazione.Add(documentazione3);
        documentazione.Add(documentazione4);
        documentazione.Add(documentazione5);
        documentazione.Add(documentazione6);
        documentazione.Add(documentazione7);
        documentazione.Add(documentazione8);
        documentazione.Add(documentazione9);
        documentazione.Add(documentazione10);
        documentazione.Add(documentazione11);
        documentazione.Add(documentazione12);
        documentazione.Add(documentazione13);
        documentazione.Add(documentazione14);

        credits.Add(crediti1);
        credits.Add(crediti2);
        credits.Add(crediti3);
        credits.Add(crediti4);
    }

    void Update()
    {
        if (stateApp == "LoadMainMenu")
            LoadMainMenu();

        if (stateApp == "BackFromMapMenu")
            DisablePage("LoadMainMenu");

        if (stateApp == "Back")
            DisablePage("LoadMainMenu");

        if (stateApp == "LoadMapMenu_1")
            DisablePage("LoadMapMenu_2");

        if (stateApp == "LoadMapMenu_2")
            LoadMapMenu();

        if (stateApp == "LoadDocumentation_1")
            DisablePage("LoadDocumentation_2");

        if (stateApp == "LoadDocumentation_2")
            LoadDocumentation();

        if (stateApp == "LoadCredits_1")
            DisablePage("LoadCredits_2");

        if (stateApp == "LoadCredits_2")
            LoadCredits();
    }

    void LoadMainMenu()
    {
        Vector3 img1StrPos = new(-700f, 0f, 0f);
        Vector3 img1FnlPos = new(-150f, 0f, 0f);

        Color strCol = new(0, 0, 0, 0);
        Color fnlCol = new(0, 0, 0, 1);

        float speedTransition = 1f;

        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);

        button1.GetComponent<RectTransform>().localPosition = new(200f, 75f, 0f);
        button2.GetComponent<RectTransform>().localPosition = new(200f, 0f, 0f);
        button3.GetComponent<RectTransform>().localPosition = new(200f, -75f, 0f);

        text1.GetComponent<TextMeshProUGUI>().text = "VISITA IL TEATRO";
        text2.GetComponent<TextMeshProUGUI>().text = "DOCUMENTAZIONE";
        text3.GetComponent<TextMeshProUGUI>().text = "BIBLIOGRAFIA E CREDITI";

        image1.GetComponent<Image>().sprite = copertina;

        if (t < 1f)
        {
            t += speedTransition * Time.deltaTime;
            image1.GetComponent<RectTransform>().localPosition = Vector3.Lerp(img1StrPos, img1FnlPos, t);
            text1.GetComponent<TextMeshProUGUI>().color = Vector4.Lerp(strCol, fnlCol, t);
            text2.GetComponent<TextMeshProUGUI>().color = Vector4.Lerp(strCol, fnlCol, t);
            text3.GetComponent<TextMeshProUGUI>().color = Vector4.Lerp(strCol, fnlCol, t);
        }

        if (t > 1f)
        {
            button1.GetComponent<Button>().interactable = true;
            button2.GetComponent<Button>().interactable = true;
            button3.GetComponent<Button>().interactable = true;
            stateApp = "MainMenu";
        }
    }

    void DisablePage(string state)
    {
        Vector3 img1StrPos = new(-700f, 0f, 0f);
        Vector3 img1FnlPos = new(-150f, 0f, 0f);

        Vector3 img2StrPos = new(200f, 500f, 0f);
        Vector3 img2FnlPos = new(200f, 100f, 0f);

        Color strCol = new(0, 0, 0, 0);
        Color fnlCol = new(0, 0, 0, 1);

        float speedTransition = 1f;
        docPage = 0;

        button1.GetComponent<Button>().interactable = false;
        button2.GetComponent<Button>().interactable = false;
        button3.GetComponent<Button>().interactable = false;

        imgButton1.GetComponent<Button>().interactable = false;
        imgButton2.GetComponent<Button>().interactable = false;
        imgButton3.GetComponent<Button>().interactable = false;
        imgButton4.GetComponent<Button>().interactable = false;

        if (t > 0f && stateApp == "BackFromMapMenu")
        {
            t -= speedTransition * Time.deltaTime;
            image1.GetComponent<RectTransform>().localPosition = Vector3.Lerp(img1StrPos, img1FnlPos, t);
            image2.GetComponent<RectTransform>().localPosition = Vector3.Lerp(img2StrPos, img2FnlPos, t);

            text1.GetComponent<TextMeshProUGUI>().color = Vector4.Lerp(strCol, fnlCol, t);
            text2.GetComponent<TextMeshProUGUI>().color = Vector4.Lerp(strCol, fnlCol, t);
            text3.GetComponent<TextMeshProUGUI>().color = Vector4.Lerp(strCol, fnlCol, t);
        }

        if (t > 0f && stateApp != "BackFromMapMenu")
        {
            t -= speedTransition * Time.deltaTime;
            image1.GetComponent<RectTransform>().localPosition = Vector3.Lerp(img1StrPos, img1FnlPos, t);

            text1.GetComponent<TextMeshProUGUI>().color = Vector4.Lerp(strCol, fnlCol, t);
            text2.GetComponent<TextMeshProUGUI>().color = Vector4.Lerp(strCol, fnlCol, t);
            text3.GetComponent<TextMeshProUGUI>().color = Vector4.Lerp(strCol, fnlCol, t);
        }

        if (t < 0f)
        {
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);

            imgButton1.SetActive(false);
            imgButton2.SetActive(false);
            imgButton3.SetActive(false);
            imgButton4.SetActive(false);

            image1.GetComponent<RectTransform>().localScale = Vector3.one;

            stateApp = state;
        }
    }

    void LoadMapMenu()
    {
        Vector3 img1StrPos = new(-700f, 0f, 0f);
        Vector3 img1FnlPos = new(-150f, 0f, 0f);

        Vector3 img2StrPos = new(200f, 500f, 0f);
        Vector3 img2FnlPos = new(200f, 100f, 0f);

        Color strCol = new(0, 0, 0, 0);
        Color fnlCol = new(0, 0, 0, 1);

        float speedTransition = 1f;

        button1.SetActive(true);
        button2.SetActive(true);

        imgButton1.SetActive(true);
        imgButton2.SetActive(true);
        imgButton3.SetActive(true);
        imgButton4.SetActive(true);

        button1.GetComponent<RectTransform>().localPosition = new(200f, -37.5f, 0f);
        button2.GetComponent<RectTransform>().localPosition = new(200f, -112.5f, 0f);

        imgButtonSelected = imgButton1;

        imgButton1.GetComponent<Image>().color = new Color(0, 255, 0, 255);
        imgButton2.GetComponent<Image>().color = new Color(255, 255, 255, 125);
        imgButton3.GetComponent<Image>().color = new Color(255, 255, 255, 125);
        imgButton4.GetComponent<Image>().color = new Color(255, 255, 255, 125);

        text1.GetComponent<TextMeshProUGUI>().text = "VISITA SCENA";
        text2.GetComponent<TextMeshProUGUI>().text = "INDIETRO";

        image1.GetComponent<Image>().sprite = mappa;
        image2.GetComponent<Image>().sprite = panoramica1;

        if (t < 1f)
        {
            t += speedTransition * Time.deltaTime;
            image1.GetComponent<RectTransform>().localPosition = Vector3.Lerp(img1StrPos, img1FnlPos, t);
            image2.GetComponent<RectTransform>().localPosition = Vector3.Lerp(img2StrPos, img2FnlPos, t);
            text1.GetComponent<TextMeshProUGUI>().color = Vector4.Lerp(strCol, fnlCol, t);
            text2.GetComponent<TextMeshProUGUI>().color = Vector4.Lerp(strCol, fnlCol, t);
        }

        if (t > 1f)
        {
            imgButton1.GetComponent<Button>().interactable = false;
            imgButton2.GetComponent<Button>().interactable = true;
            imgButton3.GetComponent<Button>().interactable = true;
            imgButton4.GetComponent<Button>().interactable = true;

            button1.GetComponent<Button>().interactable = true;
            button2.GetComponent<Button>().interactable = true;

            stateApp = "MapMenu";
        }
    }

    void LoadDocumentation()
    {
        Vector3 img1StrPos = new(-700f, 0f, 0f);
        Vector3 img1FnlPos = new(-150f, 0f, 0f);

        Color strCol = new(0, 0, 0, 0);
        Color fnlCol = new(0, 0, 0, 1);

        float speedTransition = 1f;

        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);

        button1.GetComponent<RectTransform>().localPosition = new(200f, 75f, 0f);
        button2.GetComponent<RectTransform>().localPosition = new(200f, 0f, 0f);
        button3.GetComponent<RectTransform>().localPosition = new(200f, -75f, 0f);

        text1.GetComponent<TextMeshProUGUI>().text = "Pagina Successiva";
        text2.GetComponent<TextMeshProUGUI>().text = "Pagina Precedente";
        text3.GetComponent<TextMeshProUGUI>().text = "INDIETRO";

        docPage = 0;

        image1.GetComponent<RectTransform>().localScale = new Vector3(1.25f, 1.25f, 1.25f);
        image1.GetComponent<Image>().sprite = documentazione[0];

        if (t < 1f)
        {
            t += speedTransition * Time.deltaTime;
            image1.GetComponent<RectTransform>().localPosition = Vector3.Lerp(img1StrPos, img1FnlPos, t);
            text1.GetComponent<TextMeshProUGUI>().color = Color.Lerp(strCol, fnlCol, t);
            text2.GetComponent<TextMeshProUGUI>().color = Color.Lerp(strCol, new (0.8f, 0.8f, 0.8f, 1), t);
            text3.GetComponent<TextMeshProUGUI>().color = Color.Lerp(strCol, fnlCol, t);
        }

        if (t > 1f)
        {
            button1.GetComponent<Button>().interactable = true;
            button2.GetComponent<Button>().interactable = false;
            button3.GetComponent<Button>().interactable = true;
            stateApp = "Documentation";
        }
    }

    void LoadCredits()
    {
        Vector3 img1StrPos = new(-700f, 0f, 0f);
        Vector3 img1FnlPos = new(-150f, 0f, 0f);

        Color strCol = new(0, 0, 0, 0);
        Color fnlCol = new(0, 0, 0, 1);

        float speedTransition = 1f;

        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);

        button1.GetComponent<RectTransform>().localPosition = new(200f, 75f, 0f);
        button2.GetComponent<RectTransform>().localPosition = new(200f, 0f, 0f);
        button3.GetComponent<RectTransform>().localPosition = new(200f, -75f, 0f);

        text1.GetComponent<TextMeshProUGUI>().text = "Pagina Successiva";
        text2.GetComponent<TextMeshProUGUI>().text = "Pagina Precedente";
        text3.GetComponent<TextMeshProUGUI>().text = "INDIETRO";

        docPage = 0;

        image1.GetComponent<RectTransform>().localScale = new Vector3(1.25f, 1.25f, 1.25f);
        image1.GetComponent<Image>().sprite = credits[0];

        if (t < 1f)
        {
            t += speedTransition * Time.deltaTime;
            image1.GetComponent<RectTransform>().localPosition = Vector3.Lerp(img1StrPos, img1FnlPos, t);
            text1.GetComponent<TextMeshProUGUI>().color = Color.Lerp(strCol, fnlCol, t);
            text2.GetComponent<TextMeshProUGUI>().color = Color.Lerp(strCol, new(0.8f, 0.8f, 0.8f, 1), t);
            text3.GetComponent<TextMeshProUGUI>().color = Color.Lerp(strCol, fnlCol, t);
        }

        if (t > 1f)
        {
            button1.GetComponent<Button>().interactable = true;
            button2.GetComponent<Button>().interactable = false;
            button3.GetComponent<Button>().interactable = true;
            stateApp = "Credits";
        }
    }

    void PageSucc(List<Sprite> imageList)
    {
        if (docPage < imageList.Count - 1)
        {
            docPage += 1;
            image1.GetComponent<Image>().sprite = imageList[docPage];


            if (docPage >= 1 && docPage <= imageList.Count - 2)
            {
                button1.GetComponent<Button>().interactable = true;
                button2.GetComponent<Button>().interactable = true;

                text1.GetComponent<TextMeshProUGUI>().color = Color.black;
                text2.GetComponent<TextMeshProUGUI>().color = Color.black;
            }

            if (docPage == imageList.Count - 1)
            {
                text1.GetComponent<TextMeshProUGUI>().color = new Color(0.8f, 0.8f, 0.8f, 1);
                button1.GetComponent<Button>().interactable = false;
            }
        }
    }

    void PagePrec(List<Sprite> imageList)
    {
        if (docPage >= 0)
        {
            docPage -= 1;
            image1.GetComponent<Image>().sprite = imageList[docPage];


            if (docPage >= 1 && docPage <= imageList.Count - 2)
            {
                button1.GetComponent<Button>().interactable = true;
                button2.GetComponent<Button>().interactable = true;

                text1.GetComponent<TextMeshProUGUI>().color = Color.black;
                text2.GetComponent<TextMeshProUGUI>().color = Color.black;
            }

            if (docPage == 0)
            {
                text2.GetComponent<TextMeshProUGUI>().color = new Color(0.8f, 0.8f, 0.8f, 1);
                button2.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void Button1Click()
    {
        if (stateApp == "MainMenu")
            stateApp = "LoadMapMenu_1";

        if (stateApp == "Documentation")
            PageSucc(documentazione);

        if (stateApp == "Credits")
            PageSucc(credits);

        if (stateApp == "MapMenu" && sceneToLoad == 1)
            LoadScene(1);

        if (stateApp == "MapMenu" && sceneToLoad == 2)
            LoadScene(2);

        if (stateApp == "MapMenu" && sceneToLoad == 3)
            LoadScene(3);

        if (stateApp == "MapMenu" && sceneToLoad == 4)
            LoadScene(4);
    }

    public void Button2Click()
    {
        if (stateApp == "MainMenu")
            stateApp = "LoadDocumentation_1";

        if (stateApp == "MapMenu")
            stateApp = "BackFromMapMenu";

        if (stateApp == "Documentation")
            PagePrec(documentazione);

        if (stateApp == "Credits")
            PagePrec(credits);
    }

    public void Button3Click()
    {
        if (stateApp == "MainMenu")
            stateApp = "LoadCredits_1";

        if (stateApp == "Documentation")
            stateApp = "Back";

        if (stateApp == "Credits")
            stateApp = "Back";
    }

    public void ImgButton1Click()
    {
        if (stateApp == "MapMenu")
        {
            imgButtonSelected.GetComponent<Image>().color = new Color(255, 255, 255, 125);
            imgButtonSelected.GetComponent<Button>().interactable = true;
            imgButtonSelected = imgButton1;
            imgButtonSelected.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            imgButtonSelected.GetComponent<Button>().interactable = false;
            image2.GetComponent<Image>().sprite = panoramica1;
            sceneToLoad = 1;
        }
    }

    public void ImgButton2Click()
    {
        if (stateApp == "MapMenu")
        {
            imgButtonSelected.GetComponent<Image>().color = new Color(255, 255, 255, 125);
            imgButtonSelected.GetComponent<Button>().interactable = true;
            imgButtonSelected = imgButton2;
            imgButtonSelected.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            imgButtonSelected.GetComponent<Button>().interactable = false;
            image2.GetComponent<Image>().sprite = panoramica4;
            sceneToLoad = 2;
        }
    }

    public void ImgButton3Click()
    {
        if (stateApp == "MapMenu")
        {
            imgButtonSelected.GetComponent<Image>().color = new Color(255, 255, 255, 125);
            imgButtonSelected.GetComponent<Button>().interactable = true;
            imgButtonSelected = imgButton3;
            imgButtonSelected.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            imgButtonSelected.GetComponent<Button>().interactable = false;
            image2.GetComponent<Image>().sprite = panoramica3;
            sceneToLoad = 3;
        }
    }

    public void ImgButton4Click()
    {
        if (stateApp == "MapMenu")
        {
            imgButtonSelected.GetComponent<Image>().color = new Color(255, 255, 255, 125);
            imgButtonSelected.GetComponent<Button>().interactable = true;
            imgButtonSelected = imgButton4;
            imgButtonSelected.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            imgButtonSelected.GetComponent<Button>().interactable = false;
            image2.GetComponent<Image>().sprite = panoramica2;
            sceneToLoad = 4;
        }
    }

    void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        while (!operation.isDone) 
        {
            yield return null;
        }
    }
}
