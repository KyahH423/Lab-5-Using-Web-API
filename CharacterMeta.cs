/*       
 *--------------------------------------------------------------------
 * 	   File name: CharacterMeta.cs
 * 	Project name: Lab5_Web_API
 *--------------------------------------------------------------------
 * Author’s name and email:	 Kyah Hanson - hansonkm@etsu.edu				
 *          Course-Section:  CSCI-2910-800
 *           Creation Date:	 10/5/2023		
 * -------------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Web_API
{
    internal class CharacterMeta
    {
        public IList<Character> data { get; set; }
        public CharacterMeta() { }
        public CharacterMeta(IList<Character> d)
        {
            data = d;
        }


        public override string ToString()
        {
            string msg = "";
            foreach (var item in data)
            {
                msg += item;
            }
            return msg;
        }
    }
}
