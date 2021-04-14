using System;

namespace EDUCATION.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime LastActionDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

