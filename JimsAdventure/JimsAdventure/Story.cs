using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Story
    {
        public string[] responses = {
                                        "You wander out of the fort into the fields. The local towns people are currently harvesting this years crops.", //0
                                        "The grass is high and monsters are easily hidden. You were informed to follow the path you're on.", //1 
                                        "The road turns from thick cobble to dirt but still is traversable...I can barely see the castle!", //2
                                        "You continue your way on the main road, seeing villagers on the right and left working in fields...Hello!", //3
                                        "A while later on the road still, no more people around, phew its hot! What's that in the sky?", //4
                                        "There is a darkness of smoke and ash that is over the woods just ahead of here. I'm headed in the right direction!",//5 
                                        "The dirt road passes by a river. Fish are jumping up! Stupid fish! Gosh I'm hungry.",//6
                                        "I can see a bridge in the distance... Crossing the bridge you notice something shiny in the river below",//7
                                        "You look into the river and see something that appears magical! It's just a penny, shucks.",//8
                                        "Moving down the path on the otherside of the river, Jim went into the woods",//9
                                        "This forest is creepy! Yikes! You can barely see any sunlight...is it getting dark!?",//10
                                        "The monsters are getting tougher.. This has got to be the source of the evil.",//11
                                        "Further into the forest it is almost in complete darkness. THUD, I tripped! OUCH!",//12
                                        "You see a dimly lit area ahead... what on earth could that be?",//13
                                        "Walking towards, you notice its a giant tower ... I feel weird, something isn't right", //14
                                        "You hear a loud roaring voice doing what appears to be commanding an army...", //15
                                        "'We have been commanded to obliterate the cities and burn them all...' ", //16
                                        "'...our Lord will be pleased with our current progress. GO! NOW! DESTROY THEM ALL!!",//17
                                        "You notice that the commanding voice is closer than expected... It's a man, shrouded in dark robes, radiating with magic",  // 18
                                        "Jim believes he can get the drop on him from his position...he sneaks closer hoping to get a cheap shot", // 19
                                        "'INTRUDER! YOU SHALL BE DESTROYED!! ", // 20
                                        "All the surrounding monster armys are collapsing and disappeared!? They must have been conjured illusions!", //21
                                        "A thin path is revealed to a large castle", //22
                                        "Jim follows the thin path into the fortress blanketed with a dark aura", //23
                                        "You are near the front gates.. you see hordes of monsters flying away and crossing into a portal", //24
                                        "Where does that portal take them!?! That must be how the monsters are covering the countryside",//25
                                        "The waves of demons seem to be weakening for now.. you make a break for the entrance of the keep ",//26
                                        "You're at a large catwalk over a endless abyss. Off in the distance you see necromancers and conjurers.",//27
                                        "The catwalk turns in large open hallways...I better stay out of sight or I would surely be seen", //28
                                        "Jim follows the path around a circular tower and sees a stairwell going up and down", //29
                                        "You head up the stairs when all of a sudden the ground beneath you shakes and turns flat!", //30
                                        "Oh no! I'm sliding down the tower, this will not end well!! ", //31
                                        "You go around and around for what seems like a while, all the while getting darker and darker.", //32
                                        "You fall out into a pit of bones and blood. The only light comes from a portal gateway at the bottom", //33
                                        "Jim approaches the portal... Is it unguarded?", //34
                                        "A voice inside your head erupts in a maddening booming sound..", //35
                                        "...'HISSSSSS....COME INTO THE LIIIIIGHHHHTT...", //36
                                        "Hello? Who are you? What is this place?", //37
                                        "'I'M THE ARMAGEDDON!!!' HISSSSSSSSSS! I WILL FEED ON YOUR SOOOUUULLLLL. You hyponotically enter the portal.",//38
                                        "Where am I?!... I must stop it.. I have... to save... everyone!",  // 39
                                        "'TO STOP ME WOULD BE TO STOP HUMANITY's FATE. YOU WOULD BE STOPPING DEATH ITSELF... HISSSSSSS' ", // 40
                                        "....."
                                    };


        public string Progression(int p)
        {
            return responses[p];

        }



    }

}



