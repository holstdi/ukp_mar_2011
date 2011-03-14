using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            //return movies;
            foreach (Movie m in movies)
            {
                yield return m;
            }

        }

        public void add(Movie movie)
        {
            if (!movies.Contains(movie))
            {
                movies.Add(movie);
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                List<Movie> tempList = new List<Movie>(movies);
                tempList.Sort(new MovieComparerByTitle(false));
                foreach (var movie in tempList)
                {
                    yield return movie;
                }

            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar)
                {
                    yield return movie;
                }

            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar || movie.production_studio == ProductionStudio.Disney)
                {
                    yield return movie;
                }

            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get
            {
                List<Movie> tempList = new List<Movie>(movies);
                tempList.Sort(new MovieComparerByTitle(true));
                foreach (var movie in tempList)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            List<Movie> tempList = new List<Movie>(movies);
            tempList.Sort(new MovieComparerByStudioAndDate());
            Console.WriteLine(tempList.Count);
            foreach(var movie in tempList)
            {
                Console.WriteLine("{0} - {1} - {2}",GetName(movie.production_studio),movie.date_published.Year,movie.title);
                yield return movie;
            }
            
            
        }

        public static string GetName(ProductionStudio studio)
        {
            if (studio.Equals(ProductionStudio.Disney))
            return "Disney";

            if (studio.Equals(ProductionStudio.Dreamworks))
                return "Dreamworks";

            if (studio.Equals(ProductionStudio.MGM))
                return "MGM";
            if (studio.Equals(ProductionStudio.Paramount))
                return "Paramount";
            if (studio.Equals(ProductionStudio.Pixar))
                return "Pixar";
            if (studio.Equals(ProductionStudio.Universal))
                return "Universal";

            return "";
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio != ProductionStudio.Pixar)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            foreach (var movie in movies)
            {
                if (movie.date_published > new DateTime(year,1,1) )
                {
                    yield return movie;
                }

            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            foreach (var movie in movies)
            {
                if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
                {
                    yield return movie;
                }

            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            foreach (var movie in movies)
            {
                if(movie.genre == Genre.kids)
                {
                    yield return movie;
                }

            }
        }

        public IEnumerable<Movie> all_action_movies()
        {
            foreach (var movie in movies)
            {
                if(movie.genre == Genre.action)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            List<Movie> tempList = new List<Movie>(movies);
            tempList.Sort(new MovieComparerByDate(false));
            foreach (var movie in tempList)
            {
                yield return movie;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            List<Movie> tempList = new List<Movie>(movies);
            tempList.Sort(new MovieComparerByDate(true));
            foreach(var movie in tempList)
            {
                yield return movie;
            }
        }

    }
}