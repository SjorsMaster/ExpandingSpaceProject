using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Shailes op line 185 staat een berricht voor je, Lees het even aub. Thanks :)

public class Player : MonoBehaviour

{
    /*<------ITEMS------>*/
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    public GameObject Warning;


    /*<------ANIMATORS------>*/

    Animator m_Animator;


    /*<------Booleans------>*/

    private bool MoonJumper; //Kijken of er is gesprongen
    private bool Loaded; //Kijken of GameOver scene niet al is ingeladen.
    private bool holding; //Kijken of de speler iets vast heeft.
    private bool MovingL;
    private bool MovingR;
    private bool fly;
    private bool landing;

    public bool GODMODE;
    public bool GameOver; //Kijken of het spel al over is.





    /// <summary>
    /// other
    public ParticleSystem Poof;
    /// </summary>

    /*<------Texts------>*/

    public Text ItemsLeft; //Laten zien hoeveel items er nog overzijn in dit level.


    /*<------Images------>*/

    public Image cooldown; // ??? <-Shailesh info a u b?


    /*<------INTEGERS------>*/

    private int Counter; //Sprong counter noodgevallen
    private int Collected; //Zien hoeveel er verzameld zijn.
    private int StageID; //Level nummer
    private int Completed; //Levels behaald

    public int RocketState = 0;
    public int HaveToCollect;//Hoeveel de speler moet verzamelen om het level te behalen.
    public int left; //Zien hoeveel er nog over zijn.


    public int SelectedSkin;


    /*<------FLOATS------>*/

    private float IntJumper; //Airspeed? 
    public float WalkSpeed; //Loopsnelheid
    public float Speed; //Algemene snelheid
    public float Timer; //Level tijdslimiet(Zuurstof)
    public float MinTime = 1; //Minimale tijdslimiet

    public float Teller = 0;


    /*<------GAMEOBJECTS------>*/

    public GameObject deadGrijs;
    public GameObject winGrijs;
    public GameObject deadRood;
    public GameObject deadBlauw; //Speler, DOOD
    public GameObject dead; //Speler, DOOD
    public GameObject win; //Speler, GEWONNEN
    public GameObject winBlauw;
    public GameObject winRood;
    public GameObject dust; //Rook wolken
    public GameObject confirm; //Confirmatie opakken/Weggebracht
    public GameObject raketGemaakt;//Gefixte Raket
    public GameObject raketKapot;//KapotteRaket


    /*<------STRING------>*/

    private string CurrentStage;//Place voor scene naam


    /*<------AUDIO------>*/

    public AudioSource pickup;
    public AudioSource jump;
    private bool preparedone;

    void Start()
    {
        SelectedSkin = PlayerPrefs.GetInt("Skin", 0);

        //AudioSource audio = GetComponent<AudioSource>();
        m_Animator = GetComponent<Animator>();//Vind de animator van het object.
        if (SelectedSkin == 1)
        {
            m_Animator.SetTrigger("JumpBlauw");
        }
        if (SelectedSkin == 2)
        {
            m_Animator.SetTrigger("JumpRood");
        }
        if (SelectedSkin == 3)
        {
            m_Animator.SetTrigger("JumpGrijs");
        }
        CurrentStage = SceneManager.GetActiveScene().name;//Haal scene naam op.
        PlayerPrefs.SetString("StageRestart", CurrentStage);//Slaat huidige level op voor restart.
        StageID = int.Parse(SceneManager.GetActiveScene().name); //Haal huidige level naam op, En zet om tot een Int. \\Creert errors in levels zonder int.
        Completed = PlayerPrefs.GetInt("Completed", 0); //Haalt op hoeveel levels er behaald zijn, Kan hij niks vinden? Zet hij het op 0
        ItemsLeft.text = "Left: " + left; //Laad in hoeveel items je moet behalen voor het spel echt begint.

        // Debug.Log("Get Stage NAME: " + SceneManager.GetActiveScene().name + " INT = " + StageID); //Print de level naam als int en string.
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (PlayerPrefs.GetInt("Particles", 1) == 1) { 
            Instantiate(dust, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity); //Maakt rookeffecten.
            }
            if (!landing)
            {
                landing = true;
                //m_Animator.SetTrigger("Land");
            }
            MoonJumper = false;//Zet gesprongen op niet waar
            IntJumper = 0;//IntJumper 0?
        }

        if (other.gameObject.tag == "Enemy" &&  !GODMODE)
        {
            Death();//START DEATH FUNCTION
        }

        if (other.gameObject.tag == "OOB")//OOB STAAT VOOR "OUT OF BOUNDS" aka BUITEN LEVEL.
        {
            transform.position = new Vector2(this.gameObject.transform.position.x, -4.031514f);//Zet speler omhoog, zodat hij niet vooreeuwig zou kunnen vallen
        }
        if (other.gameObject.tag == "Collectable" && !holding) //Als object verzamelbaar is en speler niets vast heeft.
        {
            if (other.gameObject.name == "ruimteonderdeel_1")
            {
                Item1.SetActive(true);
            }
            if (other.gameObject.name == "ruimteonderdeel_2")
            {
                Item2.SetActive(true);
            }
            if (other.gameObject.name == "ruimteonderdeel_3")
            {
                Item3.SetActive(true);
            }
            if (other.gameObject.name == "ruimteonderdeel_4")
            {
                Item4.SetActive(true);
            }
            if (other.gameObject.name == "ruimteonderdeel_5")
            {
                Item5.SetActive(true);
            }
            Poof.Play();

            if (PlayerPrefs.GetInt("Achievements", 1) == 1)
            {
                PlayerPrefs.SetInt("Collector", PlayerPrefs.GetInt("Collector", 0) + 1);
            }
            pickup.Play();
            if (PlayerPrefs.GetInt("Particles", 1) == 1){
                Instantiate(confirm, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity); //Geeft confirmation effect op speler.
            }
            holding = true; //Zet vasthouden op waar.
            Destroy(other.gameObject); //Verwijder bestaan van verzamelbaar object, is niet meer nodig na oppakken.
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Exit")//Aanraking met uitgang van de wereld.(Finish)
        {
            if (holding)//Als de speler iets vast heeft
            {
                pickup.Play();
                holding = false;//Zet vasthouden op nietwaar, want het is weggebracht.
                Poof.Play();
                Item1.SetActive(false);
                Item2.SetActive(false);
                Item3.SetActive(false);
                Item4.SetActive(false);
                Item5.SetActive(false);
                if (PlayerPrefs.GetInt("Particles", 1) == 1){
                    Instantiate(confirm, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);//Creeert confrimatie effect.
                }
                Collected++;//Telt op hoeveel er verzameld zijn.
                RocketState++;

                left--;//Trekt af van hoeveel er nog moeten.
                ItemsLeft.text = "Left: " + left;//Update te text zodat de speler weet hoeveel er nog zijn.
            }
            if (Collected >= HaveToCollect)//Als er ## verzameld zijn heeft de speler gewonnen.
            {
                Win();//Voert de win functie uit
            }
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            MoonJumper = true;//Zet gesprongen op waar
        }
    }

    
    void FixedUpdate()
    {

        Teller += Time.deltaTime;

        if (GameObject.Find("Debugger(Clone)") != null)
        {
            fly = (GameObject.Find("Debugger(Clone)").GetComponent<DebugScript>().FlyModus);
            GODMODE = (GameObject.Find("Debugger(Clone)").GetComponent<DebugScript>().GodModus);
        }


        //RocketState\\
        if (RocketState == 1)
        {
            //CHANGE SPRITE
        }
        if (RocketState == 2)
        {
            //CHANGE SPRITE
        }
        if (RocketState == 3)
        {
            //CHANGE SPRITE
        }
        if (RocketState == 4)
        {
            //CHANGE SPRITE
        }
        if (RocketState >= 5)
        {
            //CHANGE SPRITE
        }
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        //Hey Shailesh kun jij even instellen dat de sprites veranderen, heb hier zelf geen zin in lol.

        if (fly)
        {
            if (Input.GetKey("up"))
            {
                transform.Translate(new Vector2(0, +1.75f) * Speed);
            }
        }

        if (Input.GetKeyDown("right") || Input.GetKeyDown("left"))
        {
            if (SelectedSkin == 0)
            {
                m_Animator.SetInteger("WalkJumpIdle", 1);
            }
            if (SelectedSkin == 1)
            {
                m_Animator.SetInteger("WalkJumpIdleBlauw", 1);
            }
            if (SelectedSkin == 2)
            {
                m_Animator.SetInteger("WalkJumpIdleRood", 1);
            }
            if (SelectedSkin == 3)
            {
                m_Animator.SetInteger("WalkJumpIdleGrijs", 1);
            }

        }

        if(Input.GetKey("right"))
        {
            MovingR = true;

            //m_Animator.SetInteger("WalkJumpIdle", 1);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(new Vector2(0.8f, 0) * WalkSpeed);//Beweegt karakter heen en weer.
        }
        if (Input.GetKey("left"))
        {
            MovingL = true;
            //m_Animator.SetInteger("WalkJumpIdle", 1);
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            transform.Translate(new Vector2(0.8f, 0) * WalkSpeed);//Beweegt karakter heen en weer.
        }
        //float x = Input.GetAxis("Horizontal");//Haalt speler's links rechts beweging op.
        //transform.Translate(new Vector2(x, 0) * WalkSpeed);//Beweegt karakter heen en weer.
        //Debug.Log(x);

        if (Input.GetKeyUp("left"))
        {
            MovingL = false;
        }
        if (Input.GetKeyUp("right"))
        {
            MovingR = false;
        }

        if (!MovingR && !MovingL)
        {
            if (SelectedSkin == 0)
            {
                m_Animator.SetInteger("WalkJumpIdle", 0);
            }
            if (SelectedSkin == 1)
            {
                m_Animator.SetInteger("WalkJumpIdleBlauw", 0);
            }
            if (SelectedSkin == 2)
            {
                m_Animator.SetInteger("WalkJumpIdleRood", 0);
            }
            if (SelectedSkin == 3)
            {
                m_Animator.SetInteger("WalkJumpIdleGrijs", 0);
            }

        }

        Timer--;//Telt de timer af
        if (Timer == 0)//kijkt of de timer op 0 staat
        {
            cooldown.fillAmount -= 0.005f * MinTime;//<--Shailesh??
            Timer = 60;//<--Shailesh??
        }

        if(cooldown.fillAmount == 0 && !GODMODE)//Kijkt of de tijd op is
        {
            Death();//Voert de dood uit
        }
        if (cooldown.fillAmount <= 0.2)//Kijkt of de tijd op is
        {
            Warning.SetActive(true);
        }

        if (this.gameObject.transform.position.y <= -4.031514f)//Als speler onder de grond beland
        {
            transform.position = new Vector2(this.gameObject.transform.position.x, -4.031514f);//Speler word terug gezet.
        }
        
        if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0"))///Controllers testen niet op letten\\\
        {
            if (!MoonJumper)
            {
                if (PlayerPrefs.GetInt("Achievements", 1) == 1)
                {
                    PlayerPrefs.SetInt("MoonJumper", PlayerPrefs.GetInt("MoonJumper", 0) + 1);
                }
                if (SelectedSkin == 0)
                {
                    m_Animator.SetTrigger("Jump");
                }
                if (SelectedSkin == 1)
                {
                    m_Animator.SetTrigger("JumpBlauw");
                }
                if (SelectedSkin == 2)
                {
                    m_Animator.SetTrigger("JumpRood");
                }
                if (SelectedSkin == 3)
                {
                    m_Animator.SetTrigger("JumpGrijs");
                }
                landing = false;
                jump.Play();
                Counter = 0;//Zet jump counter op 0?
                IntJumper = 3;//????????????????????
            }
            MoonJumper = true;//Zet gesprongen op waar
        }


        if (MoonJumper)
        {
            Counter++;//COUNTER BIJTELLEN??
            if (Counter <= 100)//???
            {
                IntJumper = IntJumper - 0.1f;//Jump effect denk ik?
                transform.Translate(new Vector2(0, IntJumper) * Speed);//Sprong
                ///Mijn god hoe werkt dit hoe heb ik dit gebouwt
            }
        }
    }

    void Death()//Als dood word aangeroepen
    {
        if (!GameOver)
        {
            GameOver = true;//Gameover word op waar gezet, anders blijft het spawnen
        }
        if (PlayerPrefs.GetInt("Achievements", 1) == 1)
        {
            PlayerPrefs.SetInt("Strangeritual", PlayerPrefs.GetInt("Strangeritual", 0) + 1);
            PlayerPrefs.SetInt("EZGAME", 0);
        }
        
        if(SelectedSkin == 0)
        {
            Instantiate(dead, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);//Spawnt dood karakter
            Debug.Log(SelectedSkin);
        }
        if(SelectedSkin == 1)
        {
            Instantiate(deadBlauw, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);//Spawnt dood karakter
            Debug.Log(SelectedSkin);
        }
        if (SelectedSkin == 2)
        {
            Instantiate(deadRood, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);//Spawnt dood karakter
            Debug.Log(SelectedSkin);
        }
        if (SelectedSkin == 3)
        {
            Instantiate(deadGrijs, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);//Spawnt dood karakter
            Debug.Log(SelectedSkin);
        }
        Destroy(this.gameObject);//Verwijderd speler.
    }

    private void Win()//Als gewonnnen word aangeroepen
    {
        if (PlayerPrefs.GetInt("Achievements", 1) == 1)
        {
            if (PlayerPrefs.GetInt("GottaGoFAST", 0) == 0 && Teller <= 30)
            {
                PlayerPrefs.SetInt("GottaGoFAST", 1);
            }
        }
        Instantiate(raketGemaakt, new Vector2(-6, -2f), Quaternion.identity);//Spawnt gerepareerde raket
        if (SelectedSkin == 0)
        {
            Instantiate(win, new Vector2(-5.93f, 1f), Quaternion.identity);//Spawnt win karakter.
        }
        if (SelectedSkin == 1)
        {
            Instantiate(winBlauw, new Vector2(-5.93f, 1f), Quaternion.identity);//Spawnt win karakter.
        }
        if (SelectedSkin == 2)
        {
            Instantiate(winRood, new Vector2(-5.93f, 1f), Quaternion.identity);//Spawnt win karakter.
        }
        if (SelectedSkin == 3)
        {
            Instantiate(winGrijs, new Vector2(-5.93f, 1f), Quaternion.identity);//Spawnt win karakter.
        }

        Destroy(raketKapot);//Gooit kappotte raket weg.
        if (StageID > Completed)//Kijkt of er een hoger level is behaald dan deze (Voor savegame progress)
        {//Zo niet
            PlayerPrefs.SetInt("Completed", Completed + 1);//Levels behaald word opgeteld
            //Completed = PlayerPrefs.GetInt("Completed", 0);//Haalt op zodat de debug.log het kan aangeven
            //Debug.Log("COMPLETE! ("+Completed+")");//Laat zien hoeveel er behaald zijn
        }
        else//Zo wel
        {
            ///Debug.Log("Already Completed");//Laat zien dat het level al behaald is.
        }
        Destroy(this.gameObject);//Verwijderd speler.
    }
}
