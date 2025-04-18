using Newtonsoft.Json;
using System.ComponentModel.Design;

namespace sparta2
{//기능추가
    internal class Program
    {
        public enum Type { atk, def, hp }
        public struct Character
        {
            public int lv = 1;
            public string name = "정우";
            public string cla = "궁수";
            public int atk = 5;
            public int def = 10;
            public int hp = 10;
            public int gold = 800;
            public int dClear = 0;
            public Character() { }
        }
        static Character myChar = new Character();


        public struct Item
        {
            public string name;
            public Type type;
            public int eff;
            public string desc;
            public bool equip;
            public int gold;
            public bool hasItem = false;
            //public int idx;

            public Item(string name, Type type, int eff, string desc, bool equip) { }
        }
        static Item[] myItem = new Item[6];
        static Item[] shopItem = new Item[3];
        static int item = 3;
        static void FirstScene()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 휴식하기");
            Console.WriteLine("5. 던전가기");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            string select = Console.ReadLine();

            switch (select)
            {
                case "1":
                    Console.WriteLine("1. 상태 보기");
                    StatusUI();
                    break;
                case "2":
                    Console.WriteLine("2. 인벤토리");
                    Inventory();
                    break;
                case "3":
                    Console.WriteLine("3. 상점");
                    ShowShop();
                    break;
                case "4":
                    Console.WriteLine("휴식하기");
                    Rest();
                    break;
                case "5":
                    Console.WriteLine("던전가기");
                    DungeonUI();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    FirstScene();
                    break;
            }
        }

        static void StatusUI()
        {
            int tAtk = 0;
            int tDef = 0;
            for (int i = 0; i < myItem.Length; i++)
            {
                if (myItem[i].equip)
                {
                    switch (myItem[i].type)
                    {
                        case Type.atk:
                            tAtk += myItem[i].eff;
                            break;
                        case Type.def:
                            tDef += myItem[i].eff;
                            break;
                        case Type.hp:
                            break;
                    }
                }
            }
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("이름 : {0}", myChar.name);
            Console.WriteLine("LV : {0}", myChar.lv);
            Console.WriteLine("직업 : {0}", myChar.cla);
            Console.WriteLine("공격력 : {0} (+{1}) ", (myChar.atk + tAtk), tAtk);
            Console.WriteLine("방어력 : {0} (+{1})", (myChar.def + tDef), tDef);
            Console.WriteLine("체력 : {0}", myChar.hp);
            Console.WriteLine("골드 : {0}", myChar.gold);
        }
        static void Status() 
        {
            int tAtk = 0;
            int tDef = 0;
            for (int i = 0; i < myItem.Length; i++)
            {
                if (myItem[i].equip)
                {
                    switch (myItem[i].type)
                    {
                        case Type.atk:
                            tAtk += myItem[i].eff;
                            break;
                        case Type.def:
                            tDef += myItem[i].eff;
                            break;
                        case Type.hp:
                            break;
                    }
                }
            }
        }
        static void Inventory()
        {
            for (int i = 0; i < myItem.Length; i++)
            {
                if (myItem[i].hasItem)
                {
                    if (myItem[i].equip)
                    {
                        Console.WriteLine("[E] {0} | {1} + {2} |  {3} ", myItem[i].name, myItem[i].type, myItem[i].eff, myItem[i].desc);
                    }
                    else Console.WriteLine("{0} | {1} + {2} |  {3} ", myItem[i].name, myItem[i].type, myItem[i].eff, myItem[i].desc);
                }
            }
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            string input = Console.ReadLine();
            if (input == "1")
            {
                EquipManage();
            }
            else if (input == "0")
            {
                FirstScene();
            }
        }

        static void ItemSetting()
        {
            myItem[0].name = "칼";
            myItem[0].type = Type.atk;
            myItem[0].eff = 5;
            myItem[0].desc = "예리한 검입니다.";
            myItem[0].equip = true;
            myItem[0].gold = 0;
            myItem[0].hasItem = true;
            myItem[1].name = "방패";
            myItem[1].type = Type.def;
            myItem[1].eff = 5;
            myItem[1].desc = "튼튼한 방패입니다.";
            myItem[1].equip = false;
            myItem[1].gold = 0;
            myItem[1].hasItem = true;
            myItem[2].name = "창";
            myItem[2].type = Type.atk;
            myItem[2].eff = 3;
            myItem[2].desc = "긴 창입니다.";
            myItem[2].equip = false;
            myItem[2].gold = 0;
            myItem[2].hasItem = true;

            myItem[3].name = "상점용 칼";
            myItem[3].type = Type.atk;
            myItem[3].eff = 10;
            myItem[3].desc = "상점에서 판매하는 검입니다.";
            myItem[3].equip = false;
            myItem[3].gold = 500;
            myItem[3].hasItem = false;
            myItem[4].name = "상점용 방패";
            myItem[4].type = Type.def;
            myItem[4].eff = 7;
            myItem[4].desc = "상점에서 판매하는 방패입니다.";
            myItem[4].equip = false;
            myItem[4].gold = 400;
            myItem[4].hasItem = false;
            myItem[5].name = "상점용 창";
            myItem[5].type = Type.atk;
            myItem[5].eff = 7;
            myItem[5].desc = "상점에서 판매하는 창입니다.";
            myItem[5].equip = false;
            myItem[5].gold = 450;
            myItem[5].hasItem = false;
        }
        static void ShowShop()
        {
            Console.WriteLine("=====================================================================");
            Console.WriteLine("스파르타 상점입니다.");
            Console.WriteLine("보유골드 : {0}", myChar.gold);
            for (int i = 3; i < myItem.Length; i++)
            {
                if (myItem[i].hasItem)
                {
                    Console.WriteLine("[구매완료] {0} | {1} + {2} |  {3}\n ", myItem[i].name, myItem[i].type, myItem[i].eff, myItem[i].desc);
                }
                else Console.WriteLine("{4}G {0} | {1} + {2} |  {3} \n", myItem[i].name, myItem[i].type, myItem[i].eff, myItem[i].desc, myItem[i].gold);
            }
            Console.WriteLine("0 : 나가기");
            Console.WriteLine("9 : 판매창");
            Console.WriteLine("=====================================================================");
            string input = Console.ReadLine();
            int inp = int.Parse(input) + 2;
            switch (input)
            {
                case "1":
                    if (!myItem[inp].hasItem)
                    {
                        if (myChar.gold >= myItem[inp].gold)
                        {
                            myItem[inp].equip = true;
                            myChar.gold -= myItem[inp].gold;
                            PurcahseItem(myItem[inp]);
                        }
                        else Console.WriteLine("Gold가 부족합니다.");
                    }
                    else Console.WriteLine("이미 구매한 아이템입니다.");
                    FirstScene();
                    break;
                case "2":
                    if (!myItem[inp].equip)
                    {
                        if (myChar.gold >= myItem[inp].gold)
                        {
                            myItem[inp].equip = true;
                            myChar.gold -= myItem[inp].gold;
                            PurcahseItem(myItem[inp]);
                        }
                        else Console.WriteLine("Gold가 부족합니다.");
                    }
                    else Console.WriteLine("이미 구매한 아이템입니다.");
                    FirstScene();
                    break;
                case "3":
                    if (!myItem[inp].equip)
                    {
                        if (myChar.gold >= myItem[inp].gold)
                        {
                            myItem[inp].equip = true;
                            myChar.gold -= myItem[inp].gold;
                            PurcahseItem(myItem[inp]);
                        }
                        else Console.WriteLine("Gold가 부족합니다.");
                    }
                    else Console.WriteLine("이미 구매한 아이템입니다.");
                    break;
                case "0":
                    FirstScene();
                    break;
                case "9":
                    SellItem();
                    //판매창 로드
                    break;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }

        }
        static void EquipManage()
        {
            Equip();
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    myItem[0].equip = !myItem[0].equip;
                    Equip();
                    break;
                case "2":
                    myItem[1].equip = !myItem[1].equip;
                    Equip();
                    break;
                case "3":
                    myItem[2].equip = !myItem[2].equip;
                    Equip();
                    break;
                case "0":
                    FirstScene();
                    break;
                default: break;
            }
        }
        static void Equip()
        {
            Console.WriteLine("장착하려는 아이템 숫자를 입력해주세요");
            Console.WriteLine("[아이템 목록]\n");
            for (int i = 0; i < myItem.Length; i++)
            {
                if (myItem[i].equip)
                {
                    Console.WriteLine("[E] {0} | {1} + {2} |  {3}\n ", myItem[i].name, myItem[i].type, myItem[i].eff, myItem[i].desc);
                }
                else Console.WriteLine("{0} | {1} + {2} |  {3} \n", myItem[i].name, myItem[i].type, myItem[i].eff, myItem[i].desc);
            }
            Console.WriteLine("나가기 : 0");
        }

        static void PurcahseItem(Item shopItem) //아이템 구매
        {
            item++;
            myItem[item].name = shopItem.name;
            myItem[item].name = "칼";
            myItem[item].type = shopItem.type;
            myItem[item].eff = shopItem.eff;
            myItem[item].desc = shopItem.desc;
            myItem[item].equip = false;
            myItem[item].gold = shopItem.gold;
            myItem[item].hasItem = true;
            //myItem[item].idx = item;
        }

        static void SellItem()  //아이템 판매
        {
            SellItemUi();
            string input = Console.ReadLine();
            int i = int.Parse(input) + 2;
            if (myItem[i].hasItem)
            {
                Console.WriteLine("판매완료");
                myChar.gold += (int)(myItem[i].gold * 0.8);
                myItem[i].hasItem = false;
                myItem[i].equip = false;
                FirstScene();
            }
            else Console.WriteLine("보유하고 있지 않은 아이템입니다.");
        }

        static void SellItemUi()
        {
            Console.WriteLine("=====================================================================");
            Console.WriteLine("스파르타 상점 판매 창입니다.\n");
            Console.WriteLine("보유하신 아이템을 판매하실 수 있습니다.");
            Console.WriteLine("보유골드 : {0}", myChar.gold);
            for (int i = 3; i < myItem.Length; i++)
            {
                if (myItem[i].hasItem)
                {
                    Console.WriteLine("[구매완료] {0} | {1} + {2} |  {3}\n ", myItem[i].name, myItem[i].type, myItem[i].eff, myItem[i].desc);
                }
                else Console.WriteLine("{4}G {0} | {1} + {2} |  {3} \n", myItem[i].name, myItem[i].type, myItem[i].eff, myItem[i].desc, myItem[i].gold);
            }
            Console.WriteLine("아이템 번호 : 판매");
            Console.WriteLine("9 : 판매창");
            Console.WriteLine("0 : 나가기");
            Console.WriteLine("=====================================================================");
        }

        static void Rest()
        {
            Console.WriteLine("=============================================\n");
            Console.WriteLine("휴식을 하면 체력을 회복할 수 있습니다. 500G가 사용됩니다");
            Console.WriteLine("1 : 휴식하기");
            Console.WriteLine("0 : 나가기");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    if (myChar.gold >= 500)
                    {
                        myChar.gold -= 500;
                        myChar.hp = 100;
                    }
                    else Console.WriteLine("골드가 부족합니다");
                    FirstScene();
                    break;
                case "0":
                    FirstScene();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Rest();
                    break;

            }

        }
        static void DungeonUI()
        {
            int recDef = 0;
            Console.WriteLine("===================================================\n");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("1. 쉬운 던전      | 방어력 5 이상 권장\n");
            Console.WriteLine("2. 중간 던전      | 방어력 11 이상 권장\n");
            Console.WriteLine("3. 쉬운 던전      | 방어력 17 이상 권장\n");
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("===================================================\n");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    recDef = 5;
                    Dungeon(recDef);
                    break;
                case "2":
                    recDef = 11;
                    Dungeon(recDef);
                    break;
                case "3":
                    recDef = 17;
                    Dungeon(recDef);
                    break;
                case "0":
                    FirstScene();
                    break;
                default:
                    DungeonUI();
                    break;

            }
        }

        static void Dungeon(int recDef) 
        {
            int tAtk = 0;
            int tDef = 0;
            Random rand = new Random();
            int per = rand.Next(1, 11);
            for (int i = 0; i < myItem.Length; i++)
            {
                if (myItem[i].equip)
                {
                    switch (myItem[i].type)
                    {
                        case Type.atk:
                            tAtk += myItem[i].eff;
                            break;
                        case Type.def:
                            tDef += myItem[i].eff;
                            break;
                        case Type.hp:
                            break;
                    }
                }
            }
            tAtk += myChar.atk;
            tDef += myChar.def;
            if (tDef < recDef)
            {
                if (per <= 4)
                {
                    myChar.hp = (myChar.hp) / 2;
                    Console.WriteLine("던전에 실패하였습니다.\n hp가 감소합니다.");
                    FirstScene();
                }//실패
                else
                {
                    DungeonClear(tAtk, tDef, recDef);
                } // 성공                
            }
            else
            {
                DungeonClear(tAtk, tDef, recDef);
            }
        }
        static void DungeonClear(int tAtk, int tDef, int recDef)
        {
            Random rand = new Random();
            int preGold = myChar.gold;
            int preHp = myChar.hp;
            int useHp = rand.Next((20 - (tDef - recDef)), (36 - (tDef - recDef)));
            myChar.hp -= useHp;
            myChar.dClear++;
            if (myChar.hp < 0)
            {
                myChar.hp = 0;
            }
            switch (recDef) {
                case 5:
                    myChar.gold = 1000 + (1000 * (int)(tAtk * 0.2));
                    Console.WriteLine("축하합니다 !!\n 쉬운 던전을 클리어 하였습니다.\n");
                    Console.WriteLine("[탐험결과]");
                    Console.WriteLine("{0} -> {1}", preGold, myChar.gold);
                    Console.WriteLine("{0} -> {1}",preHp, myChar.hp);
                    FirstScene();
                    break;
                case 11:
                    myChar.gold += 1700 + (1700 * (int)(tAtk * 0.2));
                    Console.WriteLine("축하합니다 !!\n 일반 던전을 클리어 하였습니다.\n");
                    Console.WriteLine("[탐험결과]");
                    Console.WriteLine("{0} -> {1}", preGold, myChar.gold);
                    Console.WriteLine("{0} -> {1}", preHp, myChar.hp);
                    FirstScene();
                    break;
                case 17:
                    myChar.gold += 2500 + (2500 * (int)(tAtk * 0.2));
                    Console.WriteLine("축하합니다 !!\n 어려운 던전을 클리어 하였습니다.\n");
                    Console.WriteLine("[탐험결과]");
                    Console.WriteLine("{0} -> {1}", preGold, myChar.gold);
                    Console.WriteLine("{0} -> {1}", preHp, myChar.hp);
                    FirstScene();
                    break;
                }
            if(myChar.dClear == 1) 
            {
                Console.WriteLine("레벨업 하셨습니다");
                myChar.lv++;
                myChar.atk += 1;
                myChar.def += 2;
            }
            if (myChar.dClear == 2)
            {
                Console.WriteLine("레벨업 하셨습니다");
                myChar.lv++;
                myChar.atk += 1;
                myChar.def += 2;
            }
            if (myChar.dClear == 3)
            {
                Console.WriteLine("레벨업 하셨습니다");
                myChar.lv++;
                myChar.atk += 1;
                myChar.def += 2;
            }
            if (myChar.dClear == 4)
            {
                Console.WriteLine("레벨업 하셨습니다");
                myChar.lv++;
                myChar.atk += 1;
                myChar.def += 2;
            }
        }

        /*static void SaveData(Character character)
        {
            string jSon = JsonConvert.SerializeObject(character, Newtonsoft.Json.Formatting.Indented);

        }*/
        static void Main(string[] args)
        {
            ItemSetting();
            FirstScene();
        }
        
    }
}
