using Modding;
using System.Collections.Generic;

namespace EnhancedReply
{
    public class EnhancedReply : Mod, IMenuMod
    {
        private bool optionOne;
        private int optiomTwo = 1;
        public bool ToggleButtonInsideMenu => throw new System.NotImplementedException();

        public List<IMenuMod.MenuEntry> GetMenuData(IMenuMod.MenuEntry? toggleButtonEntry)
        {
            return new List<IMenuMod.MenuEntry>
            {
                new IMenuMod.MenuEntry
                {
                    Name = "Double Revival",
                    Description = "双倍回魂",
                    Values = new string[]
                    {
                        "Off",
                        "On",
                    },
                    Saver = opt => this.optionOne = opt switch{
                        0 => false ,
                        1 => true,
                        _ => throw new System.NotImplementedException()
                    },
                    Loader = () => optionOne switch{
                        false => 0,
                        true => 1
                    },
                },
                new IMenuMod.MenuEntry
                {
                    Name = "Enhanced Reply",
                    Description = "增强回复",
                    Values = new string[]
                    {
                        "1",
                        "2",
                        "3",
                        "4"

                    },
                    Saver = opt => this.optiomTwo = opt switch{
                        0 => 1,
                        1 => 2,
                        2 => 3,
                        3 => 4,
                        _ => throw new System.NotImplementedException()
                    },
                    Loader = () => this.optiomTwo switch
                    {
                        1 => 0,
                        2 => 1,
                        3 => 2,
                        4 => 3,_ => throw new System.NotImplementedException()
                    }
                }
            };
        }

        public string GetName(string name)
        {
            return "信件";
        }

        public override string GetVersion()//版本号
        {
            return "0.2.4";
        }
        public override void Initialize()
        {
            ModHooks.BeforeAddHealthHook += I_BeforeAddHealthHook;
            ModHooks.SoulGainHook += I_SoulGainHook;
        }

        private int I_BeforeAddHealthHook(int num)
        {
            return num * optiomTwo;
        }
        private int I_SoulGainHook(int num)
        {
            if (optionOne)
            {
                return num * 2;
            }
            else { return num; }
        }

    }
}

