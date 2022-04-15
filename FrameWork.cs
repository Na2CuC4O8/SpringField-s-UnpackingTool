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

        public static FileType getType(int typeIndex)
        {
            switch (typeIndex)
            {
                case 0:
                    return FileType.character;
                case 1:
                    return FileType.spine;
                case 2:
                    return FileType.live2dcharacter;
                case 3:
                    return FileType.live2dfairy;
                case 4:
                    return FileType.live2dsquad;
                case 5:
                    return FileType.live2dbg;
                case 6:
                    return FileType.resource;
                case 7:
                    return FileType.atlasclips;
                case 8:
                    return FileType.acb;
                case 9:
                    return FileType.usm;
                case 10:
                    return FileType.furniture;
                case 11:
                    return FileType.sprites;
                case 12:
                    return FileType.assetmap;
                case 13:
                    return FileType.assetparticles;
                case 14:
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
