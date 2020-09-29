using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.Domain.Models
{
    public class DomainObject : ObservableObject
    {
        public int Id { get; set; }
    }
}
