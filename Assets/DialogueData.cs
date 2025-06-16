using System;
using UnityEngine;

public class DialogueData : MonoBehaviour
{
    string[] dialogSue = {"Hi Chef, where have you been?0#You want to make exotic meals just like your grandfather?0#Hmmm…0#Well… I suppose you can try. Go into your restaurant to start cooking up a meal!0#Your restaurant is right above the town fountain, this little building behind me. Go on inside.0",
    "Hi Chef! Welcome to your restaurant… uhhh you have been here before, maybe you just forgot?0#Let me show you what to do!0#First off, you must have Coal! It’s super important for all your meals and allows you to start the fire. The we have wood won’t do any good getting a fire that can cook monster parts.0#It’s quite a rare thing but I’m sure you’ll be able to find it if you explore the Swamp enough.0#Then you’ll obviously need your ingredients. I know your experimenting with Monster parts, the more you get the more likely you’ll be able to make various meals.0#Lastly, you’ll have to use the chopping board to make your meals.0#Go over to your table and try making your first meal!0",
    "Woah Chef, this Slime Slushie is delicious!0#When you drink it, it will heal you more.0#Now that you’ve cooked your first great meal you should head out to find more ingredients *wink.0#Rumours say that if you interact with the Town Fountain, you can travel to a new part of the Swamp.0#There should be some more monster parts for you to collect in the new area.0#Here’s a map of the new area.0#Oh also! If you haven’t used your spatula yet try it out in the forest. Once you’ve… disposed of enough monsters, you can press Q to unleash a super powerful attack!0#Good luck Chef!0",
    "Woahhhh Chef! Your skin looks amazing, what did you have to eat recently?0#Well… I’m not sure how but those frog legs seem to have increased your vitality-0#Huh…0#Amazing…0#Frog legs? Seriously?0#HOW DO THOSE MAKE YOU HEALTHIER???!!!! AUGH!0#Anyways- make sure you speak to Billy the Butcher, he was looking for you.0" };
    string[] dialogBilly = {"Grumble grumble0#Uh- hello there, I’m Billy the Butcher.0#Good to see you taking over from your old man.0#Good day.0",
    "grumble grumble grumble0#Oh! Uhh sorry I didn’t see you there.0#Ahem- anyways, thanks for coming to see me.0#I heard that you’ve been exploring the Swamp…0#It’s quite a dangerous place but I’m glad someone is brave enough to try.0#When I was a boy, my father would tell a story of a horrible creature dwelling in the Swamp.0#They called it the Root of all Evil.0#I sought it out and found its lair.0#H- however… #I am too scared to face it…0#You should fight it for me! That’s a great idea! You don’t mind, do you?0#AHAHA OF COURSE YOU WOULDN’T YOU’RE THE BRAVE CHEF!!!!!!0#WHY WOULD YOU BE SCARED OF THE ROOT OF ALL EVIL?!?!??!0#I’m sure it will be the foundation for the best meal you’ll ever have!0#If you use the fountain, you’ll be taken to its territory.0#Good luck Chef!0" };
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
