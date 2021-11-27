using System;
using System.Collections.Generic;
using System.IO;
using MiniJSON;
using UnityEngine;

public class LocalizationManager : MonoBehaviour {

    public string rootDirectory = "/Resources/Localization";
    public Dictionary<SystemLanguage, Dictionary<string, string>> texts = new Dictionary<SystemLanguage, Dictionary<string, string>>();

    public static LocalizationManager Instance{ get; private set; }

    public static SystemLanguage language = SystemLanguage.English;
    

    void Awake(){
        if (Instance == null) {
            Instance = this;
            LoadTexts();
        }
        else Destroy(this);
    }

    void Start(){
        Debug.Log("Lenguaje OS: " + Application.systemLanguage);
        
        language = Application.systemLanguage;
    }

    public void SwitchLanguage(){
        language = language == SystemLanguage.Spanish ? SystemLanguage.English : SystemLanguage.Spanish;
    }

    private void LoadTexts(){
        texts = new Dictionary<SystemLanguage, Dictionary<string, string>>();
        
        var allFiles = new List<string>();
        foreach (var file in Directory.GetFiles(Application.dataPath + $"{rootDirectory}/", "*.json", SearchOption.AllDirectories)) {
            var fileName = file.Substring(file.IndexOf("Localization", StringComparison.Ordinal))
                               .Replace(@"\", @"/");
            allFiles.Add(fileName);
        }
        
        foreach (var file in allFiles){
            var asset = Resources.Load<TextAsset>(file.Replace(".json", ""));
            
            var data = asset.text;
            
            var parsedData = (Dictionary<string, object>)Json.Deserialize(data);
            var split   = file.Split('/');
            
            SetTexts(parsedData, split[split.Length-1].Replace(".json",""), split[split.Length - 2]);
        }
    }

    private void SetTexts(Dictionary<string, object> fileContent, string fileName, string language) {
        var lang = LanguageMapper.Map(language.ToUpper());

        foreach (var item in fileContent) {
            if (!texts.ContainsKey(lang)) texts.Add(lang, new Dictionary<string, string>());
            
            texts[lang].Add($"{fileName}/{item.Key}", item.Value.ToString());
            Debug.Log($"{lang} --- {fileName}/{item.Key} --- {item.Value}");
        }
    }

    public string GetText(string key){
        if (!texts[language].ContainsKey(key)){
            Debug.LogError($"Key '{key}' for language '{language}' not found");
            return key;
        }

        return texts[language][key];
    }
    
}
