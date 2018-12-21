using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GameObject;

public class CreateMusic : MonoBehaviour {

    private int point = 0;
    private List<GameObject> Musicimage;
    public GameObject BigMusicimage;
    private GameObject Arrow, Arrowopposite,btncheck;
    private JsonPlayer json;
    private AudioClip Clip;
    private GameObject ArrowLeft;
    private void Awake()
    {
        
        Musicimage = new List<GameObject>();
        json=new JsonPlayer();
        GameObject image = Resources.Load<GameObject>("music/Music_Image/item");

        for (int i = 0; i < json.getMusic().Length; i++)
        {
                        GameObject buffer = Instantiate(image);
                        buffer.GetComponent<Image>().sprite = Resources.Load<Sprite>(check(json.getMusic()[i],i));
                        buffer.transform.position = gameObject.transform.position;
                        buffer.transform.position += new Vector3((i) * 250, 0, 0);
                        buffer.transform.localScale = new Vector3(1, 1, 1);
                        buffer.transform.SetParent(gameObject.transform);
                        Musicimage.Add(buffer);
        }
        Arrow = Find("MusicCnangeArrowL");
        Arrowopposite = Find("MusicChangeArrow");
        ArrowLeft=Find("MusicCnangeArrowL");
        btncheck = Find("MusicExit");
        if(Getkind()==0)
            ArrowLeft.SetActive(false);
    
    }

    public void WriteData()
    {
        int []temp = json.getMusic();
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i] == 2)
            {
                temp[i] = 1;
            }
        }

        temp[point] = 2;
        json.setMusic(temp);

    }
    public  void Playmusic()
    {
        gameObject.GetComponent<AudioSource>().Play();
        
    }

    string check(int value,int point)
    {
        switch (value)
        {
                case 0:
                    return "music/Music_Image/unlock";

                  default:
                      if (value == 2)
                          this.point =point;
                      return "music/Music_Image/Music"+point;
                      
        }
    }
    void initPostion()
    {
        for(int i = 0; i < Musicimage.Count; i++)
        {
            Musicimage[i].transform.localPosition = new Vector3(-250*(point-i), 0f, 0f);
        }
    
    }
    void initScale()
    {
        foreach (var Scale in Musicimage)
        {
            Scale.transform.localScale = new Vector3(0f, 0f, 0f);
        }

        Musicimage[point].transform.localScale = new Vector3(1f, 1f, 1f);
        if (point - 1 >= 0)
            Musicimage[point - 1].transform.localScale = new Vector3(0.5f, .5f, .5f);
        if (point + 1 <= Musicimage.Count - 1)
            Musicimage[point + 1].transform.localScale = new Vector3(.5f, .5f, .5f);
        BigMusicimage.GetComponent<Image>().sprite = Musicimage[point].GetComponent<Image>().sprite;
     }

    public void MovePoint(float move)
    {
        if (move > 0)
        {
            StartCoroutine(ScaleToL());
        }
        else
        {
            StartCoroutine(ScaleToR());
        }

        StartCoroutine(Move(move)); //移動250
    }

    IEnumerator ScaleToL()
    {
        float ScalePoint = 0;
        while (true)
        {
            ScalePoint += 0.04f;

            Musicimage[point].transform.localScale += new Vector3(.04f, .04f, .04f);
            if (point - 1 >= 0)
            {
                Musicimage[point - 1].transform.localScale -= new Vector3(.04f, .04f, .04f);
            }

            if (point - 2 >= 0)
            {
                Musicimage[point - 2].transform.localScale -= new Vector3(.04f, .04f, .04f);
            }

            if (point + 1 <= Musicimage.Count - 1)
                Musicimage[point + 1].transform.localScale += new Vector3(.04f, .04f, .04f);
            yield return new WaitForSeconds(.01f);
            if (ScalePoint >= .5f)
            {
                break;
            }
        }

        initScale();
    }

    IEnumerator ScaleToR()
    {
        float ScalePoint = 0;
        while (true)
        {
            ScalePoint += 0.04f;
            Musicimage[point].transform.localScale += new Vector3(.04f, .04f, .04f);
            if (point - 1 >= 0)
            {
                Musicimage[point - 1].transform.localScale += new Vector3(.04f, .04f, .04f);
            }

            if (point + 1 <= Musicimage.Count)
                Musicimage[point + 1].transform.localScale -= new Vector3(.04f, .04f, .04f);
            if (point + 2 <= Musicimage.Count - 1)
                Musicimage[point + 2].transform.localScale -= new Vector3(.04f, .04f, .04f);
            yield return new WaitForSeconds(.01f);
            if (ScalePoint >= .5f)
            {
                break;
            }
        }

        initScale();
    }

    IEnumerator Move(float move)
    {
        int countp = 0;
        while (true)
        {
            countp += 50;
            foreach (var moveG in Musicimage)
            {
                moveG.transform.position -= new Vector3(move * 50, 0f, 0f);
            }

            if (countp >= 250)
            {
                initPostion();
                break;
            }

            yield return new WaitForSeconds(.01f);
        }
      
    }

    public void Check()
    {
        Color c =new Color(1f,1f,1f,1f);
        if (json.getMusic()[point]==0)
        {
            c.a = .5f;
            btncheck.GetComponent<Image>().color= c;
            btncheck.GetComponent<OpenMenu>().enabled = false;
        }
        else
        {
            c.a = 1f;
            btncheck.GetComponent<Image>().color= c;
            btncheck.GetComponent<OpenMenu>().enabled = true;
        }
        
            
        if (point == 0)
        {
            Arrowopposite.SetActive(true);
            Arrow.SetActive(false);
        }
        else if (point == Musicimage.Count - 1)
        {
            Arrow.SetActive(true);
            Arrowopposite.SetActive(false);
        }
        else
        {
            Arrowopposite.SetActive(true);
            Arrow.SetActive(true);
        }
    }

    public void increase(int x)
    {
        point += x;
    }

    // Use this for initialization
    void Start()
    {
        initScale();
        initPostion();
      //  initPostion();
    }

    public int Getkind()
    {
        return point;
    }

    public int GetBallimageCount()
    {
     
        return Musicimage.Count;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
