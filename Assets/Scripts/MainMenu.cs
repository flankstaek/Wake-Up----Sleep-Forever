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

    private float tfo = .5f; //Time that text is faded out
    private float tfd = .25f; //Time that text is displayed
    private float tad = 2.6f; //Time between attacks being sent
    private float tbf = .5f; //Time before fading in next attack

    void Awake() {
        Screen.showCursor = false;
        lines[0] = "Welcome to Wake Up // Sleep Forever";
        lines[1] = "Getting hit by an enemy changes your defense type";
        lines[2] = "This is the RED defense\nPress two adjacent bumpers to create a shield";
        lines[3] = "This is the BLUE defense\nPoint the joystick towards the direction you want to shield";
        lines[4] = "This is the GREEN defense\nPress any face button to create a temporary shield";
        lines[5] = "You lose if you get hit by the same color enemy as you";
        lines[6] = "Press START when you're ready to start playing";

        curText = lines[textMarker];

        text = textObj.guiText;
        text.text = curText;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);

        float width = Screen.width;
        float height = (403f / 1275f) * width;
        float left = (Screen.width - width)/ 2;
        float top = (Screen.height * .5f) - height/2;
        drawspace = new Rect(left, top, width, height);

        GameObject.Find("PlayerModel").renderer.material.color = Color.black;
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
            GameObject.Find("PlayerModel").renderer.material.color = Color.white;
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
        if(textMarker == 0 && faded && checkTime(tfo) && imgFade && alph <= 0) {
            fadeTextIn();
        }
        if(textMarker == 0 && !faded && checkTime(tfd)) {
            fadeTextOut(1);
        }
        if(textMarker == 1 && faded && checkTime(tfo)) {
            fadeTextIn();
        }
        if(textMarker == 1 && !faded && checkTime(tfd)) {
            if(spawn) {Instantiate(squEnemy, new Vector3(0f, -7f, 1f), Quaternion.identity); spawn = false; }
            fadeTextOut(2);
        }
        if(textMarker == 2 && faded && checkTime(tfo)) {
            fadeTextIn();
        }
        if(textMarker == 2 && !faded && checkTime(tfd)) {
            spawn = true;
            fadeTextOut(3);

        }
        if(textMarker == 3 && checkTime(tad) && killed != 3) {
            if(spawn) {
                Instantiate(triEnemy, new Vector3(0.5f, -7, 1f), Quaternion.identity);
                timeKeeper = Time.time;
                playerCollider(false);}}
        if(textMarker == 3 && killed == 3 && checkTime(tbf) && faded) {
            if(spawn) {
                playerCollider(true);
                Instantiate(cirEnemy, new Vector3(9f, 0f, 1f), Quaternion.identity);
                spawn = false;
                attackOff();}
                fadeTextIn();
            }
        if(textMarker == 3 && killed == 3 && checkTime(tfd) && !faded) {
            spawn = true;
            fadeTextOut(4);
        }
        if(textMarker == 4 && checkTime(tad) && killed != 6) {
            if(spawn) {
                Instantiate(squEnemy, new Vector3(0f, 7f, 1f), Quaternion.identity);
                timeKeeper = Time.time;
                playerCollider(false);}}
        if(textMarker == 4 && killed == 6 && checkTime(tbf) && faded) {
            if(spawn) {
                playerCollider(true);
                Instantiate(triEnemy, new Vector3(-9f, 0f, 1f), Quaternion.identity);
                spawn = false;
                attackOff();}
                fadeTextIn();
            }
        if(textMarker == 4 && killed == 6 && checkTime(tfd) && !faded) {
            spawn = true;
            fadeTextOut(5);
        }
        if(textMarker == 5 && checkTime(tad) && killed != 9) {
            if(spawn) {
                Instantiate(cirEnemy, new Vector3(0f, -7f, 1f), Quaternion.identity);
                timeKeeper = Time.time;
                playerCollider(false);}}
        
        if(textMarker == 5 && killed == 9 && checkTime(tfo) && faded) {
            fadeTextIn();
            spawn = false;
            attackOff();
        }
        if(textMarker == 5 && checkTime(tfd) && !faded) {
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
