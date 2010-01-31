using System;
using System.Collections.Generic;

namespace MaviBlog.Specs.Integration
{
    public class InMemoryUrlEncodedTitleRepository : IUrlEncodedTitleRepository
    {
        private readonly Dictionary<string, long> _idMap = new Dictionary<string, long>();

        public long GetPostIdForUrlEncodedTitle(string urlEncodedTitle)
        {
            return _idMap[urlEncodedTitle];
        }

        public void SaveUrlToPostIdMap(string urlEncodedTitle, long postId)
        {
            _idMap.Add(urlEncodedTitle, postId);
        }
    }
}