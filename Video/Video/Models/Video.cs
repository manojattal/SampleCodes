﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Video.Models
{
    public class Video
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Length { get; set; }
    }
}