using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace DesginProject
{
    public class Comment
    {
        public int CommentID
        {
            get => default(int);
            set { }
        }

        public string User
        {
            get => default(string);
            set { }
        }

        public string Subject
        {
            get => default(string);
            set { }
        }

        public string Body
        {
            get => default(string);
            set { }
        }

        public int PhotID
        {
            get => default(int);
            set { }
        }
    }
}