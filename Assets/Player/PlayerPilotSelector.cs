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

    public void Initialize(Player _player)
    {
        player = _player;

        pilotCharacters = GameMaster.Instance.PlayerManager._PilotTemplates;
        currentTemplateIndex = 0;
        currentSelectedTemplate = Instantiate(pilotCharacters[currentTemplateIndex]);
        currentSelectedTemplate.transform.position = CharacterSelect.Instance.playerPoints[player.playerIndex].position;

        colors = new Color[6];
        colors[0] = Color.white;
        colors[1] = Color.red;
        colors[2] = Color.blue;
        colors[3] = Color.green;
        colors[4] = Color.yellow;
        colors[5] = Color.black;

        currentSelectedTemplate.GetComponent<PilotTemplate>().ChangeColor(colors[currentColorIndex]);
        selectCoolDown = 1.25f;
    }

    private void Update()
    {
        if (selectCoolDown > 0) selectCoolDown -= Time.deltaTime;
        else selectCoolDown = 0;

        if (selectCoolDown == 0)
        {
            if(player._Controls._MoveInput.y > 0)
            {
                selectCoolDown = 1.25f;
                MoveColorIndexForward();
            }
            else if(player._Controls._MoveInput.y < 0)
            {
                selectCoolDown = 1.25f;
                MoveColorIndexBackward();
            }
        }
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
    // public void OnMove()

    private void ChangePilotTemplateColor() => currentSelectedTemplate.GetComponent<PilotTemplate>().ChangeColor(colors[currentColorIndex]);

    // end
}
