using Modding;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class HKInvincible : Mod, IMenuMod
    {
        private bool optionOne;
        private bool optionTwo;
        public bool ToggleButtonInsideMenu => throw new System.NotImplementedException();

        public List<IMenuMod.MenuEntry> GetMenuData(IMenuMod.MenuEntry? toggleButtonEntry)
        {
            return new List<IMenuMod.MenuEntry>
            {
                new IMenuMod.MenuEntry
                {
                    Name = "Invincible",
                    Description = "小骑士受到的伤害为0",
                    Values = new string[]
                    {
                        "Off",
                        "On"
                    },
                    Saver = opt => this.optionOne = opt switch
                    {
                        0 => false,
                        1 => true,
                        _ => throw new System.NotImplementedException()
                    },
                    Loader = () => this.optionOne switch
                    {
                        false => 0,
                        true => 1,
                    }
                },
                new IMenuMod.MenuEntry
                {
                    Name = "Transparency",
                    Description = "气化小骑士qwq",
                    Values = new string[]
                    {
                        "Off",
                        "On" 
                    },
                     Saver = opt => this.optionTwo = opt switch
                    {
                        0 => false,
                        1 => true,
                        _ => throw new System.NotImplementedException()
                    },
                    Loader = () => this.optionTwo switch
                    {
                        false => 0,
                        true => 1,
                    }

                }
               
            };
        }

        [System.Obsolete]
        new public string GetName() => "My First Mod";
        // 版本号
        public override string GetVersion() => "0.12";

        public override void Initialize()
        {
            ModHooks.TakeHealthHook += Instance_TakeHealthHook;
            ModHooks.TakeDamageHook += ModHooks_TakeDamageHook;
        }

        private int ModHooks_TakeDamageHook(ref int hazardType, int damage)
        {
            if (optionTwo)
            {
                return 0;
            }
            return hazardType;
        }

        private int Instance_TakeHealthHook(int damage)
        {
            if (this.optionOne)
            {
                return 0;
            }
            else return damage;
            
        }
    }
}
