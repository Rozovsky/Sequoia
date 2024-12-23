﻿using Sequoia.Client.Extensions;
using Sequoia.Client.Options;

namespace Sequoia.Client.Http.Configuration;

public class Path
{
    public string Uri { get; set; }
    private List<Resource> Resources { get; set; }

    public Path(List<Resource> resources)
    {
        Resources = resources;
    }

    protected internal void SetUri(string pattern)
    {
        if (pattern.Contains("http://") || pattern.Contains("https://"))
        {
            Uri = pattern;
        }
        else
        {
            var resource = Resources.FindResource(pattern);
            var segment = resource.FindSegment(pattern);

            Uri = resource.Uri + segment.Path;
        }
    }
}