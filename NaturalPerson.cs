using System.Data.Linq.Mapping;

namespace ToolsRental
{
    /*
     * may be client have to field organization then he can add organization properties
     */
    [Table(Name = "Clients")]
    public sealed class NaturalPerson
    {
        [Column]
        public string Name { get; private set; }

        [Column]
        public string Surname { get; private set; }

        [Column]
        public string Patronymic { get; private set; }

        [Column]
        public string Sex { get; private set; }

        [Column]
        public int Id { get; private set; }

        [Column]
        public string City { get; private set; }

        [Column]
        public string Street { get; private set; }

        [Column]
        public string Building { get; private set; }

        [Column]
        public string Apartment { get; private set; }

        [Column]
        public string HomePhone { get; private set; }

        [Column]
        public string OfficePhone { get; private set; }

        [Column]
        public string CellPhone { get; private set; }

        [Column]
        public string Email { get; private set; }

        [Column]
        public bool Deposit { get; private set; }

        [Column]
        public int Balance { get; private set; }

        [Column]
        public int Discount { get; private set; }

        [Column]
        public string Note { get; private set; }

        [Column]
        public long Passport { get; private set; }

        [Column]
        public string IssueDate { get; private set; }

        [Column]
        public string WhoIssuedPassport { get; private set; }

        [Column]
        public string ResidenceAddress { get; private set; }

        public NaturalPerson() : this("", "", "", "", "", "", "", "Мужской", -1, "", "", "")
        {
        }

        public NaturalPerson(string name, string surname, string patronymic, string city, 
            string street, string building, string apartment, string sex, long passport, string issueDate, 
            string whoIssuedPassport, string residenceAddress, string note = null, int discount = 0, int balance = 0, 
            bool deposit = false, string cellPhone = null, string email = null, string officePhone = null, string homePhone = null)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            City = city;
            Street = street;
            Building = building;
            Apartment = apartment;
            Sex = sex;
            Passport = passport;
            IssueDate = issueDate;
            WhoIssuedPassport = whoIssuedPassport;
            ResidenceAddress = residenceAddress;
            Note = note;
            Discount = discount;
            Balance = balance;
            Deposit = deposit;
            CellPhone = cellPhone;
            Email = email;
            OfficePhone = officePhone;
            HomePhone = homePhone;

            Id = GetHashCode();
        }

        public long GetPassportHash()
        {
            unchecked
            {
                return Passport * 1023 + 8087;
            }
        }

        public long ParseHashToPassport(int hash)
        {
            unchecked
            {
                return (hash - 8087) / 1023;
            }
        }

        public sealed override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public sealed override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
