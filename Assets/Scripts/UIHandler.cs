using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;
public class UIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject player;

    private Button button;
    private Label text;
    private PlayerHandler playerHandler;

    private void Start()
    {
    }
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        playerHandler = player.GetComponent<PlayerHandler>();
        button = root.Q<Button>("MyButton");
        text = root.Q<Label>("CollisionText");


        button.clicked += () =>
        {

            if (cube.activeSelf)
            {
                cube.SetActive(false);
            }
            else cube.SetActive(true);
        };
    }

    public void showCollisionScore()
    {
        text.text = "Score: " + playerHandler.countCollision;
    }
}
