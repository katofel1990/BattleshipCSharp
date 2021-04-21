using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class ASCII
    {
        Display _display;

        public ASCII(Display display)
        {
            _display = display;
        }

        public void Welcome()
        {
            var title = @"

                                      ____        _   _   _           _     _       
                                     |  _ \      | | | | | |         | |   (_)      
                                     | |_) | __ _| |_| |_| | ___  ___| |__  _ _ __  
                                     |  _ < / _` | __| __| |/ _ \/ __| '_ \| | '_ \ 
                                     | |_) | (_| | |_| |_| |  __/\__ \ | | | | |_) |
                                     |____/ \__,_|\__|\__|_|\___||___/_| |_|_| .__/ 
                                                                             | |    
                                                                             |_|                                       

                                                         |__
                                                         |\/
                                                         ---
                                                         / | [
                                                  !      | |||
                                                _/|     _/|-++'
                                            +  +--|    |--|--|_ |-
                                         { /|__|  |/\__|  |--- |||__/
                                        +---------------___[}-_===_.'____                 /\
                                    ____`-' ||___-{]_| _[}-  |     |_[___\==--            \/   _
                     __..._____--==/___]_|__|_____________________________[___\==--____,------' .7
                    |                                                                     BB-61/
                     \_________________________________________________________________________|

                                            PRESS ANY KEY TO CONTINUE . . . 
";
            _display.Clear();
            _display.PrintMassage(title);
            Console.ReadKey();
        }

        public string PressAnyKey()
        {
            string pressKey = @"                                            
                                            PRESS ANY KEY TO CONTINUE . . . 
";
            return pressKey;
        }

        public string MainMenuText()
        {
            string mainMenu = @"
                                      __  __       _         __  __                  
                                     |  \/  |     (_)       |  \/  |                 
                                     | \  / | __ _ _ _ __   | \  / | ___ _ __  _   _ 
                                     | |\/| |/ _` | | '_ \  | |\/| |/ _ \ '_ \| | | |
                                     | |  | | (_| | | | | | | |  | |  __/ | | | |_| |
                                     |_|  |_|\__,_|_|_| |_| |_|  |_|\___|_| |_|\__,_|
                                                 
                                                 ";
            return mainMenu;
        }
    }
}
