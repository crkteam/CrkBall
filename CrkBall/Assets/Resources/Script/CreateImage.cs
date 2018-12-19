using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class CreateImage : MonoBehaviour
{
    private int[] json;
    private int point = 0;
    private List<GameObject> ballimage;
    public GameObject BigBallimage,BtnBallChangeImage;
    
    private JsonPlayer j;
    private AudioClip Clip;
    private GameObject ArrowLeft;
    private void Awake()
    {
        ballimage = new List<GameObject>();
        json = new[] {1, 2, 3};
        j=new JsonPlayer();
        GameObject image = Resources.Load<GameObject>("Ball/Ball_Image/item");

        for (int i = 0; i < j.getBall().Length; i++)
        {
                        GameObject buffer = Instantiate(image);
                        buffer.GetComponent<Image>().sprite = Resources.Load<Sprite>(check(j.getBall()[i],i));
                        buffer.transform.position = gameObject.transform.position;
                        buffer.transform.position += new Vector3((i) * 250, 0, 0);
                        buffer.transform.localScale = new Vector3(1, 1, 1);
                        buffer.transform.SetParent(gameObject.transform);
                        ballimage.Add(buffer);
        }
        		
        ArrowLeft=GameObject.Find("BallCnangeArrowL");
        if(Getkind()==0)
            ArrowLeft.SetActive(false);

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
                    return "Ball/Ball_Image/unlock";

                  default:
                      if (value == 2)
                          this.point =point;
                      return "Ball/Ball_Image/ball"+point;
                      
        }
    }
    void initPostion()
    {
        for(int i = 0; i < ballimage.Count; i++)
        {
            ballimage[i].transform.localPosition = new Vector3(-250*(point-i), 0f, 0f);
        }
    
    }
    void initScale()
    {
        foreach (var Scale in ballimage)
        {
            Scale.transform.localScale = new Vector3(0f, 0f, 0f);
        }

        ballimage[point].transform.localScale = new Vector3(1f, 1f, 1f);
        if (point - 1 >= 0)
            ballimage[point - 1].transform.localScale = new Vector3(0.5f, .5f, .5f);
        if (point + 1 <= ballimage.Count - 1)
            ballimage[point + 1].transform.localScale = new Vector3(.5f, .5f, .5f);
        BigBallimage.GetComponent<Image>().sprite = ballimage[point].GetComponent<Image>().sprite;
        BtnBallChangeImage.GetComponent<Image>().sprite = ballimage[point].GetComponent<Image>().sprite;
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

            ballimage[point].transform.localScale += new Vector3(.04f, .04f, .04f);
            if (point - 1 >= 0)
            {
                ballimage[point - 1].transform.localScale -= new Vector3(.04f, .04f, .04f);
            }

            if (point - 2 >= 0)
            {
                ballimage[point - 2].transform.localScale -= new Vector3(.04f, .04f, .04f);
            }

            if (point + 1 <= ballimage.Count - 1)
                ballimage[point + 1].transform.localScale += new Vector3(.04f, .04f, .04f);
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
            ballimage[point].transform.localScale += new Vector3(.04f, .04f, .04f);
            if (point - 1 >= 0)
            {
                ballimage[point - 1].transform.localScale += new Vector3(.04f, .04f, .04f);
            }

            if (point + 1 <= ballimage.Count)
                ballimage[point + 1].transform.localScale -= new Vector3(.04f, .04f, .04f);
            if (point + 2 <= ballimage.Count - 1)
                ballimage[point + 2].transform.localScale -= new Vector3(.04f, .04f, .04f);
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
            foreach (var moveG in ballimage)
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

    public void check(GameObject Arrow, GameObject Arrowopposite)
    {
        if (point == 0 || point == ballimage.Count - 1)
        {
            Arrow.SetActive(false);
            
        }
        else
        {
            Arrowopposite.SetActive(true);
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
     
        return ballimage.Count;
    }

    // Update is called once per frame
    void Update()
    {
    }
}