using System;
using System.Drawing;

namespace Search.Base
{
    public class SearchStep<K> where K : class, IComparable<K>
    {
        public Bitmap GraphCapture { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
    }
}