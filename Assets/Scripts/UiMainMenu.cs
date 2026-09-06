using System;
using TMPro;
// si hay algo gris no lo necesito
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UiMainMenu : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button btnPlay;
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

    [Header("Color Players Buttons")]
    [SerializeField] private Button btnNullColorPlayer1;
    [SerializeField] private Button btnRedColorPlayer1;
    [SerializeField] private Button btnBlueColorPlayer1;

    [SerializeField] private Button btnNullColorPlayer2;
    [SerializeField] private Button btnRedColorPlayer2;
    [SerializeField] private Button btnBlueColorPlayer2;

    [Header("Panels")]
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("Slider")]
    [SerializeField] private Slider sliderPlayer1Speed;
    [SerializeField] private Slider sliderPlayer2Speed;

    [Header("SpeedPlayersTMP")]
    [SerializeField] private TMP_Text textSpeedPlayer1;
    [SerializeField] private TMP_Text textSpeedPlayer2;

    [Header("SpritesSize")]
    [SerializeField] private Sprite player1Small;
    [SerializeField] private Sprite player1Medium;
    [SerializeField] private Sprite player1Large;

    [SerializeField] private Sprite player2Small;
    [SerializeField] private Sprite player2Medium;
    [SerializeField] private Sprite player2Large;

    //[Header("Color Player Selector")]


    private void Awake()
    {
        btnPlay.onClick.AddListener(OnPlayClicked); // "When click in btnPlay ejecuta OnContinueClicked
        btnSettings.onClick.AddListener(OnSettingsClicked);
        btnCredits.onClick.AddListener(OnCreditsClicked);
        btnExit.onClick.AddListener(OnExitClicked);
        
        //Buttons Size player 1
        btnSmallPlayer1.onClick.AddListener(OnSmallPlayer1Clicked);
        btnMediumPlayer1.onClick.AddListener(OnMediumPlayer1Clicked);
        btnLargePlayer1.onClick.AddListener(OnLargePlayer1Clicked);

        //Buttons Size player 2
        btnSmallPlayer2.onClick.AddListener(OnSmallPlayer2Clicked);
        btnMediumPlayer2.onClick.AddListener(OnMediumPlayer2Clicked);
        btnLargePlayer2.onClick.AddListener(OnLargePlayer2Clicked);

        //Color Changer player 1
        btnNullColorPlayer1.onClick.AddListener(OnNullColorClikedPlayer1);
        btnRedColorPlayer1.onClick.AddListener(OnRedColorClikedPlayer1);
        btnBlueColorPlayer1.onClick.AddListener(OnBlueColorClikedPlayer1);

        //Color Changer player 2
        btnNullColorPlayer2.onClick.AddListener(OnNullColorClickedPlayer2);
        btnRedColorPlayer2.onClick.AddListener(OnRedColorClickedPlayer2);
        btnBlueColorPlayer2.onClick.AddListener(OnBlueColorClickedPlayer2);


        sliderPlayer1Speed.onValueChanged.AddListener(OnPlayer1SpeedChanged); //cuando el valor del slider cambie ejecuta OnPlayer1SpeedChanged
        sliderPlayer2Speed.onValueChanged.AddListener(OnPlayer2SpeedChanged);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    private void OnDestroy() // for each add Listener we need to put one remove listener es como decir cuando este objeto vaya a destruirse, ya no ejecutes las cosas que estaban conectadas conmigo
    {
        btnPlay.onClick.RemoveListener(OnPlayClicked);
        btnSettings.onClick.RemoveListener(OnSettingsClicked);
        btnCredits.onClick.RemoveListener(OnCreditsClicked);
        btnExit.onClick.RemoveListener(OnExitClicked);
        
        btnSmallPlayer1.onClick.RemoveAllListeners();
        btnMediumPlayer1.onClick.RemoveAllListeners();
        btnLargePlayer1.onClick.RemoveAllListeners();

        btnSmallPlayer2.onClick.RemoveAllListeners();
        btnMediumPlayer2.onClick.RemoveAllListeners();
        btnLargePlayer2.onClick.RemoveAllListeners();

        btnNullColorPlayer1.onClick.RemoveAllListeners();
        btnRedColorPlayer1.onClick.RemoveAllListeners();
        btnBlueColorPlayer1.onClick.RemoveAllListeners();

        btnNullColorPlayer2.onClick.RemoveAllListeners();
        btnRedColorPlayer2.onClick.RemoveAllListeners();
        btnBlueColorPlayer2.onClick.RemoveAllListeners();

        sliderPlayer1Speed.onValueChanged.RemoveListener(OnPlayer1SpeedChanged);
        sliderPlayer2Speed.onValueChanged.RemoveListener(OnPlayer2SpeedChanged);
    }

    private void OnPlayClicked() // this is the function called OnContinueClicked which is going to run when the btnPlay click
    {
        mainMenuCanvas.SetActive(false); //  When Play is clicked, this GameObject becomes inactive.
        SceneManager.LoadScene("Gameplay03");
    }

    private void OnSettingsClicked()
    {
        mainMenuCanvas.SetActive(false);
        settingsPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    private void OnCreditsClicked()
    {
        creditsPanel.SetActive(true);
        mainMenuCanvas.SetActive(false);
        settingsPanel.SetActive(false);
    }

    // Speed Changed Player 1 Slider
    private void OnPlayer1SpeedChanged(float value) // esta funcion va a recibir un numero decimal cuando sea llamada
    {
        switch (value)
        {
            case 1:
                GameManager.Instance.player1Speed = 500; //Guardar el valor 500 como player1Speed
                break;
            case 2:
                GameManager.Instance.player1Speed = 1000;  //Guardar el valor 500 como player1Speed
                break;
            case 3:
                GameManager.Instance.player1Speed = 2000; //Guardar el valor 500 como player1Speed
                break;
        }
        textSpeedPlayer1.text = GameManager.Instance.player1Speed.ToString();
    }

    // Speed Changed Player 2 Slider
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
        textSpeedPlayer2.text = GameManager.Instance.player2Speed.ToString();
    }

    // Size change Player 1
    private void OnLargePlayer1Clicked()
    {
        GameManager.Instance.player1Sprite = player1Large;
    }

    private void OnMediumPlayer1Clicked()
    {
        GameManager.Instance.player1Sprite = player1Medium;
    }

    private void OnSmallPlayer1Clicked()
    {
        GameManager.Instance.player1Sprite = player1Small;
    }
    // Size Change Player 2
    private void OnSmallPlayer2Clicked()
    {
        GameManager.Instance.player2Sprite = player2Small;
    }
    private void OnMediumPlayer2Clicked()
    {
        GameManager.Instance.player2Sprite = player2Medium;
    }
    private void OnLargePlayer2Clicked()
    {
        GameManager.Instance.player2Sprite = player2Large;
    }
    // Color change Player 1
    private void OnNullColorClikedPlayer1 ()
    {
        GameManager.Instance.player1Color = Color.white;
    }
    private void OnRedColorClikedPlayer1 ()
    {
        GameManager.Instance.player1Color = Color.red;
    }
    private void OnBlueColorClikedPlayer1 ()
    {
        GameManager.Instance.player1Color= Color.blue;
    }
    // Color change Player 2
    private void OnNullColorClickedPlayer2()
    {
        GameManager.Instance.player2Color = Color.white;
    }
    private void OnRedColorClickedPlayer2()
    {
        GameManager.Instance.player2Color = Color.red;
    }
    private void OnBlueColorClickedPlayer2()
    {
        GameManager.Instance.player2Color = Color.blue;
    }
   
    private void OnExitClicked()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}