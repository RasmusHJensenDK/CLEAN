﻿using clean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Services
{
    public class CleaningTask
    {
        public int TaskNumber { get; set; }
        public Offer AssociatedOffer { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        // Additional properties for task details
    }

}
