using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Common
{
    //[Table("USER", Schema = "dbo")] 
    public class User
    {
        //[Key]
        //[Column("ID")]
        public int ID { get; set; }

        //[Required]
        //[MaxLength(40)] 
        //[Column("NAME")]
        public string Name { get; set; }

        //[Required]
        //[MaxLength(40)] 
        //[Column("FIRSTNAME")]
        public string FirstName { get; set; }

        //[Required] 
        //[Column("PASSWORD")]
        public string PassWord { get; set; }

        //[Required]
        //[Column("BIRTHDAY")]
        public DateTime Birthday { get; set; }

        //[Required]
        //[Column("MAIL")]
        public string Mail { get; set; }

        //[Required]
        //[Column("SALT")]
        public string Salt { get; set; }

        //[Required]
        //[Column("GENDER")]
        public bool Gender { get; set; }

        //[Column("ADRESS")]
        public string Address { get; set; }

        //[Column("CITY")]
        public string City { get; set; }

        //[Column("POSTALCODE")]
        public string PostalCode { get; set; }

        //[Column("GEOGRAPHIC_COORDINATES")]
        public string GeographicCoordinates { get; set; }

        //[Required]
        //[Column("INSCRIPTION_DATE")]
        public DateTime IncriptionDate { get; set; }

        //[Required]
        //[Column("CREDITS")]
        public int Credits { get; set; }

        //[Required]
        //[Column("LOCKSTATUT")]
        public bool LockStatut { get; set; }

        //[Required]
        //[Column("USERTYPE")]
        public int UserType { get; set; }

        public User() { }
        public User(int _id, string _name, string _fn, string _mail, string _pw, DateTime _bDate, string _salt, bool _gender,
                   string _address, string _city, string _postalCode, string _geoCoor, DateTime _inscriptionDate, int _credits,
                  bool _LockStatut, int _userType)
        {

            this.ID = _id;
            this.Name = _name;
            //this.FirstName = _fn;
            this.PassWord = _pw;
            this.Birthday = _bDate;
            this.Mail = _mail;
            this.Salt = _salt;
            this.Gender = _gender;
            this.Address = _address;
            this.City = _city;
            this.PostalCode = _postalCode;
            this.GeographicCoordinates = _geoCoor;
            this.IncriptionDate = _inscriptionDate;
            this.Credits = _credits;
            this.LockStatut = _LockStatut;
            this.UserType = _userType;
        }

        public User(string _name, string _fn, string _mail, string _pw, DateTime _bDate, string _salt, bool _gender,
            string _address, string _city, string _postalCode, string _geoCoor, DateTime _inscriptionDate, int _credits,
            bool _LockStatut, int _userType)
        {
            this.Name = _name;
            this.FirstName = _fn;
            this.PassWord = _pw;
            this.Birthday = _bDate;
            this.Mail = _mail;
            this.Salt = _salt;
            this.Gender = _gender;
            this.Address = _address;
            this.City = _city;
            this.PostalCode = _postalCode;
            this.GeographicCoordinates = _geoCoor;
            this.IncriptionDate = _inscriptionDate;
            this.Credits = _credits;
            this.LockStatut = _LockStatut;
            this.UserType = _userType;
        }

    }
}