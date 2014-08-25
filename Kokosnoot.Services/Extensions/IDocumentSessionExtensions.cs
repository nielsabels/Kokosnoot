using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;

namespace Kokosnoot.Services.Extensions
{
    public static class DocumentSessionExtensions
    {
        public static string GetStringId<T>(this IDocumentSession session, object id)
        {
            return session.Advanced.DocumentStore.Conventions
                .DefaultFindFullDocumentKeyFromNonStringIdentifier(id, typeof(T), false);
        }
    }
}
