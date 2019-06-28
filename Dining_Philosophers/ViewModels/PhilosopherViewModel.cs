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

namespace Dining_Philosophers.ViewModels
{
	class PhilosopherViewModel : BaseViewModel
	{

		// Navigation property.
		public Person person = new Philosopher();
		public DiningSimulation diningSimulation;

		// Property for the speed slider.
		private double speedSliderValue;

		// Philosophers right hand properties.
		public bool Philosopher0_RightHand { get { return Philosopher0_RightHand; } set { Philosopher0_RightHand = value; OnPropertyChanged("Philosopher0_RightHand"); } }
		public bool Philosopher1_RightHand;
		public bool Philosopher2_RightHand;
		public bool Philosopher3_RightHand;
		public bool Philosopher4_RightHand;
		public bool Philosopher5_RightHand;

		// Philosophers left hand properties.
		public bool Philosopher0_LeftHand;
		public bool Philosopher1_LeftHand;
		public bool Philosopher2_LeftHand;
		public bool Philosopher3_LeftHand;
		public bool Philosopher4_LeftHand;
		public bool Philosopher5_LeftHand;

		// Forks at the table properties...
		public bool ForkAtTable0;
		public bool ForkAtTable1;
		public bool ForkAtTable2;
		public bool ForkAtTable3;
		public bool ForkAtTable4;
		public bool ForkAtTable5;

		private bool ForkRightHand
		{
			get
			{
				if (person.ID == 0)
				{
					Philosopher0_RightHand = person.HasRightFork;
					return Philosopher0_RightHand;
				}
				else if (person.ID == 1)
				{
					Philosopher1_RightHand = person.HasRightFork;
					return Philosopher1_RightHand;
				}
				else if (person.ID == 2)
				{
					Philosopher2_RightHand = person.HasRightFork;
					return Philosopher2_RightHand;
				}
				else if (person.ID == 3)
				{
					Philosopher3_RightHand = person.HasRightFork;
					return Philosopher3_RightHand;
				}
				else if (person.ID == 4)
				{
					Philosopher4_RightHand = person.HasRightFork;
					return Philosopher4_RightHand;
				}
				else if (person.ID == 5)
				{
					Philosopher5_RightHand = person.HasRightFork;
					return Philosopher5_RightHand;
				}
				else
				{
					return person.HasRightFork;
				}
			}
			set
			{
				if (person.ID == 0)
				{
					Philosopher0_RightHand = person.HasRightFork;
					OnPropertyChanged("Philosopher0_RightHand");
				}
				else if (person.ID == 1)
				{
					Philosopher1_RightHand = person.HasRightFork;
					OnPropertyChanged("Philosopher1_RightHand");
				}
				else if (person.ID == 2)
				{
					Philosopher2_RightHand = person.HasRightFork;
					OnPropertyChanged("Philosopher2_RightHand");
				}
				else if (person.ID == 3)
				{
					Philosopher3_RightHand = person.HasRightFork;
					OnPropertyChanged("Philosopher3_RightHand");
				}
				else if (person.ID == 4)
				{
					Philosopher4_RightHand = person.HasRightFork;
					OnPropertyChanged("Philosopher4_RightHand");
				}
				else if (person.ID == 5)
				{
					Philosopher5_RightHand = person.HasRightFork;
					OnPropertyChanged("Philosopher5_RightHand");
				}

				UpdateForkOnTable(person.RightForkId);
			}
		}

		private bool ForkLeftHand
		{
			get
			{
				if (person.ID == 0)
				{
					Philosopher0_LeftHand = person.HasLeftFork;
					return Philosopher0_LeftHand;
				}
				else if (person.ID == 1)
				{
					Philosopher1_LeftHand = person.HasLeftFork;
					return Philosopher1_LeftHand;
				}
				else if (person.ID == 2)
				{
					Philosopher2_LeftHand = person.HasLeftFork;
					return Philosopher2_LeftHand;
				}
				else if (person.ID == 3)
				{
					Philosopher3_LeftHand = person.HasLeftFork;
					return Philosopher3_LeftHand;
				}
				else if (person.ID == 4)
				{
					Philosopher4_LeftHand = person.HasLeftFork;
					return Philosopher4_LeftHand;
				}
				else if (person.ID == 5)
				{
					Philosopher5_LeftHand = person.HasLeftFork;
					return Philosopher5_LeftHand;
				}
				else
				{
					return person.HasLeftFork;
				}
			}
			set
			{
				if (person.ID == 0)
				{
					Philosopher0_LeftHand = person.HasLeftFork;
					OnPropertyChanged("Philosopher0_LeftHand");
				}
				else if (person.ID == 1)
				{
					Philosopher1_LeftHand = person.HasLeftFork;
					OnPropertyChanged("Philosopher1_LeftHand");
				}
				else if (person.ID == 2)
				{
					Philosopher2_LeftHand = person.HasLeftFork;
					OnPropertyChanged("Philosopher2_LeftHand");
				}
				else if (person.ID == 3)
				{
					Philosopher3_LeftHand = person.HasLeftFork;
					OnPropertyChanged("Philosopher3_LeftHand");
				}
				else if (person.ID == 4)
				{
					Philosopher4_LeftHand = person.HasLeftFork;
					OnPropertyChanged("Philosopher4_LeftHand");
				}
				else if (person.ID == 5)
				{
					Philosopher5_LeftHand = person.HasLeftFork;
					OnPropertyChanged("Philosopher5_LeftHand");
				}

				UpdateForkOnTable(person.LeftForkId);
			}
		}

		public ICommand StartButton { get; set; }
		public ICommand ResetButton { get; set; }

		public double SpeedSliderValue
		{
			get
			{
				return speedSliderValue;
			}
			set
			{
				speedSliderValue = value;
				OnPropertyChanged("SpeedSliderValue");
			}
		}

		public PhilosopherViewModel()
		{

		}

		public PhilosopherViewModel(DiningSimulation simulation)
		{
			// Set the simulation to use.
			diningSimulation = simulation;

			// Create new delegate commands for the buttons in PhilosophersView.
			StartButton = new DelegateCommand(new Action<object>(StartButtonAction));
			ResetButton = new DelegateCommand(new Action<object>(ResetButtonAction));
		}

		private void StartButtonAction(object obj)
		{
			diningSimulation.Start();
		}

		private void ResetButtonAction(object obj)
		{
			diningSimulation.Reset();
		}

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
