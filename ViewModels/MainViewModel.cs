using AutoMapper;
using Caliburn.Micro;
using DCTest.DTOs;
using DCTest.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace DCTest.ViewModels {
    public class MainViewModel : Screen {
        private readonly ApiHelper _apiHelper;
        private readonly IMapper _mapper;

        private BindableCollection<DataDto> _dataToDisplay = new BindableCollection<DataDto> ();
        public BindableCollection<DataDto> DataToDisplay {
            get { return _dataToDisplay; }
            set {
                _dataToDisplay = value;
                NotifyOfPropertyChange (() => DataToDisplay);
            }
        }

        public MainViewModel (ApiHelper apiHelper, IMapper mapper) {
            _apiHelper = apiHelper;
            _mapper = mapper;
        }

        protected override async Task OnInitializeAsync (CancellationToken cancellationToken) {
            DataToDisplay = new BindableCollection<DataDto> (_mapper.Map<List<DataDto>> (await _apiHelper.GetData (10)));
        }
    }
}
