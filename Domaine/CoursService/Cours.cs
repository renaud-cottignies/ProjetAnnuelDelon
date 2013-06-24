using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.CoursService
{

    //[Table("COURS", Schema = "dbo")]
    public class Cours
    {
        //[Key]
        //[Column("ID")]
        public int ID { get; set; }

        //[Required]
        //[Column("CREATION_DATE")]
        public DateTime CreationDate { get; set; }

        //[Required]
        //[Column("IDCREATOR")]
        public int Idcreator { get; set; }

        //[Column("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }

        //[Required]
        //  [Column("TITLE_COURS")]
        public string titleCours { get; set; }

        //[Required]
        //[Column("CORE_COURS")]
        public string coreCours { get; set; }

        //[Required]
        //[Column("IDLEVEL")]
        public int idLevel { get; set; }

        //[Required]
        //[Column("IDSUBJECT")]
        public int idSubject { get; set; }

        //[Required]
        //[Column("VISIBILITY")]
        public int visibility { get; set; }

        //[Required]
        //[Column("VOTE_POSITIF")]
        public int vote_positif { get; set; }

        //[Required]
        //[Column("VOTE_NEGATIF")]
        public int vote_negatif { get; set; }

        //[Column("TIMESTAMP")]
        //[Timestamp]
        //public byte[] Timestamp { get; set;}

        public Cours() { }

        public Cours(int _id, string _titleCours, string _coreCours, int _idSubject, int _visibility, DateTime _createDate, int _idCreator, int _idlevel)
        {
            this.ID = _id;
            this.idLevel = _idlevel;
            this.titleCours = _titleCours;
            this.coreCours = _coreCours;
            this.idSubject = _idSubject;
            this.visibility = _visibility;
            this.CreationDate = _createDate;
            this.Idcreator = _idCreator;
            this.vote_negatif = 0;
            this.vote_positif = 0;
            this.ModificationDate = DateTime.MaxValue;
        }

        public Cours(string _titleCours, string _coreCours, int _idSubject, int _visibility, DateTime _createDate, int _idCreator, int _idlevel)
        {
            this.idLevel = _idlevel;
            this.titleCours = _titleCours;
            this.coreCours = _coreCours;
            this.idSubject = _idSubject;
            this.visibility = _visibility;
            this.CreationDate = _createDate;
            this.Idcreator = _idCreator;
            this.vote_negatif = 0;
            this.vote_positif = 0;
            this.ModificationDate = DateTime.MaxValue;
        }

        public Cours(int _id, string _titleCours, string _coreCours, int _idSubject, int _visibility, DateTime _createDate, int _idCreator, int _idlevel, DateTime _modificationDate, int _votp, int _votn)
        {
            this.ID = _id;
            this.idLevel = _idlevel;
            this.titleCours = _titleCours;
            this.coreCours = _coreCours;
            this.idSubject = _idSubject;
            this.visibility = _visibility;
            this.CreationDate = _createDate;
            this.Idcreator = _idCreator;
            this.ModificationDate = _modificationDate;
            this.vote_positif = _votp;
            this.vote_negatif = _votn;
        }
    }
}