using Dining_Philosophers.Models;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dining_Philosophers.Delegates;
using Dining_Philosophers.Simulator;
using Dining_Philosophers.Helpers;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace Dining_Philosophers.ViewModels
{
    class PhilosopherViewModel : BaseViewModel
    {
        // Reference property for table.
        private readonly Table table;

        // Private button settings properties.
        private Brush startStopButtonColor = Brushes.LightGray;
        private Brush pauseResumeButtonColor = Brushes.LightGray;
        private string startStopButtonText = ButtonStates.Start.ToString();
        private string pauseResumeButtonText = ButtonStates.Pause.ToString();
        private bool pauseResumeButtonIsEnable = false;

        // Private property for table settings.
        private TableCloth currentTableCloth;

        // Private property for collections.
        private ObservableCollection<TableCloth> tableCloths;

        // Navigation property.
        private DiningSimulation diningSimulation;

        // Command properties for delegates..
        public ICommand StartStopButton { get; set; }
        public ICommand PauseResumeButton { get; set; }

        // Slider property.
        public double SpeedSliderValue
        {
            get
            {
                return Persons.FirstOrDefault().ThinkingTime;
            }
            set
            {
                foreach (Person person in Persons)
                {
                    person.ThinkingTime = value;
                }
                OnPropertyChanged("SpeedSliderValue");
            }
        }

        // Public properties for button settings.
        public Brush StartStopButtonColor
        {
            get
            {
                return startStopButtonColor;
            }
            set
            {
                startStopButtonColor = value;
                OnPropertyChanged("StartStopButtonColor");
            }
        }
        public Brush PauseResumeButtonColor
        {
            get
            {
                return pauseResumeButtonColor;
            }
            set
            {
                pauseResumeButtonColor = value;
                OnPropertyChanged("PauseResumeButtonColor");
            }
        }
        public string StartStopButtonText
        {
            get
            {
                return startStopButtonText;
            }
            set
            {
                startStopButtonText = value;
                OnPropertyChanged("StartStopButtonText");
            }
        }
        public string PauseResumeButtonText
        {
            get
            {
                return pauseResumeButtonText;
            }
            set
            {
                pauseResumeButtonText = value;
                OnPropertyChanged("PauseResumeButtonText");
            }
        }
        public bool PauseResumeButtonIsEnable
        {
            get
            {
                return pauseResumeButtonIsEnable;
            }
            set
            {
                pauseResumeButtonIsEnable = value;
                OnPropertyChanged("PauseResumeButtonIsEnable");
            }
        }


        // Public property for observable collection of Philosopher models.
        public ObservableCollection<Person> Persons
        {
            get
            {
                return table.Persons;
            }
            set
            {
                table.Persons = value;
            }
        }
        public ObservableCollection<bool> TableForks
        {
            get
            {
                return Table.Forks;
            }
            set
            {
                Table.Forks = value;
            }
        }
        public ObservableCollection<TableCloth> TableCloths
        {
            get
            {
                return tableCloths;
            }
            set
            {
                tableCloths = value;
            }
        }


        // Public properties for table settings.
        public TableCloth CurrentTableCloth
        {
            get
            {
                return currentTableCloth;
            }
            set
            {
                currentTableCloth = value;
                OnPropertyChanged("CurrentTableCloth");
            }
        }

        // ViewModel contructor.
        public PhilosopherViewModel()
        {
            // Set the simulation and table to use. Amount of persons to eat is set static for now.
            table = new Table(6);
            diningSimulation = new DiningSimulation(6, table);

            // Create new delegate commands for the buttons in PhilosophersView.
            StartStopButton = new DelegateCommand(new Action<object>(StartStopButtonAction));
            PauseResumeButton = new DelegateCommand(new Action<object>(PauseResumeButtonAction));

            // Fill TableCloth ObservableCollection with data.
            TableCloths = FillTableClothCollection.FillCollection();
            CurrentTableCloth = TableCloths[0];
        }

        // Method for button actions.
        private void StartStopButtonAction(object obj)
        {
            if (StartStopButtonText == ButtonStates.Start.ToString())
            {
                StartStopButtonColor = Brushes.LightGreen;
                StartStopButtonText = ButtonStates.Stop.ToString();
                diningSimulation.Start();
                PauseResumeButtonIsEnable = true;
            }
            else
            {
                if (PauseResumeButtonText == ButtonStates.Resume.ToString())
                {
                    PauseResumeButtonColor = Brushes.LightGray;
                    PauseResumeButtonText = ButtonStates.Pause.ToString();
                }
                StartStopButtonColor = Brushes.LightGray;
                StartStopButtonText = ButtonStates.Start.ToString();
                diningSimulation.Stop();
                PauseResumeButtonIsEnable = false;
            }
        }

        private void PauseResumeButtonAction(object obj)
        {
            if (PauseResumeButtonText == ButtonStates.Pause.ToString())
            {
                PauseResumeButtonColor = Brushes.Yellow;
                PauseResumeButtonText = ButtonStates.Resume.ToString();
                diningSimulation.Pause();
            }
            else
            {
                PauseResumeButtonColor = Brushes.LightGray;
                PauseResumeButtonText = ButtonStates.Pause.ToString();
                diningSimulation.Resume();
            }
        }

        private enum ButtonStates
        {
            Start,
            Stop,
            Pause,
            Resume
        }
    }
}
