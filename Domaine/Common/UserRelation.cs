using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domaine.Common
{
    [Table("USER_RELATION", Schema = "dbo")] 
    public class UserRelation
    {
        [Key]
        //[Column("ID")]
        public int ID { get; set; }

        [Required] 
        //[Column("USER_A")]
        public int userA { get; set; }

        [Required] 
        //[Column("USER_B")]
        public int userB { get; set; }

        [Required] 
        //[Column("RELATION_STAT")]
        public int relationStat { get; set; }

        [Column("TIMESTAMP")]
        [Timestamp]
        public byte[] Timestamp { get; set;}

        public UserRelation() { }

        public UserRelation(int ua, int ub, int relaStatut)
        {
            this.userA = ua;
            this.userB = ub;
            this.relationStat = relationStat;
        }
    }
}