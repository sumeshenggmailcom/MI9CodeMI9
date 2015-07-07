using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MI9.Models;

namespace MI9.Helper
{
    public class Filter
    {
        public static Response[] FilterMe(RequestList request)
        {
            if (request == null || request.payload == null)
            {
                return null;
            }

            var responses = request.payload.Where(p => p.drm && p.episodeCount > 0)
                .Select(p => new Response { image = p.image.showImage, slug = p.slug, title = p.title });
            return responses.ToArray();
        }
    }
}