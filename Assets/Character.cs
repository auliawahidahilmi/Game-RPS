using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    // dikasih new agar ngehide name di monobehaviour (parent) jadi yang dipanggil name di player aja
    [SerializeField] new string name;
    [SerializeField] CharacterType type;
    [SerializeField] int currentHp;
    [SerializeField] int maxHp;
    [SerializeField] int attackPower;
    [SerializeField] TMP_Text overHeadText;
    [SerializeField] Image avatar;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text typeText;
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text hpText;
    [SerializeField] Button button;
    private Vector3 initialPosition;
    
    public Button Button { get => button;}
    public CharacterType Type { get => type;}
    public int AttackPower { get => attackPower;}
    public int CurrentHp { get => currentHp;}
    public Vector3 InitialPosition { get => initialPosition;}
    public int MaxHp { get => maxHp;}

    private void Start()
    {
        initialPosition = this.transform.position;
        overHeadText.text = name;
        nameText.text = name;
        typeText.text = type.ToString();
        button.interactable = false;
        UpdateHpUI();
    }

    public void ChangeHP(int amount)
    {
        currentHp += amount;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        UpdateHpUI();
    }

    private void UpdateHpUI()
    {
        healthBar.fillAmount = (float)currentHp / (float)maxHp;
        hpText.text = currentHp + "/" + maxHp;
    }
}
