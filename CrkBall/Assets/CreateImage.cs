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

    private void Awake()
    {
        ballimage = new List<GameObject>();
        json = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
  
        GameObject image = Resources.Load<GameObject>("BallImage/Item");


        foreach (var value in json)
        {
            GameObject buffer = Instantiate(image);
            buffer.GetComponent<Image>().sprite = Resources.Load<Sprite>("BallImage/" + value);
            buffer.transform.position = gameObject.transform.position;
            buffer.transform.position += new Vector3((value - 1) * 250, 0, 0);
            buffer.transform.localScale = new Vector3(1, 1, 1);
            buffer.transform.SetParent(gameObject.transform);
            ballimage.Add(buffer);
        
        }
    }

    void initScale()
    {
        foreach (var Scale in ballimage)
        {
            Scale.transform.localScale=new Vector3(0f,0f,0f);
        }
        ballimage[point].transform.localScale=new Vector3(1f,1f,1f);
        if (point - 1 >= 0)
        ballimage[point-1].transform.localScale=new Vector3(0.5f,.5f,.5f);
        if(point<=ballimage.Count)
        ballimage[point+1].transform.localScale=new Vector3(.5f,.5f,.5f);
       
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
        float ScalePoint=0;
        while (true)
        {
     
            ScalePoint += 0.04f;
           ballimage[point].transform.localScale+=new Vector3(.04f,.04f,.04f);
            if (point - 1 >= 0)
            {
                ballimage[point-1].transform.localScale -= new Vector3(.04f, .04f, .04f);
            }
            if (point - 2 >= 0)
            {
                ballimage[point-2].transform.localScale -= new Vector3(.04f, .04f, .04f);
            }
            if(point<=ballimage.Count)
            ballimage[point+1].transform.localScale+=new Vector3(.04f,.04f,.04f);
            yield return  new  WaitForSeconds(.01f);
            if (ScalePoint>=.5f)
            {
               break; 
            }
        }
        initScale();
        
    }
    IEnumerator ScaleToR()
    {
        float ScalePoint=0;
        while (true)
        {
            ScalePoint += 0.04f;
            ballimage[point].transform.localScale+=new Vector3(.04f,.04f,.04f);
            if (point - 1 >= 0)
            {
                ballimage[point-1].transform.localScale += new Vector3(.04f, .04f, .04f);
            }
            if(point+1<=ballimage.Count)
                ballimage[point+1].transform.localScale-=new Vector3(.04f,.04f,.04f);
            if(point+2<=ballimage.Count)
                ballimage[point+2].transform.localScale-=new Vector3(.04f,.04f,.04f);
            yield return  new  WaitForSeconds(.01f);
            if (ScalePoint>=.5f)
            {
                break; 
            }
        }
        initScale();
    }
    IEnumerator  Move(float move)
    {
        int countp=0;
        while (true)
        {
            countp += 50;
            foreach (var moveG in ballimage)
            {
              
                moveG.transform.position-=new Vector3(move*50,0f,0f);
				
            }

            if (countp >= 250)
            {
        				
                break;
            }
            yield return new WaitForSeconds(.02f);
			

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
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}