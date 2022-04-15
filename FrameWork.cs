using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpringField_s_UpackingTool
{
    internal static class FrameWork
    {


        public enum LANG
        {
            CN,EN
        }

        static FrameWork()
        {
            AllTextBoxes = new List<BoxTextPair>();
            AllTextLabels = new List<LabelTextPair>();
            AllTextButtons = new List<ButtonTextPair>();
            AllTextCheckboxes = new List<CheckboxTextPair>(); 
        }

        public static List<BoxTextPair> AllTextBoxes;
        public static List<LabelTextPair> AllTextLabels;
        public static List<ButtonTextPair> AllTextButtons;
        public static List<CheckboxTextPair> AllTextCheckboxes;

        /// <summary>
        /// display language hot reset
        /// </summary>
        /// <param name="language"></param>
        public static void LanguageReset(LANG language)
        {
            SpringField_s_UnpackingTool.Settings1.Default.Language = language.ToString();
            switch (language)
            {
                case LANG.CN://simplified chinese
                    foreach (BoxTextPair boxTextPair in AllTextBoxes)
                    {
                        boxTextPair.textBox.Text = boxTextPair.SCNText;
                    }
                    foreach(LabelTextPair labelTextPair in AllTextLabels)
                    {
                        labelTextPair.label.Text = labelTextPair.SCNText;
                    }
                    foreach(ButtonTextPair buttonTextPair in AllTextButtons)
                    {
                        buttonTextPair.button.Text = buttonTextPair.SCNText;
                    }
                    foreach(CheckboxTextPair checkboxTextPair in AllTextCheckboxes)
                    {
                        checkboxTextPair.checkBox.Text = checkboxTextPair.SCNText;   
                    }
                    break;
                case LANG.EN://english US
                    foreach (BoxTextPair boxTextPair in AllTextBoxes)
                    {
                        boxTextPair.textBox.Text = boxTextPair.ENText;
                    }
                    foreach (LabelTextPair labelTextPair in AllTextLabels)
                    {
                        labelTextPair.label.Text = labelTextPair.ENText;
                    }
                    foreach (ButtonTextPair buttonTextPair in AllTextButtons)
                    {
                        buttonTextPair.button.Text = buttonTextPair.ENText;
                    }
                    foreach (CheckboxTextPair checkboxTextPair in AllTextCheckboxes)
                    {
                        checkboxTextPair.checkBox.Text = checkboxTextPair.ENText;
                    }
                    break;
            }
        }


        public static List<string> clone(List<string> value)
        {
            if(value == null || value.Count == 0)return null;
            List<string> result = new List<string>();
            foreach(string valueItem in value)
            {
                result.Add(valueItem);
            }
            return result;
        }

        public static FileType getType(string typeName)
        {
            switch (typeName)
            {
                case "character":
                    return FileType.character;
                case "spine":
                    return FileType.spine;
                case "live2dcharacter":
                    return FileType.live2dcharacter;
                case "live2dfairy":
                    return FileType.live2dfairy;
                case "live2dsquad":
                    return FileType.live2dsquad;
                case "live2dbackground":
                    return FileType.live2dbg;
                case "resource":
                    return FileType.resource;
                case "atlasclip":
                    return FileType.atlasclips;
                case "actorvoice":
                    return FileType.acb;
                case "anime":
                    return FileType.usm;
                case "furniture":
                    return FileType.furniture;
                case "sprite":
                    return FileType.sprites;
                case "map":
                    return FileType.assetmap;
                case "particles":
                    return FileType.assetparticles;
                case "other":
                    return FileType.other;

            }
            return FileType.empty;
        }
    }

    public class BoxTextPair
    {
        public TextBox textBox = null;
        public string SCNText = null;
        public string ENText = null;
    }

    public class LabelTextPair
    {
        public Label label = null;
        public string SCNText = null;
        public string ENText = null;
    }

    public class ButtonTextPair
    {
        public Button button = null;
        public string SCNText = null;
        public string ENText = null;
    }

    public class CheckboxTextPair
    {
        public CheckBox checkBox = null;
        public string SCNText = null;
        public string ENText = null;
    }

    public enum FileType
    {
        empty,
        spine,
        live2dcharacter,
        live2dfairy,
        live2dsquad,
        live2dbg,
        resource,
        atlasclips,
        acb,
        usm,
        furniture,
        character,
        sprites,
        assetmap,
        assetparticles,
        other
    }
    public class FileNames
    {
        public string FullName;
        public string FileName;
        public string CharacterName;
        public FileType FileType;
    }

    public class DataResult
    {
        public string Type
        {
            get;set;
        }
        public string Num
        {
            get;set;
        }
    }

}
