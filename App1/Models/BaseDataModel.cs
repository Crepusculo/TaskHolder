using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace App1.Models
{
    class BaseDataModel
    {   
        /// <summary>
        /// Unique ID
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        /// <summary>
        /// UserID
        /// </summary>
        public string BelongsTo { get; set; }
        public int Points { get; set; }
    }
}