using UnityEngine;
using System.Collections;

public class PlayerUI : MonoBehaviour {

    public GameObject playerUiPrefab;

    private GameObject playerUI;

    public void ReceivePlayerNumber(int playerNumber)
    {
        GameObject board = GameObject.FindGameObjectWithTag("GameBoard");
        float boardWidth = board.GetComponent<RectTransform>().rect.width;

        playerUI = GameObject.Instantiate(playerUiPrefab) as GameObject;
        var playerUiRectTransform = playerUI.GetComponent<RectTransform>();
        playerUI.transform.SetParent(board.transform);
        playerUiRectTransform.localScale = new Vector3(1, 1, 1);
        playerUiRectTransform.offsetMin = new Vector2((playerNumber) * (boardWidth / 4), 0);
        playerUiRectTransform.offsetMax = new Vector2(-(3 - playerNumber) * (boardWidth / 4), 0);
        //playerUiRectTransform.rect.Set(0, 0, 256, playerUiRectTransform.rect.height);
        playerUI.transform.SetParent(board.transform);

        //var playerUiRectTransform = playerUI.GetComponent<RectTransform>();


       // playerUiRectTransform.rect.Set(0, 0, 256, playerUiRectTransform.rect.height);
        /*playerUiRectTransform.rect.Set((-boardWidth/2) + ((playerNumber - 1) * (boardWidth / 4)),
                                        playerUiRectTransform.rect.yMin,
                                        boardWidth / 4,
                                        playerUiRectTransform.rect.height);*/
    }
}
