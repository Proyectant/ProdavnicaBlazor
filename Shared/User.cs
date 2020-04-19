using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blazor_shop.Shared
{
    public class User
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Min = 5, max=20")]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Min=5, max=20")]
        public string Password { get; set; }

        public ICollection<Racun> KolekcijaRacuna { get; set; }


        public User() { }



        public override bool Equals(object obj)
        {
            if (obj is User u && u.Username == this.Username && u.Password == this.Password)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return this.Username.GetHashCode();

        }
    }
}
