using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class Movie
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public override string ToString()
        {
            return string.Format("{0};{1};{2}", title, date_published, MovieLibrary.GetName(production_studio));
        }

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return ((Movie)obj).title == title;

        }

    }

    public class MovieComparerByDate : IComparer<Movie>
    {
        private readonly bool _ascending;

        public MovieComparerByDate(bool ascending)
        {
            _ascending = ascending;
        }

        public int Compare(Movie x, Movie y)
        {
            if (_ascending)
                return x.date_published.CompareTo(y.date_published);

            return y.date_published.CompareTo(x.date_published);

        }
    }

    public class MovieComparerByTitle : IComparer<Movie>
    {
        private readonly bool _ascending;

        public MovieComparerByTitle(bool ascending)
        {
            _ascending = ascending;
        }

        public int Compare(Movie x, Movie y)
        {
            if (_ascending)
                return x.title.CompareTo(y.title);

            return y.title.CompareTo(x.title);

        }
    }

    //MGM
    //Pixar
    //Dreamworks
    //Universal
    //Disney
    public class MovieComparerByStudioAndDate : IComparer<Movie>
    {
        private readonly bool _ascending;

        private List<ProductionStudio> studios = new List<ProductionStudio>() {ProductionStudio.MGM, ProductionStudio.Pixar, ProductionStudio.Dreamworks,
            ProductionStudio.Universal, ProductionStudio.Disney, ProductionStudio.Paramount};


        public int Compare(Movie x, Movie y)
        {
            var studioComparison = studios.IndexOf(x.production_studio).CompareTo(studios.IndexOf(y.production_studio));
            if (studioComparison == 0)
                return (new MovieComparerByDate(true).Compare(x, y));

            return studioComparison;
        }
    }
}
