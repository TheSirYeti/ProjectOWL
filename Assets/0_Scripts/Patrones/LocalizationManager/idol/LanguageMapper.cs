using UnityEngine;

public static class LanguageMapper {

    public static SystemLanguage Map(string lang) {
        switch (lang) {
            case "AFR":     return SystemLanguage.Afrikaans;
            case "AF":      return SystemLanguage.Afrikaans;
            case "ARA":     return SystemLanguage.Arabic;
            case "AR":      return SystemLanguage.Arabic;
            case "BAQ":     return SystemLanguage.Basque;
            case "EUS":     return SystemLanguage.Basque;
            case "EU":      return SystemLanguage.Basque;
            case "BEL":     return SystemLanguage.Belarusian;
            case "BE":      return SystemLanguage.Belarusian;
            case "BUL":     return SystemLanguage.Bulgarian;
            case "BG":      return SystemLanguage.Bulgarian;
            case "CAT":     return SystemLanguage.Catalan;
            case "CA":      return SystemLanguage.Catalan;
            case "CHI":     return SystemLanguage.Chinese;
            case "ZHO":     return SystemLanguage.Chinese;
            case "ZH":      return SystemLanguage.Chinese;
            case "CZE":     return SystemLanguage.Czech;
            case "CES":     return SystemLanguage.Czech;
            case "CE":      return SystemLanguage.Czech;
            case "DAN":     return SystemLanguage.Danish;
            case "DA":      return SystemLanguage.Danish;
            case "DUT":     return SystemLanguage.Dutch;
            case "NLD":     return SystemLanguage.Dutch;
            case "NL":      return SystemLanguage.Dutch;
            case "ENG":     return SystemLanguage.English;
            case "EN":      return SystemLanguage.English;
            case "EST":     return SystemLanguage.Estonian;
            case "ET":      return SystemLanguage.Estonian;
            case "FAO":     return SystemLanguage.Faroese;
            case "FO":      return SystemLanguage.Faroese;
            case "FIN":     return SystemLanguage.Finnish;
            case "FI":      return SystemLanguage.Finnish;
            case "FRE":     return SystemLanguage.French;
            case "FRA":     return SystemLanguage.French;
            case "FR":      return SystemLanguage.French;
            case "GER":     return SystemLanguage.German;
            case "DEU":     return SystemLanguage.German;
            case "DE":      return SystemLanguage.German;
            case "GRE":     return SystemLanguage.Greek;
            case "ELL":     return SystemLanguage.Greek;
            case "EL":      return SystemLanguage.Greek;
            case "HEB":     return SystemLanguage.Hebrew;
            case "HE":      return SystemLanguage.Hebrew;
            case "HUN":     return SystemLanguage.Hungarian;
            case "HU":      return SystemLanguage.Hungarian;
            case "ICE":     return SystemLanguage.Icelandic;
            case "ISL":     return SystemLanguage.Icelandic;
            case "IS":      return SystemLanguage.Icelandic;
            case "IND":     return SystemLanguage.Indonesian;
            case "ID":      return SystemLanguage.Indonesian;
            case "ITA":     return SystemLanguage.Italian;
            case "IT":      return SystemLanguage.Italian;
            case "JPN":     return SystemLanguage.Japanese;
            case "JA":      return SystemLanguage.Japanese;
            case "KOR":     return SystemLanguage.Korean;
            case "KO":      return SystemLanguage.Korean;
            case "LAV":     return SystemLanguage.Latvian;
            case "LV":      return SystemLanguage.Latvian;
            case "LIT":     return SystemLanguage.Lithuanian;
            case "LT":      return SystemLanguage.Lithuanian;
            case "NNO":     return SystemLanguage.Norwegian;
            case "NN":      return SystemLanguage.Norwegian;
            case "NOB":     return SystemLanguage.Norwegian;
            case "NB":      return SystemLanguage.Norwegian;
            case "POL":     return SystemLanguage.Polish;
            case "PL":      return SystemLanguage.Polish;
            case "POR":     return SystemLanguage.Portuguese;
            case "PT":      return SystemLanguage.Portuguese;
            case "RUM":     return SystemLanguage.Romanian;
            case "RON":     return SystemLanguage.Romanian;
            case "RO":      return SystemLanguage.Romanian;
            case "RUS":     return SystemLanguage.Russian;
            case "RU":      return SystemLanguage.Russian;
            case "HBS":     return SystemLanguage.SerboCroatian;
            case "BOS":     return SystemLanguage.SerboCroatian;
            case "CNR":     return SystemLanguage.SerboCroatian;
            case "HRV":     return SystemLanguage.SerboCroatian;
            case "SRP":     return SystemLanguage.SerboCroatian;
            case "SVM":     return SystemLanguage.SerboCroatian;
            case "SLO":     return SystemLanguage.Slovak;
            case "SLK":     return SystemLanguage.Slovak;
            case "SK":      return SystemLanguage.Slovak;
            case "SLV":     return SystemLanguage.Slovenian;
            case "SL":      return SystemLanguage.Slovenian;
            case "SPA":     return SystemLanguage.Spanish;
            case "ES":      return SystemLanguage.Spanish;
            case "ESP":     return SystemLanguage.Spanish;
            case "SWE":     return SystemLanguage.Swedish;
            case "SV":      return SystemLanguage.Swedish;
            case "THA":     return SystemLanguage.Thai;
            case "TH":      return SystemLanguage.Thai;
            case "TUR":     return SystemLanguage.Turkish;
            case "TR":      return SystemLanguage.Turkish;
            case "UKR":     return SystemLanguage.Ukrainian;
            case "UK":      return SystemLanguage.Ukrainian;
            case "VIE":     return SystemLanguage.Vietnamese;
            case "VI":      return SystemLanguage.Vietnamese;
            case "ZH-HANS": return SystemLanguage.ChineseSimplified;
            case "ZH-HANT": return SystemLanguage.ChineseTraditional;
            default:        return SystemLanguage.Unknown;
        }
    }
    
    
    
}