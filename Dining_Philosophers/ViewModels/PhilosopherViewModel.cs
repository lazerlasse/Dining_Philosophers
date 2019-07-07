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
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace Dining_Philosophers.ViewModels
{
	class PhilosopherViewModel : BaseViewModel
	{
		private Table table;

		// Private properties for the fork on table.
		private bool forkAtTable0;
		private bool forkAtTable1;
		private bool forkAtTable2;
		private bool forkAtTable3;
		private bool forkAtTable4;
		private bool forkAtTable5;

		// Button settings properties.
		private Brush buttonColor = Brushes.LightGray;

		// Navigation property.
		private DiningSimulation diningSimulation;

		// Philosophers right hand properties.
		public bool Philosopher0_RightHand
		{
			get
			{
				return Persons.ElementAt(0).HasRightFork;
			}
			set
			{
				Persons.ElementAt(0).HasRightFork = value;
				OnPropertyChanged("Philosopher0_RightHand");
			}
		}
		public bool Philosopher1_RightHand
		{
			get
			{
				return Persons.ElementAt(1).HasRightFork;
			}
			set
			{
				Persons.ElementAt(1).HasRightFork = value;
				OnPropertyChanged("Philosopher1_RightHand");
			}
		}
		public bool Philosopher2_RightHand
		{
			get
			{
				return table.Persons[2].HasRightFork;
			}
			set
			{
				table.Persons[2].HasRightFork = value;
				OnPropertyChanged("Philosopher2_RightHand");
			}
		}
		public bool Philosopher3_RightHand
		{
			get
			{
				return table.Persons[3].HasRightFork;
			}
			set
			{
				table.Persons[3].HasRightFork = value;
				OnPropertyChanged("Philosopher3_RightHand");
			}
		}
		public bool Philosopher4_RightHand
		{
			get
			{
				return table.Persons[4].HasRightFork;
			}
			set
			{
				table.Persons[4].HasRightFork = value;
				OnPropertyChanged("Philosopher4_RightHand");
			}
		}
		public bool Philosopher5_RightHand
		{
			get
			{
				return table.Persons[5].HasRightFork;
			}
			set
			{
				table.Persons[5].HasRightFork = value;
				OnPropertyChanged("Philosopher5_RightHand");
			}
		}

		// Philosophers left hand public properties.
		public bool Philosopher0_LeftHand
		{
			get
			{
				return table.Persons.ElementAt(0).HasLeftFork;
			}
			set
			{
				table.Persons.ElementAt(0).HasLeftFork = value;
				OnPropertyChanged("Philosopher0_LeftHand");
			}
		}
		public bool Philosopher1_LeftHand
		{
			get
			{
				return table.Persons.ElementAt(1).HasLeftFork;
			}
			set
			{
				table.Persons.ElementAt(1).HasLeftFork = value;
				OnPropertyChanged("Philosopher1_LeftHand");
			}
		}
		public bool Philosopher2_LeftHand
		{
			get
			{
				return table.Persons[2].HasLeftFork;
			}
			set
			{
				table.Persons[2].HasLeftFork = value;
				OnPropertyChanged("Philosopher2_LeftHand");
			}
		}
		public bool Philosopher3_LeftHand
		{
			get
			{
				return table.Persons[3].HasLeftFork;
			}
			set
			{
				table.Persons[3].HasLeftFork = value;
				OnPropertyChanged("Philosopher3_LeftHand");
			}
		}
		public bool Philosopher4_LeftHand
		{
			get
			{
				return table.Persons[4].HasLeftFork;
			}
			set
			{
				table.Persons[4].HasLeftFork = value;
				OnPropertyChanged("Philosopher4_LeftHand");
			}
		}
		public bool Philosopher5_LeftHand
		{
			get
			{
				return table.Persons[5].HasLeftFork;
			}
			set
			{
				table.Persons[5].HasLeftFork = value;
				OnPropertyChanged("Philosopher5_LeftHand");
			}
		}

		// Forks at the table properties...
		public bool ForkAtTable0
		{
			get
			{
				return forkAtTable0;
			}
			set
			{
				forkAtTable0 = value;
				OnPropertyChanged("ForkAtTable0");
			}
		}
		public bool ForkAtTable1
		{
			get
			{
				return forkAtTable1;
			}
			set
			{
				forkAtTable1 = value;
				OnPropertyChanged("ForkAtTable1");
			}
		}
		public bool ForkAtTable2
		{
			get
			{
				return forkAtTable2;
			}
			set
			{
				forkAtTable2 = value;
				OnPropertyChanged("ForkAtTable2");
			}
		}
		public bool ForkAtTable3
		{
			get
			{
				return forkAtTable3;
			}
			set
			{
				forkAtTable3 = value;
				OnPropertyChanged("ForkAtTable3");
			}
		}
		public bool ForkAtTable4
		{
			get
			{
				return forkAtTable4;
			}
			set
			{
				forkAtTable4 = value;
				OnPropertyChanged("ForkAtTable4");
			}
		}
		public bool ForkAtTable5
		{
			get
			{
				return forkAtTable5;
			}
			set
			{
				forkAtTable5 = value;
				OnPropertyChanged("ForkAtTable5");
			}
		}

		// Command properties for delegates..
		public ICommand StartButton { get; set; }
		public ICommand ResetButton { get; set; }

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
		public Brush ButtonColor
		{
			get
			{
				return buttonColor;
			}
			set
			{
				buttonColor = value;
				OnPropertyChanged("ButtonColor");
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
				OnPropertyChanged("Persons");
			}
		}

		// ViewModel contructor.
		public PhilosopherViewModel()
		{
			// Set the simulation to use.
			// Added amout of philosophers static..... Change this to binding......
			//Persons = new ObservableCollection<Person>();
			table = new Table(6);
			diningSimulation = new DiningSimulation(6, table);

			// Create new delegate commands for the buttons in PhilosophersView.
			StartButton = new DelegateCommand(new Action<object>(StartButtonAction));
			ResetButton = new DelegateCommand(new Action<object>(ResetButtonAction));
		}

		// Method for button actions.
		private void StartButtonAction(object obj)
		{
			ButtonColor = Brushes.LightGreen;
			diningSimulation.Start();
		}

		private void ResetButtonAction(object obj)
		{
			diningSimulation.Pause();
		}

		// Helper methods.
		private void UpdateForkOnTable(int id)
		{
			if (id == 0)
			{
				ForkAtTable0 = CheckTrueFalse(ForkAtTable0);
				OnPropertyChanged("ForkAtTable0");
			}
			if (id == 1)
			{
				ForkAtTable1 = CheckTrueFalse(ForkAtTable1);
				OnPropertyChanged("ForkAtTable1");
			}
			if (id == 2)
			{
				ForkAtTable2 = CheckTrueFalse(ForkAtTable2);
				OnPropertyChanged("ForkAtTable2");
			}
			if (id == 3)
			{
				ForkAtTable3 = CheckTrueFalse(ForkAtTable3);
				OnPropertyChanged("ForkAtTable3");
			}
			if (id == 4)
			{
				ForkAtTable4 = CheckTrueFalse(ForkAtTable4);
				OnPropertyChanged("ForkAtTable4");
			}
			if (id == 5)
			{
				ForkAtTable5 = CheckTrueFalse(ForkAtTable5);
				OnPropertyChanged("ForkAtTable5");
			}
		}

		private bool CheckTrueFalse(bool value)
		{
			if (value == true)
			{
				value = false;
			}
			else
			{
				value = true;
			}

			return value;
		}
	}
}
