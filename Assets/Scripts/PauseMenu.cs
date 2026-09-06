using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    [Header("GeneralButtons")]
    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnCredits;
    [SerializeField] private Button btnExit;


    [Header("Size Players Buttons")]
    [SerializeField] private Button btnSmallPlayer1;
    [SerializeField] private Button btnMediumPlayer1;
    [SerializeField] private Button btnLargePlayer1;

    [SerializeField] private Button btnSmallPlayer2;
    [SerializeField] private Button btnMediumPlayer2;
    [SerializeField] private Button btnLargePlayer2;

    [Header("Color Changer Players Buttons")]
    [SerializeField] private Button btnNullPlayer1;
    [SerializeField] private Button btnRedPlayer1;
    [SerializeField] private Button btnBluePlayer1;

    [SerializeField] private Button btnNullPlayer2;
    [SerializeField] private Button btnRedPlayer2;
    [SerializeField] private Button btnBluePlayer2;


    [Header("Panels")]
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject pausePanel;

    [Header("Slider")]
    [SerializeField] private Slider sliderPlayer1Speed;
    [SerializeField] private Slider sliderPlayer2Speed;

    [Header("Players")]
    [SerializeField] private MovementPlayer player1;
    [SerializeField] private MovementPlayer player2;

    [Header("Player Visuals")]
    [SerializeField] private Player player1Visual;
    [SerializeField] private Player player2Visual;

    [Header("SpeedPlayersTMP")]
    [SerializeField] private TMP_Text textSpeedPlayer1;
    [SerializeField] private TMP_Text textSpeedPlayer2;

    [Header("Sprites")]
    [SerializeField] private Sprite player1Small;
    [SerializeField] private Sprite player1Medium;
    [SerializeField] private Sprite player1Large;

    [SerializeField] private Sprite player2Small;
    [SerializeField] private Sprite player2Medium;
    [SerializeField] private Sprite player2Large;


    private bool isPause = false;

    private void Awake() // solo para add listener y get components porque esta es la inicializacion (todas las referencias)
    {
        //General Pause Buttons
        btnContinue.onClick.AddListener(OnContinueClicked); // "When click in btnPlay ejecuta OnContinueClicked
        btnSettings.onClick.AddListener(OnSettingsClicked);
        btnCredits.onClick.AddListener(OnCreditsClicked);
        btnExit.onClick.AddListener(OnExitClicked);

        //Size Buttons Player
        btnSmallPlayer1.onClick.AddListener(OnButtonSmallPlayer1Clicked);
        btnMediumPlayer1.onClick.AddListener(OnButtonMediumPlayer1Clicked);
        btnLargePlayer1.onClick.AddListener(OnButtonLargePlayer1Clicked);

        //Size Buttons Player2
        btnSmallPlayer2.onClick.AddListener(OnButtonSmallPlayer2Clicked);
        btnMediumPlayer2.onClick.AddListener(OnButtonMediumPlayer2Clicked);
        btnLargePlayer2.onClick.AddListener(OnButtonLargePlayer2Clicked);

        //Color Changer Buttons Player 1
        btnNullPlayer1.onClick.AddListener(OnNullColorClickedPlayer1);
        btnRedPlayer1.onClick.AddListener(OnRedColorClickedPlayer1);
        btnBluePlayer1.onClick.AddListener(OnBlueColorClickedPlayer1);

        //Color Changer Buttons Player 2
        btnNullPlayer2.onClick.AddListener(OnNullColorClickedPlayer2);
        btnRedPlayer2.onClick.AddListener(OnRedColorClickedPlayer2);
        btnBluePlayer2.onClick.AddListener(OnBlueColorClickedPlayer2);

        sliderPlayer1Speed.onValueChanged.AddListener(OnPlayer1SpeedChanged); //cuando el valor del slider cambie ejecuta OnPlayer1SpeedChanged
        sliderPlayer2Speed.onValueChanged.AddListener(OnPlayer2SpeedChanged);
    }

    private void Start()
    {
        creditsPanel.SetActive(false); // alt + flecha hacia abajo y arriba para mover lineas 
        settingsPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnContinueClicked();
        }
    }

    private void OnDestroy() // for each add Listener we need to put one remove listener es como decir cuando este objeto vaya a destruirse, ya no ejecutes las cosas que estaban conectadas conmigo
    {
        btnContinue.onClick.RemoveAllListeners();
        btnSettings.onClick.RemoveAllListeners();
        btnCredits.onClick.RemoveAllListeners();
        btnExit.onClick.RemoveAllListeners();

        btnSmallPlayer1.onClick.RemoveAllListeners();
        btnMediumPlayer1.onClick.RemoveAllListeners();
        btnLargePlayer1.onClick.RemoveAllListeners();

        btnSmallPlayer2.onClick.RemoveAllListeners();
        btnMediumPlayer2.onClick.RemoveAllListeners();
        btnLargePlayer2.onClick.RemoveAllListeners();

        sliderPlayer1Speed.onValueChanged.RemoveListener(OnPlayer1SpeedChanged);
        sliderPlayer2Speed.onValueChanged.RemoveListener(OnPlayer2SpeedChanged);
    }

    private void OnContinueClicked()
    {
        isPause = !isPause; //!igual a lo opuesto
        pausePanel.SetActive(isPause);
        if (isPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    private float SpeedToSliderValue(float Speed) //Genere esta variable speed to Slider Value porque el ultimo dato que guardo nuestro Game Manager.Instance fueron los valores 500, 1000, 2000
                                                  //que se ponian en la velocidad. Entonces ahora estos valores tenemos que retomarlo y re-convertirlos para que en el Slider se puedan interpretar como 1,2,3
    {
        switch (Speed)
        {
            case 500:
                return 1;
            case 1000:
                return 2;
            case 2000:
                return 3;
            default:
                return 2;
        }
    }
    private void OnSettingsClicked()
    {
        // retoma los ultimos valores del gameManager.instance. y los pone en su valor correpondiente
        sliderPlayer1Speed.value = SpeedToSliderValue(GameManager.Instance.player1Speed);
        sliderPlayer2Speed.value = SpeedToSliderValue(GameManager.Instance.player2Speed);

        settingsPanel.SetActive(true);
    }

    private void OnCreditsClicked()
    {
        creditsPanel.SetActive(true);
    }

    private void OnExitClicked()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void OnPlayer2SpeedChanged(float value)
    {
        switch (value)
        {
            case 1:
                GameManager.Instance.player2Speed = 500;
                break;
            case 2:
                GameManager.Instance.player2Speed = 1000;
                break;
            case 3:
                GameManager.Instance.player2Speed = 2000;
                break;
        }
        player2.moveSpeedPlayer = GameManager.Instance.player2Speed;
        textSpeedPlayer2.text = GameManager.Instance.player2Speed.ToString();
    }

    private void OnPlayer1SpeedChanged(float value)
    {
        switch(value)
        {
            case 1:
                GameManager.Instance.player1Speed = 500;
                break;
            case 2:
                GameManager.Instance.player1Speed = 1000;
                break;
            case 3:
                GameManager.Instance.player1Speed = 2000;
                break;
        }
        player1.moveSpeedPlayer = GameManager.Instance.player1Speed;
        textSpeedPlayer1.text = GameManager.Instance.player1Speed.ToString();
    }
    private void OnButtonSmallPlayer1Clicked()
    {
        GameManager.Instance.player1Sprite = player1Small;
        player1Visual.UpdateSprite();
    }
    private void OnButtonMediumPlayer1Clicked()
    {
        GameManager.Instance.player1Sprite = player1Medium;
        player1Visual.UpdateSprite();
    }
    private void OnButtonLargePlayer1Clicked()
    {
        GameManager.Instance.player1Sprite = player1Large;
        player1Visual.UpdateSprite();
    }
    private void OnButtonSmallPlayer2Clicked()
    {
        GameManager.Instance.player2Sprite = player2Small;
        player2Visual.UpdateSprite();
    }
    private void OnButtonMediumPlayer2Clicked()
    {
        GameManager.Instance.player2Sprite = player2Medium;
        player2Visual.UpdateSprite();
    }
    private void OnButtonLargePlayer2Clicked()
    {
        GameManager.Instance.player2Sprite = player2Large;
        player2Visual.UpdateSprite();
    }

    // INSTRUCCIONES PARA EL COLOR CHANGER PLAYER 1
    private void OnNullColorClickedPlayer1()
    {
        GameManager.Instance.player1Color = Color.white;
        player1Visual.UpdateColor();
    }
    private void OnRedColorClickedPlayer1()
    {
        GameManager.Instance.player1Color = Color.red;
        player1Visual.UpdateColor();
    }
    private void OnBlueColorClickedPlayer1()
    {
        GameManager.Instance.player1Color = Color.blue;
        player1Visual.UpdateColor();
    }
    // INSTRUCCIONES PARA EL COLOR CHANGER PLAYER 2
    private void OnNullColorClickedPlayer2()
    {
        GameManager.Instance.player2Color = Color.white;
        player2Visual.UpdateColor();
    }
    private void OnRedColorClickedPlayer2()
    {
        GameManager.Instance.player2Color = Color.red;
        player2Visual.UpdateColor();
    }
    private void OnBlueColorClickedPlayer2()
    {
        GameManager.Instance.player2Color = Color.blue;
        player2Visual.UpdateColor();
    }

}