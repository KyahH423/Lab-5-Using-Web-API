/*       
 *--------------------------------------------------------------------
 * 	   File name: Character.cs
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
    internal class Character
    {
        public string Name { get; set; }
        public List<string> Actor { get; set; }
        public List<Episode> Episodes { get; set; }
        public List<string> Occupation { get; set; }
        public string Id { get; set; }

        public Character() { }
        public Character(string name, List<string> actors, List<Episode> episodes, List<string> occupation, string id)
        {
            Name = name;
            Actor = actors;
            Episodes = episodes;
            Occupation = occupation;
            Id = id;
        }

        public override string ToString()
        {
            string msg = "";
            msg += $"Name: {Name}\n";
            msg += $"Actor(s): {String.Join(',', Actor)}\n";
            msg += $"Episodes: {String.Join(',', Episodes)}\n";
            msg += $"Occupation: {String.Join(',', Occupation)}\n";
            msg += $"ID: {Id}\n\n";
            return msg;
        }
    }
}
