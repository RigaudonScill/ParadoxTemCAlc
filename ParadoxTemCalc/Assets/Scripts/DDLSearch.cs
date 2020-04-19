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
    List<string> DDL_OptionsLibrary;

    TMP_InputField inputField;
    bool fieldSelected = false;

    [Header("List Info"), DisplayWithoutEdit()]
    public int value; //this is the value of the selection within the displayed options
    [DisplayWithoutEdit()]
    public int masterListValue; //use this to reference the master list when evaluating a selection

    [SerializeField] GameObject DisplayList; //using this to override the DDL because it sucks :D
    [SerializeField] Transform Content;
    [SerializeField] Button SelectButton; //button toggle
    public bool DisplayListOpen = false;

    [Header("Option Info")]
    [SerializeField] GameObject Template; //uses template for options to select in list
    public Color defaultColor;
    public Color selectedColor;

    [Header("Debugging")]
    public List<string> DisplayListOptions; //use this for debugging
    public bool clickedOnHandle = false;

    List<GameObject> Options;
    string lastPushed;

    ScrollRect scrollRect;
    float moveDist;
    int evenOddTick = 0;
    int refreshRate = 6;

    void Awake()
    {
        //search children for input field and drop down
        inputField = this.gameObject.GetComponentInChildren<TMP_InputField>();

        //Make a list in memory as dropdown options to be populated and referenced later as a master list
        DDL_OptionsLibrary = new List<string>();

        //this is the shrinkable list of displayed options as strings
        DisplayListOptions = new List<string>();

        //these are the actual options objects in the displayed list
        Options = new List<GameObject>();

        //grab scroll rect for later use
        scrollRect = DisplayList.GetComponent<ScrollRect>();

        //grab height of one element
        moveDist = Template.GetComponent<RectTransform>().sizeDelta.y;

        DisplayList.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.4f);
    }

    private void FixedUpdate()
    {
        //run only if we have input field and DDL components
        //...and the lists are populated
        if (!listLoaded && inputField != null && DisplayList != null && MonsterDictionary.instance.listLoaded && MoveDictionary.instance.listLoaded)
        {
            InitializeDropdownList();
        }

        if (fieldSelected)
        {
            FilterSearch(inputField.text);
        }

        //opening and closing of the list, boolean acts as listener
        if (DisplayListOpen)
        {
            DisplayList.SetActive(true);
        }
        else
        {
            DisplayList.SetActive(false);
        }

        //arrow key interactions
        if (DisplayListOpen && Input.GetKey(KeyCode.DownArrow) && evenOddTick % refreshRate == 0)
        {
            scrollRect.verticalScrollbar.interactable = false;
            if (value == DisplayListOptions.Count)
            {
                //index looped past, so reset
                value = 0;
            }
            else
            {
                //increment the value down the list
                value++;
            }
            //update display
            SetTextFieldToSelected();
            HighlightSelected();

            //set normalized position
            scrollRect.normalizedPosition = new Vector2(0, 1-(value * moveDist) / Content.GetComponent<RectTransform>().sizeDelta.y);

            scrollRect.verticalScrollbar.interactable = true;
        }
        if (DisplayListOpen && Input.GetKey(KeyCode.UpArrow) && evenOddTick%refreshRate == 0)
        {
            scrollRect.verticalScrollbar.interactable = false;
            if (value == 0)
            {
                //index looped past, so reset
                value = DisplayListOptions.Count - 1;
            }
            else
            {
                //increment the value up the list
                value--;
            }
            //update display
            SetTextFieldToSelected();
            HighlightSelected();

            //set normalized position
            scrollRect.normalizedPosition = new Vector2(0, 1-(value * moveDist) / Content.GetComponent<RectTransform>().sizeDelta.y);

            scrollRect.verticalScrollbar.interactable = true;
        }

        //force submit if select button was used to open the list instead
        //and the user pressed enter
        if (DisplayListOpen && Input.GetKeyDown(KeyCode.Return))
        {
            Submit();
        }

        evenOddTick++;
        if(evenOddTick > 120)
        {
            evenOddTick = 0;
        }
    }

    #region Search Filter
    public void FilterSearch(string typedText)
    {

        List<string> newOptions = new List<string>();

        //sort new temp options strings based on typed text
        foreach (string s in DDL_OptionsLibrary)
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

        //highlight the selection
        Invoke("HighlightSelected", 0.1f);

        fieldSelected = false;

    }
    #endregion

    #region Input Field Functions
    //called OnValueChanged from input field
    public void UpdateFilter()
    {
        //open the list if the input field is not displaying the current selection or the topmost selection
        if (!DisplayListOpen && inputField.text != DisplayListOptions[0] && inputField.text != DisplayListOptions[value])
        {
            DisplayListOpen = true;
        }
        //sanity check for resizing list
        if (DisplayListOptions.Count != 0 && value < DisplayListOptions.Count)
        {
            /*only update the search filter if:
                * --The inputField is not empty
                * --The inputField is not already displaying the topmost item
                * --The inputField is not already displaying the selected item
            */
            if (inputField.text != "" && inputField.text != DisplayListOptions[0] && inputField.text != DisplayListOptions[value])
            {
                fieldSelected = true;
            }
        }
        else
        {
            //if the value is greater than the count of display options, default to 0
            value = 0;
        }
        //if we backspace, and the list is empty, restore it to default
        if (inputField.text == "")
        {
            RestoreDefaultListValues();

            //still highlight this in case list opens
            Invoke("HighlightSelected", 0.1f);
        }


    }

    //called once the user presses enter
    public void Submit()
    {
        //Select most related item in the list if that isn't already selected, and the list isn't zero
        if(DisplayListOptions.Count != 0 && value < DisplayListOptions.Count && inputField.text != DisplayListOptions[value])
        {
            value = 0; //select topmost item in current list
        }
        fieldSelected = false;
        Invoke("DelayedClosingCheck", 0.1f);
    }

    //called when selected
    public void FieldSelected()
    {

        //clear field text automatically
        inputField.text = "";

        //restore the default list values
        RestoreDefaultListValues();

        //open the list
        DisplayListOpen = true;

        //highlight the selection
        Invoke("HighlightSelected", 0.1f);

    }

    //called when deselected
    public void FieldDeselected()
    {
         
         fieldSelected = false;
         Invoke("DelayedClosingCheck", 0.1f);

    }

    public void SetTextFieldToSelected()
    {
        if (DisplayListOptions.Count != 0 && value < DisplayListOptions.Count)
        {
            inputField.text = DisplayListOptions[value];
            //Set the selection index by its index in the master library 
            //(so it never points to an option that doesn't exist)
            masterListValue = FindStringIndexInList(DisplayListOptions[value], DDL_OptionsLibrary);
        }
    }

    public void DelayedClosingCheck()
    {

        SetTextFieldToSelected();
        DisplayListOpen = false;

    }
    #endregion

    #region Dropdown List Functions
    void InitializeDropdownList()
    {

        //Populate list with appropriate data
        switch (listType)
        {
            case ListType.Monsters:
                //show defined list of all monsters
                foreach (MonsterName n in Enum.GetValues(typeof(MonsterName)))
                {
                    DDL_OptionsLibrary.Add(n.ToString());
                }

                break;
            case ListType.Moves:

                if (filterUsingMonster)
                {
                    Monster monster = MonsterDictionary.instance.GetMonsterByName(monsterReference);
                    foreach (MoveName n in monster.canLearn)
                    {
                        DDL_OptionsLibrary.Add(n.ToString());
                    }
                }
                else
                {
                    //show defined list of all moves
                    foreach (MoveName n in Enum.GetValues(typeof(MoveName)))
                    {
                        DDL_OptionsLibrary.Add(n.ToString());
                    }
                }

                break;
            case ListType.Traits:

                if (filterUsingMonster)
                {
                    Monster monster = MonsterDictionary.instance.GetMonsterByName(monsterReference);
                    DDL_OptionsLibrary.Add(monster.trait1.ToString());
                    DDL_OptionsLibrary.Add(monster.trait2.ToString());
                }
                else
                {
                    //show defined list of all traits
                    foreach(MonsterTrait mt in Enum.GetValues(typeof(MonsterTrait)))
                    {
                        DDL_OptionsLibrary.Add(mt.ToString());
                    }
                }

                break;
            default:
                break;
        }

        //populate display list
        PopulateDisplayList(DDL_OptionsLibrary);

        //update input field to reflect current dropdown
        SetTextFieldToSelected();

        //finished loading our list
        listLoaded = true;
    }
    void RestoreDefaultListValues()
    {

        PopulateDisplayList(DDL_OptionsLibrary);

    }
    void UpdateListOptions(List<string> NewOptions)
    {

        PopulateDisplayList(NewOptions);

    }
    #endregion
    
    #region DisplayList
    public void PopulateDisplayList(List<string> list)
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
        foreach (string optionName in list)
        {
            DisplayListOptions.Add(optionName);
        }

        //instantiate the options
        foreach(string s in DisplayListOptions)
        {
            GameObject option = Instantiate(Template);
            option.GetComponentInChildren<TMP_Text>().SetText(s);
            option.transform.SetParent(Content);
            option.SetActive(true);
            option.GetComponent<Image>().color = defaultColor;
            option.GetComponent<OptionTag>().s = s;
            Options.Add(option);
        }
    }
    public void OptionSelected(string s)
    {
        //restore the list
        RestoreDefaultListValues();

        //set the list value by its index in the displayed list
        value = FindStringIndexInList(s, DisplayListOptions);

        //set input field to reflect value (this also updates the master list value)
        SetTextFieldToSelected();

        //highlight the selection once the list is refreshed
        Invoke("HighlightSelected", 0.1f);

        DisplayListOpen = false;
    }
    public void SelectPressed()
    {
        DisplayListOpen = !DisplayListOpen;
        //if the list is opening
        if (DisplayListOpen)
        {
            RestoreDefaultListValues();
            //highlight the selection once the list is refreshed
            Invoke("HighlightSelected", 0.1f);
            SetTextFieldToSelected(); //restore previous selection
        }
    }
    public void HighlightSelected()
    {
        //reset all other options colors, set only the one we need
        //(this could have been a broadcast message, but the mechanic was not working)
        OptionTag[] tags = Content.gameObject.GetComponentsInChildren<OptionTag>();
        int ind = 0;
        foreach(OptionTag tag in tags)
        {
            if (ind == value)
            {
                tag.SetColor(selectedColor);
            }
            else
            {
                tag.SetColor(defaultColor);
            }

            ind++;
        }

    }
    public int FindStringIndexInList(string s, List<string> list)
    {
        int i = 0;
        int ind = 0;
        foreach(string name in list)
        {
            if(s == name)
            {
                ind = i;
            }
            i++;
        }
        return ind;
    }
    #endregion
}
