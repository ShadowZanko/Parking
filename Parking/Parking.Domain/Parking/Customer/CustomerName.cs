using System;

namespace Domain.Parking
{
    public record CustomerName
    {
        public string Name { get; }
        public string Surname { get; }
        public string Thirdname { get; }

        private CustomerName(string name, string surname, string thirdname)
        {
            Name = name;
            Surname = surname;
            Thirdname = thirdname;
        }

        public static CustomerName Create(string name, string surname, string thirdname)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(surname) ||
                string.IsNullOrWhiteSpace(thirdname))
            {
                throw new ArgumentException("ФИО не может быть пустым");
            }
            return new CustomerName(name.Trim(), surname.Trim(), thirdname.Trim());
        }

        public override string ToString()
        {
            return $"{Surname} {Name} {Thirdname}";
        }
    }
}
