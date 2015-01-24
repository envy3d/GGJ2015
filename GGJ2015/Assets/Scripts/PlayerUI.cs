using UnityEngine;
using System.Collections;
using System.Linq;

public class PlayerUI : MonoBehaviour
{

    public GameObject playerUiPrefab;
    public UnityEngine.UI.Slider countdownSlider;
    public UnityEngine.UI.Text instructionText;
    public int countdownMaxSlices;
    public float countdownMaxTime;

    private GameManager gm;
    private int playerNumber;
    private GameObject playerUI;
    private bool active = false;
    private int countdown;
    private float countdownTime;

    void Update()
    {
        if (active)
        {
            
            
            // Countdown
            UpdateCountdown();
        }
    }

    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void Init()
    {
        active = true;
        ResetCountdown();
    }

    public void ReceivePlayerNumber(int playerNumber)
    {
        this.playerNumber = playerNumber;
        GameObject board = GameObject.FindGameObjectWithTag("GameBoard");
        float boardWidth = 1024;  //hack hack hack

        playerUI = GameObject.Instantiate(playerUiPrefab) as GameObject;
        var playerUiRectTransform = playerUI.GetComponent<RectTransform>();
        playerUI.transform.SetParent(board.transform);
        playerUiRectTransform.localScale = new Vector3(1, 1, 1);
        playerUiRectTransform.offsetMin = new Vector2((playerNumber) * (boardWidth / 4), 0);
        playerUiRectTransform.offsetMax = new Vector2( -(3 - playerNumber) * (boardWidth / 4), 0);

        countdownSlider = playerUI.GetComponentInChildren<UnityEngine.UI.Slider>();
        instructionText = (from text in playerUI.GetComponentsInChildren<UnityEngine.UI.Text>()
                           where text.name == "Instruction Text"
                           select text).Single<UnityEngine.UI.Text>();
    }

    public void UpdateCountdown()
    {
        countdown = (int)((countdownMaxSlices / countdownMaxTime) * countdownTime);
        countdownSlider.value = countdown;
        if (countdownTime <= 0 && countdownTime > -10)
        {
            gm.FailInstruction(playerNumber);
            ResetCountdown();
            
        }
        countdownTime -= Time.deltaTime;
    }

    public void ResetCountdown()
    {
        countdownSlider.maxValue = countdownMaxSlices;
        countdown = countdownMaxSlices;
        countdownTime = countdownMaxTime;
    }

    public void FailInstruction()
    {
        instructionText.text = "";
    }

    public void WinInstruction()
    {
        instructionText.text = "";
    }

    public void SetInstruction(Skill instruction)
    {
        instructionText.text = instruction.instruction;
    }
}
