using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_REST_UTILITARIOS.Models
{
    public class EmailModel
    {
        //Constructor
        public EmailModel(string id, string message)
        {
            Id = id;
            Message = message;
        }

        //Getter & Setter
        string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

    }
}