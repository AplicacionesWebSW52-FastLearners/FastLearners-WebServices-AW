using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
/* using FastLearners.Platform.Shared.Domain.Model.Aggregates;
using FastLearners.Platform.Users.Domain.Model.Commands;
using FastLearners.Platform.Users.Domain.Model.ValueObjects;
 */
namespace FastLearners.Platform.Users.Domain.Model.Aggregates
{
    public class User : AuditableAbstractAggregateRoot<User>
    {
        [ComplexType]
        [Owned]
        public class PersonName
        {
            [Column("pepe")]
            public string FirstName { get; set; }

            [Column("pepo")]
            public string MiddleName { get; set; }

            [Column("perez")]
            public string LastName { get; set; }

            public PersonName(string firstName, string middleName, string lastName)
            {
                FirstName = firstName;
                MiddleName = middleName;
                LastName = lastName;
            }

            public string GetFullName()
            {
                return $"{FirstName} {MiddleName} {LastName}".Trim();
            }
        }

        [ComplexType]
        [Owned]
        public class Membership
        {
            [Column("Basic")]
            public string Type { get; set; }

            public Membership(string type)
            {
                Type = type;
            }

            public string GetMembership()
            {
                return Type;
            }
        }

        [ComplexType]
        [Owned]
        public class EmailAddress
        {
            public string Address { get; set; }

            public EmailAddress(string address)
            {
                Address = address;
            }
        }

        [Owned]
        public PersonName Name { get; set; }

        [Owned]
        public Membership MembershipType { get; set; }

        [Owned]
        public EmailAddress Email { get; set; }

        public string Password { get; set; }

        public User(string firstName, string middleName, string lastName, string email, string membership)
        {
            Name = new PersonName(firstName, middleName, lastName);
            Email = new EmailAddress(email);
            MembershipType = new Membership(membership);
        }

        public User(CreateUserCommand command)
        {
            Name = new PersonName(command.FirstName, command.MiddleName, command.LastName);
            Email = new EmailAddress(command.Email);
            MembershipType = new Membership(command.Membership);
        }

        public User()
        {
        }

        public void UpdateName(string firstName, string middleName, string lastName)
        {
            Name = new PersonName(firstName, middleName, lastName);
        }

        public void UpdateEmail(string email)
        {
            Email = new EmailAddress(email);
        }

        public void UpdateMembership(Membership newMembership)
        {
            MembershipType = newMembership;
        }

        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
        }

        public string GetFullName()
        {
            return Name.GetFullName();
        }

        public string GetEmailAddress()
        {
            return Email.Address;
        }

        public string GetMembership()
        {
            return MembershipType.GetMembership();
        }
    }
}
