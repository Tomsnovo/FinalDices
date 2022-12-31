using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dices
{
    internal class gameMechanics
    {        
        game Game = new game();
       

        public gameMechanics()
        {
            
        }
        public void Start()
        {
            Game.Show();            
        }                
    }
}
