using System.Diagnostics;
using System;
namespace SpringField_s_UpackingTool
{
    public partial class Form1 : Form
    {
        private int w;
        private int h;
        private FrameWork.LANG language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
                FrameWork.LanguageReset(_language);
            }
        }

        /// <summary>
        /// display language
        /// </summary>
        private FrameWork.LANG _language;
        public List<FileNames> AllNames = new List<FileNames>();
        private List<DataResult> dataResults = new List<DataResult>();
        private List<string> skinNamesSP = new List<string>();
        private List<string> skinNamesPA = new List<string>();
        private List<string> live2dNewGun = new List<string>();
        private List<string> live2dFairy = new List<string>();
        private List<string> live2dsquad = new List<string>();
        private List<string> live2dbgcg = new List<string>();
        private List<string> resourcelist = new List<string>();
        private List<string> atlasCliplist = new List<string>();
        private List<string> acb = new List<string>();
        private List<string> usm = new List<string>();
        private List<string> furniture = new List<string>();
        private List<string> sprtes = new List<string>();
        private List<string> assetmap = new List<string>();
        private List<string> assetparticles = new List<string>();
        private List<string> other = new List<string> ();
        
        /// <summary>
        /// all file names/ path are here
        /// </summary>
        private Dictionary<FileType, Dictionary<string, FileNames>> AllTypeNames = new Dictionary<FileType, Dictionary<string, FileNames>>();
        private float progress
        {
            set
            {
                //progressBar1.Value
                _progress = value;
            }
        }
        private float _progress = 0;
        public string PathDiscovery { get; set; }
        public Form1()
        {
            InitializeComponent();
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            w = this.Size.Width;
            h = this.Size.Height;
            panel1.Size = new Size(panel1.Size.Width, h - 60);
            panel2.Size = new Size(w - panel1.Size.Width - 60, h - 60);
            language = FrameWork.LANG.CN;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 1;
            progressBar1.Step = 1;
            foreach(FileType type in Enum.GetValues(typeof(FileType)))
            {
                AllTypeNames.Add(type, new Dictionary<string, FileNames> ());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //SpringField_s_UnpackingTool.Settings1.Default.GFPath
            FrameWork.AllTextBoxes.Add(new BoxTextPair() { 
                textBox = textBox1,
                SCNText = "请选择热更文件夹路径",
                ENText = "Please Choose Hot Update Folder Path"
            });

            FrameWork.AllTextLabels.Add(new LabelTextPair()
            {
                label = label1,
                SCNText = "显示语言/Display Language",
                ENText = "显示语言/Display Language"
            });

            FrameWork.AllTextLabels.Add(new LabelTextPair()
            {
                label = label2,
                SCNText = "搜索相关字符",
                ENText = "Search Related"
            });

            FrameWork.AllTextLabels.Add(new LabelTextPair()
            {
                label = label3,
                SCNText = "排除字符 用英文逗号隔开",
                ENText = "Exclude Name Splite with ,"
            });
            FrameWork.AllTextLabels.Add(new LabelTextPair()
            {
                label = label4,
                SCNText = "立绘",
                ENText = "Painting"
            });
            FrameWork.AllTextLabels.Add(new LabelTextPair()
            {
                label = label5,
                SCNText = "骨骼动画",
                ENText = "Spine"
            });

            FrameWork.AllTextLabels.Add(new LabelTextPair()
            {
                label = label6,
                SCNText = "重新分类",
                ENText = "Reclassify"
            });

            FrameWork.AllTextLabels.Add(new LabelTextPair()
            {
                label = label7,
                SCNText = "数据处理完成！！",
                ENText = "Data Process Complete!!"
            });

            FrameWork.AllTextLabels.Add(new LabelTextPair()
            {
                label = label8,
                SCNText = "排除字符 用英文逗号隔开",
                ENText = "Exclude Name Splite with ,"
            });

            FrameWork.AllTextLabels.Add(new LabelTextPair()
            {
                label = label9,
                SCNText = "搜索相关字符",
                ENText = "Search Related"
            });

            FrameWork.AllTextLabels.Add(new LabelTextPair()
            {
                label = label10,
                SCNText = "搜索文件种类",
                ENText = "Related File Type"
            });

            FrameWork.AllTextLabels.Add(new LabelTextPair()
            {
                label = label11,
                SCNText = "本软件的设计目的在于帮助同人游戏开发者为少女前线的资源数\n据进行整理和归类。所有少女前线的资源数据版权归属散爆云母\n组所有。本软件的开发者不会为用户自身造成的任何法律问题承\n担责任。",
                ENText = "This software is aimed to help fan game developers to \nclassify resource asset of Girl's Frontline. However, all \ncopyright of data of Girl's Frontine is owned by SunBorn \nMac Team. The developer of this software will not take any \nresponsibility of users' leagal problems."
            });

            FrameWork.AllTextLabels.Add(new LabelTextPair()
            {
                label = label12,
                SCNText = "该模块可用于对所有资源\n根据资源种类进行归类复\n制",
                ENText = "This module is used to \nclassify(copy) all files \nvar file type"
            });

            FrameWork.AllTextLabels.Add(new LabelTextPair()
            {
                label = label13,
                SCNText = "该模块可用于根据名称搜索和查询立绘及骨骼动画资源并根据勾选\n文件进行复制导出",
                ENText = "This module is used to search Paintings and Spine Assets var \nfile name, user can copy and export selected files to new \ndirectory"
            });

            FrameWork.AllTextLabels.Add(new LabelTextPair()
            {
                label = label14,
                SCNText = "该模块可用于对\n特定类型资源根\n据文件名进行搜\n索和查询并复制\n导出",
                ENText = "This module is \nused to search \nwithin specific \ntype of files \nvar file name, \nuser can copy \nand export \nselected files to \nnew directory"
            });

            FrameWork.AllTextButtons.Add(new ButtonTextPair() { 
                button = button1,
                SCNText = "选择热更文件夹",
                ENText = "Choose Hot Update Folder"
            });


            FrameWork.AllTextButtons.Add(new ButtonTextPair()
            {
                button = button2,
                SCNText = "按文件名分析种类",
                ENText = "Analyze File Var Name"
            });
            FrameWork.AllTextButtons.Add(new ButtonTextPair()
            {
                button = button3,
                SCNText = "按文件名分析皮肤",
                ENText = "Analyze Skins Var Name"
            });
            FrameWork.AllTextButtons.Add(new ButtonTextPair()
            {
                button = button4,
                SCNText = "清除名称",
                ENText = "Clear"
            });

            FrameWork.AllTextButtons.Add(new ButtonTextPair()
            {
                button = button5,
                SCNText = "分类 并 保存",
                ENText = "Reclassify and Save"
            });

            FrameWork.AllTextButtons.Add(new ButtonTextPair()
            {
                button = button6,
                SCNText = "导出选定角色素材",
                ENText = "Export Selected Assets"
            });

            FrameWork.AllTextButtons.Add(new ButtonTextPair()
            {
                button = button7,
                SCNText = "清除名称",
                ENText = "Clear Names"
            });

            FrameWork.AllTextButtons.Add(new ButtonTextPair()
            {
                button = button8,
                SCNText = "按名称查找文件",
                ENText = "Search Related Files Var Name"
            });

            FrameWork.AllTextButtons.Add(new ButtonTextPair()
            {
                button = button9,
                SCNText = "导出并保存",
                ENText = "Save & Export"
            });

            FrameWork.AllTextCheckboxes.Add(new CheckboxTextPair()
            {
                checkBox = checkBox1,
                SCNText = "清除额外后缀",
                ENText = "Clear Extra Extension"
            });

            FrameWork.AllTextCheckboxes.Add(new CheckboxTextPair()
            {
                checkBox = checkBox2,
                SCNText = "清除哈希名称",
                ENText = "Clear Hash Name"
            });

            FrameWork.AllTextCheckboxes.Add(new CheckboxTextPair()
            {
                checkBox = checkBox3,
                SCNText = "勾选所有立绘",
                ENText = "Choose All Paintings"
            });

            FrameWork.AllTextCheckboxes.Add(new CheckboxTextPair()
            {
                checkBox = checkBox4,
                SCNText = "勾选所有骨骼动画",
                ENText = "Choose All Spine"
            });
            FrameWork.AllTextCheckboxes.Add(new CheckboxTextPair()
            {
                checkBox = checkBox5,
                SCNText = "清理哈希名称",
                ENText = "Clear Hash Name"
            });

            FrameWork.AllTextCheckboxes.Add(new CheckboxTextPair()
            {
                checkBox = checkBox6,
                SCNText = "勾选全部类型",
                ENText = "Select All Types"
            });

            FrameWork.AllTextCheckboxes.Add(new CheckboxTextPair()
            {
                checkBox = checkBox7,
                SCNText = "导出相关live2d、语音及动画",
                ENText = "Export Related Live2d & Voice & Anime"
            });

            FrameWork.AllTextCheckboxes.Add(new CheckboxTextPair()
            {
                checkBox = checkBox8,
                SCNText = "勾选全部",
                ENText = "Select All"
            });

            FrameWork.AllTextCheckboxes.Add(new CheckboxTextPair()
            {
                checkBox = checkBox9,
                SCNText = "清理文件名",
                ENText = "Clear File Name"
            });

            if (SpringField_s_UnpackingTool.Settings1.Default.GFPath != null || SpringField_s_UnpackingTool.Settings1.Default.GFPath != "")
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
            comboBox1.SelectedIndex = 0;
            checkBox1.Checked = true;
            checkBox2.Checked = true;   
            checkBox5.Checked = true;
            checkBox9.Checked = true;
            comboBox2.SelectedIndex = 0;
            button2_Click(sender,e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpringField_s_UnpackingTool.Settings1.Default.GFPath = ChooseFolder();
            textBox1.Text = SpringField_s_UnpackingTool.Settings1.Default.GFPath;
            //Form2 secondForm = new Form2();
            //secondForm.Show();
        }


        private string ChooseFolder()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                
                return folderBrowserDialog1.SelectedPath;
            }
            else
            {
                return null;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Size = new Size(panel2.Width - button1.Width - 6, textBox1.Height);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    language = FrameWork.LANG.CN;
                    break;
                case 1:
                    language = FrameWork.LANG.EN;
                    break;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        public List<FileNames> FolderAnalyse(string path)
        {
            List<FileNames> files = new List<FileNames>();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            List<string> allFileNames = new List<string>();
            List<string> _allFileNames = new List<string>();
            Dictionary<string, FileNames> NamesDic = new Dictionary<string, FileNames>();
            int fileCounter = 0;
            AllNames.Clear();
            dataResults.Clear();
            skinNamesSP.Clear();
            skinNamesPA.Clear();
            live2dNewGun.Clear();
            live2dFairy.Clear();
            live2dsquad.Clear();
            live2dbgcg.Clear();
            resourcelist.Clear();
            atlasCliplist.Clear();
            acb.Clear();
            usm.Clear();
            furniture.Clear();
            sprtes.Clear();
            assetmap.Clear();
            assetparticles.Clear();
            other.Clear();
            foreach (FileType type in Enum.GetValues(typeof(FileType)))
            {
                AllTypeNames[type].Clear();
            }

            foreach (FileInfo file in directoryInfo.GetFiles())
            {

                fileCounter++;
            }

            progressBar1.Maximum = fileCounter;

            foreach (FileInfo file in directoryInfo.GetFiles())
            {

                FileNames tmp = new FileNames()
                {
                    FileType = FileType.empty,
                    FullName = file.FullName,
                    FileName = file.Name,
                };
                allFileNames.Add(file.Name);
                _allFileNames.Add(file.Name);
                files.Add(tmp);
                NamesDic.Add(file.Name, tmp);
            }

            foreach (string fileName in allFileNames)
            {
                if (fileName.Contains("acb") && !fileName.Contains(".ab"))
                {
                    NamesDic[fileName].FileType = FileType.acb;
                    _allFileNames.Remove(fileName);
                    fileCounter -= 1;
                    progressBar1.PerformStep();
                    //Debug.WriteLine($"FullName:{fileName}");
                    string[] name = fileName.Split('.');
                    NamesDic[fileName].CharacterName = name[0].ToUpper();
                    AllTypeNames[FileType.acb].Add(NamesDic[fileName].CharacterName, NamesDic[fileName]);
                    acb.Add(NamesDic[fileName].CharacterName);

                    //Debug.WriteLine($"acb:{NamesDic[fileName].CharacterName}");
                }
            }

            foreach (string fileName in allFileNames)
            {
                if (fileName.Contains("usm"))
                {
                    NamesDic[fileName].FileType = FileType.usm;
                    _allFileNames.Remove(fileName);
                    fileCounter -= 1;
                    progressBar1.PerformStep();

                    //Debug.WriteLine($"FullName:{fileName}");
                    string[] name = fileName.Split('.');
                    NamesDic[fileName].CharacterName = name[0];
                    AllTypeNames[FileType.usm].Add(NamesDic[fileName].CharacterName, NamesDic[fileName]);
                    usm.Add(NamesDic[fileName].CharacterName);
                    //Debug.WriteLine($"usm:{NamesDic[fileName].CharacterName}");

                }
            }
            foreach (string fileName in allFileNames)
            {
                if (fileName.Contains("atlasclips"))
                {
                    NamesDic[fileName].FileType = FileType.atlasclips;
                    _allFileNames.Remove(fileName);
                    fileCounter -= 1;
                    progressBar1.PerformStep();
                    AllTypeNames[FileType.atlasclips].Add(fileName, NamesDic[fileName]);
                    atlasCliplist.Add(fileName);
                }
            }

            foreach (string fileName in allFileNames)
            {
                if (fileName.Contains("assetparticles"))
                {
                    NamesDic[fileName].FileType = FileType.assetparticles;
                    _allFileNames.Remove(fileName);
                    fileCounter -= 1;
                    progressBar1.PerformStep();
                    AllTypeNames[FileType.assetparticles].Add(fileName, NamesDic[fileName]);
                    assetparticles.Add(fileName);
                }
            }

            foreach (string fileName in allFileNames)
            {
                if (fileName.Contains("furniture") && !fileName.Contains("atlasclips"))
                {
                    NamesDic[fileName].FileType = FileType.furniture;
                    _allFileNames.Remove(fileName);
                    fileCounter -= 1;
                    progressBar1.PerformStep();
                    AllTypeNames[FileType.furniture].Add(fileName, NamesDic[fileName]);
                    furniture.Add(fileName);
                }
            }

            foreach (string fileName in allFileNames)
            {
                if (!fileName.Contains("resource") && fileName.Contains("live2d"))
                {

                    if (fileName.Contains("live2dnewgun"))
                    {
                        NamesDic[fileName].FileType = FileType.live2dcharacter;
                        _allFileNames.Remove(fileName);
                        fileCounter -= 1;
                        progressBar1.PerformStep();
                        //Debug.WriteLine($"FullName:{fileName}");
                        string[] name = fileName.Split("live2dnewgun");
                        NamesDic[fileName].CharacterName = name[1].Split('.')[0];
                        AllTypeNames[FileType.live2dcharacter].Add(NamesDic[fileName].CharacterName, NamesDic[fileName]);
                        live2dNewGun.Add(NamesDic[fileName].CharacterName);
                        //Debug.WriteLine($"live2d:{NamesDic[fileName].CharacterName}");
                    }
                    else if (fileName.Contains("live2dnewfairy"))
                    {
                        NamesDic[fileName].FileType = FileType.live2dfairy;
                        _allFileNames.Remove(fileName);
                        fileCounter -= 1;
                        progressBar1.PerformStep();
                        //Debug.WriteLine($"FullName:{fileName}");
                        string[] name = fileName.Split("live2dnewfairy");
                        NamesDic[fileName].CharacterName = name[1].Split('.')[0];
                        AllTypeNames[FileType.live2dfairy].Add(NamesDic[fileName].CharacterName, NamesDic[fileName]);
                        live2dFairy.Add(NamesDic[fileName].CharacterName);
                        //Debug.WriteLine($"live2d:{NamesDic[fileName].CharacterName}");
                    }
                    else if (fileName.Contains("live2dnewsquads"))
                    {
                        NamesDic[fileName].FileType = FileType.live2dsquad;
                        _allFileNames.Remove(fileName);
                        fileCounter -= 1;
                        progressBar1.PerformStep();
                        //Debug.WriteLine($"FullName:{fileName}");
                        string[] name = fileName.Split("live2dnewsquads");
                        NamesDic[fileName].CharacterName = name[1].Split('.')[0];
                        AllTypeNames[FileType.live2dsquad].Add(NamesDic[fileName].CharacterName, NamesDic[fileName]);
                        live2dsquad.Add(NamesDic[fileName].CharacterName);
                        //Debug.WriteLine($"live2dnewsquads:{NamesDic[fileName].CharacterName}");
                    }
                    else if (fileName.Contains("live2dnewbg"))
                    {
                        NamesDic[fileName].FileType = FileType.live2dbg;
                        _allFileNames.Remove(fileName);
                        fileCounter -= 1;
                        progressBar1.PerformStep();
                        //Debug.WriteLine($"FullName:{fileName}");
                        string[] name = fileName.Split("live2dnewbg");
                        NamesDic[fileName].CharacterName = name[1].Split('.')[0];
                        AllTypeNames[FileType.live2dbg].Add(NamesDic[fileName].CharacterName, NamesDic[fileName]);
                        live2dbgcg.Add(NamesDic[fileName].CharacterName);
                        //Debug.WriteLine($"live2dnewbg:{NamesDic[fileName].CharacterName}");
                    }

                }
            }

            foreach (string fileName in allFileNames)
            {
                if (fileName.Contains("assetmap"))
                {
                    NamesDic[fileName].FileType = FileType.assetmap;
                    _allFileNames.Remove(fileName);
                    fileCounter -= 1;
                    progressBar1.PerformStep();
                    AllTypeNames[FileType.assetmap].Add(fileName, NamesDic[fileName]);
                    assetmap.Add(fileName);
                }
            }


            foreach (string fileName in allFileNames)
            {
                if (fileName.Contains("sprites"))
                {
                    NamesDic[fileName].FileType = FileType.sprites;
                    _allFileNames.Remove(fileName);
                    fileCounter -= 1;
                    progressBar1.PerformStep();
                    AllTypeNames[FileType.sprites].Add(fileName, NamesDic[fileName]);
                    sprtes.Add(fileName);
                }
            }



            foreach (string fileName in _allFileNames)
            {
                if (fileName.Contains("resource"))
                {
                    NamesDic[fileName].FileType = FileType.resource;
                    //_allFileNames.Remove(fileName);
                    fileCounter -= 1;
                    progressBar1.PerformStep();
                    AllTypeNames[FileType.resource].Add(fileName, NamesDic[fileName]);
                    resourcelist.Add(fileName);
                }
            }

            foreach (string fileName in allFileNames)
            {
                if(fileName.Contains("character") && fileName.Contains("spine"))
                {
                    NamesDic[fileName].FileType = FileType.spine;
                    _allFileNames.Remove(fileName);
                    fileCounter -= 1;
                    progressBar1.PerformStep();

                    //Debug.WriteLine($"FullName:{fileName}");
                    string[] name = fileName.Split("character");
                    NamesDic[fileName].CharacterName = name[1].Split("spine")[0];
                    if (AllTypeNames[FileType.spine].ContainsKey(NamesDic[fileName].CharacterName))
                    {
                        //Debug.WriteLine($"charater:{NamesDic[fileName].CharacterName}");
                        string tmp = NamesDic[fileName].CharacterName + "_1";
                        NamesDic[fileName].CharacterName = tmp;
                        AllTypeNames[FileType.spine].Add(tmp, NamesDic[fileName]);
                        skinNamesSP.Add(tmp);
                    }
                    else
                    {
                        AllTypeNames[FileType.spine].Add(NamesDic[fileName].CharacterName, NamesDic[fileName]);
                        skinNamesSP.Add(NamesDic[fileName].CharacterName);
                    }
                    //Debug.WriteLine($"spine:{NamesDic[fileName].CharacterName}");
                }
            }

            



            foreach (string fileName in allFileNames)
            {
                if (fileName.Contains("character") && !fileName.Contains("spine"))
                {
                    NamesDic[fileName].FileType = FileType.character;
                    _allFileNames.Remove(fileName);
                    fileCounter -= 1;
                    progressBar1.PerformStep();

                    string[] name = fileName.Split("character");
                    NamesDic[fileName].CharacterName = name[1].Split('.')[0];
                    if (AllTypeNames[FileType.character].ContainsKey(NamesDic[fileName].CharacterName))
                    {
                        //Debug.WriteLine($"charater:{NamesDic[fileName].CharacterName}");

                        string tmp = NamesDic[fileName].CharacterName;
                        tmp = NamesDic[fileName].CharacterName+"_1";
                        NamesDic[fileName].CharacterName = tmp;
                        AllTypeNames[FileType.character].Add(tmp, NamesDic[fileName]);
                        skinNamesPA.Add(tmp);
                    }
                    else
                    {
                        AllTypeNames[FileType.character].Add(NamesDic[fileName].CharacterName, NamesDic[fileName]);
                        skinNamesPA.Add(NamesDic[fileName].CharacterName);
                    }
                    
                    //Debug.WriteLine($"charater:{NamesDic[fileName].CharacterName}");
                }
            }

            foreach(string fileName in allFileNames)
            {
                if(NamesDic[fileName].FileType == FileType.empty)
                {
                    NamesDic[fileName].FileType = FileType.other;
                    fileCounter -= 1;
                    progressBar1.PerformStep();
                    AllTypeNames[FileType.other].Add(fileName, NamesDic[fileName]);
                    other.Add(fileName);
                }
            }

            AllNames = files;
            return files;
        }

        private void DisplayGrid(List<FileNames> fileNames)
        {
            int empty = 0,
                spine = 0,
                live2dcharacter = 0,
                live2dfairy = 0,
                live2dsquad = 0,
                live2dbg = 0,
                resource = 0,
                atlasclip = 0,
                acb = 0,
                usm = 0,
                furniture = 0,
                character = 0,
                sprite = 0,
                map = 0,
                particles = 0,
                other = 0;
            foreach (FileNames file in fileNames)
            {
                switch (file.FileType)
                {
                    case FileType.spine:
                        spine++;
                        break;
                    case FileType.live2dcharacter:
                        live2dcharacter++;
                        break;
                    case FileType.live2dfairy:
                        live2dfairy++;
                        break;
                    case FileType.live2dsquad:
                        live2dsquad++;
                        break;
                    case FileType.live2dbg:
                        live2dbg++;
                        break;
                    case FileType.resource:
                        resource++;
                        break;
                    case FileType.atlasclips:
                        atlasclip++;
                        break;
                    case FileType.acb:
                        acb++;
                        break;
                    case FileType.usm:
                        usm++;
                        break;
                    case FileType.furniture:
                        furniture++;
                        break;
                    case FileType.character:
                        character++;
                        break;
                    case FileType.sprites:
                        sprite++;
                        break;
                        break;
                    case FileType.assetmap:
                        map++;
                        break;
                    case FileType.assetparticles:
                        particles++;
                        break;
                    case FileType.other:
                        other++;
                        break;
                }
            }
            dataResults.Add(new DataResult()
            {
                Type = "Character/立绘",
                Num = character.ToString()
            });
            dataResults.Add(new DataResult()
            {
                Type = "Spine/骨骼动画",
                Num = spine.ToString()
            });
            dataResults.Add(new DataResult()
            {
                Type = "live2dchar/角色动态立绘",
                Num = live2dcharacter.ToString()
            });
            dataResults.Add(new DataResult()
            {
                Type = "live2dfairy/妖精动态立绘",
                Num = live2dfairy.ToString()
            });
            dataResults.Add(new DataResult()
            {
                Type = "live2dsquad/重装动态立绘",
                Num = live2dsquad.ToString()
            });
            dataResults.Add(new DataResult()
            {
                Type = "live2dbg/动态基地背景",
                Num = live2dbg.ToString()
            });
            dataResults.Add(new DataResult()
            {
                Type = "Resource/资源",
                Num = resource.ToString()
            });
            dataResults.Add(new DataResult()
            {
                Type = "Atlasclip/图集",
                Num = atlasclip.ToString()
            });
            dataResults.Add(new DataResult()
            {
                Type = "ActorVoice/配音",
                Num = acb.ToString()
            });
            dataResults.Add(new DataResult()
            {
                Type = "Anime/动画",
                Num = usm.ToString()
            });
            dataResults.Add(new DataResult()
            {
                Type = "Furniture/家具",
                Num = furniture.ToString()
            });
            dataResults.Add(new DataResult()
            {
                Type = "Sprite/图片精灵",
                Num = sprite.ToString()
            });
            dataResults.Add(new DataResult()
            {
                Type = "Map/地图",
                Num = map.ToString()
            });
            dataResults.Add(new DataResult()
            {
                Type = "Particles/粒子",
                Num = particles.ToString()
            });
            dataResults.Add(new DataResult()
            {
                Type = "Other/其他",
                Num = other.ToString()
            });

            foreach (DataResult item in dataResults)
            {
                //Debug.WriteLine($"{item.Type}/{item.Num}");
            }

            dataGridView1.DataSource = dataResults;
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SpringField_s_UnpackingTool.Settings1.Default.GFPath == null || SpringField_s_UnpackingTool.Settings1.Default.GFPath == "") return;

            progressBar1.Maximum = 100;
            progressBar1.PerformStep();
            switch (language)
            {
                case FrameWork.LANG.CN:
                    label7.Text = "春田正在处理数据...";
                    break;
                case FrameWork.LANG.EN:
                    label7.Text = "SpringField is Processing Your Data...";
                    break;
            }
            label7.Refresh();
            dataResults.Clear();
            FolderAnalyse(SpringField_s_UnpackingTool.Settings1.Default.GFPath);
            DisplayGrid(AllNames);
            switch (language)
            {
                case FrameWork.LANG.CN:
                    label7.Text = "数据处理完成！！";
                    break;
                case FrameWork.LANG.EN:
                    label7.Text = "Data Process Complete!!";
                    break;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (skinNamesSP.Count == 0 || skinNamesPA.Count == 0) return;
            if (textBox2.Text == null || textBox2.Text == "") return;
            progressBar1.Maximum=100;
            progressBar1.PerformStep();
            checkBox4.Checked = false;
            checkBox3.Checked = false;
            switch (language)
            {
                case FrameWork.LANG.CN:
                    label7.Text = "春田正在处理数据...";
                    break;
                case FrameWork.LANG.EN:
                    label7.Text = "SpringField is Processing Your Data...";
                    break;
            }
            label7.Refresh();

            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            if (textBox2.Text == "") return;
            List<string> tmp = textBox3.Text.Split(',').ToList();
            List<string> PA = NameFinder(textBox2.Text, skinNamesPA, tmp);
            if (PA == null) return;
            foreach(string s in PA)
            {
                //richTextBox1.Text += $"{s}\n";
                checkedListBox1.Items.Add(s);
            }
            progressBar1.Maximum = 100;
            progressBar1.PerformStep();
            List<string> SP = NameFinder(textBox2.Text, skinNamesSP, tmp);
            if (SP == null) return;

            foreach (string s in SP)
            {
                //richTextBox2.Text += $"{s}\n";
                checkedListBox2.Items.Add(s);
            }
            switch (language)
            {
                case FrameWork.LANG.CN:
                    label7.Text = "数据处理完成！！";
                    break;
                case FrameWork.LANG.EN:
                    label7.Text = "Data Process Complete!!";
                    break;
            }
        }

        private List<string> NameFinder(string inputName, List<string> namelist, List<string> excludeName = null)
        {
            List<string> result = new List<string>();
            int progress = skinNamesSP.Count;
            progressBar1.Maximum = progress;
            foreach(string name in namelist)
            {
                if (name.Contains(inputName)){
                    result.Add(name);
                }
                progress -= 1;
                progressBar1.PerformStep();
            }
            if(excludeName == null)
            {
                return result;
            }
            else
            {
                if(result == null)return null;
                List<string> tmp = FrameWork.clone(result);
                if(tmp == null)return null;
                for(int i = 0; i < tmp.Count; i++)
                {
                    foreach(string name in excludeName)
                    {
                        if ( name != "" && tmp[i].Contains(name))
                        {
                            result.Remove(tmp[i]);
                        }
                    }
                }
                return result;
            }

        }


        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkedListBox3.CheckedIndices.Count == 0) return;
            string savePath = ChooseFolder();
            if (savePath == null) return;
            switch (language)
            {
                case FrameWork.LANG.CN:
                    label7.Text = "春田正在处理数据...";
                    break;
                case FrameWork.LANG.EN:
                    label7.Text = "SpringField is Processing Your Data...";
                    break;
            }
            label7.Refresh();
            foreach (int checkBox in checkedListBox3.CheckedIndices)
            {
                classifyVarType(FrameWork.getType(checkBox),savePath);
            }
            switch (language)
            {
                case FrameWork.LANG.CN:
                    label7.Text = "数据处理完成！！";
                    break;
                case FrameWork.LANG.EN:
                    label7.Text = "Data Process Complete!!";
                    break;
            }
            Process.Start("Explorer.exe", savePath);
        }
        private void TotalClassify(List<string> names, int i, string savePath, FileType type, string folderName,bool clearName, bool clearExtension,string spliter,string spliter2 = ".")
        {
            i = names.Count;
            progressBar1.Maximum = i;
            foreach(string fileName in names)
            {
                string originalPath = AllTypeNames[type][fileName].FullName;
                string tmpName = AllTypeNames[type][fileName].FileName;
                //string targetPath = savePath + $"/{folderName}/" + AllTypeNames[type][fileName].FileName;
                if (!Directory.Exists(savePath + $"/{folderName}"))
                {
                    Directory.CreateDirectory(savePath + $"/{folderName}");
                }
                string nameOnly = tmpName.Split('.')[0];
                string fullExtension = tmpName.Replace(nameOnly, "");
                string shortExtension = tmpName.Split(".")[1];
                string targetFileName;
                if (clearName)
                {
                    Debug.WriteLine(tmpName);
                    targetFileName = tmpName.Split(spliter)[1].Split(spliter2)[0];
                }
                else
                {
                    targetFileName = nameOnly.ToString();
                }
                if (clearExtension)
                {
                    targetFileName += $".{shortExtension}";
                }
                else
                {
                    targetFileName += $"{fullExtension}";
                }
                File.Copy(originalPath, savePath + $"/{folderName}/{targetFileName}", true);
                i -- ;
                progressBar1.PerformStep();

            }

        }

        private void classify(List<string> names, int i, string savePath, FileType type, string folderName,bool special = false)
        {
            i = names.Count;
            progressBar1.Maximum = i;
            foreach (string fileName in names)
            {
                if (special)
                {
                    if (AllTypeNames[type].ContainsKey(fileName))
                    {
                        string originSN = AllTypeNames[type][fileName].FullName;
                        string saveSN = savePath + $"/{folderName}/" + AllTypeNames[type][fileName].FileName;
                        string tmp = AllTypeNames[type][fileName].FileName.Split("live2dnewgun")[1].Split('.')[0];
                        saveSN = savePath + $"/{folderName}/" + tmp + ".ab";
                        if(!Directory.Exists(savePath + $"/{folderName}"))
                        {
                            Directory.CreateDirectory(savePath + $"/{folderName}");
                        }
                        File.Copy(originSN, saveSN, true);
                    }

                }
                else
                {
                    if (AllTypeNames[type].ContainsKey(fileName))
                    {
                        string originSN = AllTypeNames[type][fileName].FullName;
                        string saveSN = savePath + $"/{folderName}/" + AllTypeNames[type][fileName].FileName;
                        if (!Directory.Exists(savePath + $"/{folderName}"))
                        {
                            Directory.CreateDirectory(savePath + $"/{folderName}");
                        }
                        File.Copy(originSN, saveSN, true);
                    }


                }
                i--;
                progressBar1.PerformStep();

            }
        }


        private void classifyVarType(FileType fileType,string savePath)
        {
            int i = 0;
            progressBar1.Maximum = i;
            progressBar1.PerformStep();
            switch (fileType)
            {
                case FileType.empty:

                    break;
                case FileType.spine:
                    TotalClassify(skinNamesSP, i, savePath, FileType.spine, "Spine", checkBox2.Checked, checkBox1.Checked, "character", "spine");

                    break;


                case FileType.live2dcharacter:
                    TotalClassify(live2dNewGun, i, savePath, FileType.live2dcharacter, "CharacterLive2d",checkBox2.Checked, checkBox1.Checked, "live2dnewgun");

                    break;


                case FileType.live2dfairy:
                    TotalClassify(live2dFairy, i, savePath, FileType.live2dfairy, "FairyLive2d", checkBox2.Checked, checkBox1.Checked, "live2dnewfairy");
                    break;



                case FileType.live2dsquad:
                    TotalClassify(live2dsquad,i,savePath,FileType.live2dsquad,"HWSquadLive2d", checkBox2.Checked, checkBox1.Checked,"live2dnewsquads");
                    break;

                case FileType.live2dbg:
                    TotalClassify(live2dbgcg, i, savePath, FileType.live2dbg, "BackgroundCGLive2d", checkBox2.Checked, checkBox1.Checked,"live2dnewbg");
                    break;

                case FileType.resource:
                    TotalClassify(resourcelist, i, savePath, FileType.resource, "Resource", checkBox2.Checked, checkBox1.Checked,"resource");
                    break;


                case FileType.atlasclips:
                    TotalClassify(atlasCliplist, i, savePath, FileType.atlasclips, "AtlasClip", checkBox2.Checked, checkBox1.Checked,"atlasclips");

                    break;

                case FileType.acb:
                    TotalClassify(acb, i, savePath, FileType.acb, "ActorVoice", false, checkBox1.Checked,"");
                    break;

                case FileType.usm:
                    TotalClassify(usm, i, savePath, FileType.usm, "Anime",false,checkBox1.Checked,"");
                    break;

                case FileType.furniture:
                    TotalClassify(furniture, i, savePath, FileType.furniture, "Furniture", checkBox2.Checked, checkBox1.Checked,"resource");
                    break;

                case FileType.character:
                    TotalClassify(skinNamesPA, i, savePath, FileType.character, "Painting", checkBox2.Checked, checkBox1.Checked,"character");
                    break;

                case FileType.sprites:
                    TotalClassify(sprtes, i, savePath, FileType.sprites, "Sprite", checkBox2.Checked, checkBox1.Checked, "sprites");
                    break;


                case FileType.assetmap:
                    TotalClassify(assetmap, i, savePath, FileType.assetmap, "AssetMap", checkBox2.Checked, checkBox1.Checked, "assetmap");

                    break;

                case FileType.assetparticles:
                    TotalClassify(assetparticles, i, savePath, FileType.assetparticles, "Particles", checkBox2.Checked, checkBox1.Checked, "assetparticles");
                    break;

                case FileType.other:
                    TotalClassify(other, i, savePath, FileType.other, "Other",false,false,"");
                    break;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, checkBox3.Checked);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, checkBox4.Checked);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedIndices.Count == 0 && checkedListBox2.CheckedIndices.Count == 0) return;
            int i = 0;
            progressBar1.Maximum = i;
            progressBar1.PerformStep();
            string save = ChooseFolder();
            switch (language)
            {
                case FrameWork.LANG.CN:
                    label7.Text = "春田正在处理数据...";
                    break;
                case FrameWork.LANG.EN:
                    label7.Text = "SpringField is Processing Your Data...";
                    break;
            }
            label7.Refresh();
            
            if (save == null || save.Length == 0) return;
            string save1 = $"{save}/{textBox2.Text}";
            Directory.CreateDirectory(save1);
            List<string> pa = new List<string>();
            foreach(string file in checkedListBox1.CheckedItems)
            {
                pa.Add(file);
            }
            List<string> pb = new List<string>();
            foreach (string file in checkedListBox2.CheckedItems)
            {
                pb.Add(file);
            }

            TotalClassify(pa, i, save1, FileType.character, "Painting", checkBox2.Checked, checkBox1.Checked,"character");
            TotalClassify(pb, i, save1, FileType.spine, "Spine", checkBox2.Checked, checkBox1.Checked, "character", "spine");
            if (checkBox7.Checked)
            {
                List<string> pau = new List<string>();
                foreach(string str in pa)
                {
                    pau.Add(str.ToUpper());
                }
                List<string> pbu = new List<string>();
                foreach(string str in pb)
                {
                    pbu.Add(str.ToUpper());
                }
                classify(pau, i, save1, FileType.acb, "Voice");
                classify(pbu, i, save1, FileType.acb, "Voice");
                classify(pa, i, save1, FileType.usm, "Anime");
                classify(pb, i, save1, FileType.usm, "Anime");
                classify(pa, i, save1, FileType.live2dcharacter, "Live2d",checkBox5.Checked);
                classify(pb, i, save1, FileType.live2dcharacter, "Live2d", checkBox5.Checked);

            }
            //Debug.WriteLine(save1);
            switch (language)
            {
                case FrameWork.LANG.CN:
                    label7.Text = "数据处理完成！！";
                    break;
                case FrameWork.LANG.EN:
                    label7.Text = "Data Process Complete!!";
                    break;
            }
            Process.Start("Explorer.exe", save);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                checkedListBox3.SetItemChecked(i, checkBox6.Checked);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
            checkedListBox4.Items.Clear();
            checkBox8.Checked = false;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox4.Items.Count; i++)
            {
                checkedListBox4.SetItemChecked(i, checkBox8.Checked);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private List<string> searchRelated(string relate,string exclude,List<string> all, int i)
        {
            List<string> result = new List<string>();
            List<string> excludelis = new List<string>();
            i = all.Count;
            progressBar1.Maximum = i;
            foreach (string tmp in exclude.Split(','))
            {
                if(tmp != null && tmp != "")
                {
                    excludelis.Add(tmp);
                }
                
            }
            foreach(string name in all)
            {
                string tmp = name.ToLower();
                if (tmp.Contains(relate))
                {
                    bool exc = false;
                    foreach(string ex in excludelis)
                    {
                        if (tmp.Contains(ex))
                        {
                            exc = true;
                        }
                    }

                    if (!exc)
                    {
                        result.Add(name);
                    }
                }
                i--;
                progressBar1.PerformStep();
            }
            return result;
        }

        private void checklistboxAdd<T>(CheckedListBox checkedListBox, List<T> list)
        {

            if (list == null || list.Count == 0) return;

            foreach (T item in list)
            {
                checkedListBox.Items.Add(item);

            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            checkedListBox4.Items.Clear();
            checkBox8.Checked = false;
            if (textBox4.Text == null || textBox4.Text == "") return;
            if(
                skinNamesSP == null || 
                skinNamesPA == null || 
                live2dNewGun == null || 
                live2dFairy == null || 
                live2dsquad == null || 
                live2dbgcg == null || 
                resourcelist == null || 
                atlasCliplist == null || 
                acb == null || 
                usm == null || 
                furniture == null || 
                sprtes == null || 
                assetmap == null || 
                assetparticles == null || 
                other == null
                )
            {
                return;
            }
            int i = 0;
            List<string> tmp = new List<string>();
            progressBar1.Maximum = i;
            progressBar1.PerformStep();
            switch (language)
            {
                case FrameWork.LANG.CN:
                    label7.Text = "春田正在处理数据...";
                    break;
                case FrameWork.LANG.EN:
                    label7.Text = "SpringField is Processing Your Data...";
                    break;
            }
            label7.Refresh();
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    tmp = searchRelated(textBox4.Text, textBox5.Text, skinNamesPA,i);
                    checklistboxAdd<string>(checkedListBox4, tmp);
                    break;
                case 1:
                    tmp = searchRelated(textBox4.Text, textBox5.Text, skinNamesSP, i);
                    checklistboxAdd<string>(checkedListBox4, tmp);
                    break;
                case 2:
                    tmp = searchRelated(textBox4.Text, textBox5.Text, live2dNewGun, i);
                    checklistboxAdd<string>(checkedListBox4, tmp);
                    break;
                case 3:
                    tmp = searchRelated(textBox4.Text, textBox5.Text, live2dFairy, i);
                    checklistboxAdd<string>(checkedListBox4, tmp);
                    break;
                case 4:
                    tmp = searchRelated(textBox4.Text, textBox5.Text, live2dsquad, i);
                    checklistboxAdd<string>(checkedListBox4, tmp);

                    break;
                case 5:
                    tmp = searchRelated(textBox4.Text, textBox5.Text, live2dbgcg, i);
                    checklistboxAdd<string>(checkedListBox4, tmp);

                    break;
                case 6:
                    tmp = searchRelated(textBox4.Text, textBox5.Text, resourcelist, i);
                    checklistboxAdd<string>(checkedListBox4, tmp);

                    break;
                case 7:
                    tmp = searchRelated(textBox4.Text, textBox5.Text, atlasCliplist, i);
                    checklistboxAdd<string>(checkedListBox4, tmp);
                    break;
                case 8:
                    tmp = searchRelated(textBox4.Text, textBox5.Text, acb, i);
                    checklistboxAdd<string>(checkedListBox4, tmp);
                    break;
                case 9:
                    tmp = searchRelated(textBox4.Text, textBox5.Text, usm, i);
                    checklistboxAdd<string>(checkedListBox4, tmp);
                    break;
                case 10:
                    tmp = searchRelated(textBox4.Text, textBox5.Text, furniture, i);
                    checklistboxAdd<string>(checkedListBox4, tmp);
                    break;
                case 11:
                    tmp = searchRelated(textBox4.Text, textBox5.Text, sprtes, i);
                    checklistboxAdd<string>(checkedListBox4, tmp);
                    break;
                case 12:
                    tmp = searchRelated(textBox4.Text, textBox5.Text, assetmap, i);
                    checklistboxAdd<string>(checkedListBox4, tmp);
                    break;
                case 13:
                    tmp = searchRelated(textBox4.Text, textBox5.Text, assetparticles, i);
                    checklistboxAdd<string>(checkedListBox4, tmp);
                    break;
                case 14:
                    tmp = searchRelated(textBox4.Text, textBox5.Text, other, i);
                    checklistboxAdd<string>(checkedListBox4, tmp);
                    break;

            }
            switch (language)
            {
                case FrameWork.LANG.CN:
                    label7.Text = "数据处理完成！！";
                    break;
                case FrameWork.LANG.EN:
                    label7.Text = "Data Process Complete!!";
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox4.Items.Clear(); 
            checkBox8.Checked = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (checkedListBox4.CheckedIndices.Count == 0) return;
            List<string> names = new List<string>();
            foreach(string name in checkedListBox4.CheckedItems)
            {
                names.Add(name);
            }
            string targetPath = ChooseFolder();
            int i = 0;
            string folderName = "";
            progressBar1.Maximum = i;
            progressBar1.PerformStep();
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    folderName = "SelectedPainting";
                    TotalClassify(names, i, targetPath, FileType.character, folderName, checkBox9.Checked, checkBox9.Checked, "character");
                    break;
                case 1:
                    folderName = "SelectedSpine";
                    TotalClassify(names, i, targetPath, FileType.spine, folderName, checkBox9.Checked, checkBox9.Checked, "character", "spine");

                    break;
                case 2:
                    folderName = "SelectedLive2dCharacter";
                    TotalClassify(names, i, targetPath, FileType.live2dcharacter, folderName, checkBox9.Checked, checkBox9.Checked, "live2dnewgun");

                    break;
                case 3:
                    folderName = "SelectedLive2dFairy";
                    TotalClassify(names, i, targetPath, FileType.live2dfairy, folderName, checkBox9.Checked, checkBox9.Checked, "live2dnewfairy");

                    break;
                case 4:
                    folderName = "SelectedLive2dSquad";
                    TotalClassify(names, i, targetPath, FileType.live2dsquad, folderName, checkBox9.Checked, checkBox9.Checked, "live2dnewsquad");
                    break;
                case 5:
                    folderName = "SelectedLive2dBackgroud";
                    TotalClassify(names, i, targetPath, FileType.live2dbg, folderName, checkBox9.Checked, checkBox9.Checked, "live2dnewbg");
                    break;
                case 6:
                    folderName = "SelectedResources";
                    TotalClassify(names, i, targetPath, FileType.resource, folderName, checkBox9.Checked, checkBox9.Checked, "resource");
                    break;
                case 7:
                    folderName = "SelectedAtlasClips";
                    TotalClassify(names, i, targetPath, FileType.atlasclips, folderName, checkBox9.Checked, checkBox9.Checked, "atlasclips");
                    break;
                case 8:
                    folderName = "SelectedActorVoice";
                    TotalClassify(names, i, targetPath, FileType.acb, folderName, false, checkBox9.Checked, "");
                    break;
                case 9:
                    folderName = "SelectedSFAnime";
                    TotalClassify(names, i, targetPath, FileType.usm, folderName, false, checkBox9.Checked, "");
                    break;
                case 10:
                    folderName = "SelectedFurniture";
                    TotalClassify(names, i, targetPath, FileType.furniture, folderName, checkBox9.Checked, checkBox9.Checked, "resource");
                    break;
                case 11:
                    folderName = "SelectedSprite";
                    TotalClassify(names, i, targetPath, FileType.sprites, folderName, checkBox9.Checked, checkBox9.Checked, "sprites");
                    break;
                case 12:
                    folderName = "SelectedAssetMap";
                    TotalClassify(names, i, targetPath, FileType.assetmap, folderName, checkBox9.Checked, checkBox9.Checked, "assetmap");
                    break;
                case 13:
                    folderName = "SelectedParticles";
                    TotalClassify(names, i, targetPath, FileType.assetparticles, folderName, checkBox9.Checked, checkBox9.Checked, "assetparticles");
                    break;
                case 14:
                    folderName = "SelectedOther";
                    TotalClassify(names, i, targetPath, FileType.other, folderName, false, false, "");
                    break;
            }
            Process.Start("Explorer.exe", Path.Combine(targetPath,Path.Combine(targetPath,folderName)));
        }
    }
}