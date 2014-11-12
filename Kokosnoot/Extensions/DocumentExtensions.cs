using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kokosnoot.Models.Persistence;

namespace Kokosnoot.Extensions
{
    public static class DocumentExtensions
    {
        public static string MvcDocumentId(this Document document)
        {
            return document.Id.Split('/').LastOrDefault();
        }

    }
}