using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace RPG
{
    public static class Sound
    {
        public static SoundPlayer title = new SoundPlayer(Properties.Resources.Airship);
        public static SoundPlayer field = new SoundPlayer(Properties.Resources.Field2);
        public static SoundPlayer battle = new SoundPlayer(Properties.Resources.Battlesound);
        public static SoundPlayer dungeon = new SoundPlayer(Properties.Resources.Dungeon9);
        public static SoundPlayer end = new SoundPlayer(Properties.Resources.Field3);
        public static SoundPlayer final = new SoundPlayer(Properties.Resources.Battle9);
    }
    
}
