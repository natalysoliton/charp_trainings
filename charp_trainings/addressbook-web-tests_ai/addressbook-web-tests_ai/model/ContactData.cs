using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmail;
        private string allNames;
        private string textInDetails;

        public bool Equals(ContactData other) 
        {
            if (Object.ReferenceEquals(other, null)) 
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other)) 
            {
                return true;
            }
            return FirstName == other.FirstName
                && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode()
                & LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "firstname=" + FirstName
                + "\nlastname=" + LastName;

        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int LastnameCompare = LastName.CompareTo(other.LastName);
            if (LastnameCompare != 0)
            {
                return LastName.CompareTo(other.LastName);
            }
            return FirstName.CompareTo(other.FirstName);
        }

        public ContactData() { }

        public ContactData(string firstname)
        {
            FirstName = firstname;
        }

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllNames
        {
            get
            {
                if (allNames != null)
                {
                    return allNames;
                }
                else
                {
                    return (FirstName + " " + LastName).Trim();
                }
            }
            set
            {
                allNames = value;
            }
        }

          public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone)).Trim(); 
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmail = value;
            }
        }

        public string TextInDetails
        {
            get
            {
                if (textInDetails != null)
                {
                    return textInDetails;
                }
                else
                {
                    return (
                        (CleanUpNameInDetails(FirstName) + " " + CleanUpNameInDetails(LastName)).Trim() + "\r\n"
                        + CleanUpAddressInDetails(Address)
                        //+ CleanUpHomePhoneInDetails(HomePhone)
                        //+ CleanUpMobilePhoneInDetails(MobilePhone)
                        //+ CleanUpWorkPhoneInDetails(WorkPhone)
                        //+ "\r\n"
                        + CleanUpPhoneInDetails(HomePhone, MobilePhone, WorkPhone)
                        + CleanUpTextInDetails(Email)
                        + CleanUpTextInDetails(Email2)
                        + CleanUpTextInDetails(Email3))
                        .Trim();
                }
            }
            set
            {
                textInDetails = value;
            }
        }

        private string CleanUpPhoneInDetails(string homePhone, string mobilePhone, string workPhone)
        {
            var phones = new List<string>();

            if (!string.IsNullOrEmpty(homePhone))
            {
                phones.Add("H: " + homePhone);
            }

            if (!string.IsNullOrEmpty(mobilePhone))
            {
                phones.Add("M: " + mobilePhone);
            }

            if (!string.IsNullOrEmpty(workPhone))
            {
                phones.Add("W: " + workPhone);
            }

            if (phones.Count > 0)
            {
                return string.Join("\r\n", phones) + "\r\n\r\n";
            }

            return string.Empty;
        }

        private string CleanUpAddressInDetails(string address)
        {
            if (address == null || address == "")
            {
                return "\r\n";
            }
            return address + "\r\n\r\n";
        }

        private string CleanUpNameInDetails(string name)
        {
            if (name == null || name == "")
            {
                return "";
            }
            return name;
        }

        private string CleanUpTextInDetails(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text + "\r\n";
        }

        private string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "") 
            {
                return "";
            }
            //return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
           
            return Regex.Replace(phone, "[ \\-()]", "") + "\r\n"; 
        }
        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }
    }
}
