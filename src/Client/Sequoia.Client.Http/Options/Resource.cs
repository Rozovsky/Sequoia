﻿namespace Sequoia.Client.Http.Options
{
    public class Resource
    {
        public string Name { get; set; }
        public string Uri { get; set; }
        public List<Segment> Segments { get; set; }
    }
}