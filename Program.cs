﻿using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;


Console.Clear();
messageWithColor(ConsoleColor.Red,"Welcome to Dark World!",true);
Console.ResetColor();
Console.WriteLine("Hello please select mode with number below!\n1: New Game\n2: Load Game\n3: Credit\n4: Exit"); 
Console.ForegroundColor = ConsoleColor.Green;
Console.Write("Select>: ");
Console.ResetColor();
string sel = Console.ReadLine();

//initlize Character for player
Character Player = new Character();
//For new game
if(sel=="1")
{
  //Loop to select new Character
    while(true)
    {   
            Console.Clear();
            messageWithColor(ConsoleColor.DarkMagenta,"Select Class of your Hero!",true);
            Console.WriteLine("1: Knight");
            Console.WriteLine("2: Wizard");
            Console.WriteLine("3: Elf");
            Console.WriteLine("4: Warrior");
            Console.WriteLine("5: EXIT TO TITLE");
            messageWithColor(ConsoleColor.Green,"Select>: ",false);
            string classHero_Selector = Console.ReadLine();

        try
        {
            //For Knight
        if (classHero_Selector=="1")
        {
            messageWithColor(ConsoleColor.Green,"You has selected Knight, Please type user name: ",false);
            string userName = Console.ReadLine();
            Character Hero = new Character();
            Hero.Health=40;
            Hero.Damage=5;
            Hero.Defend=3;
            Hero.Mana=0;
            Hero.Level=1;
            Hero.EXP=0;
            Hero.Class="Knight";
            Hero.UserName = userName;
            Player = Hero;
            messageWithColor(ConsoleColor.DarkMagenta,"Character has been created! CLASS: "+Player.Class+", USER NAME: "+Player.UserName,false);
            break;
            
        
        }
        //For Wizard
        if(classHero_Selector=="2")
        {
            messageWithColor(ConsoleColor.Green,"You has selected Wizard, Please type user name: ",false);
            string userName = Console.ReadLine();
            Character Hero = new Character();
            Hero.Health=20;
            Hero.Damage=2;
            Hero.Defend=2;
            Hero.Mana=20;
            Hero.Level=1;
            Hero.EXP=0;
            Hero.Class="Wizard";
            Hero.UserName = userName;
            Player = Hero;
            messageWithColor(ConsoleColor.DarkMagenta,"Character has been created! CLASS: "+Player.Class+", USER NAME: "+Player.UserName,false);
            break;
            
        }
        //For Elf
        if(classHero_Selector=="3")
        {
            messageWithColor(ConsoleColor.Green,"You has selected Elf, Please type user name: ",false);
            string userName = Console.ReadLine();
            Character Hero = new Character();
            Hero.Health=30;
            Hero.Damage=4;
            Hero.Defend=3;
            Hero.Mana=20;
            Hero.Level=1;
            Hero.EXP=0;
            Hero.Class="Elf";
            Hero.UserName = userName;
            Player = Hero;
            messageWithColor(ConsoleColor.DarkMagenta,"Character has been created! CLASS: "+Player.Class+", USER NAME: "+Player.UserName,false);
            break;
            
        }
        //For Warrior
        if(classHero_Selector=="4")
        {
            messageWithColor(ConsoleColor.Green,"You has selected Warrior, Please type user name: ",false);
            string userName = Console.ReadLine();
            Character Hero = new Character();
            Hero.Health=50;
            Hero.Damage=4;
            Hero.Defend=6;
            Hero.Mana=20;
            Hero.Level=1;
            Hero.EXP=0;
            Hero.UserName = userName;
            Hero.Class="Warrior";
            Player = Hero;
            messageWithColor(ConsoleColor.DarkMagenta,"Character has been created! CLASS: "+Player.Class+", USER NAME: "+Player.UserName,false);
            break;
           
            
        }
        if(classHero_Selector=="5") break;
        }
        catch
        {
            Console.Clear();
            continue;
        }
        
    
   
    
    }
     MenuTitle(Player);
}
    
if(sel=="2")
{
    messageWithColor(ConsoleColor.Green,"Please type User name here: ",false);
    string userName = Console.ReadLine();
}
//For print message with color
 void messageWithColor(ConsoleColor color,string message,bool brline)
    {
        Console.ForegroundColor = color;
        if(brline)
        Console.WriteLine(message);
        else
        Console.Write(message);
        Console.ResetColor();
    }
//Menu
void MenuTitle(Character charac)
{
    if(charac.UserName==""||charac.UserName==null)
    {
        return;
    }
    else
    {
        messageWithColor(ConsoleColor.DarkBlue,"User>: "+charac.UserName,true);
        Console.WriteLine("1: Go to Dungeon\n2: Stas\n3: Save\n4: Exit");
        messageWithColor(ConsoleColor.Green,"Select>: ",false);
        string sel = Console.ReadLine();
        if(sel=="1")
        {
            MonsterList();
            string monsterSel = Console.ReadLine();
            if(monsterSel=="1")
            {
                Monsters Slime = new Monsters(13,3,4,4,"Slime");
                Battle(Player,Slime);
            }
        }
    }
}
//Method to print Monsters list 
void MonsterList()
{
    messageWithColor(ConsoleColor.Red,"=====Monsters List=====",true);
    Console.WriteLine("1: Small Slime (⭐)");
    Console.WriteLine("2: Small Bat (⭐)");
    Console.WriteLine("3: Kix (lv2 ⭐)");
    Console.WriteLine("4: Tyconx (Lv1 ⭐⭐)");

}
//Battle
bool Battle(Character charac,Monsters monster)
{
    //init damage random
    var generator = new Random();
    messageWithColor(ConsoleColor.DarkMagenta,"Battle Started",true);
    while(true)
    {
        if(charac.Health>0&&monster.Health>0)
        {
            int realdamagePlayer= generator.Next((charac.Damage-monster.Defend)-2,(charac.Damage-monster.Defend)+3);
            monster.Health-=realdamagePlayer;
            messageWithColor(ConsoleColor.DarkYellow,monster.Name+" deal "+realdamagePlayer,true);
            int realdamageMonster = generator.Next((monster.Damage-charac.Defend)-2,(monster.Damage-charac.Defend)+4);
            charac.Health-=realdamageMonster;
            messageWithColor(ConsoleColor.DarkRed,"You deal from "+monster.Name+" "+realdamageMonster,true);
        }
        if(charac.Health<=0)
        {
            messageWithColor(ConsoleColor.Red,"You're Death",true);            
            return false;
           
        }
         if(monster.Health<=0)
        {
            messageWithColor(ConsoleColor.Green,"You win!",true);
            return true;
        }
         
    }
}