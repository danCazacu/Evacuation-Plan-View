using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;


public class Corner
{
    private String v_X;
    private String v_Y;
    private String wall1;
    private String wall2;
    private String roomLabel = null;
    private String levelLabel = null;

    public Corner(String x, String y, String wall1, String wall2, String roomLabel, String levelLabel)
    {
        this.v_X = x;
        this.v_Y = y;

        this.wall1 = wall1;
        this.wall2 = wall2;

        this.roomLabel = roomLabel;
        this.levelLabel = levelLabel;

    }

    public String getCX()
    {
        return this.v_X;
    }
    public String getRoomLabel()
    {
        return this.roomLabel;
    }
    public String getLevelLabel()
    {
        return this.levelLabel;
    }
    public String getCY()
    {
        return this.v_Y;
    }

    public String getW1()
    {
        return this.wall1;
    }

    public String getW2()
    {
        return this.wall2;
    }


}
public class perete
{
        private String label;
        private float x1,x2,y1,y2;
        private float centerX,centerY;
        private float length;
        private float width = 0.01f;
        private float angleY;

        public perete(float x1,float x2,float y1,float y2,String label) {
            this.label = label;
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
            this.centerX = (x1+ x2)/ 2;
            this.centerY = (y1 + y2) / 2;
            this.length = (float) Math.Sqrt(((x2 - x1) * (x2 - x1)) - ((y2 - y1) * (y2 - y2)));
            //this.angleY = (float) Math.Tan((y2- y1)/(x2- x1));
            this.angleY = (float)Mathf.Atan2(y2 - y1, x2 - x1) * 180 / Mathf.PI;


    }

    public float getCenterX()
        {
            return this.centerX;

        }

        public float getCenterY()
        {
            return this.centerY;
        }

        public float getX1()
        {
            return this.x1;
        }
        public float getX2()
        {
            return this.x2;
        }
        public float getY1()
        {
            return this.y1;
        }
        public float getY2()
        {
            return this.y1;
        }

        public float getLength()
        {
            return this.length;
        }
        public float getWidth()
        {
            return this.width;
        }

        public float getAngleY()
        {
            return this.angleY;
        }
        public String getLabel()
        {
            return this.label;
        }

    }

    public class TestWall : MonoBehaviour {
    
    // Use this for initialization
    public static List<perete> createWalls()
    {
        List<Corner> arr = new List<Corner>();
        StringBuilder output = new StringBuilder();
        String corx = null;
        String cory = null;
        String wallL = null;
        String wall1 = null;
        String wall2 = null;
        String roomLabel = null;
        String levelLabel = null;

        int number_of_walls;

        string xmlstring = File.ReadAllText(@"C:\Users\Admin\Desktop\Base.xml");

        // Create an XmlReader
        XmlReader xReader = XmlReader.Create(new StringReader(xmlstring));
        bool checkx = false;
        bool checky = false;
        bool checkw = false;
        bool checkr = false;
        bool checkl = false;
        while (xReader.Read())
        {

            if (xReader.Name.Equals("cornerX"))
            {
                checkx = true;

            }
            if (checkx && xReader.NodeType == XmlNodeType.Text)
            {
                corx = xReader.Value;
                checkx = false;
                xReader.Read();

            }

            if (xReader.Name.Equals("ROOM"))
            {
                checkr = true;
            }
            if (checkr && xReader.NodeType == XmlNodeType.Text)
            {
                roomLabel = xReader.Value;
                checkr = false;
                xReader.Read();

            }

            if (xReader.Name.Equals("LEVEL"))
            {
                checkl = true;
            }
            if (checkl && xReader.NodeType == XmlNodeType.Text)
            {
                levelLabel = xReader.Value;
                checkl = false;
                xReader.Read();
            }

            if (xReader.Name.Equals("cornerY"))
            {
                checky = true;
            }
            if (checky && xReader.NodeType == XmlNodeType.Text)
            {
                cory = xReader.Value;
                checky = false;
                xReader.Read();

            }

            if (xReader.Name.Equals("wallLabels"))
            {
                checkw = true;
            }
            if (checkw && xReader.NodeType == XmlNodeType.Text)
            {

                checkw = false;
                wallL = xReader.Value;

                int pos = 0;

                for (int i = 0; i < wallL.Length; i++)
                    if (wallL.ElementAt(i) != ',')
                        wall1 = wall1 + wallL.ElementAt(i);
                    else
                    {
                        pos = i;
                        break;
                    }

                for (int i = pos + 1; i < wallL.Length; i++)
                    wall2 = wall2 + wallL.ElementAt(i);
                xReader.Read();

            }

            if (corx != null && cory != null && wall1 != null && wall2 != null && roomLabel != null && levelLabel != null)
            {
                Corner cor = new Corner(corx, cory, wall1, wall2, roomLabel, levelLabel);
                arr.Add(cor);

                corx = null;
                cory = null;

                wall1 = null;
                wall2 = null;

            }

        }

        List<perete> pereti = new List<perete>();
        for (int i = 0; i < arr.Count; i++)
        {
            perete wall = null;
            for (int j = i + 1; j < arr.Count; j++)
            {
                if (arr.ElementAt(i).getLevelLabel().Equals(arr.ElementAt(j).getLevelLabel()))
               // if (arr.ElementAt(i).getLevelLabel().Equals('1'))
                {
                    if (arr.ElementAt(i).getRoomLabel().Equals(arr.ElementAt(j).getRoomLabel()))
                    {
                        if (arr.ElementAt(i).getW1().Equals(arr.ElementAt(j).getW1()))
                        {
                            wall = new perete(float.Parse(arr.ElementAt(i).getCX()), float.Parse(arr.ElementAt(j).getCX())
                                , float.Parse(arr.ElementAt(i).getCY()), float.Parse(arr.ElementAt(j).getCY()), arr.ElementAt(i).getW1());

                            pereti.Add(wall);
                        }
                        if (arr.ElementAt(i).getW1().Equals(arr.ElementAt(j).getW2()))
                        {
                            wall = new perete(float.Parse(arr.ElementAt(i).getCX()), float.Parse(arr.ElementAt(j).getCX())
                                , float.Parse(arr.ElementAt(i).getCY()), float.Parse(arr.ElementAt(j).getCY()), arr.ElementAt(i).getW1());

                            pereti.Add(wall);

                        }
                        if (arr.ElementAt(i).getW2().Equals(arr.ElementAt(j).getW1()))
                        {
                            wall = new perete(float.Parse(arr.ElementAt(i).getCX()), float.Parse(arr.ElementAt(j).getCX())
                                , float.Parse(arr.ElementAt(i).getCY()), float.Parse(arr.ElementAt(j).getCY()), arr.ElementAt(i).getW1());

                            pereti.Add(wall);
                        }
                        if (arr.ElementAt(i).getW2().Equals(arr.ElementAt(j).getW2()))
                        {
                            wall = new perete(float.Parse(arr.ElementAt(i).getCX()), float.Parse(arr.ElementAt(j).getCX())
                                , float.Parse(arr.ElementAt(i).getCY()), float.Parse(arr.ElementAt(j).getCY()), arr.ElementAt(i).getW1());

                            pereti.Add(wall);
                        }

                    }
                }

            }
        }
        return pereti;
    }

    public List<perete> pereti = TestWall.createWalls();
    void Start () {

        // vector de pereti 
        //mijoc
        //unghi
        //lungime 
        GameObject wall = null;
        wall = new GameObject();
        for (int i=0; i<pereti.Count;i++)
        {
            wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall.transform.position = new Vector3(pereti.ElementAt(i).getCenterX(),0.5F,pereti.ElementAt(i).getCenterY());
            wall.transform.localScale = new Vector3(pereti.ElementAt(i).getLength(),1,pereti.ElementAt(i).getWidth());
            wall.transform.eulerAngles = new Vector3(0,pereti.ElementAt(i).getAngleY(),0);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
