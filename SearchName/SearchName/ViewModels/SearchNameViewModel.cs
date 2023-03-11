using SearchName.Models;
using SearchName.Services;
using System.ComponentModel;

namespace SearchName.ViewModels
{
    public class SearchNameViewModel : ISearchNameViewModel
    {
        private IDataService service;
        private IList<Models.Result> results = new List<Models.Result>();
        private bool busy = false;
        private bool resultsFound = false;
        private bool noResultsFound = false;

        public SearchNameViewModel(Services.IDataService service)
        {
            this.service = service;
        }

        public string Name { get; set; }

        public IList<Result> Results
        {
            get
            {
                return results;
            }
            private set
            {
                results = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Results)));
            }
        }

        public bool Busy
        {
            get
            {
                return busy;
            }
            private set
            {
                busy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Busy)));
            }
        }

        public bool ResultsFound
        {
            get
            {
                return resultsFound;
            }
            private set
            {
                resultsFound = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResultsFound)));
            }
        }

        public bool NoResultsFound
        {
            get
            {
                return noResultsFound;
            }
            private set
            {
                noResultsFound = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoResultsFound)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ClearResults()
        {
            Results.Clear();
            NoResultsFound = ResultsFound = false;
        }

        public async Task SearchName()
        {
            Busy = true;
            Results = await service.GetResultsByName(Name);
            Busy = false;
            NoResultsFound = !(ResultsFound = Results.Count > 0);
        }
    }
}
