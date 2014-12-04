using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    /*
    If statement numbers & shit:
    timeFade = .25
    1f
    2f
    .5f
    .5f

    */

    //Off screen boundaries : X = 9, Y = 7

    public Texture2D img;
    private Rect drawspace;

    public GameObject textObj;
    private GUIText text;

    private int textMarker = 0;
    private string[] lines = new string[7];
    private string curText;

    private float timeKeeper = 0;
    public float timeFade;
    private bool faded = true;

    public GameObject triEnemy;
    public GameObject squEnemy;
    public GameObject cirEnemy;

    private bool spawn = true;
    private int killed = 0;
    private float alph = 0;
    private bool imgFade = false;

    void Awake() {
        Screen.showCursor = false;
        lines[0] = "Welcome to Wake Up // Sleep Forever";
        lines[1] = "Getting hit by an enemy changes your attack";
        lines[2] = "This is the RED attack.\nPress two adjacent bumpers to create a shield";
        lines[3] = "This is the BLUE attack.\nPoint the joystick towards the direction you want to shield";
        lines[4] = "This is the GREEN attack.\nPress any face button to create a temporary shield.";
        lines[5] = "You lose if you get hit by the same color enemy as you.";
        lines[6] = "Press START when you're ready to start playing";

        curText = lines[textMarker];

        text = textObj.guiText;
        text.text = curText;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);

        float width = Screen.width;
        float height = (403f / 1275f) * width;
        float left = (Screen.width - width)/ 2;
        float top = (Screen.height * .0f);
        drawspace = new Rect(left, top, width, height);

    }

    void Start() {
        timeKeeper = Time.time;
    }

    void OnGUI() {
        setText();
        if(alph < 1f && !imgFade) {
            alph += .1f * Time.deltaTime;
        }
        else if(alph >= 1f) {
            imgFade = true;
        }
        if(imgFade && alph > 0) {
            alph -= .1f * Time.deltaTime;
        }
        GUI.color = new Color(1, 1, 1, alph);
        if(alph > 0)
            GUI.DrawTexture(drawspace, img);
    }

    void Update() {
        if(Input.GetAxis("Start") > 0) {
            Application.LoadLevel("sleep");
        }
        if(Input.GetKeyDown("escape")) {
            Application.Quit();
        }
        if(textMarker == 0 && faded && checkTime(.75f) && imgFade && alph <= 0) {
            fadeTextIn();
        }
        if(textMarker == 0 && !faded && checkTime(1.5f)) {
            fadeTextOut(1);
        }
        if(textMarker == 1 && faded && checkTime(.5f)) {
            fadeTextIn();
        }
        if(textMarker == 1 && !faded && checkTime(.5f)) {
            if(spawn) {Instantiate(squEnemy, new Vector3(0f, -7f, 1f), Quaternion.identity); spawn = false; }
            fadeTextOut(2);
        }
        if(textMarker == 2 && faded && checkTime(.5f)) {
            fadeTextIn();
        }
        if(textMarker == 2 && !faded && checkTime(.75f)) {
            spawn = true;
            fadeTextOut(3);

        }
        if(textMarker == 3 && checkTime(2f) && killed != 3) {
            if(spawn) {
                Instantiate(triEnemy, new Vector3(0.5f, -7, 1f), Quaternion.identity);
                timeKeeper = Time.time;
                playerCollider(false);}}
        if(textMarker == 3 && killed == 3 && checkTime(1f) && faded) {
            if(spawn) {
                playerCollider(true);
                Instantiate(cirEnemy, new Vector3(9f, 0f, 1f), Quaternion.identity);
                spawn = false;
                attackOff();}
                fadeTextIn();
            }
            if(textMarker == 3 && killed == 3 && checkTime(.5f) && !faded) {
                spawn = true;
                fadeTextOut(4);
            }
            if(textMarker == 4 && checkTime(2f) && killed != 6) {
                if(spawn) {
                    Instantiate(squEnemy, new Vector3(-9f, 0f, 1f), Quaternion.identity);
                    timeKeeper = Time.time;
                    playerCollider(false);}}
            if(textMarker == 4 && killed == 6 && checkTime(1f) && faded) {
                if(spawn) {
                    playerCollider(true);
                    Instantiate(triEnemy, new Vector3(-.5f, -7f, 1f), Quaternion.identity);
                    spawn = false;
                    attackOff();}
                    fadeTextIn();
                }
            if(textMarker == 4 && killed == 6 && checkTime(.5f) && !faded) {
                spawn = true;
                fadeTextOut(5);
            }
            if(textMarker == 5 && checkTime(1f) && killed != 9) {
                if(spawn) {
                    Instantiate(cirEnemy, new Vector3(0f, 7f, 1f), Quaternion.identity);
                    timeKeeper = Time.time;
                    playerCollider(false);}}
            
            if(textMarker == 5 && killed == 9 && checkTime(.5f) && faded) {
                fadeTextIn();
                spawn = false;
                attackOff();
            }
            if(textMarker == 5 && checkTime(1f) && !faded) {
                fadeTextOut(6);
            }
            if(textMarker == 6 && checkTime(0f) && faded) {
                fadeTextIn();
            }

            }

        //update text
        void setText() {
            curText = lines[textMarker];
            text.text = curText;    
        }

        //True if fading (false when finished so you can while(fadeIn()))

        bool fadeTextIn() {
            if(text.color.a < 1f) {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + timeFade * Time.deltaTime);
                return true;
            }
            else {
                faded = false;
                timeKeeper = Time.time;
                return false;
            }
        }

        bool fadeTextOut(int m) {
            if(text.color.a > 0f) {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - timeFade * Time.deltaTime);
                return true;
            }
            else {
                timeKeeper = Time.time;
                faded = true;
                textMarker = m;
                return false;
            }
        }

        //True if it's been t seconds since last time we updated timeKeeper
        bool checkTime(float t) {
            return Time.time - timeKeeper > t;
        }

        GameObject randEnemy() {
            int r = Random.Range(0,3);
            switch (r) {
                case 0:
                return cirEnemy;
                case 1:
                return triEnemy;
                case 2:
                return squEnemy;
                default:
                Debug.Log("Randomization error");
                return null;
            } 
        }

        Vector3 randPoint() {
            Vector3 pos = new Vector3(0, 0, 0);
            //Eventually spawn an enemy somewhere MAYBE for now just hard code it, it's easier.

            return pos;
        }



        public void addKill() {
            killed++;
        }

        void playerCollider(bool p) {
            GameObject.Find("PlayerCollider").GetComponent<IntroPlayerScript>().collide = p;
        }

        void attackOff() {
            GameObject.Find("PlayerCollider").GetComponent<IntroPlayerScript>().attackOff();
        }
            }
