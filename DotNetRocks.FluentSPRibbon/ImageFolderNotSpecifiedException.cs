using System;

namespace DotNetRocks.FluentSPRibbon
{
    public class ImageFolderNotSpecifiedException : Exception
    {
        public ImageFolderNotSpecifiedException()
            : base()
        {

        }

        public ImageFolderNotSpecifiedException(String message)
            : base(message)
        {

        }

        public ImageFolderNotSpecifiedException(String message, Exception innerException)
            : base(message, innerException)
        {

        }

    }
}
