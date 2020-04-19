using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class DDLSearch : MonoBehaviour
{
    enum ListType
    {
        Monsters,
        Moves,
        Traits
    }

    [SerializeField] ListType listType = ListType.Monsters;
    [DisplayWithoutEdit()]
    public bool listLoaded = false;
    [Header("Filtering Using Monster:")]
    [SerializeField] bool filterUsingMonster;
    [SerializeField] MonsterName monsterReference;
    List<string> DDL_Options;

    TMP_InputField inputField;
    bool fieldSelected = false;
    TMP_Dropdown DDL;

    [Header("List Info")]
    [DisplayWithoutEdit()]
    bool DisplayListOpen = false;
    [SerializeField] GameObject DisplayList; //using this to override the DDL because it sucks :D
    [SerializeField] Transform Content;
    public List<string> DisplayListOptions; //use this for debugging
    [SerializeField] Button SelectButton;
    [SerializeField] GameObject Template; //uses template for options to select in list
    List<GameObject> Options;
    string lastPushed;

    void Awake()
    {
        //search children for input field and drop down
        inputField = this.gameObject.GetComponentInChildren<TMP_InputField>();
        DDL = this.gameObject.GetComponentInChildren<TMP_Dropdown>();

        //Make a list in memory as dropdown options to be populated and referenced later as a master list
        DDL_Options = new List<string>();

        Options = new List<GameObject>();

        DisplayListOptions = new List<string>();
    }

    private void FixedUpdate()
    {
        //run only if we have input field and DDL components
        //...and the lists are populated
        if (!listLoaded && inputField != null && DDL != null && MonsterDictionary.instance.listLoaded && MoveDictionary.instance.listLoaded)
        {
            InitializeDropdownList();
        }

        if (fieldSelected)
        {
            FilterSearch(inputField.text);
        }

        if (DisplayListOpen)
        {
            DisplayList.SetActive(true);
        }
        else
        {
            DisplayList.SetActive(false);
        }
    }

    #region Search Filter
    public void FilterSearch(string typedText)
    {

        List<string> newOptions = new List<string>();

        //sort new temp options strings based on typed text
        foreach (string s in DDL_Options)
        {
            bool match = false;
            int matchingChars = 0;
            //edge case, was breaking when typed text was too long
            if(typedText.Length <= s.Length)
            {
                //check each character of typed text for match, each one that doesn't match, remove
                for (int i = 0; i < typedText.Length; i++)
                {
                    match = typedText[i].ToString().Equals(s[i].ToString(), StringComparison.InvariantCultureIgnoreCase);

                    if (match)
                    {
                        //log how many characters are matching
                        matchingChars++;
                    }
                }
                //evaluate match status after all chars in typedText have been evaluated
                if (matchingChars == typedText.Length)
                {
                    newOptions.Add(s);
                }
            }

        }

        if(newOptions.Count == 0)
        {
            string s = "None";
            newOptions.Add(s);
        }
        //update the list
        UpdateListOptions(newOptions);

        //DDL.Show();
        //DisplayListOpen = true;

        fieldSelected = false;

    }
    #endregion

    #region Input Field Functions
    //called OnValueChanged from input field
    public void UpdateFilter()
    {
        if(DDL.options.Count != 0)
        {
            if (inputField.text != "" && inputField.text != DDL_Options[0] && inputField.text != DDL.options[DDL.value].text)
            {
                fieldSelected = true;
            }
        }

        if (inputField.text == "")
        {
            RestoreDefaultListValues();
        }
    }

    //called once the user presses enter
    public void Submit()
    {
        //Select most related item in the list
        DDL.SetValueWithoutNotify(0); //select topmost item in current list
        DDL.RefreshShownValue();

        lastPushed = "";
        Invoke("DelayedClosingCheck", 0.1f);

        //DisplayListOpen = false;
    }

    //called when selected
    public void FieldSelected()
    {

        //clear field text automatically
        inputField.text = "";

        //open the list
        //DDL.Show();
        DisplayListOpen = true;
    }

    //called when deselected
    public void FieldDeselected()
    {

        /*
        //update input field to reflect current dropdown value
        if (DDL.options.Count != 0)
        {
            inputField.text = DDL.options[DDL.value].text;
        }
        else
        {
            inputField.text = DDL_Options[0]; //default zero value for this list
        }
        
        DisplayListOpen = false;
        */

        Invoke("DelayedClosingCheck", 0.1f);


    }

    public void DelayedClosingCheck()
    {
        if (lastPushed == "")
        {
            if (DDL.options.Count != 0)
            {
                inputField.text = DDL.options[DDL.value].text;
            }
            DisplayListOpen = false;
        }
        else
        {
            inputField.text = lastPushed;
            DisplayListOpen = false;
        }
    }
    #endregion

    #region Dropdown List Functions
    void InitializeDropdownList()
    {
        //Clear the existing options in the list
        DDL.ClearOptions();

        //Populate list with appropriate data
        switch (listType)
        {
            case ListType.Monsters:
                //show defined list of all monsters
                foreach (MonsterName n in Enum.GetValues(typeof(MonsterName)))
                {
                    DDL_Options.Add(n.ToString());
                }

                break;
            case ListType.Moves:

                if (filterUsingMonster)
                {
                    Monster monster = MonsterDictionary.instance.GetMonsterByName(monsterReference);
                    foreach (MoveName n in monster.canLearn)
                    {
                        DDL_Options.Add(n.ToString());
                    }
                }
                else
                {
                    //show defined list of all moves
                    foreach (MoveName n in Enum.GetValues(typeof(MoveName)))
                    {
                        DDL_Options.Add(n.ToString());
                    }
                }

                break;
            case ListType.Traits:

                if (filterUsingMonster)
                {
                    Monster monster = MonsterDictionary.instance.GetMonsterByName(monsterReference);
                    DDL_Options.Add(monster.trait1.ToString());
                    DDL_Options.Add(monster.trait2.ToString());
                }
                else
                {
                    //show defined list of all traits
                    foreach(MonsterTrait mt in Enum.GetValues(typeof(MonsterTrait)))
                    {
                        DDL_Options.Add(mt.ToString());
                    }
                }

                break;
            default:
                break;
        }

        //add these options to the list
        DDL.AddOptions(DDL_Options);

        //populate the real display list
        PopulateDisplayList(DDL.options);

        //update input field to reflect current dropdown
        if (inputField.text != DDL.options[DDL.value].text)
        {
            inputField.text = DDL.options[DDL.value].text;
        }

        //finished loading our list
        listLoaded = true;
    }
    void RestoreDefaultListValues()
    {
        int prevVal = DDL.value;
        DDL.ClearOptions();
        DDL.AddOptions(DDL_Options);
        DDL.value = prevVal;

        PopulateDisplayList(DDL.options);

    }
    void UpdateListOptions(List<string> NewOptions)
    {
        DDL.ClearOptions();
        DDL.AddOptions(NewOptions);
        DDL.value = 0;
        DDL.RefreshShownValue();

        PopulateDisplayList(DDL.options);
    }
    //called when dropdown value changes
    public void UpdateText()
    {


    }
    #endregion
    
    #region DisplayList
    public void PopulateDisplayList(List<TMP_Dropdown.OptionData> list)
    {
        //clear the reference list
        DisplayListOptions.Clear();
        //destroy all of the options created previously
        if(Options.Count != 0)
        {
            foreach(GameObject go in Options)
            {
                Destroy(go.gameObject);
            }
        }

        //populate the reference list
        foreach (TMP_Dropdown.OptionData optionData in list)
        {
            DisplayListOptions.Add(optionData.text);
        }

        //instantiate the options
        foreach(string s in DisplayListOptions)
        {
            GameObject option = Instantiate(Template);
            option.GetComponentInChildren<TMP_Text>().SetText(s);
            option.transform.SetParent(Content);
            option.SetActive(true);
            option.GetComponent<OptionTag>().s = s;
            Options.Add(option);
        }
    }

    public void OptionSelected(string s)
    {
        //grab the option selected and use it!
        inputField.text = s;

        //find the value on the list
        int i = 0;
        int value = 0;
        foreach(TMP_Dropdown.OptionData optionData in DDL.options)
        {
            if(optionData.text == s)
            {
                //match!
                //grab this value
                value = i;
            }
            i++;
        }


        //restore the list
        RestoreDefaultListValues();

        //sets the value to the one selected on the backend
        DDL.SetValueWithoutNotify(value);
        DDL.RefreshShownValue();
        lastPushed = s;
        DisplayListOpen = false;
    }

    public void SelectPressed()
    {
        DisplayListOpen = !DisplayListOpen;
        if (DisplayListOpen)
        {
            RestoreDefaultListValues();
        }

        lastPushed = "";
    }
    #endregion
}
