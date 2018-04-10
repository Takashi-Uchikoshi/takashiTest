using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Runtime.Serialization;

namespace B2.BestFunction.Models
{
    /// <summary>
    /// メイン画面の左側の機能ボタン、アクションパネルとそのボタンなどのデータ
    /// </summary>   
    [DataContract]
    public class BfMenu
    {
        public BfMenu()
        {
            //■TBD. テストデータ作成
            {
                // Dashboad
                this.KinoButtons.Add(new KinoButton()
                {
                    Text = "Dashboard",
                    Type = KinoButtonType.SetBfForm,
                    Command = new Command 
                    {
                        FileName = "BfDashboard.dll",
                        FormName = "B2.BestFunction.BfDashboardForm",
                        MenuLevel = "Dashboard",
                    },
                });
            
                // 発注
                this.KinoButtons.Add(new KinoButton()
                {
                    Text = "発注",
                    Type = KinoButtonType.SetBfForm,
                    Command = new Command
                    {
                        FileName = "BfFormSample.exe",
                        FormName = "B2.BestFunction.BfFormSample",
                        MenuLevel = "発注",
                    },
                });

                // 在庫
                this.KinoButtons.Add(new KinoButton()
                {
                    Text = "在庫",
                    ActionSubPanels = new List<ActionSubPanel>
                    {
                        new ActionSubPanel()
                        {
                            Title = "在庫一覧",
                            Note = "在庫の説明ああああああああああああああああああああ",
                            ActionButtons = new List<ActionButton>
                            {
                                new ActionButton(),
                                new ActionButton(),
                                new ActionButton
                                {
                                    Command = new Command
                                    {
                                        Enable = true,
                                        MenuShowMode = MenuShowMode.Ichiran,
                                        FileName = "BfFormSample.exe",
                                        FormName = "B2.BestFunction.BfFormSample",
                                        MenuLevel = "在庫 ＞ 在庫知覧 ＞ 一覧",
                                  },
                                },
                                new ActionButton(),
                            },
                        },
                        new ActionSubPanel()
                        {
                            Title = "入庫",
                            Note = "入庫の説明ああああああああああああああああああああ",
                            ActionButtons = new List<ActionButton>
                            {
                                new ActionButton
                                {
                                    Command = new Command
                                    {
                                        Enable = true,
                                        MenuShowMode = MenuShowMode.Kensaku,
                                        FileName = "BfFormSample.exe",
                                        FormName = "B2.BestFunction.BfFormSample",
                                        MenuLevel = "在庫 ＞ 入庫 ＞ 検索",
                                    },
                                },
                                new ActionButton
                                {
                                    Command = new Command
                                    {
                                        Enable = true,
                                        MenuShowMode = MenuShowMode.Rireki,
                                        FileName = "BfFormSample.exe",
                                        FormName = "B2.BestFunction.BfFormSample",
                                        MenuLevel = "在庫 ＞ 入庫 ＞ 履歴",
                                    },
                                },
                                new ActionButton
                                {
                                    Command = new Command
                                    {
                                        Enable = true,
                                        MenuShowMode = MenuShowMode.Ichiran,
                                        FileName = "BfFormSample.exe",
                                        FormName = "B2.BestFunction.BfFormSample",
                                        MenuLevel = "在庫 ＞ 入庫 ＞ 一覧",
                                    },
                                },
                                new ActionButton
                                {
                                     Command = new Command
                                    {
                                        Enable = true,
                                        MenuShowMode = MenuShowMode.Shinki,
                                        FileName = "BfFormSample.exe",
                                        FormName = "B2.BestFunction.BfFormSample",
                                        MenuLevel = "在庫 ＞ 入庫 ＞ 新規",
                                   },
                                },
                            },
                        },
                    },
                });

                // マスタ
                this.KinoButtons.Add(new KinoButton()
                {
                    Text = "マスタ",
                    ActionSubPanels = new List<ActionSubPanel>
                    {
                        new ActionSubPanel()
                        {
                            Title = "薬品",
                            Note = "説明ああああああああああああああああああああ",
                            ActionButtons = new List<ActionButton>
                            {
                                new ActionButton(),
                                new ActionButton(),
                                new ActionButton
                                {
                                    Command = new Command
                                    {
                                        Enable = true,
                                        MenuShowMode = MenuShowMode.Ichiran,
                                        FileName = "BfFormSample.exe",
                                        FormName = "B2.BestFunction.BfFormSample",
                                        MenuLevel = "マスタ ＞ 薬品 ＞ 一覧",
                                  },
                                },
                                new ActionButton(),
                            },
                        },
                    },
                });
            }
        }

        [DataMember(Name = "KinoButtons")]
        public List<KinoButton> KinoButtons = new List<KinoButton>();

        public static string Serialize(BfMenu bfMenu)
        {
            string json;
            using (var msin = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(BfMenu));
                serializer.WriteObject(msin, bfMenu);
                json = Encoding.UTF8.GetString(msin.ToArray());
            }

            return json;
        }

        public static BfMenu Deserialize(string json)
        {
            using (var msout = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(BfMenu));
                return (BfMenu)serializer.ReadObject(msout);
            }
        }
    }
}
