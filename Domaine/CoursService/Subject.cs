using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.CoursService
{
    [Table("SUBJECT", Schema = "dbo")] 
    public class Subject
    {
        [Key]
        //[Column("ID")]
        public int ID { get; set; }

        [Required]
        //[MaxLength(40)] 
        //[Column("NAME")]
        public string Name { get; set; }

        [Required]
        //[Column("ICONPATH")]
        public string IconPath { get; set; }

        [Column("TIMESTAMP")]
        [Timestamp]
        public byte[] Timestamp { get; set; }

        public Subject() { }

        public Subject(string _Name, string _iconPath)
        {
            this.Name = _Name;
            this.IconPath = _iconPath;
        }
    }
}