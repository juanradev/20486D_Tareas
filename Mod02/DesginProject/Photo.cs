using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace DesginProject
{
    public class Photo
    {
        public int PhotoID
        {
            get => default(int);
            set { }
        }

        public string Title
        {
            get => default(string);
            set { }
        }

        public byte[] PhotoFile
        {
            get => default(byte[]);
            set { }
        }

        public string Description
        {
            get => default(string);
            set { }
        }

        public DateTime CreatedDate
        {
            get => default(DateTime);
            set { }
        }

        public int Owner
        {
            get => default(int);
            set { }
        }

        public List<Comment> PhotoComments
        {
            get => default;
            set { }
        }

    }
}