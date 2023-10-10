/*       
 *--------------------------------------------------------------------
 * 	   File name: Episode.cs
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
    internal class Episode
    {
        public string Title { get; set; } = string.Empty;
        public string Id { get; set; }
        public List<string> Chars { get; set; }

        public Episode() { }
        public Episode(string title, string id, List<string> chars)
        {
            Title = title;
            Id = id;
            Chars = chars;
        }

        public override string ToString()
        {
            string msg = Title;
            return msg;
        }
    }
}
