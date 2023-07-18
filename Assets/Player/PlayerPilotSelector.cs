using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class PlayerPilotSelector : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private List<PilotTemplate> pilotCharacters;
    private int currentTemplateIndex;
    private PilotTemplate currentSelectedTemplate;
    private Color[] colors;
    private int currentColorIndex;
    private float selectCoolDown;
    [SerializeField] private bool isReady;

    public void Initialize(Player _player)
    {
        player = _player;

        pilotCharacters = GameMaster.Instance._PlayerManager._PilotTemplates;
        currentTemplateIndex = 0;
        currentSelectedTemplate = Instantiate(pilotCharacters[currentTemplateIndex], transform);
        currentSelectedTemplate.name = "Player-" + (player.playerIndex + 1).ToString() + "-Template";
        transform.position = CharacterSelect.Instance.templatePlacementPoints[player.playerIndex].position;

        colors = new Color[6];
        colors[0] = Color.white;
        colors[1] = Color.red;
        colors[2] = Color.blue;
        colors[3] = Color.green;
        colors[4] = Color.yellow;
        colors[5] = Color.black;

        currentSelectedTemplate.GetComponent<PilotTemplate>().ChangeColor(colors[currentColorIndex]);
        selectCoolDown = 1.5f;
        // checkmark ui object can go away

        isReady = false;
    }

    private void Update()
    {
        if (selectCoolDown > 0) selectCoolDown -= Time.deltaTime;
        else selectCoolDown = 0;

        if(!isReady)
        {
            if (selectCoolDown == 0)
            {
                if (player._Controls._MoveInput.y > 0)
                {
                    selectCoolDown = 1.25f;
                    MoveColorIndexForward();
                }
                else if (player._Controls._MoveInput.y < 0)
                {
                    selectCoolDown = 1.25f;
                    MoveColorIndexBackward();
                }
                else if (player._Controls._JumpInput || player._Controls._MenuInput)
                {
                    if (player._Controls._JumpInput) player._Controls.UseJump();
                    else if (player._Controls._MenuInput) player._Controls.UseMenu();

                    PlayerReadyUp();
                }
            }
        }
    }

    private void PlayerReadyUp()
    {
        player.SetPlayerColor(colors[currentColorIndex]);
        CharacterSelect.Instance.AnotherPlayerIsReady();
        // show the check mark ui element
        // change color of checkmark
        isReady = true;
    }

    public void MoveColorIndexForward()
    {
        currentColorIndex++;
        if (currentColorIndex > colors.Length - 1) currentColorIndex = 0;
        ChangePilotTemplateColor();
    }
    public void MoveColorIndexBackward()
    {
        currentColorIndex--;
        if (currentColorIndex < 0) currentColorIndex = colors.Length - 1;
        ChangePilotTemplateColor();
    }

    private void ChangePilotTemplateColor() => currentSelectedTemplate.GetComponent<PilotTemplate>().ChangeColor(colors[currentColorIndex]);

    // end
}
