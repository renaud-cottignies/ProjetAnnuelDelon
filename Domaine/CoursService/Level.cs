using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//[Table("LEVEL", Schema = "dbo")] 
namespace Domaine.CoursService
{
    public class Level
    {
        //[Key]
        //[Column("ID")]
        public int ID { get; set; }

        //[Required]
        //[MaxLength(40)] 
        //[Column("NAME")]
        public string Name { get; set; }

        //[Required]
        //[Column("ICONPATH")]
        public string IconPath { get; set; }

        //[Column("TIMESTAMP")]
        //[Timestamp]
        //public byte[] Timestamp { get; set;}

        public Level() { }

        public Level(string _Name, string _iconPath)
        {
            this.Name = _Name;
            this.IconPath = _iconPath;
        }
    }
}