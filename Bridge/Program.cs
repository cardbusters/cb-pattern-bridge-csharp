using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            //implementation
            var implementationOfSoundTrack      = new SoundTrack();
            var implementationOfAlbum           = new Album();
            var implementationOfGroupOfAlbums   = new GroupOfAlbums();
            
            //abstraction
            var abstractionOfSmallWidget    = new SmallWidget(implementationOfSoundTrack);
            var abstractionOfMediumWidget   = new MediumWidget(implementationOfAlbum);
            var abstractionOfBigWidget      = new BigWidget(implementationOfGroupOfAlbums);

            //client code
            WebPage webPage = new WebPage();
            webPage.AddWebElement(abstractionOfSmallWidget);
            webPage.AddWebElement(abstractionOfMediumWidget);
            webPage.AddWebElement(abstractionOfBigWidget);

            Console.ReadKey();
        }
    }


    abstract class Widget : IWebElement
    {
        protected IContent _implementation;

        public Widget(IContent implementation)
        {
            this._implementation = implementation;
        }

        public virtual string Render()
        {
            return "";
        }
    }

    class SmallWidget : Widget
    {
        public SmallWidget(IContent implementation)
            : base (implementation)
        {

        }

        public override string Render()
        {
            return $"Small widget with an {_implementation.ShowContent()} \n";
        }
    }

    class MediumWidget : Widget
    {
        public MediumWidget(IContent implementation)
            : base(implementation)
        {

        }

        public override string Render()
        {
            return $"Medium widget with an {_implementation.ShowContent()} \n";
        }
    }

    class BigWidget : Widget
    {
        public BigWidget(IContent implementation)
            : base(implementation)
        {

        }

        public override string Render()
        {
            return $"Big widget with an {_implementation.ShowContent()} \n";
        }
    }

    //Implementation
    public interface IContent
    {

        string ShowContent();
    }

    class SoundTrack : IContent
    {
        public string ShowContent()
        {
            return "Implementaion of SoundTrack";
        }
    }

    class Album : IContent
    {
        public string ShowContent()
        {
            return "Implementation of Album";
        }
    }
    
    class GroupOfAlbums : IContent
    {
        public string ShowContent()
        {
            return "Implementation of GroupOfAlbums";
        }
    }

    class WebPage
    {
        public void AddWebElement(IWebElement widget)
        {
            Console.Write(widget.Render());
        }
    }
}
