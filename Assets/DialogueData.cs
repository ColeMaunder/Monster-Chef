using System;
using UnityEngine;

public class DialogueData : MonoBehaviour
{
    string[] dialogSue = {"Hi Chef, where have you been?1#You went into the Swamp?? Why?3#You want to make exotic meals just like your grandfather?0#Hmmm…3#Well… I suppose you can try.2# Go into your restaurant to start cooking up a meal!0#Your restaurant is right above the town fountain, this little building behind me. Go on inside.0",
    "Hi Chef! Welcome to your restaurant… uhhh you have been here before, maybe you just forgot?1#Let me show you what to do!2#First off, you must have Coal! It’s super important for all your meals and allows you to start the fire.2#The wood we have won’t do any good for making a fire that can cook monster parts.3#It’s quite a rare thing but I’m sure you’ll be able to find it if you explore the Swamp enough.2#Then you’ll obviously need your ingredients.0#I know your experimenting with Monster parts, the more you get the more likely you’ll be able to make yummy meals.2#Lastly, you’ll have to use the chopping board to make your meals.0#Go over to your table and try making your first meal!2",
    "Woah Chef, this Slime Slushie is delicious!4#When you drink it, it will heal you more.4#Now that you’ve cooked your first great meal you should head out to find more ingredients.2#Rumours say that if you interact with the Town Fountain, you can travel to a new part of the Swamp.3#There should be some more monster parts for you to collect in the new area.0#Here’s a map of the new area.0#Oh also! If you haven’t used your spatula yet try it out in the forest. Once you’ve… disposed of enough monsters, you can press Q to unleash a super powerful attack!1#Good luck Chef!2",
    "Woahhhh Chef! Your skin looks amazing, what did you have to eat recently?4#Well… I’m not sure how but those frog legs seem to have increased your vitality-1#Huh…0#Amazing…3#Frog legs? Seriously?3#HOW DO THOSE MAKE YOU HEALTHIER???!!!! AUGH!3#Anyways- make sure you speak to Billy the Butcher, he was looking for you.2" };
    string[] dialogBilly = {"Grumble grumble0#Uh hello there, I’m Billy the Butcher.0#Good to see you taking over from your old man.0#Good day.2",
    "grumble grumble grumble0#Oh! Uhh sorry I didn’t see you there.1#Ahem- anyways, thanks for coming to see me.0#I heard that you’ve been exploring the Swamp…1#It’s quite a dangerous place.2# I’m glad someone is brave enough to try and adventure through it.0#When I was a boy, my father would tell a story of a horrible creature dwelling in the Swamp.2#They called it the Root of all Evil.1#I sought it out and found its lair.1#H- however…0#I am too scared to face it…2#You should fight it for me! That’s a great idea! You don’t mind, do you?1#AHAHA OF COURSE YOU WOULDN’T YOU’RE THE BRAVE CHEF!!!!!!1#WHY WOULD YOU BE SCARED OF THE ROOT OF ALL EVIL?!?!??!1#I’m sure it will be the foundation for the best meal you’ll ever have!1#If you use the fountain, you’ll be taken to its territory.0#G-Good luck Chef!0" };
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public string[] GetDialog(int charicterID,int lineID){
        switch (charicterID)
        {
            case 0:
                string[] datalinesSue = dialogSue[lineID].Split("#");
                for (int i = 0; i < datalinesSue.Length; i++){
                    datalinesSue[i] = datalinesSue[i].Remove(datalinesSue[i].Length-1);
                }
                return datalinesSue;
            case 1:
                string[] datalinesBilly = dialogBilly[lineID].Split("#");
                for (int i = 0; i < datalinesBilly.Length; i++){
                    datalinesBilly[i] = datalinesBilly[i].Remove(datalinesBilly[i].Length-1);
                }
                return datalinesBilly;
            default:
            string[] linesNull = {};
            return linesNull;
        
        }
    }
    public int[] GetFaceID(int charicterID,int lineID){
        switch (charicterID)
        {
            case 0:
                string[] datalinesSueString = dialogSue[lineID].Split("#");
                int[] datalinesSue = new int[datalinesSueString.Length];
                for (int i = 0; i < datalinesSue.Length; i++){
                    datalinesSue[i] = (int) datalinesSueString[i][datalinesSueString[i].Length - 1] - 48;
                }
                return datalinesSue;
            case 1:
            string[] datalinesBillyString = dialogSue[lineID].Split("#");
                int[] datalinesBilly= new int[datalinesBillyString.Length];
                for (int i = 0; i < datalinesBilly.Length; i++){
                    datalinesBilly[i] = (int) datalinesBillyString[i][datalinesBillyString[i].Length - 1] - 48;
                }
                return datalinesBilly;
            default:
            int[] linesNull = {};
            return linesNull;
        
        }
    }
}
